/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemServiceTest
    {
        private void CompareWebItem(PostTVItemModel postTVItemModel, WebBase webBase)
        {
            Assert.Equal(postTVItemModel.ParentID, webBase.TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, webBase.TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, webBase.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, webBase.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
    }
}
