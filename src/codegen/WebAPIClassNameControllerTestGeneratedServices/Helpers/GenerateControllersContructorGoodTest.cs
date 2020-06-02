using System.Text;
using System.Threading.Tasks;

namespace WebAPIClassNameControllerTestGeneratedServices.Services
{
    public partial class WebAPIClassNameControllerTestGeneratedService : IWebAPIClassNameControllerTestGeneratedService
    {
        private async Task<bool> GenerateControllersContructorGoodTest(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        [Theory]");
            sb.AppendLine(@"        [InlineData(""en-CA"")]");
            sb.AppendLine(@"        [InlineData(""fr-CA"")]");
            sb.AppendLine($@"        public async Task { TypeName }Controller_Constructor_Good_Test(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            bool retBool = await Setup(new CultureInfo(culture));");
            sb.AppendLine(@"            Assert.True(retBool);");
            sb.AppendLine(@"            Assert.NotNull(loggedInService);");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Service);");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Controller);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
