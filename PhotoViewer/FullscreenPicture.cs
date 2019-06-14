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
			pictureBoxO.ImageLocation = filePath;
		}

		public FullscreenPicture(int width, int height, Action closeParent, Bitmap image) : this(width, height, closeParent)
		{
			pictureBoxO.Image = image;
		}

		private FullscreenPicture(int width, int height, Action closeParent)
		{
			_closeParent = closeParent;
			InitializeComponent();
			pictureBoxO.MouseWheel += FullscreenPic_MouseWheel;
			pictureBoxO.MouseHover += pictureBoxO_MouseHover;
			MouseWheel += FullscreenPic_MouseWheel;
			MouseHover += pictureBoxO_MouseHover;
			pictureBoxO.Focus();

			Size = new Size(width, height);
			pictureBoxO.Size = new Size(Size.Width, Size.Height);
			pictureBoxO.Location = new Point(0, 0);
		}

		private void pictureBoxO_DoubleClick(object sender, EventArgs e)
		{
			_closeParent();
		}

		private void FullscreenPic_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)Keys.Escape) return;
			_closeParent();
		}

		private void pictureBoxO_MouseDown(object sender, MouseEventArgs e)
		{
			_mouseDown = true;
			_mousePos = MousePosition;
		}

		private void pictureBoxO_MouseHover(object sender, EventArgs e)
		{
			pictureBoxO.Focus();
		}

		private void pictureBoxO_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyValue != (char)Keys.Escape) return;
			_closeParent();
		}

		private void FullscreenPic_MouseWheel(object sender, MouseEventArgs e)
		{
			Size size = pictureBoxO.Size;
			if (e.Delta > 0 && pictureBoxO.Size.Width < (double)Size.Width * 5)
			{
				pictureBoxO.Size = new Size((int)(size.Width * 1.1), (int)(size.Height * 1.1));

				if (pictureBoxO.Width > Screen.PrimaryScreen.Bounds.Width)
				{
					if (pictureBoxO.Size.Height > Screen.PrimaryScreen.Bounds.Height)
					{
						Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
						Location = new Point(0, 0);
						pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
					}
					else
					{
						Size = new Size(Screen.PrimaryScreen.Bounds.Width, pictureBoxO.Size.Height);
						Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
						pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
					}
				}
				else if (pictureBoxO.Height > Screen.PrimaryScreen.Bounds.Height)
				{
					Size = new Size(pictureBoxO.Size.Width, Screen.PrimaryScreen.Bounds.Height);
					Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
					pictureBoxO.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
				}
				else
				{
					Size = pictureBoxO.Size;
					Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
					pictureBoxO.Location = new Point(0, 0);
				}
			}
			else if (e.Delta < 0 && pictureBoxO.Size.Width > Size.Width * 0.2)
			{
				pictureBoxO.Size = new Size((int)(size.Width * 0.9), (int)(size.Height * 0.9));
				if (pictureBoxO.Width > Screen.PrimaryScreen.Bounds.Width)
				{
					if (pictureBoxO.Size.Height > Screen.PrimaryScreen.Bounds.Height)
					{
						Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
						Location = new Point(0, 0);
						pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
					}
					else
					{
						Size = new Size(Screen.PrimaryScreen.Bounds.Width, pictureBoxO.Size.Height);
						Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
						pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
					}
				}
				else if (pictureBoxO.Height > Screen.PrimaryScreen.Bounds.Height)
				{
					Size = new Size(pictureBoxO.Size.Width, Screen.PrimaryScreen.Bounds.Height);
					Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
					pictureBoxO.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
				}
				else
				{
					Size = pictureBoxO.Size;
					Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
					pictureBoxO.Location = new Point(0, 0);
				}
			}
		}

		private void pictureBoxO_MouseMove(object sender, MouseEventArgs e)
		{
			if (_mouseDown)
			{
				if (pictureBoxO.Size.Width < Screen.PrimaryScreen.Bounds.Size.Width && pictureBoxO.Size.Height < Screen.PrimaryScreen.Bounds.Size.Height)
				{
					int x = Location.X + MousePosition.X - _mousePos.X;
					int y = Location.Y + MousePosition.Y - _mousePos.Y;
					if (x < 0)
						x = 0;
					else if (x > Screen.PrimaryScreen.Bounds.Width - Size.Width)
						x = Screen.PrimaryScreen.Bounds.Width - Size.Width;
					if (y < Screen.PrimaryScreen.Bounds.Y)
						y = 0;
					else if (y > Screen.PrimaryScreen.Bounds.Height - Size.Height)
						y = Screen.PrimaryScreen.Bounds.Height - Size.Height;
					Location = new Point(x, y);
					pictureBoxO.Location = new Point(0, 0);
				}
				else if (pictureBoxO.Size.Width < Screen.PrimaryScreen.Bounds.Size.Width)
				{
					int x = Location.X + MousePosition.X - _mousePos.X;
					int y = 0;
					if (x < 0)
						x = 0;
					else if (x > Screen.PrimaryScreen.Bounds.Width - Size.Width)
						x = Screen.PrimaryScreen.Bounds.Width - Size.Width;
					Location = new Point(x, y);

					int py = pictureBoxO.Location.Y + MousePosition.Y - _mousePos.Y;

					if (py < Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Size.Height)
						py = Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Size.Height;
					else if (py > 0)
						py = 0;
					pictureBoxO.Location = new Point(0, py);
				}
				else if (pictureBoxO.Size.Height < Screen.PrimaryScreen.Bounds.Size.Height)
				{
					int x = 0;
					int y = Location.Y + MousePosition.Y - _mousePos.Y;
					if (y < 0)
						y = 0;
					else if (y > Screen.PrimaryScreen.Bounds.Height - Size.Height)
						y = Screen.PrimaryScreen.Bounds.Height - Size.Height;
					Location = new Point(x, y);

					int px = pictureBoxO.Location.X + MousePosition.X - _mousePos.X;

					if (px < Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Size.Width)
						px = Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Size.Width;
					else if (px > 0)
						px = 0;
					pictureBoxO.Location = new Point(px, 0);
				}
				else
				{
					int x = Location.X + MousePosition.X - _mousePos.X;
					int y = Location.Y + MousePosition.Y - _mousePos.Y;
					if (x < 0)
						x = 0;
					else if (x > Screen.PrimaryScreen.Bounds.Width - Size.Width)
						x = Screen.PrimaryScreen.Bounds.Width - Size.Width;
					if (y < 0)
						y = 0;
					else if (y > Screen.PrimaryScreen.Bounds.Height - Size.Height)
						y = Screen.PrimaryScreen.Bounds.Height - Size.Height;

					Location = new Point(x, y);

					int px = pictureBoxO.Location.X + MousePosition.X - _mousePos.X;
					int py = pictureBoxO.Location.Y + MousePosition.Y - _mousePos.Y;

					if (py < Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Size.Height)
						py = Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Size.Height;
					else if (py > 0)
						py = 0;

					if (px < Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Size.Width)
						px = Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Size.Width;
					else if (px > 0)
						px = 0;

					pictureBoxO.Location = new Point(px, py);
				}
				_mousePos = MousePosition;
			}
		}

		private void pictureBoxO_MouseUp(object sender, MouseEventArgs e)
		{
			_mouseDown = false;
		}

		private void pictureBoxO_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			if (pictureBoxO.Width > Screen.PrimaryScreen.Bounds.Width)
			{
				if (pictureBoxO.Size.Height > Screen.PrimaryScreen.Bounds.Height)
				{
					Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
					Location = new Point(0, 0);
					pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
				}
				else
				{
					Size = new Size(Screen.PrimaryScreen.Bounds.Width, pictureBoxO.Size.Height);
					Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
					pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
				}
			}
			else if (pictureBoxO.Height > Screen.PrimaryScreen.Bounds.Height)
			{
				Size = new Size(pictureBoxO.Size.Width, Screen.PrimaryScreen.Bounds.Height);
				Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
				pictureBoxO.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
			}
			else
			{
				Size = pictureBoxO.Size;
				Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
				pictureBoxO.Location = new Point(0, 0);
			}
		}
	}
}
