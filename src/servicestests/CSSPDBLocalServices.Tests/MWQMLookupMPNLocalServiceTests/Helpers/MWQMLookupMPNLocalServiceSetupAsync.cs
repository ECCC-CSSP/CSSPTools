namespace CSSPDBLocalServices.Tests;

    [Collection("Sequential")]
    public partial class MWQMLookupMPNLocalServiceTest : CSSPDBLocalServiceTest
    {
        public MWQMLookupMPNLocalServiceTest() : base()
        {

        }

        private async Task<bool> MWQMLookupMPNLocalServiceSetupAsync(string culture)
        {
            List<string> TableList = new List<string>() { "MWQMLookupMPNs" };

            Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
            Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

            return await Task.FromResult(true);
        }
    }

