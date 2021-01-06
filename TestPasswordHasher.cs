using Xunit;
using IIG.FileWorker;
using IIG.PasswordHashingUtils;

namespace lab4
{
    public class TestPasswordHasher
    {

        [Fact]
        public void PasswordHashWriteToFiletest()
        {
            Assert.True(BaseFileWorker.Write(PasswordHasher.GetHash("password", "salt"), "C:\\test\\test.txt"));
        }

        [Fact]
        public void PasswordHashReadFromFileTest()
        {
            Assert.Equal("FF361BA585A54825FD5980AB02CFCFC53F3586BCF80A4CE6B1A1CBEB572690C4", BaseFileWorker.ReadAll("C:\\test\\test.txt"));
        }
    }
}