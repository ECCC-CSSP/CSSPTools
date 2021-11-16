/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class LatLng
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(-180.0D, 180.0D)]
        public double Lat { get; set; }
        [CSSPRange(-90.0D, 90.0D)]
        public double Lng { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LatLng() : base()
        {
        }
        #endregion Constructors
    }
}
