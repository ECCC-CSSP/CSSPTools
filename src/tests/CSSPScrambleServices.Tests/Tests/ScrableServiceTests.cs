using CSSPScrambleServices;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ScrambleServices.Tests
{
    [Collection("Sequential")]
    public partial class ScrambleServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ScrambleService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(ScrambleService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ScrambleService_Scramble_and_Descramble_With_Empty_String_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string retStr = ScrambleService.Scramble("");
            Assert.Equal("", retStr);

            retStr = ScrambleService.Descramble("");
            Assert.Equal("", retStr);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ScrambleService_Scramble_and_Descramble_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Random random = new Random();

            for(int countWord = 0; countWord < 10000; countWord++)
            {
                string Word = "";
                string ScrambleWord = "";
                string DescrambleWord = "";

                int wordLength = random.Next(1, 250);
                for (int i = 0; i < wordLength; i++)
                {
                    Word += (char)random.Next('0', 'z');
                }

                ScrambleWord = ScrambleService.Scramble(Word);
                Assert.NotEqual(Word, ScrambleWord);

                DescrambleWord = ScrambleService.Descramble(ScrambleWord);
                Assert.Equal(Word, DescrambleWord);
            }

        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
