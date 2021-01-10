using Xunit;
using IIG.FileWorker;
using IIG.PasswordHashingUtils;

namespace lab4
{
    public class TestPasswordHasher
    {

        [Fact]
        public void PasswordHashWriteToUnexistingFiletest()
        {
            Assert.True(BaseFileWorker.Write(PasswordHasher.GetHash("password", "salt"), "C:\\test\\Nonexist.txt"));
        }

        [Fact]
        public void PasswordHashWriteReadTest()
        {
            var hashString = PasswordHasher.GetHash("password", "salt");

            Assert.True(BaseFileWorker.Write(hashString, "C:\\test\\test.txt"));
            Assert.Equal(BaseFileWorker.ReadAll("C:\\test\\test.txt"), hashString);
        }

        [Fact]
        public void PasswordHashWriteReadNullSaltTest()
        {
            var hashString = PasswordHasher.GetHash("pass", null);

            Assert.True(BaseFileWorker.Write(hashString, "C:\\test\\test1.txt"));
            Assert.Equal(BaseFileWorker.ReadAll("C:\\test\\test1.txt"), hashString);
        }

        [Fact]
        public void PasswordHashWriteReadSpecialPassTest()
        {
            var hashString = PasswordHasher.GetHash("", "saltsalt");

            Assert.True(BaseFileWorker.Write(hashString, "C:\\test\\test2.txt"));
            Assert.Equal(BaseFileWorker.ReadAll("C:\\test\\test2.txt"), hashString);
        }
    }
}
