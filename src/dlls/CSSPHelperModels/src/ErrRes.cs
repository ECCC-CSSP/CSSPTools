/*
 * Manually edited
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public class ErrRes
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public List<string> ErrList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ErrRes()
        {
            ErrList = new List<string>();
        }
        #endregion Constructors
    }
}
