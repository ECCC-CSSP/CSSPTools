using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CSSPWebAPIs.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        #region Variables public
        public List<LanguageEnum> LanguageListAllowable = new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr };
        //public int TakeMax = 1000000;
        public string BasePath = @"E:\inetpub\wwwroot\cssp\App_Data\";
        public double R = 6378137.0;
        public double d2r = Math.PI / 180;
        public double r2d = 180 / Math.PI;
        //public Random random = new Random((int)(DateTime.Now.Ticks));
        //public List<TVTypeNamesAndPath> tvTypeNamesAndPathList = new List<TVTypeNamesAndPath>();
        //public List<PolSourceObsInfoChild> polSourceObsInfoChildList = new List<PolSourceObsInfoChild>();
        #endregion Variables public

        #region Properties
        //public CSSPDBContext db { get; set; } = null;
        public int ContactID { get; set; } = 0;
        public bool CanSendEmail { get; set; } = true;
        public string FromEmail { get; set; } = "ec.pccsm-cssp.ec@canada.ca";
        public LanguageEnum LanguageRequest { get; set; } = LanguageEnum.en;
        public CultureInfo Culture { get; set; } = new CultureInfo("en-CA");
        #endregion Properties

        #region Constructors
        public BaseController()
        {
            // will need to get the ContactID from the User
            this.ContactID = 1; // ContactID;
        }

        #endregion Constructors

        #region Functions protected
        protected async Task SetCulture()
        {
            string cultureStr = Request.RouteValues["culture"].ToString();
            if (cultureStr.Substring(0, 2) == "fr")
            {
                LanguageRequest = LanguageEnum.fr;
                Culture = new CultureInfo("fr-CA");
            }

            if (LanguageRequest == LanguageEnum.fr)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");
            }
        }
        #endregion Functions protected
    }
}
