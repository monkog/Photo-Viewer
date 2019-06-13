using NUnit.Framework;
using PhotoViewer;

namespace PhotoViewerTests
{
	[TestFixture]
	public class DirectoryContentTests
	{
		[Test]
		public void Ctor_ProperParams_PropertiesInitialized()
		{
			const int fileCount = 5;
			const int currentIndex = 2;
			const string path = "xyz";
			
			var unitUnderTest = new DirectoryContent(fileCount, currentIndex, path);

			Assert.AreEqual(fileCount, unitUnderTest.FileCount);
			Assert.AreEqual(currentIndex, unitUnderTest.CurrentIndex);
			Assert.AreEqual(path, unitUnderTest.Path);
		}
	}
}
