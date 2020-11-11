/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class LoggedInContactInfo
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public Contact LoggedInContact { get; set; }
        public List<TVTypeUserAuthorization> TVTypeUserAuthorizationList { get; set; }
        public List<TVItemUserAuthorization> TVItemUserAuthorizationList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LoggedInContactInfo() : base()
        {
            TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
            TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
        }
        #endregion Constructors
    }
}
