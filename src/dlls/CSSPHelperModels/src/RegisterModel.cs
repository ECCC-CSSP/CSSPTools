/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPEnums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class RegisterModel
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(100)]
        [CSSPMinLength(1)]
        public string FirstName { get; set; }
        [CSSPMaxLength(100)]
        [CSSPAllowNull]
        public string Initial { get; set; }
        [CSSPMaxLength(100)]
        [CSSPMinLength(1)]
        public string LastName { get; set; }
        [CSSPMaxLength(100)]
        [CSSPMinLength(5)]
        public string LoginEmail { get; set; }
        [CSSPMaxLength(50)]
        [CSSPMinLength(5)]
        public string Password { get; set; }
        [CSSPMaxLength(50)]
        [CSSPMinLength(5)]
        public string ConfirmPassword { get; set; }
        [CSSPAllowNull]
        [CSSPEnumType]
        public ContactTitleEnum? ContactTitle { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public RegisterModel() : base()
        {
        }
        #endregion Constructors
    }
}
