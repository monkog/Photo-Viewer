using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoViewer
{
	public partial class FullscreenPicture : Form
	{
		private readonly Action _closeParent;

		private bool _mouseDown;

		private Point _mousePos;

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
			var size = DisplayedImage.Size;
			if (e.Delta > 0 && DisplayedImage.Size.Width < (double)Size.Width * 5)
			{
				DisplayedImage.Size = new Size((int)(size.Width * 1.1), (int)(size.Height * 1.1));

				if (DisplayedImage.Width > Screen.PrimaryScreen.Bounds.Width)
				{
					if (DisplayedImage.Size.Height > Screen.PrimaryScreen.Bounds.Height)
					{
						Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
						Location = new Point(0, 0);
						DisplayedImage.Location = new Point((Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Height) / 2);
					}
					else
					{
						Size = new Size(Screen.PrimaryScreen.Bounds.Width, DisplayedImage.Size.Height);
						Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Height) / 2);
						DisplayedImage.Location = new Point((Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Width) / 2, 0);
					}
				}
				else if (DisplayedImage.Height > Screen.PrimaryScreen.Bounds.Height)
				{
					Size = new Size(DisplayedImage.Size.Width, Screen.PrimaryScreen.Bounds.Height);
					Location = new Point((Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Width) / 2, 0);
					DisplayedImage.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Height) / 2);
				}
				else
				{
					Size = DisplayedImage.Size;
					Location = new Point((Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Height) / 2);
					DisplayedImage.Location = new Point(0, 0);
				}
			}
			else if (e.Delta < 0 && DisplayedImage.Size.Width > Size.Width * 0.2)
			{
				DisplayedImage.Size = new Size((int)(size.Width * 0.9), (int)(size.Height * 0.9));
				if (DisplayedImage.Width > Screen.PrimaryScreen.Bounds.Width)
				{
					if (DisplayedImage.Size.Height > Screen.PrimaryScreen.Bounds.Height)
					{
						Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
						Location = new Point(0, 0);
						DisplayedImage.Location = new Point((Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Height) / 2);
					}
					else
					{
						Size = new Size(Screen.PrimaryScreen.Bounds.Width, DisplayedImage.Size.Height);
						Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Height) / 2);
						DisplayedImage.Location = new Point((Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Width) / 2, 0);
					}
				}
				else if (DisplayedImage.Height > Screen.PrimaryScreen.Bounds.Height)
				{
					Size = new Size(DisplayedImage.Size.Width, Screen.PrimaryScreen.Bounds.Height);
					Location = new Point((Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Width) / 2, 0);
					DisplayedImage.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Height) / 2);
				}
				else
				{
					Size = DisplayedImage.Size;
					Location = new Point((Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Height) / 2);
					DisplayedImage.Location = new Point(0, 0);
				}
			}
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

			var x = DisplayedImage.Width > screenBounds.Width ? 0 : (screenBounds.Width - DisplayedImage.Width) / 2;
			var y = DisplayedImage.Height > screenBounds.Height ? 0 : (screenBounds.Height - DisplayedImage.Height) / 2;
			Location = new Point(x, y);

			var imageX = DisplayedImage.Width > screenBounds.Width ? (screenBounds.Width - DisplayedImage.Width) / 2 : 0;
			var imageY = DisplayedImage.Height > screenBounds.Height ? (screenBounds.Height - DisplayedImage.Height) / 2 : 0;
			DisplayedImage.Location = new Point(imageX, imageY);
		}
	}
}
