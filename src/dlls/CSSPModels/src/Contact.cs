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
    public partial class Contact : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int ContactID { get; set; }
        [CSSPExist(ExistTypeName = "AspNetUser", ExistPlurial = "s", ExistFieldID = "Id")]
        [CSSPMaxLength(128)]
        public string Id { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        public int ContactTVItemID { get; set; }
        [CSSPMaxLength(255)]
        [CSSPMinLength(6)]
        [DataType(DataType.EmailAddress)]
        public string LoginEmail { get; set; }
        [CSSPMaxLength(100)]
        public string FirstName { get; set; }
        [CSSPMaxLength(100)]
        public string LastName { get; set; }
        [CSSPMaxLength(50)]
        [CSSPAllowNull]
        public string Initial { get; set; }
        [CSSPMaxLength(100)]
        public string WebName { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        public ContactTitleEnum? ContactTitle { get; set; }
        public bool IsAdmin { get; set; }
        public bool EmailValidated { get; set; }
        public bool Disabled { get; set; }
        public bool IsNew { get; set; }
        [CSSPMaxLength(200)]
        [CSSPAllowNull]
        public string SamplingPlanner_ProvincesTVItemID { get; set; }
        [CSSPMaxLength(255)]
        [CSSPAllowNull]
        public string Token { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Contact() : base()
        {
        }
        #endregion Constructors
    }
}
