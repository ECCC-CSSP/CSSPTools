using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
   public class TVTypeUserAuthorizationModel : LastUpdateAndContactModel
    {
       public TVTypeUserAuthorizationModel()
       {
       }
       public int TVTypeUserAuthorizationID { get; set; }
       public int ContactTVItemID { get; set; }
       public TVTypeEnum TVType { get; set; }
       public string TVPath { get; set; }
       public int TVLevel { get; set; }
       public TVAuthEnum TVAuth { get; set; }
    }
}
