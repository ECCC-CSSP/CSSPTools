using System;
using Xunit;
using CSSPEnumsDLL.Tests.SetupInfo;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;
using CSSPEnumsDLL.Enums;

namespace CSSPEnumsDLL.Tests.Services
{
    public partial class BaseEnumServiceTest : SetupData
    {
        #region Variables
        private SetupData setupData;
        private BaseEnumService baseEnumService { get; set; }
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BaseEnumServiceTest()
        {
            setupData = new SetupData();
        }
        #endregion Constructors

        // All the testing function are under the BaseEnumServiceGeneratedTest.cs

        #region Testing Methods private
        #endregion Testing Methods private

        #region Functions private
        public void SetupTest(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            baseEnumService = new BaseEnumService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en));
        }
        #endregion Functions private

    }
}
