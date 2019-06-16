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
		}

		public FullscreenPicture(int width, int height, Action closeParent, Image image) : this(width, height, closeParent)
		{
			DisplayedImage.Image = image;
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
			if (DisplayedImage.Size.Width < Screen.PrimaryScreen.Bounds.Size.Width && DisplayedImage.Size.Height < Screen.PrimaryScreen.Bounds.Size.Height)
			{
				var x = Location.X + MousePosition.X - _mousePos.X;
				var y = Location.Y + MousePosition.Y - _mousePos.Y;
				if (x < 0)
					x = 0;
				else if (x > Screen.PrimaryScreen.Bounds.Width - Size.Width)
					x = Screen.PrimaryScreen.Bounds.Width - Size.Width;
				if (y < Screen.PrimaryScreen.Bounds.Y)
					y = 0;
				else if (y > Screen.PrimaryScreen.Bounds.Height - Size.Height)
					y = Screen.PrimaryScreen.Bounds.Height - Size.Height;
				Location = new Point(x, y);
				DisplayedImage.Location = new Point(0, 0);
			}
			else if (DisplayedImage.Size.Width < Screen.PrimaryScreen.Bounds.Size.Width)
			{
				var x = Location.X + MousePosition.X - _mousePos.X;
				var y = 0;
				if (x < 0)
					x = 0;
				else if (x > Screen.PrimaryScreen.Bounds.Width - Size.Width)
					x = Screen.PrimaryScreen.Bounds.Width - Size.Width;
				Location = new Point(x, y);

				int py = DisplayedImage.Location.Y + MousePosition.Y - _mousePos.Y;

				if (py < Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Size.Height)
					py = Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Size.Height;
				else if (py > 0)
					py = 0;
				DisplayedImage.Location = new Point(0, py);
			}
			else if (DisplayedImage.Size.Height < Screen.PrimaryScreen.Bounds.Size.Height)
			{
				var x = 0;
				var y = Location.Y + MousePosition.Y - _mousePos.Y;
				if (y < 0)
					y = 0;
				else if (y > Screen.PrimaryScreen.Bounds.Height - Size.Height)
					y = Screen.PrimaryScreen.Bounds.Height - Size.Height;
				Location = new Point(x, y);

				int px = DisplayedImage.Location.X + MousePosition.X - _mousePos.X;

				if (px < Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Size.Width)
					px = Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Size.Width;
				else if (px > 0)
					px = 0;
				DisplayedImage.Location = new Point(px, 0);
			}
			else
			{
				var x = Location.X + MousePosition.X - _mousePos.X;
				var y = Location.Y + MousePosition.Y - _mousePos.Y;
				if (x < 0)
					x = 0;
				else if (x > Screen.PrimaryScreen.Bounds.Width - Size.Width)
					x = Screen.PrimaryScreen.Bounds.Width - Size.Width;
				if (y < 0)
					y = 0;
				else if (y > Screen.PrimaryScreen.Bounds.Height - Size.Height)
					y = Screen.PrimaryScreen.Bounds.Height - Size.Height;

				Location = new Point(x, y);

				var px = DisplayedImage.Location.X + MousePosition.X - _mousePos.X;
				var py = DisplayedImage.Location.Y + MousePosition.Y - _mousePos.Y;

				if (py < Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Size.Height)
					py = Screen.PrimaryScreen.Bounds.Height - DisplayedImage.Size.Height;
				else if (py > 0)
					py = 0;

				if (px < Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Size.Width)
					px = Screen.PrimaryScreen.Bounds.Width - DisplayedImage.Size.Width;
				else if (px > 0)
					px = 0;

				DisplayedImage.Location = new Point(px, py);
			}
			_mousePos = MousePosition;
		}

		private void MouseUpOccured(object sender, MouseEventArgs e)
		{
			_mouseDown = false;
		}

		private void Loaded(object sender, AsyncCompletedEventArgs e)
		{
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
}
