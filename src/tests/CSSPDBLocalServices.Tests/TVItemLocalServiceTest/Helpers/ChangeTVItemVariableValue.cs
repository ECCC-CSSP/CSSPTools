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
        private void ChangeTVItemVariableValue(TVItem tvItem, string variable)
        {
            switch (variable)
            {
                case "DBCommand":
                    {
                        tvItem.DBCommand = (DBCommandEnum)10000;
                    }
                    break;
                case "TVType":
                    {
                        tvItem.TVType = (TVTypeEnum)10000;
                    }
                    break;
                case "TVLevel":
                    {
                        tvItem.TVLevel = 0;
                    }
                    break;
                case "TVPath":
                    {
                        tvItem.TVPath = "";
                    }
                    break;
                case "ParentID":
                    {
                        tvItem.ParentID = 0;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
