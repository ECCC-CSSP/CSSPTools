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
    public partial class EmailDistributionListContact : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int EmailDistributionListContactID { get; set; }
        [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID")]
        public int EmailDistributionListID { get; set; }
        public bool IsCC { get; set; }
        [CSSPMaxLength(100)]
        public string Name { get; set; }
        [CSSPMaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool CMPRainfallSeasonal { get; set; }
        public bool CMPWastewater { get; set; }
        public bool EmergencyWeather { get; set; }
        public bool EmergencyWastewater { get; set; }
        public bool ReopeningAllTypes { get; set; }
        #endregion Properties in DB

        #region Constructors
        public EmailDistributionListContact() : base()
        {
        }
        #endregion Constructors
    }
}
