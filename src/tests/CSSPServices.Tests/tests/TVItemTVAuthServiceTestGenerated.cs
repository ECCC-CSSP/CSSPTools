 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{

    public partial class TVItemTVAuthServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemTVAuthService tvItemTVAuthService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemTVAuthServiceTest() : base()
        {
            //tvItemTVAuthService = new TVItemTVAuthService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private TVItemTVAuth GetFilledRandomTVItemTVAuth(string OmitPropName)
        {
            TVItemTVAuth tvItemTVAuth = new TVItemTVAuth();

            if (OmitPropName != "TVItemUserAuthID") tvItemTVAuth.TVItemUserAuthID = GetRandomInt(1, 11);
            if (OmitPropName != "TVText") tvItemTVAuth.TVText = GetRandomString("", 6);
            if (OmitPropName != "TVItemID1") tvItemTVAuth.TVItemID1 = GetRandomInt(1, 11);
            if (OmitPropName != "TVTypeStr") tvItemTVAuth.TVTypeStr = GetRandomString("", 6);
            if (OmitPropName != "TVAuth") tvItemTVAuth.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "TVAuthText") tvItemTVAuth.TVAuthText = GetRandomString("", 5);

            return tvItemTVAuth;
        }
        #endregion Functions private
    }
}
