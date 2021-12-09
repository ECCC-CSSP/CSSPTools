namespace CSSPDBLocalServices.Tests;

    [Collection("Sequential")]
    public partial class TelLocalServiceTest : CSSPDBLocalServiceTest
    {
        public TelLocalServiceTest() : base()
        {


        }

        private async Task<bool> TelLocalServiceSetupAsync(string culture)
        {
            List<string> TableList = new List<string>() { "Tels", "TVItems", "TVItemLanguages" };

            Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
            Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

            return await Task.FromResult(true);
        }
    }

