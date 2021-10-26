/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using System;
using System.Collections.Generic;

namespace CSSPDBLocalServices.Tests
{
    public partial class TelLocalServiceTest
    {
        private TelLocalModel FillTelLocalModel()
        {
            TelLocalModel telModel = new TelLocalModel();

            Tel tel = new Tel()
            {
                TelID = 0,
                DBCommand = DBCommandEnum.Created,
                TelTVItemID = 0,
                TelType = TelTypeEnum.Personal,
                TelNumber = "15061231234",
                LastUpdateDate_UTC = DateTime.UtcNow,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            };

            telModel.Tel = tel;

            return telModel;
        }
    }
}
