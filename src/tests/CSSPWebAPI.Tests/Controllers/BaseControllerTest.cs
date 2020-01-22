using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebAPI;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
    public class BaseControllerTest
    {
        #region Variables
        public List<LanguageEnum> AllowableLanguages { get; private set; }
        public DatabaseTypeEnum DatabaseType { get; private set; }
        public int AdminContactID { get; private set; }
        public int TestEmailValidatedContactID { get; private set; }
        public int TestEmailNotValidatedContactID { get; private set; }
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BaseControllerTest()
        {
            AllowableLanguages = new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr };
            this.DatabaseType = DatabaseTypeEnum.SqlServerTestDB;
            AdminContactID = 1; // charles leblanc is admin
            TestEmailValidatedContactID = 2; // testing
            TestEmailNotValidatedContactID = 3; // testing
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public 

        #region Functions private
        #endregion Functions private
    }
}
