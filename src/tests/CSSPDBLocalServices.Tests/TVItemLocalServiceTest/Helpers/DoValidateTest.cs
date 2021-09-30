/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task DoValidateTest(int ParentTVItemID, WebTypeEnum webType, TVTypeEnum tvType, string obj, string variable, string err)
        {
            await LoadWebType(ParentTVItemID, webType);

            List<TVItemModel> tvItemParentList = await GetWebBaseParentList(webType);
            Assert.NotNull(tvItemParentList);

            string TVTextEN = "New item";
            string TVTextFR = "Nouveau item";
            PostTVItemModel postTVItemModel = FillPostTVItemModelForAdd(tvItemParentList, TVTextEN, TVTextFR, tvType);

            switch (obj)
            {
                case "TVItem":
                    {
                        ChangeTVItemVariableValue(postTVItemModel.TVItem, variable);
                    }
                    break;
                case "TVItemParent":
                    {
                        ChangeTVItemVariableValue(postTVItemModel.TVItemParent, variable);
                    }
                    break;
                //case "TVItemGrandParent":
                //    {
                //        ChangeTVItemVariableValue(postTVItemModel.TVItemGrandParent, variable);
                //    }
                //    break;
                case "TVItemLanguageEN":
                    {
                        ChangeTVItemLanguageVariableValue(postTVItemModel.TVItem, postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1], variable);
                    }
                    break;
                case "TVItemLanguageFR":
                    {
                        ChangeTVItemLanguageVariableValue(postTVItemModel.TVItem, postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1], variable);
                    }
                    break;
                default:
                    break;
            }

            await TestAddOrModifyError(postTVItemModel, err);
        }
    }
}
