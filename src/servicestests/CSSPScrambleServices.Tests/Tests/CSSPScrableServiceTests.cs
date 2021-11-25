namespace CSSPScrambleServices.Tests;

public partial class CSSPScrambleServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ScrambleService_Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPScrambleServiceSetup(culture));
        Assert.NotNull(CSSPScrambleService);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ScrambleService_Scramble_and_Descramble_With_Empty_String_Good_Test(string culture)
    {
        Assert.True(await CSSPScrambleServiceSetup(culture));

        string retStr = CSSPScrambleService.Scramble("");
        Assert.Equal("", retStr);

        retStr = CSSPScrambleService.Descramble("");
        Assert.Equal("", retStr);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ScrambleService_Scramble_and_Descramble_Good_Test(string culture)
    {
        Assert.True(await CSSPScrambleServiceSetup(culture));

        Random random = new Random();

        for (int countWord = 0; countWord < 10000; countWord++)
        {
            string Word = "";
            string ScrambleWord = "";
            string DescrambleWord = "";

            int wordLength = random.Next(1, 250);
            for (int i = 0; i < wordLength; i++)
            {
                Word += (char)random.Next('0', 'z');
            }

            ScrambleWord = CSSPScrambleService.Scramble(Word);
            Assert.NotEqual(Word, ScrambleWord);

            DescrambleWord = CSSPScrambleService.Descramble(ScrambleWord);
            Assert.Equal(Word, DescrambleWord);
        }

    }
}

