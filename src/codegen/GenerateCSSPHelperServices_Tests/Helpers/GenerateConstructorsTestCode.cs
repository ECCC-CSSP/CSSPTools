using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> GenerateConstructorsTestCode(string TypeName, string TypeNameLower, Type type, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated Constructors");
            sb.AppendLine(@"        [Theory]");
            sb.AppendLine(@"        [InlineData(""en-CA"")]");
            sb.AppendLine(@"        //[InlineData(""fr-CA"")]");
            sb.AppendLine(@"        public async Task AppTaskParameter_Constructor_Test(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Assert.True(await Setup(culture));");
            sb.AppendLine(@"            Assert.NotNull(CSSPCultureService);");
            sb.AppendLine(@"            Assert.NotNull(enums);");
            sb.AppendLine(@"        }");

            sb.AppendLine(@"        #endregion Tests Generated Constructors");
            sb.AppendLine(@"");


            return await Task.FromResult(true);
        }
    }
}
