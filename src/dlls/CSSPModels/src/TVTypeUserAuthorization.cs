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
    public partial class TVTypeUserAuthorization : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int TVTypeUserAuthorizationID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        public int ContactTVItemID { get; set; }
        [CSSPEnumType]
        public TVTypeEnum TVType { get; set; }
        [CSSPEnumType]
        public TVAuthEnum TVAuth { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TVTypeUserAuthorization() : base()
        {
        }
        #endregion Constructors
    }
}
