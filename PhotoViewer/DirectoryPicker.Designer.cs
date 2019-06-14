namespace PhotoViewer
{
    partial class DirectoryPicker
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
			this.components = new System.ComponentModel.Container();
			this.AddFilesLabel = new System.Windows.Forms.Label();
			this.Ok = new System.Windows.Forms.Button();
			this.Close = new System.Windows.Forms.Button();
			this.Browse = new System.Windows.Forms.Button();
			this.DirectoryPath = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.IncludeSubDirectories = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// AddFilesLabel
			// 
			this.AddFilesLabel.AutoSize = true;
			this.AddFilesLabel.Location = new System.Drawing.Point(12, 9);
			this.AddFilesLabel.Name = "AddFilesLabel";
			this.AddFilesLabel.Size = new System.Drawing.Size(131, 13);
			this.AddFilesLabel.TabIndex = 0;
			this.AddFilesLabel.Text = "Add files from the directory";
			// 
			// Ok
			// 
			this.Ok.Location = new System.Drawing.Point(62, 101);
			this.Ok.Name = "Ok";
			this.Ok.Size = new System.Drawing.Size(75, 23);
			this.Ok.TabIndex = 1;
			this.Ok.Text = "Ok";
			this.Ok.UseVisualStyleBackColor = true;
			this.Ok.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OkClick);
			// 
			// Close
			// 
			this.Close.CausesValidation = false;
			this.Close.Location = new System.Drawing.Point(143, 101);
			this.Close.Name = "Close";
			this.Close.Size = new System.Drawing.Size(75, 23);
			this.Close.TabIndex = 2;
			this.Close.Text = "Close";
			this.Close.UseVisualStyleBackColor = true;
			this.Close.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseClick);
			// 
			// Browse
			// 
			this.Browse.CausesValidation = false;
			this.Browse.Location = new System.Drawing.Point(173, 43);
			this.Browse.Name = "Browse";
			this.Browse.Size = new System.Drawing.Size(75, 23);
			this.Browse.TabIndex = 3;
			this.Browse.Text = "Browse";
			this.Browse.UseVisualStyleBackColor = true;
			this.Browse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BrowseClick);
			// 
			// DirectoryPath
			// 
			this.DirectoryPath.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
			this.DirectoryPath.BackColor = System.Drawing.SystemColors.Control;
			this.errorProvider.SetIconAlignment(this.DirectoryPath, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.DirectoryPath.Location = new System.Drawing.Point(28, 43);
			this.DirectoryPath.Name = "DirectoryPath";
			this.DirectoryPath.ReadOnly = true;
			this.DirectoryPath.Size = new System.Drawing.Size(139, 20);
			this.DirectoryPath.TabIndex = 4;
			this.DirectoryPath.Validating += new System.ComponentModel.CancelEventHandler(this.PathValidating);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// IncludeSubDirectories
			// 
			this.IncludeSubDirectories.AutoSize = true;
			this.IncludeSubDirectories.Location = new System.Drawing.Point(49, 73);
			this.IncludeSubDirectories.Name = "IncludeSubDirectories";
			this.IncludeSubDirectories.Size = new System.Drawing.Size(132, 17);
			this.IncludeSubDirectories.TabIndex = 5;
			this.IncludeSubDirectories.Text = "Include sub-directories";
			this.IncludeSubDirectories.UseVisualStyleBackColor = true;
			// 
			// DirectoryPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(261, 134);
			this.Controls.Add(this.IncludeSubDirectories);
			this.Controls.Add(this.DirectoryPath);
			this.Controls.Add(this.Browse);
			this.Controls.Add(this.Close);
			this.Controls.Add(this.Ok);
			this.Controls.Add(this.AddFilesLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DirectoryPicker";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Browse directory";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddFilesLabel;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox DirectoryPath;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox IncludeSubDirectories;
    }
}