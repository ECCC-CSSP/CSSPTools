namespace CSSPDBLocalServices.Tests;

    [Collection("Sequential")]
    public partial class ProvinceLocalServiceTest : CSSPDBLocalServiceTest
    {
        public ProvinceLocalServiceTest() : base()
        {


        }

        private async Task<bool> ProvinceLocalServiceSetup(string culture)
        {
            List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

            Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
            Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

            return await Task.FromResult(true);
        }
    }

