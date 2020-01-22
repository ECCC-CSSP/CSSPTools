using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebAPI;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;

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
        public HttpClient httpClient { get; set; }
        #endregion Properties

        #region Constructors
        public BaseControllerTest()
        {
            AllowableLanguages = new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr };
            this.DatabaseType = DatabaseTypeEnum.SqlServerTestDB;
            AdminContactID = 1; // charles leblanc is admin
            TestEmailValidatedContactID = 2; // testing
            TestEmailNotValidatedContactID = 3; // testing

            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            httpClient = server.CreateClient();
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public 

        #region Functions private
        #endregion Functions private
    }
}
