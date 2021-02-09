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
    public partial class PolSourceObservationIssue : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int PolSourceObservationIssueID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "PolSourceObservation", ExistPlurial = "s", ExistFieldID = "PolSourceObservationID")]
        [CSSPForeignKey(TableName = "PolSourceObservations", FieldName = "PolSourceObservationID")]
        public int PolSourceObservationID { get; set; }
        [CSSPMaxLength(250)]
        public string ObservationInfo { get; set; }
        [CSSPRange(0, 1000)]
        public int Ordinal { get; set; }
        [CSSPAllowNull]
        public string ExtraComment { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceObservationIssue() : base()
        {
        }
        #endregion Constructors
    }
}
