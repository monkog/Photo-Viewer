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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.buttonPrzegladaj = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dodaj pliki z katalogu";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(62, 101);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonOk_MouseClick);
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.CausesValidation = false;
            this.buttonZamknij.Location = new System.Drawing.Point(143, 101);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(75, 23);
            this.buttonZamknij.TabIndex = 2;
            this.buttonZamknij.Text = "Zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = true;
            this.buttonZamknij.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonZamknij_MouseClick);
            // 
            // buttonPrzegladaj
            // 
            this.buttonPrzegladaj.CausesValidation = false;
            this.buttonPrzegladaj.Location = new System.Drawing.Point(173, 43);
            this.buttonPrzegladaj.Name = "buttonPrzegladaj";
            this.buttonPrzegladaj.Size = new System.Drawing.Size(75, 23);
            this.buttonPrzegladaj.TabIndex = 3;
            this.buttonPrzegladaj.Text = "Przeglądaj";
            this.buttonPrzegladaj.UseVisualStyleBackColor = true;
            this.buttonPrzegladaj.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPrzegladaj_MouseClick);
            // 
            // textBox
            // 
            this.textBox.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.textBox.BackColor = System.Drawing.SystemColors.Control;
            this.errorProvider.SetIconAlignment(this.textBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.textBox.Location = new System.Drawing.Point(28, 43);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(139, 20);
            this.textBox.TabIndex = 4;
            this.textBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(49, 73);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(112, 17);
            this.checkBox.TabIndex = 5;
            this.checkBox.Text = "Dodaj podkatalogi";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // Wczytywanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 134);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonPrzegladaj);
            this.Controls.Add(this.buttonZamknij);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Wczytywanie";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodaj katalog";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.Button buttonPrzegladaj;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox checkBox;
    }
}