/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularModelsGenerated\bin\Debug\netcoreapp3.1\AngularModelsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.model';
import { AddressTypeEnum } from '../../enums/generated/AddressTypeEnum';
import { StreetTypeEnum } from '../../enums/generated/StreetTypeEnum';

export class Address extends LastUpdate {
    AddressID: number;
    AddressTVItemID: number;
    AddressType: AddressTypeEnum;
    CountryTVItemID: number;
    GoogleAddressText: string;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    MunicipalityTVItemID: number;
    PostalCode: string;
    ProvinceTVItemID: number;
    StreetName: string;
    StreetNumber: string;
    StreetType?: StreetTypeEnum;
}