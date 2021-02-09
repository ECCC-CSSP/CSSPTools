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
    public partial class ContactShortcut : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int ContactShortcutID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID")]
        [CSSPForeignKey(TableName = "Contacts", FieldName = "ContactID")]
        public int ContactID { get; set; }
        [CSSPMaxLength(100)]
        public string ShortCutText { get; set; }
        [CSSPMaxLength(200)]
        public string ShortCutAddress { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ContactShortcut() : base()
        {
        }
        #endregion Constructors
    }
}
