using IIG.FileWorker;
using Xunit;

namespace lab4
{
    public class TestFileWorker
    {

		//READ

		[Fact]
		public void ReadAllWithoutPathTest()
		{
			Assert.Null(BaseFileWorker.ReadAll(""));
		}

		[Fact]
		public void ReadAllWithWrongPathTest()
		{
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\test\\notTest.txt"));
		}

		[Fact]
		public void ReadWithoutFileNameExtensionTest()
		{
			Assert.Null(BaseFileWorker.ReadAll("C:\\test\\test1"));
		}
		[Fact]
		public void ReadAllFromFileTest()
		{
			Assert.Equal("somethingToRead", BaseFileWorker.ReadAll("C:\\test\\test1.txt"));
		}

		//WRITE

		[Fact]
		public void WriteWithoutPathTest()
		{
			Assert.False(BaseFileWorker.Write("test", ""));
		}

		[Fact]
		public void WriteWithoutFileNameExtensionTest()
		{
			Assert.True(BaseFileWorker.Write("test", "C:\\test\\test3"));
		}

		[Fact]
		public void WriteToNotExistingFileTest()
		{
			Assert.True(BaseFileWorker.Write("test", "C:\\test\\nonexistingTest.txt"));
		}

		[Fact]
		public void WriteToExistingFileTest()
		{
			Assert.True(BaseFileWorker.Write("text", "C:\\test\\test2.txt"));
			Assert.Equal("text", BaseFileWorker.ReadAll("C:\\test\\test2.txt"));
		}
	}
}