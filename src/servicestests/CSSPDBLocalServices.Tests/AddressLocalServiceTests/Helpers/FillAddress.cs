namespace CSSPDBLocalServices.Tests;

public partial class AddressLocalServiceTest
{
    private Address FillAddress()
    {
        return new Address()
        {
            AddressID = 0,
            //DBCommand = DBCommandEnum.Created,
            AddressTVItemID = 0,
            AddressType = AddressTypeEnum.Civic,
            CountryTVItemID = 5,
            ProvinceTVItemID = 7,
            MunicipalityTVItemID = 27764,
            StreetName = "Main",
            StreetNumber = "1234",
            StreetType = StreetTypeEnum.Street,
            PostalCode = "E39 6S8",
            GoogleAddressText = "1245 Main, Street, Bouctouche, New Brunswick, Canada",
            //LastUpdateDate_UTC = DateTime.UtcNow,
            //LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        };
    }
}

