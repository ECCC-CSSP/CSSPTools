/*
 * Manually edited
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    [NotMapped]
    public partial class CSSPWQInputParam
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        public CSSPWQInputTypeEnum CSSPWQInputType { get; set; }
        [CSSPMaxLength(200)]
        [CSSPMinLength(1)]
        public string Name { get; set; }
        [CSSPRange(1, -1)]
        public int TVItemID { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "CSSPWQInputTypeEnum", EnumType = "CSSPWQInputType")]
        [CSSPAllowNull]
        public string CSSPWQInputTypeText { get; set; }
        public List<string> sidList { get; set; }
        public List<string> MWQMSiteList { get; set; }
        public List<int> MWQMSiteTVItemIDList { get; set; }
        public List<string> DailyDuplicateMWQMSiteList { get; set; }
        public List<int> DailyDuplicateMWQMSiteTVItemIDList { get; set; }
        public List<string> InfrastructureList { get; set; }
        public List<int> InfrastructureTVItemIDList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public CSSPWQInputParam() : base()
        {
            sidList = new List<string>();
            MWQMSiteList = new List<string>();
            MWQMSiteTVItemIDList = new List<int>();
            DailyDuplicateMWQMSiteList = new List<string>();
            DailyDuplicateMWQMSiteTVItemIDList = new List<int>();
            InfrastructureList = new List<string>();
            InfrastructureTVItemIDList = new List<int>();
        }
        #endregion Constructors
    }
}
