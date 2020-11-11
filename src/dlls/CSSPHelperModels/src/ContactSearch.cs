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

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class ContactSearch
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, -1)]
        public int ContactID { get; set; }
        [CSSPRange(1, -1)]
        public int ContactTVItemID { get; set; }
        [CSSPMaxLength(255)]
        public string FullName { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ContactSearch() : base()
        {
        }
        #endregion Constructors
    }
}
