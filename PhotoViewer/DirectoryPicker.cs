using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void OkClick(object sender, MouseEventArgs e)
		{
			if (!ValidateChildren()) return;
			var form = Owner as MainWindow;

			var dir = new DirectoryInfo(DirectoryPath.Text);

			if (!form.PathList.Any(c => c.Path == DirectoryPath.Text))
			{
				form.PathList.Add(new DirectoryContent(dir.GetFiles().Length, 1, DirectoryPath.Text));
			}

			form.SelectedPathIndex = form.PathList.Count - 1;

			var shortPath = form.PathList[form.SelectedPathIndex].Path.Substring(form.PathList[form.SelectedPathIndex].Path.LastIndexOf("\\") + 1);
			if (shortPath == "")
				shortPath = form.PathList[form.SelectedPathIndex].Path;

			var lvi = new ListViewItem(new[] { shortPath, form.PathList[form.SelectedPathIndex].FileCount.ToString() })
			{
				ImageIndex = 0,
				StateImageIndex = 0
			};
			form.HistoryList.Items.Add(lvi);

			if (IncludeSubDirectories.Checked)
			{
				AddSubdirectories(DirectoryPath.Text);
				CreateTreeForPath(form.TreeView, form.PathList[form.SelectedPathIndex].Path, true);

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
			else CreateTreeForPath(form.TreeView, form.PathList[form.SelectedPathIndex].Path, false);

			form.SelectedPathIndex = form.PathList.Count - 1;

			var dirElems = Directory.GetFiles(form.PathList[form.SelectedPathIndex].Path);
			if (form.PathList[form.SelectedPathIndex].FileCount > 0)
				form.CurrentImage.ImageLocation = dirElems[0];

			DialogResult = DialogResult.OK;
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

		private void AddSubdirectories(string path)
		{
			var form = Owner as MainWindow;
			var folders = new Dictionary<string, DirectoryInfo>();
			var foldersToAdd = new List<string> { path };

			while (foldersToAdd.Any())
			{
				var rootFolder = foldersToAdd.First();
				foldersToAdd.RemoveAt(0);
				string[] childFolders = { };

				try
				{
					childFolders = Directory.GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly);
				}
				catch (UnauthorizedAccessException) { }

				if (!childFolders.Any()) continue;
				foldersToAdd.AddRange(childFolders);

				foreach (var folder in childFolders)
					folders.Add(folder, new DirectoryInfo(folder));
			}

			foreach (var folder in folders)
			{
				if (form.PathList.Any(p => p.Path == folder.Key)) continue;
				form.PathList.Add(new DirectoryContent(folder.Value.GetFiles().Length, 1, folder.Key));
			}
		}

		private static void CreateTreeForPath(TreeView tree, string path, bool includeSubdirectories)
		{
			var paths = path.Split('\\');
			var rootExists = false;

			foreach (TreeNode node in tree.Nodes)
			{
				if (node.Text != paths[0]) continue;
				rootExists = true;
				break;
			}

			if (!rootExists) tree.Nodes.Add(paths[0]);

			var foldersToAdd = new List<string> { path };

			while (foldersToAdd.Any())
			{
				var rootFolder = foldersToAdd.First();
				foldersToAdd.RemoveAt(0);
				var parentNode = FindParentNode(tree, rootFolder);

				if (includeSubdirectories)
				{
					try
					{
						var availableFolders = Directory.GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly);
						foldersToAdd.AddRange(availableFolders);
					}
					catch (UnauthorizedAccessException) { /* ignored*/ }
				}

				CreateTreeNode(rootFolder, parentNode);
			}

			tree.ExpandAll();
		}

		private static void CreateTreeNode(string rootFolder, TreeNode parentNode)
		{
			var parentFolders = rootFolder.Split('\\').ToList();
			parentFolders = parentFolders.Skip(parentFolders.IndexOf(parentFolders.Single(f => f == parentNode.Text)) + 1).ToList();

			foreach (var folder in parentFolders)
			{
				var isTargetNode = folder == parentFolders.Last();
				if (isTargetNode)
				{
					var exists = false;
					TreeNode foundNode = null;
					foreach (TreeNode node in parentNode.Nodes)
					{
						if (node.Text != folder) continue;
						exists = true;
						foundNode = node;
					}

					if (exists)
					{
						foundNode.ImageIndex = 1;
						continue;
					}
				}

				var newNode = parentNode.Nodes.Add(folder);
				newNode.ImageIndex = isTargetNode ? 1 : 0;
				parentNode = newNode;
			}
		}

		private static TreeNode FindParentNode(TreeView tree, string folder)
		{
			var folders = folder.Split('\\');
			var parentPathFolders = folders.Take(folders.Length - 1);
			TreeNode parentNode = null;

			foreach (TreeNode node in tree.Nodes)
			{
				if (node.Text != folders[0]) continue;
				parentNode = node;
				break;
			}

			foreach (var parent in parentPathFolders)
			{
				foreach (TreeNode node in parentNode.Nodes)
				{
					if (node.Text != parent) continue;
					parentNode = node;
					break;
				}
			}

			return parentNode;
		}
	}
}
