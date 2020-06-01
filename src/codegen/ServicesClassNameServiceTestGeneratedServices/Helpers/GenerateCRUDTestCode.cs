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
            sb.AppendLine(@"        [InlineData(""fr-CA"")]");
            sb.AppendLine($@"        public async Task { TypeName }_CRUD_Good_Test(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"            // CRUD testing");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"            // -------------------------------");
            sb.AppendLine(@"");
            sb.AppendLine(@"            await Setup(new CultureInfo(culture));");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName } { TypeNameLower } = GetFilledRandom{ TypeName }(""""); ");
            sb.AppendLine(@"");
            sb.AppendLine($@"            // List<{ TypeName }>");
            sb.AppendLine($@"            var action{ TypeName }List = await { TypeNameLower }Service.Get{ TypeName }List();");
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }List.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }List.Result).Value);");
            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (List<{ TypeName }>)(((OkObjectResult)action{ TypeName }List.Result).Value);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            int count = ((List<{ TypeName }>)((OkObjectResult)action{ TypeName }List.Result).Value).Count();");
            sb.AppendLine(@"            Assert.True(count > 0);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            // Add { TypeName }");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            var action{ TypeName }Added = await { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.Register);");
            }
            else
            {
                sb.AppendLine($@"            var action{ TypeName }Added = await { TypeNameLower }Service.Add({ TypeNameLower });");
            }
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Added.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Added.Result).Value);");
            sb.AppendLine($@"            { TypeName } { TypeNameLower }Added = ({ TypeName })(((OkObjectResult)action{ TypeName }Added.Result).Value);");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Added);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            // Update { TypeName }");
            sb.AppendLine($@"            var action{ TypeName }Updated = await { TypeNameLower }Service.Update({ TypeNameLower });");
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Updated.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Updated.Result).Value);");
            sb.AppendLine($@"            { TypeName } { TypeNameLower }Updated = ({ TypeName })(((OkObjectResult)action{ TypeName }Updated.Result).Value);");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Updated);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            // Delete { TypeName }");
            sb.AppendLine($@"            var action{ TypeName }Deleted = await { TypeNameLower }Service.Delete({ TypeNameLower });");
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Deleted.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Deleted.Result).Value);");
            sb.AppendLine($@"            { TypeName } { TypeNameLower }Deleted = ({ TypeName })(((OkObjectResult)action{ TypeName }Deleted.Result).Value);");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Deleted);");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated CRUD");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
