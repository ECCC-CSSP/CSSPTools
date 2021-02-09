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
    public partial class RainExceedance : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int RainExceedanceID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "75")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int RainExceedanceTVItemID { get; set; }
        [CSSPRange(1, 12)]
        public int StartMonth { get; set; }
        [CSSPRange(1, 31)]
        public int StartDay { get; set; }
        [CSSPRange(1, 12)]
        public int EndMonth { get; set; }
        [CSSPRange(1, 31)]
        public int EndDay { get; set; }
        [CSSPRange(0.0D, 300.0D)]
        public double RainMaximum_mm { get; set; }
        [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID")]
        [CSSPForeignKey(TableName = "EmailDistributionLists", FieldName = "EmailDistributionListID")]
        public int? StakeholdersEmailDistributionListID { get; set; }
        [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID")]
        [CSSPForeignKey(TableName = "EmailDistributionLists", FieldName = "EmailDistributionListID")]
        public int? OnlyStaffEmailDistributionListID { get; set; }
        public bool IsActive { get; set; }
        #endregion Properties in DB

        #region Constructors
        public RainExceedance() : base()
        {
        }
        #endregion Constructors
    }
}
