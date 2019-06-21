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
		public Dictionary<string, DirectoryInfo> Directories = new Dictionary<string, DirectoryInfo>();

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

			Directories.Add(DirectoryPath.Text, new DirectoryInfo(DirectoryPath.Text));
			if (IncludeSubDirectories.Checked) AddSubdirectories(DirectoryPath.Text);

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
				catch (UnauthorizedAccessException) { /* ignored */ }

				if (!childFolders.Any()) continue;
				foldersToAdd.AddRange(childFolders);

				foreach (var folder in childFolders)
					Directories.Add(folder, new DirectoryInfo(folder));
			}
		}
	}
}
