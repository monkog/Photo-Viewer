using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PhotoViewer.Properties;

namespace PhotoViewer
{
	public partial class MainWindow : Form
	{
		public List<DirectoryContent> PathList;
		public int CurrentPath = -1;

		public MainWindow()
		{
			InitializeComponent();
			CurrentImage.Visible = false;
			History.Checked = true;
			PathList = new List<DirectoryContent>();
			HistoryList.SmallImageList = new ImageList();
			HistoryList.SmallImageList.Images.Add(Resources.imageDir);
		}

		private void BrowseClick(object sender, MouseEventArgs e)
		{
			var directoryPicker = new DirectoryPicker { Owner = this };
			directoryPicker.ShowDialog();
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
			if (PathList[CurrentPath].CurrentIndex > 1)
			{
				PathList[CurrentPath].CurrentIndex--;
				ImageIndex.Text = PathList[CurrentPath].CurrentIndex.ToString();
				if (PathList[CurrentPath].CurrentIndex == 1)
					ButtonLeft.Enabled = false;
				if (ButtonRight.Enabled == false)
					ButtonRight.Enabled = true;

				string[] dirElems = Directory.GetFiles(PathList[CurrentPath].Path);
				CurrentImage.ImageLocation = dirElems[PathList[CurrentPath].CurrentIndex - 1];
			}
		}

		private void ButtonRightClick(object sender, MouseEventArgs e)
		{
			PathList[CurrentPath].CurrentIndex++;
			ImageIndex.Text = PathList[CurrentPath].CurrentIndex.ToString();
			if (ButtonLeft.Enabled == false)
				ButtonLeft.Enabled = true;
			if (PathList[CurrentPath].CurrentIndex == PathList[CurrentPath].FileCount)
				ButtonRight.Enabled = false;

			string[] dirElems = Directory.GetFiles(PathList[CurrentPath].Path);
			CurrentImage.ImageLocation = dirElems[PathList[CurrentPath].CurrentIndex - 1];
		}

		private void HistoryListClicked(object sender, EventArgs e)
		{
			ListView.SelectedIndexCollection indexes = HistoryList.SelectedIndices;
			CurrentPath = indexes[0];

			if (PathList[CurrentPath].FileCount > 0)
			{
				string[] dirElems = Directory.GetFiles(PathList[CurrentPath].Path);

				if (PathList[CurrentPath].CurrentIndex == 1)
				{
					CurrentImage.ImageLocation = dirElems[0];
					CurrentImage.Visible = true;
					ButtonLeft.Visible = true;
					ButtonLeft.Enabled = false;
					ButtonRight.Visible = true;
					ImageIndex.Visible = true;
					ImageIndex.Text = PathList[CurrentPath].CurrentIndex.ToString();
					if (PathList[CurrentPath].FileCount == 1)
						ButtonRight.Enabled = false;
					else
						ButtonRight.Enabled = true;
				}
				else if (PathList[CurrentPath].CurrentIndex == PathList[CurrentPath].FileCount)
				{
					CurrentImage.ImageLocation = dirElems[PathList[CurrentPath].CurrentIndex - 1];
					CurrentImage.Visible = true;
					ButtonLeft.Visible = true;
					ButtonLeft.Enabled = true;
					ButtonRight.Visible = true;
					ButtonRight.Enabled = false;
					ImageIndex.Visible = true;
					ImageIndex.Text = PathList[CurrentPath].CurrentIndex.ToString();
				}
				else
				{
					CurrentImage.ImageLocation = dirElems[PathList[CurrentPath].CurrentIndex - 1];
					CurrentImage.Visible = true;
					ButtonLeft.Visible = true;
					ButtonLeft.Enabled = true;
					ButtonRight.Visible = true;
					ButtonRight.Enabled = true;
					ImageIndex.Visible = true;
					ImageIndex.Text = PathList[CurrentPath].CurrentIndex.ToString();
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
			if (!CurrentImage.Visible) return;
			TransparentBackground image;

			if (CurrentImage.Image == CurrentImage.ErrorImage)
			{
				image = new TransparentBackground(CurrentImage.Image.Size.Width, CurrentImage.Image.Size.Height, Resources.question) { Owner = this };
			}
			else
			{
				var dirElems = Directory.GetFiles(PathList[CurrentPath].Path);
				var imagePath = dirElems[PathList[CurrentPath].CurrentIndex - 1];
				image = new TransparentBackground(CurrentImage.Image.Size.Width, CurrentImage.Image.Size.Height, imagePath) { Owner = this };
			}

			image.Show();
		}

		private void TreeItemSelected(object sender, TreeViewEventArgs e)
		{
			string path = e.Node.FullPath;
			path = path.Substring(0, 3) + path.Substring(4);

			for (int i = 0; i < PathList.Count; i++)
				if (PathList[i].Path == path)
				{
					CurrentPath = i;
					break;
				}

			if (PathList[CurrentPath].FileCount > 0)
			{
				string[] dirElems = Directory.GetFiles(PathList[CurrentPath].Path);

				if (PathList[CurrentPath].CurrentIndex == 1)
				{
					CurrentImage.ImageLocation = dirElems[0];
					CurrentImage.Visible = true;
					ButtonLeft.Visible = true;
					ButtonLeft.Enabled = false;
					ButtonRight.Visible = true;
					ImageIndex.Visible = true;
					ImageIndex.Text = PathList[CurrentPath].CurrentIndex.ToString();
					if (PathList[CurrentPath].FileCount == 1)
						ButtonRight.Enabled = false;
					else
						ButtonRight.Enabled = true;
				}
				else if (PathList[CurrentPath].CurrentIndex == PathList[CurrentPath].FileCount)
				{
					CurrentImage.ImageLocation = dirElems[PathList[CurrentPath].CurrentIndex - 1];
					CurrentImage.Visible = true;
					ButtonLeft.Visible = true;
					ButtonLeft.Enabled = true;
					ButtonRight.Visible = true;
					ButtonRight.Enabled = false;
					ImageIndex.Visible = true;
					ImageIndex.Text = PathList[CurrentPath].CurrentIndex.ToString();
				}
				else
				{
					CurrentImage.ImageLocation = dirElems[PathList[CurrentPath].CurrentIndex - 1];
					CurrentImage.Visible = true;
					ButtonLeft.Visible = true;
					ButtonLeft.Enabled = true;
					ButtonRight.Visible = true;
					ButtonRight.Enabled = true;
					ImageIndex.Visible = true;
					ImageIndex.Text = PathList[CurrentPath].CurrentIndex.ToString();
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
}
