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
    public partial class SamplingPlanEmail : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int SamplingPlanEmailID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID")]
        [CSSPForeignKey(TableName = "SamplingPlans", FieldName = "SamplingPlanID")]
        public int SamplingPlanID { get; set; }
        [CSSPMaxLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsContractor { get; set; }
        public bool LabSheetHasValueOver500 { get; set; }
        public bool LabSheetReceived { get; set; }
        public bool LabSheetAccepted { get; set; }
        public bool LabSheetRejected { get; set; }
        #endregion Properties in DB

        #region Constructors
        public SamplingPlanEmail() : base()
        {
        }
        #endregion Constructors
    }
}
