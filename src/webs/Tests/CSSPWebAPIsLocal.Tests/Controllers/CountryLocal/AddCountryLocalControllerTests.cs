namespace CSSPWebAPIsLocal.Tests;

public partial class CountryLocalControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddCountryLocal_ParentTVItemID_1_Good_Test(string culture)
    {
        Assert.True(await CountryLocalControllerSetupAsync(culture));

        int ParentTVItemID = 1;

        TVItemModel tvItemModel = new TVItemModel();

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            string stringData = ""; // JsonSerializer.Serialize(ParentTVItemID);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["CSSPLocalUrl"] }api/{ culture }/CountryLocal/{ ParentTVItemID }", contentData).Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string responseContent = await response.Content.ReadAsStringAsync();
            tvItemModel = JsonSerializer.Deserialize<TVItemModel>(responseContent);
            Assert.NotNull(tvItemModel);
        }

        DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
        Assert.True(di.Exists);
        List<FileInfo> fiList = di.GetFiles().ToList();
        Assert.True(fiList.Count() > 0);
        Assert.True(fiList.Where(c => c.Name.Contains("-1.gz")).Any());

        TVItem tvItem = (from c in dbLocal.TVItems
                         where c.TVItemID == -1
                         select c).FirstOrDefault();

        Assert.NotNull(tvItem);
        Assert.Equal(-1, tvItem.TVItemID);

        List<TVItemLanguage> tvItemLanguageList = (from c in dbLocal.TVItemLanguages
                                                   where c.TVItemID == -1
                                                   select c).ToList();

        Assert.True(tvItemLanguageList.Count() == 2);
        Assert.Equal(-1, tvItemLanguageList[0].TVItemLanguageID);
        Assert.Equal(-2, tvItemLanguageList[1].TVItemLanguageID);
    }
}

