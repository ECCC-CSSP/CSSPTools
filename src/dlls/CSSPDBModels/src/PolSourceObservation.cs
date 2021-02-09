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

namespace CSSPDBModels
{
    public partial class PolSourceObservation : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int PolSourceObservationID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "PolSourceSite", ExistPlurial = "s", ExistFieldID = "PolSourceSiteID")]
        [CSSPForeignKey(TableName = "PolSourceSites", FieldName = "PolSourceSiteID")]
        public int PolSourceSiteID { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime ObservationDate_Local { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int ContactTVItemID { get; set; }
        public bool DesktopReviewed { get; set; }
        public string Observation_ToBeDeleted { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceObservation() : base()
        {
        }
        #endregion Constructors
    }
}
