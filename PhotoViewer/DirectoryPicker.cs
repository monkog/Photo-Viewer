using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using PhotoViewer.Properties;

namespace PhotoViewer
{
    public partial class DirectoryPicker : Form
    {
        public DirectoryPicker()
        {
            InitializeComponent();
        }

        private void BrowseClick(object sender, MouseEventArgs e)
        {
	        using (var folderBrowserDialog = new FolderBrowserDialog())
	        {
		        folderBrowserDialog.ShowDialog();
		        if (string.IsNullOrEmpty(folderBrowserDialog.SelectedPath)) return;
				
		        DirectoryPath.Text = folderBrowserDialog.SelectedPath;
	        }
        }

        private void CloseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void OkClick(object sender, MouseEventArgs e)
        {
	        if (!ValidateChildren()) return;
	        var form = Owner as MainWindow;
	        var dir = new DirectoryInfo(DirectoryPath.Text);
	        form.PathList.Add(new DirectoryContent(dir.GetFiles().Length, 1, DirectoryPath.Text));
	        form.SelectedPathIndex = form.PathList.Count - 1;

	        var shortPath = form.PathList[form.SelectedPathIndex].Path.Substring(form.PathList[form.SelectedPathIndex].Path.LastIndexOf("\\") + 1);
	        if (shortPath == "")
		        shortPath = form.PathList[form.SelectedPathIndex].Path;

	        var lvi = new ListViewItem(new[] {shortPath, form.PathList[form.SelectedPathIndex].FileCount.ToString()})
	        {
		        ImageIndex = 0, StateImageIndex = 0
	        };
	        form.HistoryList.Items.Add(lvi);

	        if (IncludeSubDirectories.Checked)
	        {
		        AddItem(DirectoryPath.Text);
		        AddNode(form.PathList[form.SelectedPathIndex].Path, true);

		        for (var i = form.SelectedPathIndex + 1; i < form.PathList.Count; i++)
		        {
			        shortPath = form.PathList[i].Path.Substring(form.PathList[i].Path.LastIndexOf("\\") + 1);
			        if (shortPath == "")
				        shortPath = form.PathList[i].Path;

			        lvi = new ListViewItem(new[] { shortPath, form.PathList[i].FileCount.ToString() });
			        form.HistoryList.Items.Add(lvi);
			        lvi.ImageIndex = 0;
			        lvi.StateImageIndex = 0;
		        }
	        }
	        else
		        AddNode(form.PathList[form.SelectedPathIndex].Path, false);

	        form.SelectedPathIndex = form.PathList.Count - 1;

	        var dirElems = Directory.GetFiles(form.PathList[form.SelectedPathIndex].Path);
	        if (form.PathList[form.SelectedPathIndex].FileCount > 0)
		        form.CurrentImage.ImageLocation = dirElems[0];

	        if (form.PathList[form.PathList.Count - 1].FileCount != 0)
	        {
		        form.SelectedPathIndex = form.PathList.Count - 1;
		        form.CurrentImage.Visible = true;
		        form.ButtonLeft.Visible = true;
		        form.ButtonLeft.Enabled = false;
		        form.ButtonRight.Visible = true;
		        form.ImageIndex.Visible = true;
		        form.ImageIndex.Text = form.PathList[form.SelectedPathIndex].CurrentIndex.ToString();
		        form.ButtonRight.Enabled = form.PathList[form.SelectedPathIndex].FileCount != 1;
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

        private void PathValidating(object sender, CancelEventArgs e)
        {
            if (DirectoryPath.Text.Length == 0)
            {
                errorProvider.SetError(DirectoryPath, Resources.ProvideDirectoryPath);
                e.Cancel = true;
                return;
            }

            errorProvider.Clear();
            e.Cancel = false;
        }

        private void AddItem(string path)
        {
            try
            {
                var form = Owner as MainWindow;
                var folders = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);

                if (folders.Length == 0) return;
                var dirs = new DirectoryInfo[folders.Length];

                for (var i = 0; i < folders.Length; i++)
                {
	                dirs[i] = new DirectoryInfo(folders[i]);
	                AddItem(dirs[i].ToString());
                }

                for (var i = 0; i < folders.Length; i++)
	                form.PathList.Add(new DirectoryContent(dirs[i].GetFiles().Length, 1, folders[i]));
            }
            catch (System.UnauthorizedAccessException) { }
        }

        private static void AddSubs(TreeNode node, string path)
        {
            var folders = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
            var shortFolders = new string[folders.Length];

            for (var i = 0; i < folders.Length; i++)
            {
                shortFolders[i] = folders[i].Substring(folders[i].LastIndexOf("\\") + 1);
                var exists = false;

                foreach (TreeNode tn in node.Nodes)
                    if (tn.Text == shortFolders[i])
                        exists = true;

                if (exists == false)
                    node.Nodes.Add(shortFolders[i]);
            }

            var j = 0;
            if (folders.Length != 0)
            {
                foreach (TreeNode tn in node.Nodes)
                {
                    tn.ImageIndex = 1;
                    tn.SelectedImageIndex = 1;
                    AddSubs(tn, folders[j++]);
                }
            }
            node.ExpandAll();
        }

        private void AddNode(string path, bool subdirectories)
        {
            var form = Owner as MainWindow;
            var paths = path.Split('\\');
            paths[0] = path.Substring(0, 3);

            if (subdirectories)
            {
                AddNode(path, false);

                TreeNode root = null;
                foreach (TreeNode tn in form.TreeView.Nodes)
                    if (tn.Text == paths[0])
                    {
                        root = tn;
                        break;
                    }

                var i = 0;
                while (root.Text != paths[paths.Length - 1])
                    foreach (TreeNode tn in root.Nodes)
                        if (tn.Text == paths[i++])
                            root = tn;

                AddSubs(root, path);
            }
            else
            {
                var exists = false;

                foreach (TreeNode node in form.TreeView.Nodes)
                {
	                if (node.Text != paths[0]) continue;
	                exists = true;
                    break;
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

                    var pathExists = true;
                    var i = 1;

                    for (i = 1; i < paths.Length && pathExists; i++)
                    {
                        pathExists = false;
                        foreach (TreeNode node in root.Nodes)
                            if (node.Text == paths[i])
                            {
                                root = node;
                                pathExists = true;
                            }
                    }

                    if (pathExists) return;
                    {
	                    i--;
	                    for (; i < paths.Length; i++)
	                    {
		                    var tn = new TreeNode(paths[i]);
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
                    var root = form.TreeView.Nodes.Add(paths[0]);
                    var defRoot = root;

                    for (var i = 1; i < paths.Length; i++)
                    {
                        var tn = new TreeNode(paths[i]);
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
    }
}
