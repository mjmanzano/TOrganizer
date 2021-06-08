using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TOrganizer
{

    public partial class Form1 : Form
    {
        const string config_filename = "config.txt";
        const string _EXIFTOOL = "EXIFTOOLPATH";
        const string _IMGPATH = "IMGPATH";
        const string _SORTCHK = "SORT_CHECKED";
        const string _TSUFFIX = "TEMP_SUFFIX";

        string EXIFTOOLPATH = "";
        string IMAGEFOLDER = "";

        string EXIFARG = "";

        public Form1()
        {
            InitializeComponent();
           Startup();
        }


        private void Startup()
        {
            try
            {
                    StreamReader sr = new StreamReader(config_filename);
                    LoadConfig(sr);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                if(e.GetType().ToString() == "System.IO.FileNotFoundException")
                {
                    File.Create(config_filename);
                }
            }
        }

        private void LoadConfig(StreamReader sr)
        {
            string text;
            text = sr.ReadToEnd();
            sr.Close();
            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                LoadVariables(line);
            }
        }

        private void LoadVariables(string line)
        {
            string[] config = line.Split(new[] { ':' }, 2);
            if (config.Length >= 2) {
                switch (config[0].Trim()) {
                    case _EXIFTOOL:
                        EXIFTOOLPATH = config[1].Trim();
                        ExifToolDirectory.Text = config[1].Trim();
                        if (!File.Exists(EXIFTOOLPATH))
                        {
                            MessageBox.Show("Exiftool does not exist in the config path.");
                        }
                        break;
                    case _IMGPATH:
                        IMAGEFOLDER = config[1].Trim();
                        ImagePath.Text = config[1].Trim();
                        break;
                    case _SORTCHK:
                        Sort_Checkbox.Checked = get_bool(config[1].Trim());
                        break;
                    case _TSUFFIX:
                        Suffix_checkbox.Checked = get_bool(config[1].Trim());
                        break;
                    default:
                        break;
                }
            }
        }

        private void ExifToolDirectory_TextChanged(object sender, EventArgs e)
        {
            string path = ExifToolDirectory.Text;
            UpdateConfig(_EXIFTOOL, path);
        }

        private void ImagePath_TextChanged(object sender, EventArgs e)
        {
            IMAGEFOLDER = ImagePath.Text;
            UpdateConfig(_IMGPATH, IMAGEFOLDER);
        }

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    ImagePath.Text = fbd.SelectedPath;
                    IMAGEFOLDER = fbd.SelectedPath;
                    UpdateConfig(_IMGPATH, IMAGEFOLDER);
                }
            }
        }

        private void UpdateConfig(string config_name, string value)
        {
            string text = File.ReadAllText(config_filename);
            string[] lines = text.Split('\n');

            bool found_tag = false;

            int x;
            for (x = 0; x < lines.Length; x++)
            {
                string[] row = lines[x].Split(new[] { ':' }, 2);

                if (row.Length >= 2)
                {
                    if (row[0].Trim() == config_name)
                    {
                        lines[x] = config_name + " : " + value;
                        found_tag = true;
                    }
                }
            }

            if (found_tag == false)
            {
                Array.Resize(ref lines, lines.Length + 1);
                lines[x] = (config_name + " : " + value);
            }

            text = "";
            for(int y = 0; y < lines.Length; y++)
            {
                if (y == lines.Length - 1)
                {
                    text = text + lines[y];
                }
                else
                {
                    text = text + lines[y] + '\n';
                }
            }


            File.WriteAllText(config_filename, text);
        }

        private void Run_Click(object sender, EventArgs e)
        {

            if (IMAGEFOLDER != "")
            {
                 EXIFARG = "\"" + IMAGEFOLDER + @"\*.CR2" + "\"" + " -CameraTemperature" + " -csv > " + "\"" + IMAGEFOLDER + @"\temperature_log.csv" + "\"";

                var process = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = EXIFTOOLPATH,
                        Arguments = EXIFARG,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                string output = "";
                int x = 0;

                while (!process.StandardOutput.EndOfStream)
                {
                    string line = process.StandardOutput.ReadLine();
                    string[] row = line.Split(',');
                    
                    if (row.Length > 1 && x > 0)
                    {
                        output = output + line + '\n';
                        string img_path = row[0];
                        if (Sort_Checkbox.Checked)
                        {
                            img_path = SortImage(row[0], row[1]);
                        }
                        
                        if (Suffix_checkbox.Checked && row[1].Trim() != "")
                        {
                            AddSuffix(img_path, row[1]);
                        }
                    }
                    x++;
                }
                try
                {
                    File.WriteAllText(IMAGEFOLDER + @"\temperature_log.csv", output);
                }
                catch(Exception e2)
                {
                    Console.WriteLine("Exception: " + e2.GetType());
                    if (e2.GetType().ToString() == "System.IO.FileNotFoundException")
                    {
                        MessageBox.Show("Exception: " + e2.GetType());
                    }
                }
                MessageBox.Show("Operation completed successfully. " + x + " images sorted.");
            }
            else
            {
                MessageBox.Show("No Image folder has been set.");
            }
        }
        private static string SortImage(string path, string folder)
        {
            string directory = System.IO.Path.GetDirectoryName(path);
            string target_directory = directory + @"/" + folder;
            string file_name = Path.GetFileName(path);
            System.IO.Directory.CreateDirectory(target_directory);

            string new_path = target_directory + @"/" + file_name;
            System.IO.File.Move(path, new_path);
            return new_path;
        }

        private static void AddSuffix(string path, string suffix)
        {
            string filename = Path.GetFileNameWithoutExtension(path);
            string ext = Path.GetExtension(path);
            string parent = Path.GetDirectoryName(path);

            filename = filename + "_" + suffix.Replace(" ", "");

            System.IO.File.Move(path, parent + @"\" + filename + ext);
        }

        private void Sort_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Sort_Checkbox.Checked)
            {
                UpdateConfig(_SORTCHK, "1");
            }
            else
            {
                UpdateConfig(_SORTCHK, "0");
            }
        }

        private bool get_bool(string i)
        {
            int j = Int16.Parse(i);
            if (j <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Suffix_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Suffix_checkbox.Checked)
            {
                UpdateConfig(_TSUFFIX, "1");
            }
            else
            {
                UpdateConfig(_TSUFFIX, "0");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Location of ExifTool";
                ofd.DefaultExt = "exe";
                ofd.Filter = "executable files (*.exe)|*.exe";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Multiselect = false;
                if (EXIFTOOLPATH != "") {
                    ofd.InitialDirectory = EXIFTOOLPATH;
                        }

                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    ExifToolDirectory.Text = ofd.FileName;
                    EXIFTOOLPATH = ofd.FileName;
                    UpdateConfig(_EXIFTOOL, EXIFTOOLPATH);
                }
            }
        }
    }
}
