/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
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

export function AddressTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
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

export function AddressTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let AddressTypeEnumText: string;
    AddressTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            AddressTypeEnumText = e.EnumText;
            return false;
        }
    });

    return AddressTypeEnumText;
}
