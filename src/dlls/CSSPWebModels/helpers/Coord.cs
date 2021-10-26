/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Linq;
using CSSPCustomAttributes;

namespace CSSPWebModels
{
    [NotMapped]
    public class Coord
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Ordinal { get; set; }

        public Coord()
        {
        }
    }
}
