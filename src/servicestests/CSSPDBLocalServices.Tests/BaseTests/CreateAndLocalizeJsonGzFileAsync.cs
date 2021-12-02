namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    protected async Task CreateAndLocalizeJsonGzFileAsync(List<ToRecreate> ToRecreateList)
    {
        foreach (ToRecreate toRecreate in ToRecreateList)
        {
            var actionCreateGz = await CSSPCreateGzFileService.CreateGzFileAsync(toRecreate.WebType, toRecreate.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionCreateGz.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCreateGz.Result).Value);
            bool boolRet2 = (bool)((OkObjectResult)actionCreateGz.Result).Value;
            Assert.True(boolRet2);

            string FileName = await BaseGzFileService.GetFileName(toRecreate.WebType, toRecreate.TVItemID);

            var actionLocalize = await CSSPFileService.LocalizeAzureJSONFileAsync(FileName);
            Assert.Equal(200, ((ObjectResult)actionLocalize.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalize.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionLocalize.Result).Value;
            Assert.True(boolRet);

            FileInfo fi = new FileInfo(Configuration["CSSPJSONPath"] + FileName);

            Assert.True(fi.Exists);
        }
    }
}

