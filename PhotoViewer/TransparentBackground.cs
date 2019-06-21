using System.Drawing;
using System.Windows.Forms;

namespace PhotoViewer
{
	public partial class TransparentBackground : Form
	{
		private readonly FullscreenPicture _picture;

		public TransparentBackground(int width, int height, string imagePath)
		{
			InitializeComponent();

			_picture = new FullscreenPicture(width, height, Close, imagePath) { Owner = this };
		}

		public TransparentBackground(int width, int height, Image image)
		{
			InitializeComponent();

			_picture = new FullscreenPicture(width, height, Close, image) { Owner = this };
		}

		private void Loaded(object sender, System.EventArgs e)
		{
			_picture.Show();
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Escape) return;
			Close();
		}
	}
}
