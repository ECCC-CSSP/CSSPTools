using System.Text;
using System.Threading.Tasks;

namespace WebAPIClassNameControllerTestGeneratedServices.Services
{
    public partial class WebAPIClassNameControllerTestGeneratedService : IWebAPIClassNameControllerTestGeneratedService
    {
        private async Task<bool> GenerateControllersCRUDGoodTest(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        [Theory]");
            sb.AppendLine(@"        [InlineData(""en-CA"")]");
            sb.AppendLine(@"        [InlineData(""fr-CA"")]");
            sb.AppendLine($@"        public async Task { TypeName }Controller_CRUD_Good_Test(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            bool retBool = await Setup(new CultureInfo(culture));");
            sb.AppendLine(@"            Assert.True(retBool);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            using (TransactionScope ts = new TransactionScope())");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                // testing Get");
            sb.AppendLine($@"               var action{ TypeName }List = await { TypeNameLower }Controller.Get();");
            sb.AppendLine($@"               Assert.Equal(200, ((ObjectResult)action{ TypeName }List.Result).StatusCode);");
            sb.AppendLine($@"               Assert.NotNull(((OkObjectResult)action{ TypeName }List.Result).Value);");
            sb.AppendLine($@"               List<{ TypeName }> { TypeNameLower }List = (List<{ TypeName }>)(((OkObjectResult)action{ TypeName }List.Result).Value);");
            sb.AppendLine(@"");
            sb.AppendLine($@"               int count = ((List<{ TypeName }>)((OkObjectResult)action{ TypeName }List.Result).Value).Count();");
            sb.AppendLine(@"                Assert.True(count > 0);");
            sb.AppendLine(@"");
            sb.AppendLine($@"               // testing Get({ TypeName }ID)");
            sb.AppendLine($@"               var action{ TypeName } = await { TypeNameLower }Controller.Get({ TypeNameLower }List[0].{ TypeName }ID);");
            sb.AppendLine($@"               Assert.Equal(200, ((ObjectResult)action{ TypeName }.Result).StatusCode);");
            sb.AppendLine($@"               Assert.NotNull(((OkObjectResult)action{ TypeName }.Result).Value);");
            sb.AppendLine($@"               { TypeName } { TypeNameLower } = ({ TypeName })(((OkObjectResult)action{ TypeName }.Result).Value);");
            sb.AppendLine($@"               Assert.NotNull({ TypeNameLower });");
            sb.AppendLine($@"               Assert.Equal({ TypeNameLower }List[0].{ TypeName }ID, { TypeNameLower }.{ TypeName }ID);");
            sb.AppendLine(@"");
            if (TypeName == "MWQMLookupMPN")
            {
                sb.AppendLine($@"               // testing Delete({ TypeName } { TypeNameLower })");
                sb.AppendLine($@"               var action{ TypeName }Delete = await { TypeNameLower }Controller.Delete({ TypeNameLower });");
                sb.AppendLine($@"               Assert.Equal(200, ((ObjectResult)action{ TypeName }Delete.Result).StatusCode);");
                sb.AppendLine($@"               Assert.NotNull(((OkObjectResult)action{ TypeName }Delete.Result).Value);");
                sb.AppendLine($@"               { TypeName } { TypeNameLower }Delete = ({ TypeName })(((OkObjectResult)action{ TypeName }Delete.Result).Value);");
                sb.AppendLine($@"               Assert.NotNull({ TypeNameLower }Delete);");
                sb.AppendLine(@"");
            }
            sb.AppendLine($@"               // testing Post({ TypeName } { TypeNameLower })");
            sb.AppendLine($@"               { TypeNameLower }.{ TypeName }ID = 0;");
            if (TypeName == "SamplingPlan")
            {
                sb.AppendLine($@"               samplingPlan.SamplingPlanName = samplingPlan.SamplingPlanName.Replace(samplingPlan.Year.ToString(), (samplingPlan.Year + 20).ToString());");
            }
            if (TypeName == "TVItem")
            {
                sb.AppendLine($@"               tvItem.ParentID = tvItemList[1].ParentID;");
                sb.AppendLine($@"               tvItem.TVLevel = 1; ");
                sb.AppendLine($@"               tvItem.TVPath = ""Timbucto"";");
                sb.AppendLine($@"               tvItem.TVType = TVTypeEnum.Country;");
            }
            sb.AppendLine($@"               var action{ TypeName }New = await { TypeNameLower }Controller.Post({ TypeNameLower });");
            sb.AppendLine($@"               Assert.Equal(200, ((ObjectResult)action{ TypeName }New.Result).StatusCode);");
            sb.AppendLine($@"               Assert.NotNull(((OkObjectResult)action{ TypeName }New.Result).Value);");
            sb.AppendLine($@"               { TypeName } { TypeNameLower }New = ({ TypeName })(((OkObjectResult)action{ TypeName }New.Result).Value);");
            sb.AppendLine($@"               Assert.NotNull({ TypeNameLower }New);");
            sb.AppendLine(@"");
            sb.AppendLine($@"               // testing Put({ TypeName } { TypeNameLower })");
            sb.AppendLine($@"               var action{ TypeName }Update = await { TypeNameLower }Controller.Put({ TypeNameLower }New);");
            sb.AppendLine($@"               Assert.Equal(200, ((ObjectResult)action{ TypeName }Update.Result).StatusCode);");
            sb.AppendLine($@"               Assert.NotNull(((OkObjectResult)action{ TypeName }Update.Result).Value);");
            sb.AppendLine($@"               { TypeName } { TypeNameLower }Update = ({ TypeName })(((OkObjectResult)action{ TypeName }Update.Result).Value);");
            sb.AppendLine($@"               Assert.NotNull({ TypeNameLower }Update);");
            sb.AppendLine(@"");
            if (!(TypeName == "MWQMLookupMPN"))
            {
                sb.AppendLine($@"               // testing Delete({ TypeName } { TypeNameLower })");
                sb.AppendLine($@"               var action{ TypeName }Delete = await { TypeNameLower }Controller.Delete({ TypeNameLower }Update);");
                sb.AppendLine($@"               Assert.Equal(200, ((ObjectResult)action{ TypeName }Delete.Result).StatusCode);");
                sb.AppendLine($@"               Assert.NotNull(((OkObjectResult)action{ TypeName }Delete.Result).Value);");
                sb.AppendLine($@"               { TypeName } { TypeNameLower }Delete = ({ TypeName })(((OkObjectResult)action{ TypeName }Delete.Result).Value);");
                sb.AppendLine($@"               Assert.NotNull({ TypeNameLower }Delete);");
            }
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
