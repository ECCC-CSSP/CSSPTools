/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class FileItem
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string Name { get; set; }
        [CSSPRange(1, -1)]
        public int TVItemID { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public FileItem() : base()
        {
        }
        #endregion Constructors
    }
}
