using GenerateCodeBase.Resources;
using GenerateCodeStatusDB.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenerateCodeBase.Tests
{
    public partial class GenerateCodeBaseTests
    {
        #region Variables
        #endregion Variables

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Fact]
        public void GenerateCodeBaseServiceFillCSSPPropTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                //generateCodeBaseService.FillCSSPProp(PropertyInfo propInfo, CSSPProp csspProp, Type type);

                Assert.True(true);
            }
        }
        [Fact]
        public void GenerateCodeBaseServiceFillDLLTypeInfoListTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                //generateCodeBaseService.FillDLLTypeInfoList(FileInfo fiDLL, List<DLLTypeInfo> DLLTypeInfoList);

                Assert.True(true);
            }
        }
        [Fact]
        public void GenerateCodeBaseServiceSkipTypeTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                //generateCodeBaseService.SkipType(Type type);

                Assert.True(true);
            }
        }
        [Fact]
        public void GenerateCodeBaseServiceSetCultureTest()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                generateCodeBaseService.SetCulture(new CultureInfo(culture));
                Assert.Equal(new CultureInfo(culture), generateCodeStatusDBService.Culture);
                Assert.Equal(new CultureInfo(culture), AppRes.Culture);
            }
        }
        #endregion Functions public
    }
}
