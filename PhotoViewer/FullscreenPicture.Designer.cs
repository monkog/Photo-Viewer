namespace PhotoViewer
{
    partial class FullscreenPicture
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
			this.DisplayedImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.DisplayedImage)).BeginInit();
			this.SuspendLayout();
			// 
			// DisplayedImage
			// 
			this.DisplayedImage.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.DisplayedImage.BackColor = System.Drawing.SystemColors.Control;
			this.DisplayedImage.Location = new System.Drawing.Point(0, 0);
			this.DisplayedImage.Name = "DisplayedImage";
			this.DisplayedImage.Size = new System.Drawing.Size(284, 262);
			this.DisplayedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.DisplayedImage.TabIndex = 0;
			this.DisplayedImage.TabStop = false;
			this.DisplayedImage.DoubleClick += new System.EventHandler(this.DoubleClickOccured);
			this.DisplayedImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownOccured);
			this.DisplayedImage.MouseHover += new System.EventHandler(this.MouseHoverOccured);
			this.DisplayedImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveOccured);
			this.DisplayedImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpOccured);
			this.DisplayedImage.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyDownOccured);
			// 
			// FullscreenPicture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.DisplayedImage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FullscreenPicture";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FullscreenPic";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.MouseHover += new System.EventHandler(this.MouseHoverOccured);
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyDownOccured);
			((System.ComponentModel.ISupportInitialize)(this.DisplayedImage)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox DisplayedImage;

    }
}