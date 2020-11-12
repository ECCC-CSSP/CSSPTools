/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from 'src/app/services/app-state.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum PolSourceInactiveReasonEnum {
    Abandoned = 1,
    Closed = 2,
    Removed = 3,
}

export function GetPolSourceInactiveReasonEnum(): typeof PolSourceInactiveReasonEnum
{
  return PolSourceInactiveReasonEnum;
}

export function PolSourceInactiveReasonEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Abandoned (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Closed (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Removed (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Abandoned' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Closed' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Removed' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function PolSourceInactiveReasonEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    PolSourceInactiveReasonEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
