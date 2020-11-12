/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from 'src/app/services/app-state.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum LabSheetStatusEnum {
    Created = 1,
    Transferred = 2,
    Accepted = 3,
    Rejected = 4,
}

export function GetLabSheetStatusEnum(): typeof LabSheetStatusEnum
{
  return LabSheetStatusEnum;
}

export function LabSheetStatusEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Created (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Transferred (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepté' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Created' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Transferred' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepted' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function LabSheetStatusEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    LabSheetStatusEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
