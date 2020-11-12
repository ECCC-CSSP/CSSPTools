/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from 'src/app/services/app-state.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum AddressTypeEnum {
    Mailing = 1,
    Shipping = 2,
    Civic = 3,
}

export function GetAddressTypeEnum(): typeof AddressTypeEnum
{
  return AddressTypeEnum;
}

export function AddressTypeEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Postale' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Livraison' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Civic (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Mailing' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Shipping' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Civic' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AddressTypeEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    AddressTypeEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
