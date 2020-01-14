/*
 * This document is manually edited.
 * 
 * All testing function are generated under documents
 * EnumsTestGenerated.cs and EnumsPolSourceObsInfoEnumTestGenerated.cs
 * 
 * Last edited by Charles LeBlanc. 
 * 
 */
using Xunit;
using System.Globalization;
using System.Threading;

namespace CSSPEnums.Tests
{
    public partial class EnumsTest
    {
        #region Variables
        private Enums enums { get; set; }
        #endregion Variables

        #region Properties

        #endregion Properties

        #region Constructors
        public EnumsTest()
        {
        }
        #endregion Constructors

        // All the testing function are under the EnumsGeneratedTest.cs

        #region Testing Methods private
        #endregion Testing Methods private

        #region Functions private
        public void SetupTest(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            enums = new Enums((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en));
        }
        #endregion Functions private

    }
}
