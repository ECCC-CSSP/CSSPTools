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
    public partial class Log : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int LogID { get; set; }
        [CSSPMaxLength(50)]
        public string TableName { get; set; }
        [CSSPRange(1, -1)]
        public int ID { get; set; }
        [CSSPEnumType]
        public LogCommandEnum LogCommand { get; set; }
        public string Information { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Log() : base()
        {
        }
        #endregion Constructors
    }
}
