using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class Addresses
    {
        public int AddressID { get; set; }
        public int AddressTVItemID { get; set; }
        public int AddressType { get; set; }
        public int CountryTVItemID { get; set; }
        public int ProvinceTVItemID { get; set; }
        public int MunicipalityTVItemID { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public int? StreetType { get; set; }
        public string PostalCode { get; set; }
        public string GoogleAddressText { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems AddressTVItem { get; set; }
        public virtual TVItems CountryTVItem { get; set; }
        public virtual TVItems MunicipalityTVItem { get; set; }
        public virtual TVItems ProvinceTVItem { get; set; }
    }
}
