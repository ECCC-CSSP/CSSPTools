using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class Addresses
    {
        [Key]
        public int AddressID { get; set; }
        public int AddressTVItemID { get; set; }
        public int AddressType { get; set; }
        public int CountryTVItemID { get; set; }
        public int ProvinceTVItemID { get; set; }
        public int MunicipalityTVItemID { get; set; }
        [StringLength(200)]
        public string StreetName { get; set; }
        [StringLength(50)]
        public string StreetNumber { get; set; }
        public int? StreetType { get; set; }
        [StringLength(11)]
        public string PostalCode { get; set; }
        [StringLength(200)]
        public string GoogleAddressText { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(AddressTVItemID))]
        [InverseProperty(nameof(TVItems.AddressesAddressTVItem))]
        public virtual TVItems AddressTVItem { get; set; }
        [ForeignKey(nameof(CountryTVItemID))]
        [InverseProperty(nameof(TVItems.AddressesCountryTVItem))]
        public virtual TVItems CountryTVItem { get; set; }
        [ForeignKey(nameof(MunicipalityTVItemID))]
        [InverseProperty(nameof(TVItems.AddressesMunicipalityTVItem))]
        public virtual TVItems MunicipalityTVItem { get; set; }
        [ForeignKey(nameof(ProvinceTVItemID))]
        [InverseProperty(nameof(TVItems.AddressesProvinceTVItem))]
        public virtual TVItems ProvinceTVItem { get; set; }
    }
}
