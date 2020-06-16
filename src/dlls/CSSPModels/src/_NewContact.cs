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
    public partial class NewContact
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(200)]
        [CSSPMinLength(1)]
        public string LoginEmail { get; set; }
        [CSSPMaxLength(200)]
        [CSSPMinLength(1)]
        public string FirstName { get; set; }
        [CSSPMaxLength(200)]
        [CSSPMinLength(1)]
        public string LastName { get; set; }
        [CSSPMaxLength(50)]
        [CSSPAllowNull]
        public string Initial { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        public ContactTitleEnum? ContactTitle { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "ContactTitleEnum", EnumType = "ContactTitle")]
        [CSSPAllowNull]
        public string ContactTitleText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public NewContact() : base()
        {
        }
        #endregion Constructors
    }
}
