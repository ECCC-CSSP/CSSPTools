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
    public partial class HelpDocLocalServiceTest
    {
        private HelpDocLocalModel FillHelpDocLocalModel()
        {
            HelpDocLocalModel helpDocModel = new HelpDocLocalModel();

            HelpDoc address = new HelpDoc()
            {
                HelpDocID = 0,
                DBCommand = DBCommandEnum.Created,
                DocKey = "ThisIsDocKey",
                Language = LanguageEnum.en,
                DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>",
                LastUpdateDate_UTC = DateTime.UtcNow,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            };

            helpDocModel.HelpDoc = address;

            return helpDocModel;
        }
    }
}
