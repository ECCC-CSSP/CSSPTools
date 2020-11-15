/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from 'src/app/services/app-state.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum LocalDBCommandEnum {
    Change = 1,
    New = 2,
    Delete = 3,
}

export function GetLocalDBCommandEnum(): typeof LocalDBCommandEnum
{
  return LocalDBCommandEnum;
}

export function LocalDBCommandEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Changer' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Nouveau' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Effacer' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Change' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'New' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Delete' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function LocalDBCommandEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    LocalDBCommandEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}