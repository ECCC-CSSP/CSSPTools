/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPDBModels
{
    public partial class RatingCurve : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int RatingCurveID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID")]
        [CSSPForeignKey(TableName = "HydrometricSites", FieldName = "HydrometricSiteID")]
        public int HydrometricSiteID { get; set; }
        [CSSPMaxLength(50)]
        public string RatingCurveNumber { get; set; }
        #endregion Properties in DB

        #region Constructors
        public RatingCurve() : base()
        {
        }
        #endregion Constructors
    }
}
