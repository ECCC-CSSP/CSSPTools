/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private void ChangeTVItemLanguageVariableValue(TVItem tvItem, TVItemLanguage tvItemLanguage, string variable)
        {
            switch (variable)
            {
                case "DBCommand":
                    {
                        tvItemLanguage.DBCommand = (DBCommandEnum)10000;
                    }
                    break;
                case "TVItemLanguageID":
                    {
                        tvItem.TVItemID = 1;
                        tvItemLanguage.TVItemLanguageID = 0;
                    }
                    break;
                case "TVItemID":
                    {
                        tvItem.TVItemID = 1;
                        tvItemLanguage.TVItemID = 0;
                    }
                    break;
                case "Language":
                    {
                        tvItemLanguage.Language = (LanguageEnum)10000;
                    }
                    break;
                case "TVText":
                    {
                        tvItemLanguage.TVText = "";
                    }
                    break;
                case "TranslationStatus":
                    {
                        tvItemLanguage.TranslationStatus = (TranslationStatusEnum)10000;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
