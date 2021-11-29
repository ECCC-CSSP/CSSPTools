using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPHelperModels;
using ManageServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPServerLoggedInServices
{
    public interface ICSSPServerLoggedInService
    {
        // properties
        LoggedInContactInfo LoggedInContactInfo { get; set; }

        // functions
        Task<bool> SetLoggedInContactInfoAsync(string LoginEmail);

    }
    public partial class CSSPServerLoggedInService : ICSSPServerLoggedInService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LoggedInContactInfo LoggedInContactInfo { get; set; }

        private IConfiguration Configuration { get; }
        private CSSPDBContext db { get; }
        #endregion Properties

        #region Constructors
        public CSSPServerLoggedInService(IConfiguration Configuration, CSSPDBContext db)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (db == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db") }");

            this.Configuration = Configuration;
            this.db = db;
            
            LoggedInContactInfo = new LoggedInContactInfo();
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
