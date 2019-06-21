using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoViewer
{
	public partial class FullscreenPicture : Form
	{
		private readonly Action _closeParent;

		private bool _mouseDown;

		private Point _mousePos;

		private Size _initialSize;

		private double _zoomFactor;

		public FullscreenPicture(int width, int height, Action closeParent, string filePath) : this(width, height, closeParent)
		{
			DisplayedImage.ImageLocation = filePath;
			SetImageBounds();
		}

		public FullscreenPicture(int width, int height, Action closeParent, Image image) : this(width, height, closeParent)
		{
			DisplayedImage.Image = image;
			SetImageBounds();
		}

		private FullscreenPicture(int width, int height, Action closeParent)
		{
			_closeParent = closeParent;
			InitializeComponent();

			DisplayedImage.MouseWheel += MouseWheelChanged;
			MouseWheel += MouseWheelChanged;
			DisplayedImage.Focus();

			DisplayedImage.Size = new Size(width, height);
		}

		private void DoubleClickOccured(object sender, EventArgs e)
		{
			_closeParent();
		}

		private void MouseDownOccured(object sender, MouseEventArgs e)
		{
			_mouseDown = true;
			_mousePos = MousePosition;
		}

		private void MouseHoverOccured(object sender, EventArgs e)
		{
			DisplayedImage.Focus();
		}

		private void KeyDownOccured(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyValue != (char)Keys.Escape) return;
			_closeParent();
		}

		private void MouseWheelChanged(object sender, MouseEventArgs e)
		{
			var screenBounds = Screen.PrimaryScreen.Bounds;
			var newZoomFactor = e.Delta > 0 ? _zoomFactor + 0.1 : _zoomFactor - 0.1;
			var recalculatedSize = new Size((int)(_initialSize.Width * newZoomFactor), (int)(_initialSize.Height * newZoomFactor));

			if (newZoomFactor > 5.0 || (recalculatedSize.Width < screenBounds.Width * 0.2 && newZoomFactor < 1.0)) return;
			DisplayedImage.Size = recalculatedSize;
			_zoomFactor = newZoomFactor;

			var width = Math.Min(DisplayedImage.Width, screenBounds.Width);
			var height = Math.Min(DisplayedImage.Height, screenBounds.Height);
			Size = new Size(width, height);

			var x = Math.Max(0, (screenBounds.Width - DisplayedImage.Width) / 2);
			var y = Math.Max(0, (screenBounds.Height - DisplayedImage.Height) / 2);
			Location = new Point(x, y);

			var imageX = Math.Min(0, (screenBounds.Width - DisplayedImage.Width) / 2);
			var imageY = Math.Min(0, (screenBounds.Height - DisplayedImage.Height) / 2);
			DisplayedImage.Location = new Point(imageX, imageY);
		}

		private void MouseMoveOccured(object sender, MouseEventArgs e)
		{
			if (!_mouseDown) return;

			var screenBounds = Screen.PrimaryScreen.Bounds;
			var x = Math.Max(0, Math.Min(Location.X + MousePosition.X - _mousePos.X, screenBounds.Width - Width));
			var y = Math.Max(0, Math.Min(Location.Y + MousePosition.Y - _mousePos.Y, screenBounds.Height - Height));
			Location = new Point(x, y);

			var imageX = Math.Min(0, Math.Max(DisplayedImage.Location.X + MousePosition.X - _mousePos.X, screenBounds.Width - DisplayedImage.Width));
			var imageY = Math.Min(0, Math.Max(DisplayedImage.Location.Y + MousePosition.Y - _mousePos.Y, screenBounds.Height - DisplayedImage.Height));
			DisplayedImage.Location = new Point(imageX, imageY);

			_mousePos = MousePosition;
		}

		private void MouseUpOccured(object sender, MouseEventArgs e)
		{
			_mouseDown = false;
		}

		private void SetImageBounds()
		{
			var screenBounds = Screen.PrimaryScreen.Bounds;

			var width = Math.Min(DisplayedImage.Width, screenBounds.Width);
			var height = Math.Min(DisplayedImage.Height, screenBounds.Height);
			Size = new Size(width, height);
			_initialSize = Size;
			_zoomFactor = 1.0;

			var x = DisplayedImage.Width > screenBounds.Width ? 0 : (screenBounds.Width - DisplayedImage.Width) / 2;
			var y = DisplayedImage.Height > screenBounds.Height ? 0 : (screenBounds.Height - DisplayedImage.Height) / 2;
			Location = new Point(x, y);

			var imageX = DisplayedImage.Width > screenBounds.Width ? (screenBounds.Width - DisplayedImage.Width) / 2 : 0;
			var imageY = DisplayedImage.Height > screenBounds.Height ? (screenBounds.Height - DisplayedImage.Height) / 2 : 0;
			DisplayedImage.Location = new Point(imageX, imageY);
		}
	}
}
