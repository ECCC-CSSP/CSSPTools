﻿using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GenerateDoCRUDTest(string TypeName, string TypeNameLower, StringBuilder sb, string DBType)
        {
            string db = "";
            if (DBType == "DB")
            {
                db = "db";
            }
            if (DBType == "DBLocal")
            {
                db = "dbLocal";
            }
            if (DBType == "DBLocalIM")
            {
                db = "dbLocalIM";
            }
            sb.AppendLine($@"        private async Task DoCRUD{ DBType }Test()");
            sb.AppendLine(@"        {");
            if (DBType == "DB")
            {
                sb.AppendLine($@"            { db }.Database.BeginTransaction();");
            }
            if (DBType == "DBLocal")
            {
                sb.AppendLine($@"            { db }.Database.BeginTransaction();");
            }
            if (DBType == "DBLocalIM")
            {
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"            { TypeNameLower }.Id = ""slefjlsejflsiejflsejf"";");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine($@"            { TypeNameLower }.{ TypeName }ID = 10000000;");
                    sb.AppendLine(@"");
                }
            }
            sb.AppendLine($@"            // Post { TypeName }");
            if (TypeName == "Contact") 
            {                          
                sb.AppendLine($@"            var action{ TypeName }Added = await { TypeName }{ DBType }Service.Post({ TypeNameLower }, AddContactTypeEnum.Register);");
            }                          
            else                       
            {                          
                sb.AppendLine($@"            var action{ TypeName }Added = await { TypeName }{ DBType }Service.Post({ TypeNameLower });");
            }                          
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Added.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Added.Result).Value);");
            sb.AppendLine($@"            { TypeName } { TypeNameLower }Added = ({ TypeName })((OkObjectResult)action{ TypeName }Added.Result).Value;");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Added);");
            sb.AppendLine(@"");        
            sb.AppendLine($@"            // List<{ TypeName }>");
            sb.AppendLine($@"            var action{ TypeName }List = await { TypeName }{ DBType }Service.Get{ TypeName }List();");
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }List.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }List.Result).Value);");
            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (List<{ TypeName }>)((OkObjectResult)action{ TypeName }List.Result).Value;");
            sb.AppendLine(@"");        
            sb.AppendLine($@"            int count = ((List<{ TypeName }>)((OkObjectResult)action{ TypeName }List.Result).Value).Count();");
            sb.AppendLine(@"            Assert.True(count > 0);");
            if (DBType == "DB")
            {
                sb.AppendLine(@"");
                sb.AppendLine($@"            // List<{ TypeName }> with skip and take");
                sb.AppendLine($@"            var action{ TypeName }ListSkipAndTake = await { TypeName }{ DBType }Service.Get{ TypeName }List(1, 1);");
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
                    sb.AppendLine($@"            Assert.False({ TypeNameLower }List[0].{ TypeName }ID == { TypeNameLower }ListSkipAndTake[0].{ TypeName }ID);");
                }
            }
            if (DBType == "DBLocal")
            {
                sb.AppendLine(@"");
                sb.AppendLine($@"            // List<{ TypeName }> with skip and take");
                sb.AppendLine($@"            var action{ TypeName }ListSkipAndTake = await { TypeName }{ DBType }Service.Get{ TypeName }List(1, 1);");
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
                    sb.AppendLine($@"            Assert.False({ TypeNameLower }List[0].{ TypeName }ID == { TypeNameLower }ListSkipAndTake[0].{ TypeName }ID);");
                }
            }
            if (DBType == "DBLocalIM")
            {
            }
            sb.AppendLine(@"");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"            // Get { TypeName } With Id");
                sb.AppendLine($@"            var action{ TypeName }Get = await { TypeName }{ DBType }Service.Get{ TypeName }WithId({ TypeNameLower }List[0].Id);");
            }
            else
            {
                sb.AppendLine($@"            // Get { TypeName } With { TypeName }ID");
                sb.AppendLine($@"            var action{ TypeName }Get = await { TypeName }{ DBType }Service.Get{ TypeName }With{ TypeName }ID({ TypeNameLower }List[0].{ TypeName }ID);");
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
                sb.AppendLine($@"            Assert.Equal({ TypeNameLower }Get.{ TypeName }ID, { TypeNameLower }List[0].{ TypeName }ID);");
            }
            sb.AppendLine(@"");        
            sb.AppendLine($@"            // Put { TypeName }");
            sb.AppendLine($@"            var action{ TypeName }Updated = await { TypeName }{ DBType }Service.Put({ TypeNameLower });");
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Updated.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Updated.Result).Value);");
            sb.AppendLine($@"            { TypeName } { TypeNameLower }Updated = ({ TypeName })((OkObjectResult)action{ TypeName }Updated.Result).Value;");
            sb.AppendLine($@"            Assert.NotNull({ TypeNameLower }Updated);");
            sb.AppendLine(@"");        
            sb.AppendLine($@"            // Delete { TypeName }");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"            var action{ TypeName }Deleted = await { TypeName }{ DBType }Service.Delete({ TypeNameLower }.Id);");
            }
            else
            {
                sb.AppendLine($@"            var action{ TypeName }Deleted = await { TypeName }{ DBType }Service.Delete({ TypeNameLower }.{ TypeName }ID);");
            }
            sb.AppendLine($@"            Assert.Equal(200, ((ObjectResult)action{ TypeName }Deleted.Result).StatusCode);");
            sb.AppendLine($@"            Assert.NotNull(((OkObjectResult)action{ TypeName }Deleted.Result).Value);");
            sb.AppendLine($@"            bool retBool = (bool)((OkObjectResult)action{ TypeName }Deleted.Result).Value;");
            sb.AppendLine($@"            Assert.True(retBool);");
            sb.AppendLine(@"");
            if (DBType == "DB")
            {
                sb.AppendLine($@"            { db }.Database.RollbackTransaction();");
            }
            if (DBType == "DBLocal")
            {
                sb.AppendLine($@"            { db }.Database.RollbackTransaction();");
            }
            if (DBType == "DBLocalIM")
            {
            }
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
