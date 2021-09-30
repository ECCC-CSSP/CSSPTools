using CSSPCultureServices.Resources;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using System;

namespace CSSPLogServices.Tests
{
    public partial class CSSPLogServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPLocalLoggedInService_Scramble_and_Descramble_With_Empty_String_Good_Test(string culture)
        {
            Assert.True(await CSSPLogServiceSetup(culture));

            string retStr = CSSPLogService.Scramble("");
            Assert.Equal("", retStr);

            retStr = CSSPLogService.Descramble("");
            Assert.Equal("", retStr);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPLocalLoggedInService_Scramble_and_Descramble_Good_Test(string culture)
        {
            Assert.True(await CSSPLogServiceSetup(culture));

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

                ScrambleWord = CSSPLogService.Scramble(Word);
                Assert.NotEqual(Word, ScrambleWord);

                DescrambleWord = CSSPLogService.Descramble(ScrambleWord);
                Assert.Equal(Word, DescrambleWord);
            }

        }
    }
}
