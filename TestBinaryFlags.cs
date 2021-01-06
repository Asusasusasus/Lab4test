using IIG.BinaryFlag;
using IIG.CoSFE.DatabaseUtils;
using Xunit;

namespace lab4
{
    public class BinaryFlagTests
    {
        private const string Server = @"DESKTOP-S4984VN\SQLSERVER";
        private const string Database = @"IIG.CoSWE.FlagpoleDB";
        private const bool IsTrusted = true;
        private const string Login = @"coswe";
        private const string Password = @"L}EjpfCgru9X@GLj";
        private const int ConnectionTime = 20;

        FlagpoleDatabaseUtils flagpoleDatabaseUtils = new FlagpoleDatabaseUtils(Server, Database, IsTrusted, Login, Password, ConnectionTime);

        // Testing ADD

        [Fact]
        public void AddTrueFlagTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(2, true);
            Assert.False(flagpoleDatabaseUtils.AddFlag("T", flag.GetFlag()));

        }

        [Fact]
        public void AddTrueFlagWithLogicalErrorTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(2, true);
            Assert.False(flagpoleDatabaseUtils.AddFlag("F", flag.GetFlag()));
        }

        [Fact]
        public void AddFalseFlagTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(3, false);
            Assert.False(flagpoleDatabaseUtils.AddFlag("F", flag.GetFlag()));

        }

        [Fact]
        public void AddFalseFlagWithLogicalErrorTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(4, false);
            Assert.False(flagpoleDatabaseUtils.AddFlag("T", flag.GetFlag()));
        }

        // Testing GET

        [Fact]
        public void GetFlagTest()
        {

            MultipleBinaryFlag flag = new MultipleBinaryFlag(5, true);
            string view = "T";
            bool flagValue = flag.GetFlag();
            string viewFromDB;
            bool? flagValueFromDB;
            flagpoleDatabaseUtils.AddFlag(view, flagValue);

            Assert.False(flagpoleDatabaseUtils.GetFlag(5, out viewFromDB, out flagValueFromDB));
            Assert.NotEqual(view, viewFromDB);
            Assert.NotEqual(flagValue, flagValueFromDB);
        }

        [Fact]
        public void GetFlagByWrongIdTest()
        {
            Assert.False(flagpoleDatabaseUtils.GetFlag(10, out _, out _));
        }
    }
}


