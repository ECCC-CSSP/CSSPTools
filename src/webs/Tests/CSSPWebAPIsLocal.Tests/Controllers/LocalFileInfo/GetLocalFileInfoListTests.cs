namespace CSSPWebAPIsLocal.Tests;

public partial class LocalFileInfoControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetLocalFileInfoList_Good_Test(string culture)
    {
        Assert.True(await LocalFileInfoControllerSetupAsync(culture));

        int ParentTVItemID = 1;

        string DirectoryPath = $"{ Configuration["CSSPFilesPath"] }{ParentTVItemID}\\";

        DirectoryInfo di = new DirectoryInfo(DirectoryPath);

        if (!di.Exists)
        {
            try
            {
                di.Create();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        string FileName = "ThisFileShouldNotExis.txt";
        FileInfo fi = new FileInfo($"{DirectoryPath}{FileName}");

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

        StreamWriter sw = fi.CreateText();
        sw.WriteLine("bonjour");
        sw.Close();

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/LocalFileInfo/GetLocalFileInfoList/{ParentTVItemID}";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            List<LocalFileInfo> LocalFileInfoList = JsonSerializer.Deserialize<List<LocalFileInfo>>(responseContent);
            Assert.True(LocalFileInfoList.Count > 0);
            Assert.True(LocalFileInfoList.Where(c => c.FileName == FileName).Any());
        }

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
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetLocalFileInfoList_For_Municipality_Good_Test(string culture)
    {
        Assert.True(await LocalFileInfoControllerSetupAsync(culture));

        int ParentTVItemID = 27764;

        string DirectoryPath = $"{ Configuration["CSSPFilesPath"] }{ParentTVItemID}\\";

        DirectoryInfo di = new DirectoryInfo(DirectoryPath);

        if (!di.Exists)
        {
            try
            {
                di.Create();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        string FileName = "ThisFileShouldNotExis.txt";
        FileInfo fi = new FileInfo($"{DirectoryPath}{FileName}");

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

        StreamWriter sw = fi.CreateText();
        sw.WriteLine("bonjour");
        sw.Close();

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/LocalFileInfo/GetLocalFileInfoList/{ParentTVItemID}";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            List<LocalFileInfo> LocalFileInfoList = JsonSerializer.Deserialize<List<LocalFileInfo>>(responseContent);
            Assert.True(LocalFileInfoList.Count > 0);
            Assert.True(LocalFileInfoList.Where(c => c.FileName == FileName).Any());
        }

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
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetLocalFileInfoList_Error_Test(string culture)
    {
        Assert.True(await LocalFileInfoControllerSetupAsync(culture));

        int TVItemID = 1000000;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/LocalFileInfo/GetLocalFileInfoList/{TVItemID}";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(responseContent);
            Assert.NotNull(errRes);
            Assert.True(errRes.ErrList.Count > 0);
        }
    }
}

