//using System.Text;
//using System.Threading.Tasks;

//namespace GenerateCSSPHelperServices_Tests
//{
//    public partial class Startup
//    {
//        private async Task<bool> GenerateCRUDTestCode(string TypeName, string TypeNameLower, StringBuilder sb)
//        {
//            sb.AppendLine($@"        #region Tests Generated Constructor [DB]");
//            sb.AppendLine(@"        [Theory]");
//            sb.AppendLine(@"        [InlineData(""en-CA"")]");
//            sb.AppendLine(@"        //[InlineData(""fr-CA"")]");
//            sb.AppendLine($@"        public async Task { TypeName }DB_Constructor_Good_Test(string culture)");
//            sb.AppendLine(@"        {");
//            sb.AppendLine(@"            Assert.True(await Setup(culture));");
//            sb.AppendLine(@"        }");
//            sb.AppendLine($@"        #endregion Tests Generated Constructor [DB]");
//            sb.AppendLine(@"");
//            sb.AppendLine($@"        #region Tests Generated [DB] CRUD");
//            sb.AppendLine(@"        [Theory]");
//            sb.AppendLine(@"        [InlineData(""en-CA"")]");
//            sb.AppendLine(@"        //[InlineData(""fr-CA"")]");
//            sb.AppendLine($@"        public async Task { TypeName }DB_CRUD_Good_Test(string culture)");
//            sb.AppendLine(@"        {");
//            sb.AppendLine(@"            Assert.True(await Setup(culture));");
//            sb.AppendLine(@"");
//            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
//            sb.AppendLine(@"");
//            sb.AppendLine($@"            await DoCRUDDBTest();");
//            sb.AppendLine(@"        }");
//            sb.AppendLine($@"        #endregion Tests Generated [DB] CRUD");
//            sb.AppendLine(@"");
//            return await Task.FromResult(true);
//        }
//    }
//}
