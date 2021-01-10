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

        [Fact]
        public void AddingFlagsTest()
        {
            MultipleBinaryFlag flag1 = new MultipleBinaryFlag(3, false);
            MultipleBinaryFlag flag2 = new MultipleBinaryFlag(3, true);
            MultipleBinaryFlag flag3 = new MultipleBinaryFlag(40, false);
            MultipleBinaryFlag flag4 = new MultipleBinaryFlag(40, true);
            MultipleBinaryFlag flag5 = new MultipleBinaryFlag(70, false);
            MultipleBinaryFlag flag6 = new MultipleBinaryFlag(70, true);

            Assert.False(flagpoleDatabaseUtils.AddFlag(flag1.ToString(), flag1.GetFlag()));
            Assert.False(flagpoleDatabaseUtils.AddFlag(flag2.ToString(), flag2.GetFlag()));
            Assert.False(flagpoleDatabaseUtils.AddFlag(flag3.ToString(), flag3.GetFlag()));
            Assert.False(flagpoleDatabaseUtils.AddFlag(flag4.ToString(), flag4.GetFlag()));
            Assert.False(flagpoleDatabaseUtils.AddFlag(flag5.ToString(), flag5.GetFlag()));
            Assert.False(flagpoleDatabaseUtils.AddFlag(flag6.ToString(), flag6.GetFlag()));
        }

        [Fact]
        public void AddFlagsManuallyTest()
        {
            Assert.False(flagpoleDatabaseUtils.AddFlag("TTT", true));
            Assert.False(flagpoleDatabaseUtils.AddFlag("FFFFF", false));
            Assert.False(flagpoleDatabaseUtils.AddFlag("TTTFFTTF", true));
        }

        [Fact]
        public void AddFlagWithBigNumberTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(999999999, false);
            Assert.False(flagpoleDatabaseUtils.AddFlag(flag.ToString(), flag.GetFlag()));
        }

        [Fact]
        public void AddGetFlagTest()
        {
            ResetIndex();

            MultipleBinaryFlag flag = new MultipleBinaryFlag(3);

            string resView;
            bool? resValue;

            flagpoleDatabaseUtils.AddFlag(flag.ToString(), true);

            flagpoleDatabaseUtils.GetFlag(1, out resView, out resValue);

            Assert.NotEqual(flag.ToString(), resView);
            Assert.NotEqual(flag.GetFlag(), resValue);           
        }

        [Fact]
        public void GetFlagByWrongIdTest()
        {
            Assert.False(flagpoleDatabaseUtils.GetFlag(1000, out _, out _));
        }

        private void ResetIndex()
        {
            flagpoleDatabaseUtils.ExecSql("DBCC CHECKIDENT('dbo.MultipleBinaryFlags', RESEED, 0)");
        }
    }
}


