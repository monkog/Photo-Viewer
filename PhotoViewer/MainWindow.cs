using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PhotoViewer
{
    public partial class MainWindow : Form
    {
        public List<help> pathList;
        public int currentPath = -1;

        public MainWindow()
        {
            InitializeComponent();
            MinimizeBox = false;
            CurrentImage.Visible = false;
            History.Checked = true;
            pathList = new List<help>();
            HistoryList.SmallImageList = new ImageList();
            HistoryList.SmallImageList.Images.Add(Properties.Resources.imageDir);
        }

        private void BrowseClick(object sender, MouseEventArgs e)
        {
            DirectoryPicker wczytaj = new DirectoryPicker();
            wczytaj.Owner = this;
            wczytaj.MinimizeBox = false;
            wczytaj.MaximizeBox = false;
            wczytaj.ShowInTaskbar = false;
            wczytaj.ShowDialog();
        }

		private void ButtonLeftClick(object sender, MouseEventArgs e)
        {
            if (pathList[currentPath].currentNumber > 1)
            {
                pathList[currentPath].currentNumber--;
                ImageIndex.Text = pathList[currentPath].currentNumber.ToString();
                if (pathList[currentPath].currentNumber == 1)
                    ButtonLeft.Enabled = false;
                if (ButtonRight.Enabled == false)
                    ButtonRight.Enabled = true;

                string[] dirElems = Directory.GetFiles(pathList[currentPath].path);
                CurrentImage.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
            }
        }

        private void ButtonRightClick(object sender, MouseEventArgs e)
        {
            pathList[currentPath].currentNumber++;
            ImageIndex.Text = pathList[currentPath].currentNumber.ToString();
            if (ButtonLeft.Enabled == false)
                ButtonLeft.Enabled = true;
            if (pathList[currentPath].currentNumber == pathList[currentPath].numberOfFiles)
                ButtonRight.Enabled = false;

            string[] dirElems = Directory.GetFiles(pathList[currentPath].path);
            CurrentImage.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
        }
		
        private void HistoryListClicked(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.HistoryList.SelectedIndices;
            currentPath = indexes[0];

            if (pathList[currentPath].numberOfFiles > 0)
            {
                string[] dirElems = Directory.GetFiles(pathList[currentPath].path);

                if (pathList[currentPath].currentNumber == 1)
                {
                    CurrentImage.ImageLocation = dirElems[0];
                    CurrentImage.Visible = true;
                    ButtonLeft.Visible = true;
                    ButtonLeft.Enabled = false;
                    ButtonRight.Visible = true;
                    ImageIndex.Visible = true;
                    ImageIndex.Text = pathList[currentPath].currentNumber.ToString();
                    if (pathList[currentPath].numberOfFiles == 1)
                        ButtonRight.Enabled = false;
                    else
                        ButtonRight.Enabled = true;
                }
                else if (pathList[currentPath].currentNumber == pathList[currentPath].numberOfFiles)
                {
                    CurrentImage.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
                    CurrentImage.Visible = true;
                    ButtonLeft.Visible = true;
                    ButtonLeft.Enabled = true;
                    ButtonRight.Visible = true;
                    ButtonRight.Enabled = false;
                    ImageIndex.Visible = true;
                    ImageIndex.Text = pathList[currentPath].currentNumber.ToString();
                }
                else
                {
                    CurrentImage.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
                    CurrentImage.Visible = true;
                    ButtonLeft.Visible = true;
                    ButtonLeft.Enabled = true;
                    ButtonRight.Visible = true;
                    ButtonRight.Enabled = true;
                    ImageIndex.Visible = true;
                    ImageIndex.Text = pathList[currentPath].currentNumber.ToString();
                }
            }
            else
            {
                ButtonLeft.Visible = false;
                ButtonRight.Visible = false;
                ImageIndex.Visible = false;
                CurrentImage.Visible = false;
            }
        }

        private void CurrentImageDoubleClick(object sender, EventArgs e)
        {
            if (CurrentImage.Visible == true)
            {
                Image obraz = new Image();
                obraz.Owner = this;
                obraz.ShowInTaskbar = false;
                obraz.WindowState = FormWindowState.Maximized;
                obraz.FormBorderStyle = FormBorderStyle.None;
                obraz.TopMost = true;
                obraz.Visible = false;
                obraz.draw();
                obraz.Show();
            }
        }
		
        private void HistoryCheckedChanged(object sender, EventArgs e)
        {
            if (History.Checked == true)
            {
                HistoryList.Enabled = true;
                HistoryList.Visible = true;
                TreeView.Enabled = false;
                TreeView.Visible = false;
            }
            else
            {
                HistoryList.Enabled = false;
                HistoryList.Visible = false;
                TreeView.Enabled = true;
                TreeView.Visible = true;
            }
        }
		
        private void TreeItemSelected(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.FullPath;
            path = path.Substring(0,3) + path.Substring(4);

            for (int i = 0; i < pathList.Count; i++)
                if (pathList[i].path == path)
                {
                    currentPath = i;
                    break;
                }

            if (pathList[currentPath].numberOfFiles > 0)
            {
                string[] dirElems = Directory.GetFiles(pathList[currentPath].path);

                if (pathList[currentPath].currentNumber == 1)
                {
                    CurrentImage.ImageLocation = dirElems[0];
                    CurrentImage.Visible = true;
                    ButtonLeft.Visible = true;
                    ButtonLeft.Enabled = false;
                    ButtonRight.Visible = true;
                    ImageIndex.Visible = true;
                    ImageIndex.Text = pathList[currentPath].currentNumber.ToString();
                    if (pathList[currentPath].numberOfFiles == 1)
                        ButtonRight.Enabled = false;
                    else
                        ButtonRight.Enabled = true;
                }
                else if (pathList[currentPath].currentNumber == pathList[currentPath].numberOfFiles)
                {
                    CurrentImage.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
                    CurrentImage.Visible = true;
                    ButtonLeft.Visible = true;
                    ButtonLeft.Enabled = true;
                    ButtonRight.Visible = true;
                    ButtonRight.Enabled = false;
                    ImageIndex.Visible = true;
                    ImageIndex.Text = pathList[currentPath].currentNumber.ToString();
                }
                else
                {
                    CurrentImage.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
                    CurrentImage.Visible = true;
                    ButtonLeft.Visible = true;
                    ButtonLeft.Enabled = true;
                    ButtonRight.Visible = true;
                    ButtonRight.Enabled = true;
                    ImageIndex.Visible = true;
                    ImageIndex.Text = pathList[currentPath].currentNumber.ToString();
                }
            }
            else
            {
                ButtonLeft.Visible = false;
                ButtonRight.Visible = false;
                ImageIndex.Visible = false;
                CurrentImage.Visible = false;
            }
        }
    }

    public class help
    {
        public int numberOfFiles;
        public int currentNumber;
        public string path;

        public help(int nof, int cn, string pth)
        {
            numberOfFiles = nof;
            currentNumber = cn;
            path = pth;
        }
    }

}
