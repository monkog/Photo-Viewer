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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.radioDrzewo = new System.Windows.Forms.RadioButton();
            this.radioHistoria = new System.Windows.Forms.RadioButton();
            this.listViewHistoria = new System.Windows.Forms.ListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonWczytaj = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.Black;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            this.splitContainer.Panel1.Controls.Add(this.radioDrzewo);
            this.splitContainer.Panel1.Controls.Add(this.radioHistoria);
            this.splitContainer.Panel1.Controls.Add(this.listViewHistoria);
            this.splitContainer.Panel1.Controls.Add(this.buttonWczytaj);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer.Panel2.Controls.Add(this.labelNumber);
            this.splitContainer.Panel2.Controls.Add(this.buttonRight);
            this.splitContainer.Panel2.Controls.Add(this.buttonLeft);
            this.splitContainer.Size = new System.Drawing.Size(804, 434);
            this.splitContainer.SplitterDistance = 265;
            this.splitContainer.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(0, 22);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(262, 380);
            this.treeView.TabIndex = 5;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "dir.png");
            this.imageList.Images.SetKeyName(1, "imageDir.png");
            // 
            // radioDrzewo
            // 
            this.radioDrzewo.AutoSize = true;
            this.radioDrzewo.Location = new System.Drawing.Point(92, 3);
            this.radioDrzewo.Name = "radioDrzewo";
            this.radioDrzewo.Size = new System.Drawing.Size(61, 17);
            this.radioDrzewo.TabIndex = 4;
            this.radioDrzewo.TabStop = true;
            this.radioDrzewo.Text = "Drzewo";
            this.radioDrzewo.UseVisualStyleBackColor = true;
            // 
            // radioHistoria
            // 
            this.radioHistoria.AutoSize = true;
            this.radioHistoria.Location = new System.Drawing.Point(7, 3);
            this.radioHistoria.Name = "radioHistoria";
            this.radioHistoria.Size = new System.Drawing.Size(60, 17);
            this.radioHistoria.TabIndex = 3;
            this.radioHistoria.TabStop = true;
            this.radioHistoria.Text = "Historia";
            this.radioHistoria.UseVisualStyleBackColor = true;
            this.radioHistoria.CheckedChanged += new System.EventHandler(this.radioHistoria_CheckedChanged);
            // 
            // listViewHistoria
            // 
            this.listViewHistoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewHistoria.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader,
            this.columnHeader1});
            this.listViewHistoria.FullRowSelect = true;
            this.listViewHistoria.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listViewHistoria.Location = new System.Drawing.Point(0, 22);
            this.listViewHistoria.Name = "listViewHistoria";
            this.listViewHistoria.Size = new System.Drawing.Size(262, 380);
            this.listViewHistoria.TabIndex = 2;
            this.listViewHistoria.UseCompatibleStateImageBehavior = false;
            this.listViewHistoria.View = System.Windows.Forms.View.Details;
            this.listViewHistoria.Click += new System.EventHandler(this.listViewHistoria_Click);
            // 
            // columnHeader
            // 
            this.columnHeader.Text = "Nazwa Folderu";
            this.columnHeader.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Liczba plików";
            this.columnHeader1.Width = 97;
            // 
            // buttonWczytaj
            // 
            this.buttonWczytaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWczytaj.Location = new System.Drawing.Point(187, 408);
            this.buttonWczytaj.Name = "buttonWczytaj";
            this.buttonWczytaj.Size = new System.Drawing.Size(75, 23);
            this.buttonWczytaj.TabIndex = 1;
            this.buttonWczytaj.Text = "Wczytaj";
            this.buttonWczytaj.UseVisualStyleBackColor = true;
            this.buttonWczytaj.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonWczytaj_MouseClick);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.ErrorImage = global::PhotoViewer.Properties.Resources.question;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(529, 399);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // labelNumber
            // 
            this.labelNumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(265, 413);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(13, 13);
            this.labelNumber.TabIndex = 2;
            this.labelNumber.Text = "1";
            this.labelNumber.Visible = false;
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRight.Location = new System.Drawing.Point(292, 408);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(45, 23);
            this.buttonRight.TabIndex = 1;
            this.buttonRight.Text = ">>";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Visible = false;
            this.buttonRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseClick);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonLeft.Enabled = false;
            this.buttonLeft.Location = new System.Drawing.Point(206, 408);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(45, 23);
            this.buttonLeft.TabIndex = 0;
            this.buttonLeft.Text = "<<";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Visible = false;
            this.buttonLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseClick);
            // 
            // przegladarkaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(804, 434);
            this.Controls.Add(this.splitContainer);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "przegladarkaForm";
            this.Text = "Przegladarka obrazkow";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button buttonWczytaj;
        private System.Windows.Forms.ColumnHeader columnHeader;
        public System.Windows.Forms.ListView listViewHistoria;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.Button buttonRight;
        public System.Windows.Forms.Button buttonLeft;
        public System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.RadioButton radioDrzewo;
        private System.Windows.Forms.RadioButton radioHistoria;
        public System.Windows.Forms.TreeView treeView;
        public System.Windows.Forms.ImageList imageList;
    }
}

