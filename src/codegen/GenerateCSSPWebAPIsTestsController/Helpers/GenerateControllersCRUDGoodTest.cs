using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPWebAPIsTestsController
{
    public partial class Startup
    {
        private async Task<bool> GenerateControllersCRUDGoodTest(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        [Theory]");
            sb.AppendLine(@"        [InlineData(""en-CA"")]");
            sb.AppendLine(@"        //[InlineData(""fr-CA"")]");
            sb.AppendLine($@"        public async Task { TypeName }Controller_CRUD_Good_Test(string culture)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Assert.True(await Setup(culture));");
            sb.AppendLine(@"");
            sb.AppendLine(@"            using (HttpClient httpClient = new HttpClient())");
            sb.AppendLine(@"            {");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(""Bearer"", contact2.Token);");
            }
            else
            {
                sb.AppendLine(@"                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(""Bearer"", contact.Token);");
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"                // testing Get");
            sb.AppendLine($@"                string url = $""{{ CSSPAzureUrl }}api/{{ culture }}/{ TypeName }"";");
            sb.AppendLine($@"                var response = await httpClient.GetAsync(url);");
            sb.AppendLine($@"                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);");
            sb.AppendLine($@"                string responseContent = await response.Content.ReadAsStringAsync();");
            sb.AppendLine($@"                Assert.NotEmpty(responseContent);");
            sb.AppendLine($@"                List<{ TypeName }> { TypeNameLower }List = JsonSerializer.Deserialize<List<{ TypeName }>>(responseContent);");
            sb.AppendLine($@"                Assert.True({ TypeNameLower }List.Count > 0);");
            sb.AppendLine($@"");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"                // testing Get(Id)");
                sb.AppendLine($@"                string urlID = url + ""/"" + { TypeNameLower }List[0].Id;");
            }
            else
            {
                sb.AppendLine($@"                // testing Get({ TypeName }ID)");
                sb.AppendLine($@"                string urlID = url + ""/"" + { TypeNameLower }List[0].{ TypeName }ID;");
            }
            sb.AppendLine($@"                response = await httpClient.GetAsync(urlID);");
            sb.AppendLine($@"                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);");
            sb.AppendLine($@"                responseContent = await response.Content.ReadAsStringAsync();");
            sb.AppendLine($@"                Assert.NotEmpty(responseContent);");
            sb.AppendLine($@"                { TypeName } { TypeNameLower } = JsonSerializer.Deserialize<{ TypeName }>(responseContent);");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"                Assert.Equal({ TypeNameLower }List[0].Id, { TypeNameLower }.Id);");
            }
            else
            {
                sb.AppendLine($@"                Assert.Equal({ TypeNameLower }List[0].{ TypeName }ID, { TypeNameLower }.{ TypeName }ID);");
            }
            sb.AppendLine($@"");
            if (TypeName == "MWQMLookupMPN")
            {
                sb.AppendLine($@"                // testing Delete({ TypeName }ID)");
                sb.AppendLine($@"                urlID = url + ""/"" + { TypeNameLower }.{ TypeName }ID;");
                sb.AppendLine($@"                response = await httpClient.DeleteAsync(urlID);");
                sb.AppendLine($@"                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);");
                sb.AppendLine($@"                responseContent = await response.Content.ReadAsStringAsync();");
                sb.AppendLine($@"                Assert.NotEmpty(responseContent);");
                sb.AppendLine($@"                bool retBool = JsonSerializer.Deserialize<bool>(responseContent);");
                sb.AppendLine($@"                Assert.True(retBool);");
            }
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"                // testing Post({ TypeName })");
                sb.AppendLine($@"                { TypeNameLower }.Id = """";");
            }
            else
            {
                sb.AppendLine($@"                // testing Post({ TypeName })");
                sb.AppendLine($@"                { TypeNameLower }.{ TypeName }ID = 0;");
            }
            if (TypeName == "SamplingPlan")
            {
                sb.AppendLine($@"               samplingPlan.SamplingPlanName = samplingPlan.SamplingPlanName.Replace(samplingPlan.Year.ToString(), (samplingPlan.Year + 20).ToString());");
            }
            if (TypeName == "TVItem")
            {
                sb.AppendLine($@"                tvItem.ParentID = tvItemList[1].ParentID;");
                sb.AppendLine($@"                tvItem.TVLevel = 1; ");
                sb.AppendLine($@"                tvItem.TVPath = ""Timbucto"";");
                sb.AppendLine($@"                tvItem.TVType = TVTypeEnum.Country;");
            }
            sb.AppendLine($@"                string content = JsonSerializer.Serialize<{ TypeName }>({ TypeNameLower });");
            sb.AppendLine($@"                HttpContent httpContent = new StringContent(content);");
            sb.AppendLine($@"                httpContent.Headers.ContentType = new MediaTypeHeaderValue(""application/json"");");
            sb.AppendLine($@"                response = await httpClient.PostAsync(url, httpContent);");
            sb.AppendLine($@"                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);");
            sb.AppendLine($@"                responseContent = await response.Content.ReadAsStringAsync();");
            sb.AppendLine($@"                Assert.NotEmpty(responseContent);");
            sb.AppendLine($@"                { TypeNameLower } = JsonSerializer.Deserialize<{ TypeName }>(responseContent);");
            sb.AppendLine($@"                Assert.NotNull({ TypeNameLower });");
            sb.AppendLine($@"");
            sb.AppendLine($@"                // testing Put({ TypeName })");
            sb.AppendLine($@"                content = JsonSerializer.Serialize<{ TypeName }>({ TypeNameLower });");
            sb.AppendLine($@"                httpContent = new StringContent(content);");
            sb.AppendLine($@"                httpContent.Headers.ContentType = new MediaTypeHeaderValue(""application/json"");");
            sb.AppendLine($@"                response = await httpClient.PutAsync(url, httpContent);");
            sb.AppendLine($@"                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);");
            sb.AppendLine($@"                responseContent = await response.Content.ReadAsStringAsync();");
            sb.AppendLine($@"                Assert.NotEmpty(responseContent);");
            sb.AppendLine($@"                { TypeNameLower } = JsonSerializer.Deserialize<{ TypeName }>(responseContent);");
            sb.AppendLine($@"                Assert.NotNull({ TypeNameLower });");
            sb.AppendLine($@"");
            if (!(TypeName == "MWQMLookupMPN"))
            {
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                // testing Delete(Id)");
                    sb.AppendLine($@"                urlID = url + ""/"" + { TypeNameLower }.Id;");
                }
                else
                {
                    sb.AppendLine($@"                // testing Delete({ TypeName }ID)");
                    sb.AppendLine($@"                urlID = url + ""/"" + { TypeNameLower }.{ TypeName }ID;");
                }
                sb.AppendLine($@"                response = await httpClient.DeleteAsync(urlID);");
                sb.AppendLine($@"                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);");
                sb.AppendLine($@"                responseContent = await response.Content.ReadAsStringAsync();");
                sb.AppendLine($@"                Assert.NotEmpty(responseContent);");
                sb.AppendLine($@"                bool retBool = JsonSerializer.Deserialize<bool>(responseContent);");
                sb.AppendLine($@"                Assert.True(retBool);");
            }
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
