using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace PhotoViewer
{
    public partial class DirectoryPicker : Form
    {
        string prevPath = "";

        public DirectoryPicker()
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
                var form = this.Owner as MainWindow;
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
                        form.pathList.Add(new DirectoryContent(dirs[i].GetFiles().Length, 1, folders[i]));
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
            var form = this.Owner as MainWindow;
            string[] paths = path.Split('\\');
            paths[0] = path.Substring(0, 3);

            if (subdirectories)
            {
                addNode(path, false);

                TreeNode root = null;
                foreach (TreeNode tn in form.TreeView.Nodes)
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

                foreach (TreeNode node in form.TreeView.Nodes)
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
                    foreach (TreeNode tn in form.TreeView.Nodes)
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
                    TreeNode root = form.TreeView.Nodes.Add(paths[0]);
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
                var form = this.Owner as MainWindow;
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(prevPath);
                form.pathList.Add(new DirectoryContent(dir.GetFiles().Length, 1, prevPath));
                form.currentPath = form.pathList.Count - 1;

                string shortPath = form.pathList[form.currentPath].Path.Substring(form.pathList[form.currentPath].Path.LastIndexOf("\\") + 1);
                if (shortPath == "")
                    shortPath = form.pathList[form.currentPath].Path;

                ListViewItem lvi = new ListViewItem(new[] { shortPath, form.pathList[form.currentPath].FileCount.ToString() });
                lvi.ImageIndex = 0;
                lvi.StateImageIndex = 0;
                form.HistoryList.Items.Add(lvi);

                if (checkBox.Checked == true)
                {
                    addItem(prevPath);
                    addNode(form.pathList[form.currentPath].Path, true);

                    for (int i = form.currentPath + 1; i < form.pathList.Count; i++)
                    {
                        shortPath = form.pathList[i].Path.Substring(form.pathList[i].Path.LastIndexOf("\\") + 1);
                        if (shortPath == "")
                            shortPath = form.pathList[i].Path;

                        lvi = new ListViewItem(new[] { shortPath, form.pathList[i].FileCount.ToString() });
                        form.HistoryList.Items.Add(lvi);
                        lvi.ImageIndex = 0;
                        lvi.StateImageIndex = 0;
                    }
                }
                else
                    addNode(form.pathList[form.currentPath].Path, false);

                form.currentPath = form.pathList.Count - 1;

                string[] dirElems = Directory.GetFiles(form.pathList[form.currentPath].Path);
                if (form.pathList[form.currentPath].FileCount > 0)
                    form.CurrentImage.ImageLocation = dirElems[0];

                if (form.pathList[form.pathList.Count - 1].FileCount != 0)
                {
                    form.currentPath = form.pathList.Count - 1;
                    form.CurrentImage.Visible = true;
                    form.ButtonLeft.Visible = true;
                    form.ButtonLeft.Enabled = false;
                    form.ButtonRight.Visible = true;
                    form.ImageIndex.Visible = true;
                    form.ImageIndex.Text = form.pathList[form.currentPath].CurrentIndex.ToString();
                    if (form.pathList[form.currentPath].FileCount == 1)
                        form.ButtonRight.Enabled = false;
                    else
                        form.ButtonRight.Enabled = true;
                }
                else
                {
                    form.ButtonLeft.Visible = false;
                    form.ButtonRight.Visible = false;
                    form.ImageIndex.Visible = false;
                    form.CurrentImage.Visible = false;
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
