using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class FullscreenPic : Form
    {
        public int width;
        public int height;
        private bool mouseDown = false;
        private Point mousePos;

        public FullscreenPic()
        {
            InitializeComponent();
            pictureBoxO.MouseWheel += new MouseEventHandler(FullscreenPic_MouseWheel);
            pictureBoxO.MouseHover += new EventHandler(pictureBoxO_MouseHover);
            this.MouseWheel += FullscreenPic_MouseWheel;
            this.MouseHover += new EventHandler(pictureBoxO_MouseHover);
            pictureBoxO.Focus();
        }

        private void pictureBoxO_DoubleClick(object sender, EventArgs e)
        {
            Obraz form = (Obraz)Application.OpenForms["Obraz"];
            form.Close();
            Close();
        }

        private void FullscreenPic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Obraz form = (Obraz)Application.OpenForms["Obraz"];
                form.Close();
                Close();
            }
        }

        private void pictureBoxO_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mousePos = MousePosition;
        }

        private void pictureBoxO_MouseHover(object sender, EventArgs e)
        {
            pictureBoxO.Focus();
        }

        private void pictureBoxO_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Escape)
            {
                Obraz form = (Obraz)Application.OpenForms["Obraz"];
                form.Close();
                Close();
            }
        }

        private void FullscreenPic_MouseWheel(object sender, MouseEventArgs e)
        {
            Size size = pictureBoxO.Size;
            if (e.Delta > 0 && pictureBoxO.Size.Width < (double)width * 5)
            {
                pictureBoxO.Size = new Size((int)((double)size.Width * 1.1), (int)((double)size.Height * 1.1));

                if (pictureBoxO.Width > Screen.PrimaryScreen.Bounds.Width)
                {
                    if (pictureBoxO.Size.Height > Screen.PrimaryScreen.Bounds.Height)
                    {
                        this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        this.Location = new System.Drawing.Point(0, 0);
                        pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                    }
                    else
                    {
                        this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, pictureBoxO.Size.Height);
                        this.Location = new System.Drawing.Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                        pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
                    }
                }
                else if (pictureBoxO.Height > Screen.PrimaryScreen.Bounds.Height)
                {
                    this.Size = new Size(pictureBoxO.Size.Width, Screen.PrimaryScreen.Bounds.Height);
                    this.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
                    pictureBoxO.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                }
                else
                {
                    this.Size = pictureBoxO.Size;
                    this.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                    pictureBoxO.Location = new Point(0, 0);
                }
            }
            else if (e.Delta < 0 && pictureBoxO.Size.Width > (double)width * 0.2)
            {
                pictureBoxO.Size = new Size((int)((double)size.Width * 0.9), (int)((double)size.Height * 0.9));
                if (pictureBoxO.Width > Screen.PrimaryScreen.Bounds.Width)
                {
                    if (pictureBoxO.Size.Height > Screen.PrimaryScreen.Bounds.Height)
                    {
                        this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        this.Location = new System.Drawing.Point(0, 0);
                        pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                    }
                    else
                    {
                        this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, pictureBoxO.Size.Height);
                        this.Location = new System.Drawing.Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                        pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
                    }
                }
                else if (pictureBoxO.Height > Screen.PrimaryScreen.Bounds.Height)
                {
                    this.Size = new Size(pictureBoxO.Size.Width, Screen.PrimaryScreen.Bounds.Height);
                    this.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
                    pictureBoxO.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                }
                else
                {
                    this.Size = pictureBoxO.Size;
                    this.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                    pictureBoxO.Location = new Point(0, 0);
                }
            }
        }

        private void pictureBoxO_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (pictureBoxO.Size.Width < Screen.PrimaryScreen.Bounds.Size.Width && pictureBoxO.Size.Height < Screen.PrimaryScreen.Bounds.Size.Height)
                {
                    int x = this.Location.X + MousePosition.X - mousePos.X;
                    int y = this.Location.Y + MousePosition.Y - mousePos.Y;
                    if (x < 0)
                        x = 0;
                    else if (x > Screen.PrimaryScreen.Bounds.Width - this.Size.Width)
                        x = Screen.PrimaryScreen.Bounds.Width - this.Size.Width;
                    if (y < Screen.PrimaryScreen.Bounds.Y)
                        y = 0;
                    else if (y > Screen.PrimaryScreen.Bounds.Height - this.Size.Height)
                        y = Screen.PrimaryScreen.Bounds.Height - this.Size.Height;
                    this.Location = new Point(x, y);
                    pictureBoxO.Location = new Point(0, 0);
                }
                else if (pictureBoxO.Size.Width < Screen.PrimaryScreen.Bounds.Size.Width)
                {
                    int x = this.Location.X + MousePosition.X - mousePos.X;
                    int y = 0;
                    if (x < 0)
                        x = 0;
                    else if (x > Screen.PrimaryScreen.Bounds.Width - this.Size.Width)
                        x = Screen.PrimaryScreen.Bounds.Width - this.Size.Width;
                    this.Location = new Point(x, y);

                    int py = pictureBoxO.Location.Y + MousePosition.Y - mousePos.Y;

                    if (py < Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Size.Height)
                        py = Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Size.Height;
                    else if (py > 0)
                        py = 0;
                    pictureBoxO.Location = new Point(0, py);
                }
                else if (pictureBoxO.Size.Height < Screen.PrimaryScreen.Bounds.Size.Height)
                {
                    int x = 0;
                    int y = this.Location.Y + MousePosition.Y - mousePos.Y;
                    if (y < 0)
                        y = 0;
                    else if (y > Screen.PrimaryScreen.Bounds.Height - this.Size.Height)
                        y = Screen.PrimaryScreen.Bounds.Height - this.Size.Height;
                    this.Location = new Point(x, y);

                    int px = pictureBoxO.Location.X + MousePosition.X - mousePos.X;

                    if (px < Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Size.Width)
                        px = Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Size.Width;
                    else if (px > 0)
                        px = 0;
                    pictureBoxO.Location = new Point(px, 0);
                }
                else
                {
                    int x = this.Location.X + MousePosition.X - mousePos.X;
                    int y = this.Location.Y + MousePosition.Y - mousePos.Y;
                    if (x < 0)
                        x = 0;
                    else if (x > Screen.PrimaryScreen.Bounds.Width - this.Size.Width)
                        x = Screen.PrimaryScreen.Bounds.Width - this.Size.Width;
                    if (y < 0)
                        y = 0;
                    else if (y > Screen.PrimaryScreen.Bounds.Height - this.Size.Height)
                        y = Screen.PrimaryScreen.Bounds.Height - this.Size.Height;

                    this.Location = new Point(x, y);

                    int px = pictureBoxO.Location.X + MousePosition.X - mousePos.X;
                    int py = pictureBoxO.Location.Y + MousePosition.Y - mousePos.Y;

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
                mousePos = MousePosition;
            }
        }

        private void pictureBoxO_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBoxO_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (pictureBoxO.Width > Screen.PrimaryScreen.Bounds.Width)
            {
                if (pictureBoxO.Size.Height > Screen.PrimaryScreen.Bounds.Height)
                {
                    this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    this.Location = new System.Drawing.Point(0, 0);
                    pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                }
                else
                {
                    this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, pictureBoxO.Size.Height);
                    this.Location = new System.Drawing.Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                    pictureBoxO.Location = new Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
                }
            }
            else if (pictureBoxO.Height > Screen.PrimaryScreen.Bounds.Height)
            {
                this.Size = new Size(pictureBoxO.Size.Width, Screen.PrimaryScreen.Bounds.Height);
                this.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, 0);
                pictureBoxO.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
            }
            else
            {
                this.Size = pictureBoxO.Size;
                this.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxO.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - pictureBoxO.Height) / 2);
                pictureBoxO.Location = new Point(0, 0);
            }
        }
    }
}
