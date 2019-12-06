using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
  public  class AddressModel : LastUpdateAndContactModel
    {
      public AddressModel()
      {
      }
      public int AddressID { get; set; }
      public int AddressTVItemID { get; set; }
      public string AddressTVText { get; set; }
      public AddressTypeEnum AddressType { get; set; }
      public string AddressTypeText { get; set; }
      public int CountryTVItemID { get; set; }
      public string CountryTVText { get; set; }
      public int ProvinceTVItemID { get; set; }
      public string ProvinceTVText { get; set; }
      public int MunicipalityTVItemID { get; set; }
      public string MunicipalityTVText { get; set; }
      public string StreetName { get; set; }
      public string StreetNumber { get; set; }
      public Nullable<StreetTypeEnum> StreetType { get; set; }
      public string StreetTypeText { get; set; }
      public string PostalCode { get; set; }
      public string GoogleAddressText { get; set; }
      public string LatLngText { get; set; }
    }
}
