/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from '../../services/app-state.service';
import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';
import { LanguageEnum } from './LanguageEnum';

export enum ShellSubComponentEnum {
    Root = 1,
    Country = 2,
    Province = 3,
    Area = 4,
    Sector = 5,
    Subsector = 6,
}

export function GetShellSubComponentEnum(): typeof ShellSubComponentEnum
{
  return ShellSubComponentEnum;
}

export function ShellSubComponentEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Root (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Country (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Province (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Area (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Sector (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Subsector (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Root' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Country' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Province' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Area' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Sector' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Subsector' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ShellSubComponentEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    ShellSubComponentEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
