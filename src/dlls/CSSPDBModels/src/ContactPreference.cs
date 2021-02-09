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
    public partial class ContactPreference : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int ContactPreferenceID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID")]
        [CSSPForeignKey(TableName = "Contacts", FieldName = "ContactID")]
        public int ContactID { get; set; }
        [CSSPEnumType]
        public TVTypeEnum TVType { get; set; }
        [CSSPRange(1, 1000)]
        public int MarkerSize { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ContactPreference() : base()
        {
        }
        #endregion Constructors
    }
}
