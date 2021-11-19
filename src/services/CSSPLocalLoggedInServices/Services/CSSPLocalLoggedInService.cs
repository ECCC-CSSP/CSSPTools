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

namespace CSSPLocalLoggedInServices
{
    public interface ICSSPLocalLoggedInService
    {
        LoggedInContactInfo LoggedInContactInfo { get; set; }

        Task<bool> SetLocalLoggedInContactInfo();
    }
    public partial class CSSPLocalLoggedInService : ICSSPLocalLoggedInService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LoggedInContactInfo LoggedInContactInfo { get; set; }

        //private IConfiguration Configuration { get; }
        private CSSPDBManageContext dbManage { get; }
        #endregion Properties

        #region Constructors
        public CSSPLocalLoggedInService(IConfiguration Configuration, CSSPDBManageContext dbManage)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "LoggedInService") }");

            //this.Configuration = Configuration;
            this.dbManage = dbManage;
            
            LoggedInContactInfo = new LoggedInContactInfo();
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
