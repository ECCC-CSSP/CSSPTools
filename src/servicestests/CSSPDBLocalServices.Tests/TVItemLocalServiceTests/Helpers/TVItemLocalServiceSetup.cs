namespace CSSPDBLocalServices.Tests;

    [Collection("Sequential")]
    public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
    {
        public TVItemLocalServiceTest() : base()
        {


        }

        private async Task<bool> TVItemLocalServiceSetup(string culture)
        {
            List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages" };

            Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
            Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

            return await Task.FromResult(true);
        }
    }

