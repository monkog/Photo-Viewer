using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotoViewer
{
	public partial class Image : Form
	{
		public Image()
		{
			InitializeComponent();
		}

		private void Loaded(object sender, System.EventArgs e)
		{
			var form = Owner as MainWindow;
			var picture = new FullscreenPicture(Close) { Owner = this };

			var dirElems = Directory.GetFiles(form.pathList[form.currentPath].Path);

			if (form.CurrentImage.Image == form.CurrentImage.ErrorImage)
				picture.pictureBoxO.Image = Properties.Resources.question;
			else
				picture.pictureBoxO.ImageLocation = dirElems[form.pathList[form.currentPath].CurrentIndex - 1];

			picture.Size = new Size(form.CurrentImage.Image.Size.Width, form.CurrentImage.Image.Size.Height);
			picture.pictureBoxO.Size = new Size(picture.Size.Width, picture.Size.Height);
			picture.pictureBoxO.Location = new Point(0, 0);
			picture.width = picture.Size.Width;
			picture.height = picture.Size.Height;
			picture.Show();
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Escape) return;
			Close();
		}
	}
}
