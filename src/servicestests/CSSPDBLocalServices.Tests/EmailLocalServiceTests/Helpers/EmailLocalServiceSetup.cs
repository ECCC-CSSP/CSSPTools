namespace CSSPDBLocalServices.Tests;

    [Collection("Sequential")]
    public partial class EmailLocalServiceTest : CSSPDBLocalServiceTest
    {
        public EmailLocalServiceTest() : base()
        {


        }

        private async Task<bool> EmailLocalServiceSetup(string culture)
        {
            List<string> TableList = new List<string>() { "Emails", "TVItems", "TVItemLanguages" };

            Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
            Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

            return await Task.FromResult(true);
        }
    }

