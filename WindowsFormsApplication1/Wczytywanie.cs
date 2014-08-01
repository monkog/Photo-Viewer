using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Wczytywanie : Form
    {
        string prevPath = "";

        public Wczytywanie()
        {
            InitializeComponent();
        }

        private void buttonZamknij_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            if (textBox.Text.Length == 0)
            {
                errorProvider.SetError(textBox, "Podaj ścieżkę do katalogu");
                e.Cancel = true;
                return;
            }
            errorProvider.SetError(textBox, "");
            e.Cancel = false;
        }

        private void addItem(string path)
        {
            try
            {
                var form = this.Owner as przegladarkaForm;
                string[] folders = Directory.GetDirectories(path, "*", System.IO.SearchOption.TopDirectoryOnly);

                if (folders.Length != 0)
                {
                    System.IO.DirectoryInfo[] dirs = new System.IO.DirectoryInfo[folders.Length];

                    for (int i = 0; i < folders.Length; i++)
                    {
                        dirs[i] = new System.IO.DirectoryInfo(folders[i]);
                        addItem(dirs[i].ToString());
                    }

                    for (int i = 0; i < folders.Length; i++)
                        form.pathList.Add(new help(dirs[i].GetFiles().Length, 1, folders[i]));
                }
            }
            catch (System.UnauthorizedAccessException) { }
        }

        private void addSubs(TreeNode node, string path)
        {
            string[] folders = Directory.GetDirectories(path, "*", System.IO.SearchOption.TopDirectoryOnly);
            string[] shortFolders = new string[folders.Length];

            for (int i = 0; i < folders.Length; i++)
            {
                shortFolders[i] = folders[i].Substring(folders[i].LastIndexOf("\\") + 1);
                bool exists = false;

                foreach (TreeNode tn in node.Nodes)
                    if (tn.Text == shortFolders[i])
                        exists = true;

                if (exists == false)
                    node.Nodes.Add(shortFolders[i]);
            }

            int j = 0;
            if (folders.Length != 0)
            {
                foreach (TreeNode tn in node.Nodes)
                {
                    tn.ImageIndex = 1;
                    tn.SelectedImageIndex = 1;
                    addSubs(tn, folders[j++]);
                }
            }
            node.ExpandAll();
        }

        private void addNode(string path, bool subdirectories)
        {
            var form = this.Owner as przegladarkaForm;
            string[] paths = path.Split('\\');
            paths[0] = path.Substring(0, 3);

            if (subdirectories)
            {
                addNode(path, false);

                TreeNode root = null;
                foreach (TreeNode tn in form.treeView.Nodes)
                    if (tn.Text == paths[0])
                    {
                        root = tn;
                        break;
                    }

                int i = 0;
                while (root.Text != paths[paths.Length - 1])
                    foreach (TreeNode tn in root.Nodes)
                        if (tn.Text == paths[i++])
                            root = tn;

                addSubs(root, path);
            }
            else
            {
                bool exists = false;

                foreach (TreeNode node in form.treeView.Nodes)
                {
                    if (node.Text == paths[0])
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    TreeNode root = null;
                    foreach (TreeNode tn in form.treeView.Nodes)
                        if (tn.Text == paths[0])
                        {
                            root = tn;
                            break;
                        }

                    bool pathExists = true;
                    int i = 1;

                    for (i = 1; i < paths.Length && pathExists == true; i++)
                    {
                        pathExists = false;
                        foreach (TreeNode node in root.Nodes)
                            if (node.Text == paths[i])
                            {
                                root = node;
                                pathExists = true;
                            }
                    }

                    if (pathExists == false)
                    {
                        i--;
                        for (; i < paths.Length; i++)
                        {
                            TreeNode tn = new TreeNode(paths[i]);
                            root.Nodes.Add(tn);
                            root = tn;
                            root.Expand();
                            if (i != paths.Length - 1)
                            {
                                tn.ImageIndex = 0;
                                tn.SelectedImageIndex = 0;
                            }
                            else
                            {
                                tn.ImageIndex = 1;
                                tn.SelectedImageIndex = 1;
                            }
                        }
                    }
                }
                else
                {
                    TreeNode root = form.treeView.Nodes.Add(paths[0]);
                    TreeNode defRoot = root;

                    for (int i = 1; i < paths.Length; i++)
                    {
                        TreeNode tn = new TreeNode(paths[i]);
                        root.Nodes.Add(tn);
                        root = tn;
                        root.Expand();
                        if (i != paths.Length - 1)
                        {
                            tn.ImageIndex = 0;
                            tn.SelectedImageIndex = 0;
                        }
                        else
                        {
                            tn.ImageIndex = 1;
                            tn.SelectedImageIndex = 1;
                        }
                    }
                    defRoot.ExpandAll();
                }
            }
        }

        private void buttonOk_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ValidateChildren())
            {
                var form = this.Owner as przegladarkaForm;
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(prevPath);
                form.pathList.Add(new help(dir.GetFiles().Length, 1, prevPath));
                form.currentPath = form.pathList.Count - 1;

                string shortPath = form.pathList[form.currentPath].path.Substring(form.pathList[form.currentPath].path.LastIndexOf("\\") + 1);
                if (shortPath == "")
                    shortPath = form.pathList[form.currentPath].path;

                ListViewItem lvi = new ListViewItem(new[] { shortPath, form.pathList[form.currentPath].numberOfFiles.ToString() });
                lvi.ImageIndex = 0;
                lvi.StateImageIndex = 0;
                form.listViewHistoria.Items.Add(lvi);

                if (checkBox.Checked == true)
                {
                    addItem(prevPath);
                    addNode(form.pathList[form.currentPath].path, true);

                    for (int i = form.currentPath + 1; i < form.pathList.Count; i++)
                    {
                        shortPath = form.pathList[i].path.Substring(form.pathList[i].path.LastIndexOf("\\") + 1);
                        if (shortPath == "")
                            shortPath = form.pathList[i].path;

                        lvi = new ListViewItem(new[] { shortPath, form.pathList[i].numberOfFiles.ToString() });
                        form.listViewHistoria.Items.Add(lvi);
                        lvi.ImageIndex = 0;
                        lvi.StateImageIndex = 0;
                    }
                }
                else
                    addNode(form.pathList[form.currentPath].path, false);

                form.currentPath = form.pathList.Count - 1;

                string[] dirElems = Directory.GetFiles(form.pathList[form.currentPath].path);
                if (form.pathList[form.currentPath].numberOfFiles > 0)
                    form.pictureBox.ImageLocation = dirElems[0];

                if (form.pathList[form.pathList.Count - 1].numberOfFiles != 0)
                {
                    form.currentPath = form.pathList.Count - 1;
                    form.pictureBox.Visible = true;
                    form.buttonLeft.Visible = true;
                    form.buttonLeft.Enabled = false;
                    form.buttonRight.Visible = true;
                    form.labelNumber.Visible = true;
                    form.labelNumber.Text = form.pathList[form.currentPath].currentNumber.ToString();
                    if (form.pathList[form.currentPath].numberOfFiles == 1)
                        form.buttonRight.Enabled = false;
                    else
                        form.buttonRight.Enabled = true;
                }
                else
                {
                    form.buttonLeft.Visible = false;
                    form.buttonRight.Visible = false;
                    form.labelNumber.Visible = false;
                    form.pictureBox.Visible = false;
                }

                Close();
            }
        }

        private void buttonPrzegladaj_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "")
            {
                prevPath = fbd.SelectedPath;
                textBox.Text = fbd.SelectedPath;
            }
            else if (prevPath != "")
                textBox.Text = prevPath;
        }
    }
}
