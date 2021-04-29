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
        private void CompareWebItem(PostTVItemModel postTVItemModel, TVItemModel webBase)
        {
            Assert.Equal(postTVItemModel.TVItem.ParentID, webBase.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVItem.TVType, webBase.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText, webBase.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText, webBase.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
    }
}
