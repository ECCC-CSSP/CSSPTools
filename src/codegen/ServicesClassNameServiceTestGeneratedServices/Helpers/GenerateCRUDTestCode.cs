using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GenerateCRUDTestCode(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated CRUD");
            sb.AppendLine(@"        [Theory]");
            sb.AppendLine(@"        [InlineData(""en-CA"", DBLocationEnum.Local)]");
            sb.AppendLine(@"        [InlineData(""fr-CA"", DBLocationEnum.Local)]");
            sb.AppendLine(@"        [InlineData(""en-CA"", DBLocationEnum.Server)]");
            sb.AppendLine(@"        [InlineData(""fr-CA"", DBLocationEnum.Server)]");
            sb.AppendLine($@"        public async Task { TypeName }_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"            // CRUD testing");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Assert.True(await Setup(culture));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            LoggedInService.DBLocation = DBLocation;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (LoggedInService.DBLocation == DBLocationEnum.Local)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                await DoCRUDTest();");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            else");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                using (TransactionScope ts = new TransactionScope())");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    await DoCRUDTest();");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated CRUD");
            sb.AppendLine(@"");
            return await Task.FromResult(true);
        }
    }
}
