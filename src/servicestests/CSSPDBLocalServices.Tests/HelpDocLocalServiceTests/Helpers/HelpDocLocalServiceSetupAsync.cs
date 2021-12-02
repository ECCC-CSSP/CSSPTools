namespace CSSPDBLocalServices.Tests;

    [Collection("Sequential")]
    public partial class HelpDocLocalServiceTest : CSSPDBLocalServiceTest
    {
        public HelpDocLocalServiceTest() : base()
        {

        }

        private async Task<bool> HelpDocLocalServiceSetupAsync(string culture)
        {
            List<string> TableList = new List<string>() { "HelpDocs" };

            Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
            Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

            return await Task.FromResult(true);
        }
    }

