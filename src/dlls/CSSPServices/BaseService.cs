using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CSSPServices
{
    public partial class BaseService
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
        //public CSSPDBContext db { get; set; }
        public bool CanSendEmail { get; set; }
        public int ContactID { get; set; }
        public string FromEmail { get; set; }
        public LanguageEnum LanguageRequest { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors  

        #region Validation
        #endregion Validation

        #region Functions public
        #endregion Functions public
    }
}
