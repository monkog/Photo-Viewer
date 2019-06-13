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

		public DirectoryContent(int fileCount, int currentIndex, string path)
		{
			FileCount = fileCount;
			CurrentIndex = currentIndex;
			Path = path;
		}
	}
}