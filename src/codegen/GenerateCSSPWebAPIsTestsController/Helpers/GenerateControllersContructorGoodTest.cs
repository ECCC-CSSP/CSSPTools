using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPWebAPIsTestsController
{
    public partial class Startup
    {
        private async Task<bool> GenerateControllersContructorGoodTest(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        [Theory]");
            sb.AppendLine(@"        [InlineData(""en-CA"")]");
            sb.AppendLine(@"        //[InlineData(""fr-CA"")]");
            sb.AppendLine($@"        public async Task { TypeName }Controller_Constructor_Good_Test(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Assert.True(await Setup(culture));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            Assert.NotNull(LoggedInService);");
            sb.AppendLine($@"            Assert.NotNull({ TypeName }DBService);");
            sb.AppendLine($@"            Assert.NotNull({ TypeName }Controller);");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
