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
			this.pictureBoxO = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxO)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxO
			// 
			this.pictureBoxO.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pictureBoxO.BackColor = System.Drawing.SystemColors.Control;
			this.pictureBoxO.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxO.Name = "pictureBoxO";
			this.pictureBoxO.Size = new System.Drawing.Size(284, 262);
			this.pictureBoxO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxO.TabIndex = 0;
			this.pictureBoxO.TabStop = false;
			this.pictureBoxO.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBoxO_LoadCompleted);
			this.pictureBoxO.DoubleClick += new System.EventHandler(this.pictureBoxO_DoubleClick);
			this.pictureBoxO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxO_MouseDown);
			this.pictureBoxO.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxO_MouseMove);
			this.pictureBoxO.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxO_MouseUp);
			this.pictureBoxO.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxO_PreviewKeyDown);
			// 
			// FullscreenPicture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.pictureBoxO);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FullscreenPicture";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FullscreenPic";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FullscreenPic_KeyPress);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxO)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxO;

    }
}