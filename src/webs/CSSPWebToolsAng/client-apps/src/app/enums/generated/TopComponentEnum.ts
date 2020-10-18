/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from '../../services/app-state.service';
import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';
import { LanguageEnum } from './LanguageEnum';

export enum TopComponentEnum {
    Home = 1,
    Shell = 2,
}

export function GetTopComponentEnum(): typeof TopComponentEnum
{
  return TopComponentEnum;
}

export function TopComponentEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Home (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Shell (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Home' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Shell' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function TopComponentEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    TopComponentEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
