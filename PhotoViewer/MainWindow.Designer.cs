namespace PhotoViewer
{
    partial class MainWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.TreeView = new System.Windows.Forms.TreeView();
			this.ImageList = new System.Windows.Forms.ImageList(this.components);
			this.Tree = new System.Windows.Forms.RadioButton();
			this.History = new System.Windows.Forms.RadioButton();
			this.HistoryList = new System.Windows.Forms.ListView();
			this.FolderNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FileCountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Browse = new System.Windows.Forms.Button();
			this.CurrentImage = new System.Windows.Forms.PictureBox();
			this.ImageIndex = new System.Windows.Forms.Label();
			this.ButtonRight = new System.Windows.Forms.Button();
			this.ButtonLeft = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CurrentImage)).BeginInit();
			this.SuspendLayout();
			// 
			// Splitter
			// 
			this.Splitter.BackColor = System.Drawing.Color.Black;
			this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Splitter.Location = new System.Drawing.Point(0, 0);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.Splitter.Panel1.Controls.Add(this.TreeView);
			this.Splitter.Panel1.Controls.Add(this.Tree);
			this.Splitter.Panel1.Controls.Add(this.History);
			this.Splitter.Panel1.Controls.Add(this.HistoryList);
			this.Splitter.Panel1.Controls.Add(this.Browse);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.Splitter.Panel2.Controls.Add(this.CurrentImage);
			this.Splitter.Panel2.Controls.Add(this.ImageIndex);
			this.Splitter.Panel2.Controls.Add(this.ButtonRight);
			this.Splitter.Panel2.Controls.Add(this.ButtonLeft);
			this.Splitter.Size = new System.Drawing.Size(804, 434);
			this.Splitter.SplitterDistance = 265;
			this.Splitter.TabIndex = 0;
			// 
			// TreeView
			// 
			this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TreeView.ImageIndex = 0;
			this.TreeView.ImageList = this.ImageList;
			this.TreeView.Location = new System.Drawing.Point(0, 22);
			this.TreeView.Name = "TreeView";
			this.TreeView.SelectedImageIndex = 0;
			this.TreeView.Size = new System.Drawing.Size(262, 380);
			this.TreeView.TabIndex = 5;
			this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeItemSelected);
			// 
			// ImageList
			// 
			this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageList.Images.SetKeyName(0, "dir.png");
			this.ImageList.Images.SetKeyName(1, "imageDir.png");
			// 
			// Tree
			// 
			this.Tree.AutoSize = true;
			this.Tree.Location = new System.Drawing.Point(92, 3);
			this.Tree.Name = "Tree";
			this.Tree.Size = new System.Drawing.Size(47, 17);
			this.Tree.TabIndex = 4;
			this.Tree.TabStop = true;
			this.Tree.Text = "Tree";
			this.Tree.UseVisualStyleBackColor = true;
			// 
			// History
			// 
			this.History.AutoSize = true;
			this.History.Location = new System.Drawing.Point(7, 3);
			this.History.Name = "History";
			this.History.Size = new System.Drawing.Size(57, 17);
			this.History.TabIndex = 3;
			this.History.TabStop = true;
			this.History.Text = "History";
			this.History.UseVisualStyleBackColor = true;
			this.History.CheckedChanged += new System.EventHandler(this.HistoryCheckedChanged);
			// 
			// HistoryList
			// 
			this.HistoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.HistoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FolderNameHeader,
            this.FileCountHeader});
			this.HistoryList.FullRowSelect = true;
			this.HistoryList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.HistoryList.Location = new System.Drawing.Point(0, 22);
			this.HistoryList.Name = "HistoryList";
			this.HistoryList.Size = new System.Drawing.Size(262, 380);
			this.HistoryList.TabIndex = 2;
			this.HistoryList.UseCompatibleStateImageBehavior = false;
			this.HistoryList.View = System.Windows.Forms.View.Details;
			this.HistoryList.Click += new System.EventHandler(this.HistoryListClicked);
			// 
			// FolderNameHeader
			// 
			this.FolderNameHeader.Text = "Folder name";
			this.FolderNameHeader.Width = 150;
			// 
			// FileCountHeader
			// 
			this.FileCountHeader.Text = "File count";
			this.FileCountHeader.Width = 97;
			// 
			// Browse
			// 
			this.Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Browse.Location = new System.Drawing.Point(187, 408);
			this.Browse.Name = "Browse";
			this.Browse.Size = new System.Drawing.Size(75, 23);
			this.Browse.TabIndex = 1;
			this.Browse.Text = "Browse";
			this.Browse.UseVisualStyleBackColor = true;
			this.Browse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BrowseClick);
			// 
			// CurrentImage
			// 
			this.CurrentImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CurrentImage.ErrorImage = global::PhotoViewer.Properties.Resources.question;
			this.CurrentImage.Location = new System.Drawing.Point(3, 3);
			this.CurrentImage.Name = "CurrentImage";
			this.CurrentImage.Size = new System.Drawing.Size(529, 399);
			this.CurrentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CurrentImage.TabIndex = 3;
			this.CurrentImage.TabStop = false;
			this.CurrentImage.DoubleClick += new System.EventHandler(this.CurrentImageDoubleClick);
			// 
			// ImageIndex
			// 
			this.ImageIndex.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.ImageIndex.AutoSize = true;
			this.ImageIndex.Location = new System.Drawing.Point(265, 413);
			this.ImageIndex.Name = "ImageIndex";
			this.ImageIndex.Size = new System.Drawing.Size(13, 13);
			this.ImageIndex.TabIndex = 2;
			this.ImageIndex.Text = "1";
			this.ImageIndex.Visible = false;
			// 
			// ButtonRight
			// 
			this.ButtonRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.ButtonRight.Location = new System.Drawing.Point(292, 408);
			this.ButtonRight.Name = "ButtonRight";
			this.ButtonRight.Size = new System.Drawing.Size(45, 23);
			this.ButtonRight.TabIndex = 1;
			this.ButtonRight.Text = ">>";
			this.ButtonRight.UseVisualStyleBackColor = true;
			this.ButtonRight.Visible = false;
			this.ButtonRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonRightClick);
			// 
			// ButtonLeft
			// 
			this.ButtonLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.ButtonLeft.Enabled = false;
			this.ButtonLeft.Location = new System.Drawing.Point(206, 408);
			this.ButtonLeft.Name = "ButtonLeft";
			this.ButtonLeft.Size = new System.Drawing.Size(45, 23);
			this.ButtonLeft.TabIndex = 0;
			this.ButtonLeft.Text = "<<";
			this.ButtonLeft.UseVisualStyleBackColor = true;
			this.ButtonLeft.Visible = false;
			this.ButtonLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonLeftClick);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ClientSize = new System.Drawing.Size(804, 434);
			this.Controls.Add(this.Splitter);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "MainWindow";
			this.Text = "Image viewer";
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel1.PerformLayout();
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
			this.Splitter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.CurrentImage)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Splitter;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.ColumnHeader FolderNameHeader;
        public System.Windows.Forms.ListView HistoryList;
        private System.Windows.Forms.ColumnHeader FileCountHeader;
        public System.Windows.Forms.PictureBox CurrentImage;
        public System.Windows.Forms.Button ButtonRight;
        public System.Windows.Forms.Button ButtonLeft;
        public System.Windows.Forms.Label ImageIndex;
        private System.Windows.Forms.RadioButton Tree;
        private System.Windows.Forms.RadioButton History;
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.ImageList ImageList;
    }
}

