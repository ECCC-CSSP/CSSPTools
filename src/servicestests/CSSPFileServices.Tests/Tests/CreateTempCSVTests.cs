namespace CSSPFileServices.Tests;

//[Collection("Sequential")]
public partial class FileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateTempCSV_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        FileInfo fi = new FileInfo($@"{ Configuration["CSSPTempFilesPath"] }\\TestingThisWillBeUnique.csv");

        TableConvertToCSVModel tableConvertToCSVModel = new TableConvertToCSVModel();
        tableConvertToCSVModel.CSVString = "a,b,c";
        tableConvertToCSVModel.TableFileName = fi.Name;

        var actionRes = await CSSPFileService.CreateTempCSV(tableConvertToCSVModel);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        fi = new FileInfo(fi.FullName);
        Assert.True(fi.Exists);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateTempCSV_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        FileInfo fi = new FileInfo($@"{ Configuration["CSSPTempFilesPath"] }\\TestingThisWillBeUnique.csv");

        TableConvertToCSVModel tableConvertToCSVModel = new TableConvertToCSVModel();
        tableConvertToCSVModel.CSVString = "a,b,c";
        tableConvertToCSVModel.TableFileName = fi.Name;

        var actionRes = await CSSPFileService.CreateTempCSV(tableConvertToCSVModel);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory(Skip = "Will need to rewrite this one")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateTempCSV_PathDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        FileInfo fi = new FileInfo($@"{ Configuration["CSSPTempFilesPath"] }\\TestingThisWillBeUnique.csv");

        TableConvertToCSVModel tableConvertToCSVModel = new TableConvertToCSVModel();
        tableConvertToCSVModel.CSVString = "a,b,c";
        tableConvertToCSVModel.TableFileName = fi.Name;

        //config.CSSPTempFilesPath = config.CSSPTempFilesPath.Replace("cssptempfiles", "notexist");

        var actionRes = await CSSPFileService.CreateTempCSV(tableConvertToCSVModel);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
}

