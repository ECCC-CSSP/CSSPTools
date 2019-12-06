using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
   public class TVItemUserAuthorizationModel : LastUpdateAndContactModel
    {
       public TVItemUserAuthorizationModel()
       {
       }
       public int TVItemUserAuthorizationID { get; set; }
       public int ContactTVItemID { get; set; }
       public int TVItemID1 { get; set; }
       public string TVText1 { get; set; }
       public string TVPath1 { get; set; }
       public int TVLevel1 { get; set; }
       public Nullable<int> TVItemID2 { get; set; }
       public string TVText2 { get; set; }
       public string TVPath2 { get; set; }
       public int TVLevel2 { get; set; }
       public Nullable<int> TVItemID3 { get; set; }
       public string TVText3 { get; set; }
       public string TVPath3 { get; set; }
       public int TVLevel3 { get; set; }
       public Nullable<int> TVItemID4 { get; set; }
       public string TVText4 { get; set; }
       public string TVPath4 { get; set; }
       public TVAuthEnum TVAuth { get; set; }
       public int TVLevel4 { get; set; }
    }
}
