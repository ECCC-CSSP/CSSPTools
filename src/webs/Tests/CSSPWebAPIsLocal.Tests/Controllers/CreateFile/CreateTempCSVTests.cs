namespace CSSPWebAPIsLocal.Tests;

public partial class CreateFileControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateTempCSV_Good_Test(string culture)
    {
        Assert.True(await CreateFileControllerSetupAsync(culture));

        FileInfo fi = new FileInfo($@"{ Configuration["CSSPTempFilesPath"] }\\TestingThisWillBeUnique.txt");
        if (fi.Exists)
        {
            try
            {
                fi.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        TableConvertToCSVModel tableConvertToCSVModel = new TableConvertToCSVModel();
        tableConvertToCSVModel.CSVString = "a,b,c";
        tableConvertToCSVModel.TableFileName = "TestingThisWillBeUnique.txt";

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            string stringData = JsonSerializer.Serialize(tableConvertToCSVModel);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["LocalUrl"] }api/{ culture }/CreateFile/CreateTempCSV/", contentData).Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        fi = new FileInfo(fi.FullName);
        Assert.True(fi.Exists);

        if (fi.Exists)
        {
            try
            {
                fi.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }
    }
}

