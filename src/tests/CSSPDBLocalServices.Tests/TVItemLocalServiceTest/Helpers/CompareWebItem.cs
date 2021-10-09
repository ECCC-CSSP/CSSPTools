/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private void CompareWebItem(TVItemLocalModel postTVItemModel, TVItemModel webBase)
        {
            Assert.Equal(postTVItemModel.TVItem.ParentID, webBase.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVItem.TVType, webBase.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText, webBase.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText);
            Assert.Equal(postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVText, webBase.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVText);
        }
    }
}
