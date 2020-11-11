using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBLocalServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> GenerateBasicTestNotMapped(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated Basic Test Not Mapped");
            sb.AppendLine(@"        [Theory]");
            sb.AppendLine(@"        [InlineData(""en-CA"")]");
            sb.AppendLine(@"        [InlineData(""fr-CA"")]");
            sb.AppendLine($@"        public async Task { TypeName }Service_Good_Test(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Assert.True(await Setup(culture));");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine(@"");
            sb.AppendLine($@"            List<ValidationResult> ValidationResultsList = { TypeName }Service.Validate(new ValidationContext({ TypeNameLower })).ToList();");
            sb.AppendLine(@"            Assert.True(ValidationResultsList.Count == 0);");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated Basic Test Not Mapped");
            sb.AppendLine(@"");
            return await Task.FromResult(true);
        }
    }
}
