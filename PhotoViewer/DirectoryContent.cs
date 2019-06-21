namespace PhotoViewer
{
	public class DirectoryContent
	{
		/// <summary>
		/// Gets the number of files.
		/// </summary>
		public int FileCount { get; }

		/// <summary>
		/// Gets the currently displayed file index.
		/// </summary>
		public int CurrentIndex { get; set; }

		/// <summary>
		/// Gets the directory path.
		/// </summary>
		public string Path { get; }

		/// <summary>
		/// Gets the directory name.
		/// </summary>
		public string DirectoryName { get; }

		public DirectoryContent(int fileCount, int currentIndex, string path)
		{
			FileCount = fileCount;
			CurrentIndex = currentIndex;
			Path = path;

			DirectoryName = path.Substring(Path.LastIndexOf("\\") + 1); ;
			if (DirectoryName == string.Empty) DirectoryName = Path;
		}
	}
}