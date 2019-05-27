using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PhotoViewer
{
    public partial class przegladarkaForm : Form
    {
        public List<help> pathList;
        public int currentPath = -1;

        public przegladarkaForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            pictureBox.Visible = false;
            radioHistoria.Checked = true;
            pathList = new List<help>();
            listViewHistoria.SmallImageList = new ImageList();
            listViewHistoria.SmallImageList.Images.Add(Properties.Resources.imageDir);
        }

        private void buttonWczytaj_MouseClick(object sender, MouseEventArgs e)
        {
            Wczytywanie wczytaj = new Wczytywanie();
            wczytaj.Owner = this;
            wczytaj.MinimizeBox = false;
            wczytaj.MaximizeBox = false;
            wczytaj.ShowInTaskbar = false;
            wczytaj.ShowDialog();
        }

        private void buttonLeft_MouseClick(object sender, MouseEventArgs e)
        {
            if (pathList[currentPath].currentNumber > 1)
            {
                pathList[currentPath].currentNumber--;
                labelNumber.Text = pathList[currentPath].currentNumber.ToString();
                if (pathList[currentPath].currentNumber == 1)
                    buttonLeft.Enabled = false;
                if (buttonRight.Enabled == false)
                    buttonRight.Enabled = true;

                string[] dirElems = Directory.GetFiles(pathList[currentPath].path);
                pictureBox.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
            }
        }

        private void buttonRight_MouseClick(object sender, MouseEventArgs e)
        {
            pathList[currentPath].currentNumber++;
            labelNumber.Text = pathList[currentPath].currentNumber.ToString();
            if (buttonLeft.Enabled == false)
                buttonLeft.Enabled = true;
            if (pathList[currentPath].currentNumber == pathList[currentPath].numberOfFiles)
                buttonRight.Enabled = false;

            string[] dirElems = Directory.GetFiles(pathList[currentPath].path);
            pictureBox.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
        }

        private void listViewHistoria_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.listViewHistoria.SelectedIndices;
            currentPath = indexes[0];

            if (pathList[currentPath].numberOfFiles > 0)
            {
                string[] dirElems = Directory.GetFiles(pathList[currentPath].path);

                if (pathList[currentPath].currentNumber == 1)
                {
                    pictureBox.ImageLocation = dirElems[0];
                    pictureBox.Visible = true;
                    buttonLeft.Visible = true;
                    buttonLeft.Enabled = false;
                    buttonRight.Visible = true;
                    labelNumber.Visible = true;
                    labelNumber.Text = pathList[currentPath].currentNumber.ToString();
                    if (pathList[currentPath].numberOfFiles == 1)
                        buttonRight.Enabled = false;
                    else
                        buttonRight.Enabled = true;
                }
                else if (pathList[currentPath].currentNumber == pathList[currentPath].numberOfFiles)
                {
                    pictureBox.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
                    pictureBox.Visible = true;
                    buttonLeft.Visible = true;
                    buttonLeft.Enabled = true;
                    buttonRight.Visible = true;
                    buttonRight.Enabled = false;
                    labelNumber.Visible = true;
                    labelNumber.Text = pathList[currentPath].currentNumber.ToString();
                }
                else
                {
                    pictureBox.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
                    pictureBox.Visible = true;
                    buttonLeft.Visible = true;
                    buttonLeft.Enabled = true;
                    buttonRight.Visible = true;
                    buttonRight.Enabled = true;
                    labelNumber.Visible = true;
                    labelNumber.Text = pathList[currentPath].currentNumber.ToString();
                }
            }
            else
            {
                buttonLeft.Visible = false;
                buttonRight.Visible = false;
                labelNumber.Visible = false;
                pictureBox.Visible = false;
            }
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (pictureBox.Visible == true)
            {
                Obraz obraz = new Obraz();
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

        private void radioHistoria_CheckedChanged(object sender, EventArgs e)
        {
            if (radioHistoria.Checked == true)
            {
                listViewHistoria.Enabled = true;
                listViewHistoria.Visible = true;
                treeView.Enabled = false;
                treeView.Visible = false;
            }
            else
            {
                listViewHistoria.Enabled = false;
                listViewHistoria.Visible = false;
                treeView.Enabled = true;
                treeView.Visible = true;
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
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
                    pictureBox.ImageLocation = dirElems[0];
                    pictureBox.Visible = true;
                    buttonLeft.Visible = true;
                    buttonLeft.Enabled = false;
                    buttonRight.Visible = true;
                    labelNumber.Visible = true;
                    labelNumber.Text = pathList[currentPath].currentNumber.ToString();
                    if (pathList[currentPath].numberOfFiles == 1)
                        buttonRight.Enabled = false;
                    else
                        buttonRight.Enabled = true;
                }
                else if (pathList[currentPath].currentNumber == pathList[currentPath].numberOfFiles)
                {
                    pictureBox.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
                    pictureBox.Visible = true;
                    buttonLeft.Visible = true;
                    buttonLeft.Enabled = true;
                    buttonRight.Visible = true;
                    buttonRight.Enabled = false;
                    labelNumber.Visible = true;
                    labelNumber.Text = pathList[currentPath].currentNumber.ToString();
                }
                else
                {
                    pictureBox.ImageLocation = dirElems[pathList[currentPath].currentNumber - 1];
                    pictureBox.Visible = true;
                    buttonLeft.Visible = true;
                    buttonLeft.Enabled = true;
                    buttonRight.Visible = true;
                    buttonRight.Enabled = true;
                    labelNumber.Visible = true;
                    labelNumber.Text = pathList[currentPath].currentNumber.ToString();
                }
            }
            else
            {
                buttonLeft.Visible = false;
                buttonRight.Visible = false;
                labelNumber.Visible = false;
                pictureBox.Visible = false;
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
