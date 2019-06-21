using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PhotoViewer.Properties;

namespace PhotoViewer
{
	public partial class MainWindow : Form
	{
		public List<DirectoryContent> PathList;

		public int SelectedPathIndex = -1;

		public MainWindow()
		{
			InitializeComponent();
			PathList = new List<DirectoryContent>();
			HistoryList.SmallImageList = new ImageList();
			HistoryList.SmallImageList.Images.Add(Resources.imageDir);
		}

		private void BrowseClick(object sender, MouseEventArgs e)
		{
			var directoryPicker = new DirectoryPicker();
			var result = directoryPicker.ShowDialog();
			if (result == DialogResult.Cancel) return;

			var items = CreateDirectoryContentItems(directoryPicker.Directories).ToList();
			CreateListItems(items);
			CreateTreeItems(items);
			SelectedPathIndex = PathList.IndexOf(PathList.LastOrDefault(p => p.FileCount > 0));
			InitializeImageViewer();
		}

		private void HistoryCheckedChanged(object sender, EventArgs e)
		{
			var displayHistory = History.Checked;
			HistoryList.Enabled = displayHistory;
			HistoryList.Visible = displayHistory;
			TreeView.Enabled = !displayHistory;
			TreeView.Visible = !displayHistory;
		}

		private void ButtonLeftClick(object sender, MouseEventArgs e)
		{
			PathList[SelectedPathIndex].CurrentIndex--;
			ButtonLeft.Enabled = PathList[SelectedPathIndex].CurrentIndex > 1;
			ButtonRight.Enabled = true;

			UpdateImageAndIndex();
		}

		private void ButtonRightClick(object sender, MouseEventArgs e)
		{
			PathList[SelectedPathIndex].CurrentIndex++;
			ButtonLeft.Enabled = true;
			ButtonRight.Enabled = PathList[SelectedPathIndex].CurrentIndex != PathList[SelectedPathIndex].FileCount;

			UpdateImageAndIndex();
		}

		private void UpdateImageAndIndex()
		{
			ImageIndex.Text = PathList[SelectedPathIndex].CurrentIndex.ToString();
			var files = Directory.GetFiles(PathList[SelectedPathIndex].Path);
			CurrentImage.ImageLocation = files[PathList[SelectedPathIndex].CurrentIndex - 1];
		}

		private void CurrentImageDoubleClick(object sender, EventArgs e)
		{
			if (!CurrentImage.Visible) return;
			TransparentBackground image;

			if (CurrentImage.Image == CurrentImage.ErrorImage)
			{
				image = new TransparentBackground(CurrentImage.Image.Size.Width, CurrentImage.Image.Size.Height, Resources.question) { Owner = this };
			}
			else
			{
				var dirElems = Directory.GetFiles(PathList[SelectedPathIndex].Path);
				var imagePath = dirElems[PathList[SelectedPathIndex].CurrentIndex - 1];
				image = new TransparentBackground(CurrentImage.Image.Size.Width, CurrentImage.Image.Size.Height, imagePath) { Owner = this };
			}

			image.Show();
		}

		private void HistoryListClicked(object sender, EventArgs e)
		{
			SelectedPathIndex = HistoryList.SelectedIndices[0];
			InitializeImageViewer();
		}

		private void TreeItemSelected(object sender, TreeViewEventArgs e)
		{
			var path = e.Node.FullPath.Replace(@"\\", @"\");
			SelectedPathIndex = PathList.IndexOf(PathList.SingleOrDefault(p => p.Path == path));
			InitializeImageViewer();
		}

		private void InitializeImageViewer()
		{
			var hasFiles = SelectedPathIndex != -1 && PathList[SelectedPathIndex].FileCount > 0;

			CurrentImage.Visible = hasFiles;
			ButtonLeft.Visible = hasFiles;
			ButtonRight.Visible = hasFiles;
			ImageIndex.Visible = hasFiles;

			if (!hasFiles) return;

			var files = Directory.GetFiles(PathList[SelectedPathIndex].Path);
			CurrentImage.ImageLocation = files[PathList[SelectedPathIndex].CurrentIndex - 1];
			ImageIndex.Text = PathList[SelectedPathIndex].CurrentIndex.ToString();

			ButtonLeft.Enabled = PathList[SelectedPathIndex].CurrentIndex != 1;
			ButtonRight.Enabled = PathList[SelectedPathIndex].CurrentIndex != PathList[SelectedPathIndex].FileCount;
		}

		private IEnumerable<DirectoryContent> CreateDirectoryContentItems(Dictionary<string, DirectoryInfo> directories)
		{
			var createdItems = new List<DirectoryContent>();
			foreach (var folder in directories)
			{
				if (PathList.Any(p => p.Path == folder.Key)) continue;
				try
				{
					var item = new DirectoryContent(folder.Value.GetFiles().Length, 1, folder.Key);
					createdItems.Add(item);
					PathList.Add(item);
				}
				catch (UnauthorizedAccessException) { /* ignored */ }
			}

			return createdItems;
		}

		private void CreateListItems(IEnumerable<DirectoryContent> items)
		{
			foreach (var item in items)
			{
				var listViewItem = new ListViewItem(new[] { item.DirectoryName, item.FileCount.ToString() })
				{
					ImageIndex = 0,
					StateImageIndex = 0
				};

				HistoryList.Items.Add(listViewItem);
			}
		}

		private void CreateTreeItems(IEnumerable<DirectoryContent> items)
		{
			foreach (var directoryContent in items)
			{
				var paths = directoryContent.Path.Split('\\');
				var rootExists = false;

				foreach (TreeNode node in TreeView.Nodes)
				{
					if (node.Text != paths[0]) continue;
					rootExists = true;
					break;
				}

				if (!rootExists) TreeView.Nodes.Add(paths[0]);

				var parentNode = FindParentNode(directoryContent.Path);
				CreateTreeNode(directoryContent.Path, parentNode);
			}

			TreeView.ExpandAll();
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
						foundNode.SelectedImageIndex = 1;
						continue;
					}
				}

				var newNode = parentNode.Nodes.Add(folder);
				newNode.ImageIndex = isTargetNode ? 1 : 0;
				newNode.SelectedImageIndex = isTargetNode ? 1 : 0;
				parentNode = newNode;
			}
		}

		private TreeNode FindParentNode(string folder)
		{
			var folders = folder.Split('\\');
			var parentPathFolders = folders.Take(folders.Length - 1);
			TreeNode parentNode = null;

			foreach (TreeNode node in TreeView.Nodes)
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
