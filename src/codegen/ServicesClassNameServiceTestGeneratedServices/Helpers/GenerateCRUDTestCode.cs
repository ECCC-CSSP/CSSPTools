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
            sb.AppendLine(@"        [InlineData(""en-CA"")]");
            sb.AppendLine(@"        //[InlineData(""fr-CA"")]");
            sb.AppendLine($@"        public async Task { TypeName }_CRUD_Good_Test(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Assert.True(await Setup(culture));");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine(@"");
            sb.AppendLine(@"            await DoCRUDTest();");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated CRUD");
            sb.AppendLine(@"");
            return await Task.FromResult(true);
        }
    }
}
