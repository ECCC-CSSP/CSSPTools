using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBLocalServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> GenerateDoCRUDTest(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine($@"        private async Task DoCRUDDBTest()");
            sb.AppendLine(@"        {");
            sb.AppendLine($@"            dbLocal.Database.BeginTransaction();");
            sb.AppendLine($@"            // Post { TypeName }");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            var action{ TypeName }Added = await { TypeName }DBService.Post({ TypeNameLower }, AddContactTypeEnum.Register);");
            }
            else
            {
                sb.AppendLine($@"            var action{ TypeName }Added = await { TypeName }DBService.Post({ TypeNameLower });");
            }
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Added.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Added.Result).Value);");
            sb.AppendLine($@"            { TypeName } { TypeNameLower }Added = ({ TypeName })((OkObjectResult)action{ TypeName }Added.Result).Value;");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Added);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            // List<{ TypeName }>");
            sb.AppendLine($@"            var action{ TypeName }List = await { TypeName }DBService.Get{ TypeName }List();");
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }List.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }List.Result).Value);");
            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (List<{ TypeName }>)((OkObjectResult)action{ TypeName }List.Result).Value;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            int count = ((List<{ TypeName }>)((OkObjectResult)action{ TypeName }List.Result).Value).Count();");
            sb.AppendLine(@"            Assert.True(count > 0);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            // List<{ TypeName }> with skip and take");
            sb.AppendLine($@"            var action{ TypeName }ListSkipAndTake = await { TypeName }DBService.Get{ TypeName }List(1, 1);");
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }ListSkipAndTake.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }ListSkipAndTake.Result).Value);");
            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }ListSkipAndTake = (List<{ TypeName }>)((OkObjectResult)action{ TypeName }ListSkipAndTake.Result).Value;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            int countSkipAndTake = ((List<{ TypeName }>)((OkObjectResult)action{ TypeName }ListSkipAndTake.Result).Value).Count();");
            sb.AppendLine(@"            Assert.True(countSkipAndTake == 1);");
            sb.AppendLine(@"");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"            Assert.False({ TypeNameLower }List[0].Id == { TypeNameLower }ListSkipAndTake[0].Id);");
            }
            else
            {
                sb.AppendLine($@"            Assert.False({ TypeNameLower }List[0].{ TypeName.Replace("Local", "") }ID == { TypeNameLower }ListSkipAndTake[0].{ TypeName.Replace("Local", "") }ID);");
            }
            sb.AppendLine(@"");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"            // Get { TypeName } With Id");
                sb.AppendLine($@"            var action{ TypeName }Get = await { TypeName }DBService.Get{ TypeName }WithId({ TypeNameLower }List[0].Id);");
            }
            else
            {
                sb.AppendLine($@"            // Get { TypeName } With { TypeName.Replace("Local", "") }ID");
                sb.AppendLine($@"            var action{ TypeName }Get = await { TypeName }DBService.Get{ TypeName }With{ TypeName.Replace("Local", "") }ID({ TypeNameLower }List[0].{ TypeName.Replace("Local", "") }ID);");
            }
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Get.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Get.Result).Value);");
            sb.AppendLine($@"            { TypeName } { TypeNameLower }Get = ({ TypeName })((OkObjectResult)action{ TypeName }Get.Result).Value;");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Get);");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"            Assert.Equal({ TypeNameLower }Get.Id, { TypeNameLower }List[0].Id);");
            }
            else
            {
                sb.AppendLine($@"            Assert.Equal({ TypeNameLower }Get.{ TypeName.Replace("Local", "") }ID, { TypeNameLower }List[0].{ TypeName.Replace("Local", "") }ID);");
            }
            sb.AppendLine(@"");
            sb.AppendLine($@"            // Put { TypeName }");
            sb.AppendLine($@"            var action{ TypeName }Updated = await { TypeName }DBService.Put({ TypeNameLower });");
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Updated.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Updated.Result).Value);");
            sb.AppendLine($@"            { TypeName } { TypeNameLower }Updated = ({ TypeName })((OkObjectResult)action{ TypeName }Updated.Result).Value;");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Updated);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            // Delete { TypeName }");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"            var action{ TypeName }Deleted = await { TypeName }DBService.Delete({ TypeNameLower }.Id);");
            }
            else
            {
                sb.AppendLine($@"            var action{ TypeName }Deleted = await { TypeName }DBService.Delete({ TypeNameLower }.{ TypeName.Replace("Local", "") }ID);");
            }
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Deleted.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Deleted.Result).Value);");
            sb.AppendLine($@"            bool retBool = (bool)((OkObjectResult)action{ TypeName }Deleted.Result).Value;");
            sb.AppendLine($@"            Assert.True(retBool);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            dbLocal.Database.RollbackTransaction();");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
