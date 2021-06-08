
namespace TOrganizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExifToolDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ImagePath = new System.Windows.Forms.TextBox();
            this.OpenFolder = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.Sort_Checkbox = new System.Windows.Forms.CheckBox();
            this.Suffix_checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ExifToolDirectory
            // 
            this.ExifToolDirectory.Location = new System.Drawing.Point(12, 39);
            this.ExifToolDirectory.Name = "ExifToolDirectory";
            this.ExifToolDirectory.Size = new System.Drawing.Size(413, 20);
            this.ExifToolDirectory.TabIndex = 0;
            this.ExifToolDirectory.TextChanged += new System.EventHandler(this.ExifToolDirectory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exif Tool Directory:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Image Folder";
            // 
            // ImagePath
            // 
            this.ImagePath.Location = new System.Drawing.Point(12, 91);
            this.ImagePath.Name = "ImagePath";
            this.ImagePath.Size = new System.Drawing.Size(413, 20);
            this.ImagePath.TabIndex = 5;
            this.ImagePath.TextChanged += new System.EventHandler(this.ImagePath_TextChanged);
            // 
            // OpenFolder
            // 
            this.OpenFolder.Location = new System.Drawing.Point(443, 91);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(103, 20);
            this.OpenFolder.TabIndex = 6;
            this.OpenFolder.Text = "Open Folder";
            this.OpenFolder.UseVisualStyleBackColor = true;
            this.OpenFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(12, 130);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 7;
            this.Run.Text = "Sort";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Sort_Checkbox
            // 
            this.Sort_Checkbox.AutoSize = true;
            this.Sort_Checkbox.Location = new System.Drawing.Point(120, 130);
            this.Sort_Checkbox.Name = "Sort_Checkbox";
            this.Sort_Checkbox.Size = new System.Drawing.Size(131, 17);
            this.Sort_Checkbox.TabIndex = 8;
            this.Sort_Checkbox.Text = "Sort Images to Folders";
            this.Sort_Checkbox.UseVisualStyleBackColor = true;
            this.Sort_Checkbox.CheckedChanged += new System.EventHandler(this.Sort_Checkbox_CheckedChanged);
            // 
            // Suffix_checkbox
            // 
            this.Suffix_checkbox.AutoSize = true;
            this.Suffix_checkbox.Location = new System.Drawing.Point(288, 130);
            this.Suffix_checkbox.Name = "Suffix_checkbox";
            this.Suffix_checkbox.Size = new System.Drawing.Size(118, 17);
            this.Suffix_checkbox.TabIndex = 9;
            this.Suffix_checkbox.Text = "Add Temp as Suffix";
            this.Suffix_checkbox.UseVisualStyleBackColor = true;
            this.Suffix_checkbox.CheckedChanged += new System.EventHandler(this.Suffix_checkbox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 183);
            this.Controls.Add(this.Suffix_checkbox);
            this.Controls.Add(this.Sort_Checkbox);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.OpenFolder);
            this.Controls.Add(this.ImagePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExifToolDirectory);
            this.Name = "Form1";
            this.Text = "TOrganizer v0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ExifToolDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ImagePath;
        private System.Windows.Forms.Button OpenFolder;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.CheckBox Sort_Checkbox;
        private System.Windows.Forms.CheckBox Suffix_checkbox;
    }
}

