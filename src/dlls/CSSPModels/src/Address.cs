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
    public partial class Address : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Address ID")]
        [CSSPDisplayFR(DisplayFR = "Address ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the Addresses table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table Adresses")]
        public int AddressID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "2")]
        [CSSPDisplayEN(DisplayEN = "Address TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Address TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems avec l'identifiant unique")]
        public int AddressTVItemID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Address type")]
        [CSSPDisplayFR(DisplayFR = "Type d'address")]
        [CSSPDescriptionEN(DescriptionEN = @"Address type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'adresse")]
        public AddressTypeEnum AddressType { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "6")]
        [CSSPDisplayEN(DisplayEN = "Country")]
        [CSSPDisplayFR(DisplayFR = "Pays")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the country")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le pays")]
        public int CountryTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "18")]
        [CSSPDisplayEN(DisplayEN = "Province")]
        [CSSPDisplayFR(DisplayFR = "Province")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the province")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la province")]
        public int ProvinceTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "15")]
        [CSSPDisplayEN(DisplayEN = "Municipality")]
        [CSSPDisplayFR(DisplayFR = "Municipalité")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the municipality")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la municipalité")]
        public int MunicipalityTVItemID { get; set; }
        [StringLength(200)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Street name")]
        [CSSPDisplayFR(DisplayFR = "Nom de la rue")]
        [CSSPDescriptionEN(DescriptionEN = @"Street name of the address")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de la rue de l'adresse")]
        public string StreetName { get; set; }
        [StringLength(50)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Street number")]
        [CSSPDisplayFR(DisplayFR = "Numéro de la rue")]
        [CSSPDescriptionEN(DescriptionEN = @"Street number of the address")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro de la rue de l'adresse")]
        public string StreetNumber { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Street type")]
        [CSSPDisplayFR(DisplayFR = "Type de rue")]
        [CSSPDescriptionEN(DescriptionEN = @"Street type of the address")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de rue de l'adresse")]
        public StreetTypeEnum? StreetType { get; set; }
        [StringLength(11, MinimumLength = 6)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Postal code")]
        [CSSPDisplayFR(DisplayFR = "Code postale")]
        [CSSPDescriptionEN(DescriptionEN = @"Postal code of the address")]
        [CSSPDescriptionFR(DescriptionFR = @"Code postale de l'adresse")]
        public string PostalCode { get; set; }
        [StringLength(200, MinimumLength = 10)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Google address")]
        [CSSPDisplayFR(DisplayFR = "Adresse Google")]
        [CSSPDescriptionEN(DescriptionEN = @"Google address provided by Google Location Service")]
        [CSSPDescriptionFR(DescriptionFR = @"Adresse Google fourni par le service Google Location")]
        public string GoogleAddressText { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Address() : base()
        {
        }
        #endregion Constructors
    }
}
