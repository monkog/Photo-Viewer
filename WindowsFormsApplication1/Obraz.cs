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

namespace WindowsFormsApplication1
{
    public partial class Obraz : Form
    {
        public int width;
        public int height;
        public int x;
        public int y;

        public Obraz()
        {
            InitializeComponent();
        }

        public void draw()
        {
            var form = this.Owner as przegladarkaForm;
            FullscreenPic fp = new FullscreenPic();
            fp.Owner = this;
            fp.FormBorderStyle = FormBorderStyle.None;
            fp.MainMenuStrip = null;
            fp.ShowInTaskbar = false;
            fp.TopMost = true;
            string[] dirElems = Directory.GetFiles(form.pathList[form.currentPath].path);

            if (form.pictureBox.Image == form.pictureBox.ErrorImage)
                fp.pictureBoxO.Image = Properties.Resources.question;
            else
                fp.pictureBoxO.ImageLocation = dirElems[form.pathList[form.currentPath].currentNumber - 1];
            
            fp.Size = new Size(form.pictureBox.Image.Size.Width, form.pictureBox.Image.Size.Height);
            fp.pictureBoxO.Size = new Size(fp.Size.Width, fp.Size.Height);
            fp.pictureBoxO.Location = new Point(0, 0);
            fp.width = fp.Size.Width;
            fp.height = fp.Size.Height;
            fp.Show();
        }

        private void Obraz_KeyPress(object sender, KeyPressEventArgs e)
        {
            FullscreenPic form = (FullscreenPic)Application.OpenForms["FullscreenPic"];
            form.Close();
            Close();
        }
    }
}
