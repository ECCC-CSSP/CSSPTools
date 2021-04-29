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
        private void CompareTVFileModelItem(PostTVItemModel postTVItemModel, TVFileModel tvFileModel)
        {
            Assert.Equal(postTVItemModel.TVItem.ParentID, tvFileModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText, tvFileModel.TVFile.ServerFileName);
        }
    }
}
