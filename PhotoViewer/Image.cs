using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotoViewer
{
    public partial class Image : Form
    {
        public int width;
        public int height;
        public int x;
        public int y;

        public Image()
        {
            InitializeComponent();
        }

        public void draw()
        {
            var form = this.Owner as MainWindow;
            FullscreenPicture fp = new FullscreenPicture();
            fp.Owner = this;
            fp.FormBorderStyle = FormBorderStyle.None;
            fp.MainMenuStrip = null;
            fp.ShowInTaskbar = false;
            fp.TopMost = true;
            string[] dirElems = Directory.GetFiles(form.pathList[form.currentPath].path);

            if (form.CurrentImage.Image == form.CurrentImage.ErrorImage)
                fp.pictureBoxO.Image = Properties.Resources.question;
            else
                fp.pictureBoxO.ImageLocation = dirElems[form.pathList[form.currentPath].currentNumber - 1];
            
            fp.Size = new Size(form.CurrentImage.Image.Size.Width, form.CurrentImage.Image.Size.Height);
            fp.pictureBoxO.Size = new Size(fp.Size.Width, fp.Size.Height);
            fp.pictureBoxO.Location = new Point(0, 0);
            fp.width = fp.Size.Width;
            fp.height = fp.Size.Height;
            fp.Show();
        }

        private void Obraz_KeyPress(object sender, KeyPressEventArgs e)
        {
            FullscreenPicture form = (FullscreenPicture)Application.OpenForms["FullscreenPic"];
            form.Close();
            Close();
        }
    }
}
