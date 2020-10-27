/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from '../../services/app-state.service';
import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';
import { LanguageEnum } from './LanguageEnum';

export enum FilesSortPropEnum {
    FileName = 1,
    FileSize = 2,
    FileType = 3,
    FilePurpose = 4,
}

export function GetFilesSortPropEnum(): typeof FilesSortPropEnum
{
  return FilesSortPropEnum;
}

export function FilesSortPropEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Nom de filière' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Grosseur de filière' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Type de filière' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'But de filière' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'File name' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'File size' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'File type' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'File purpose' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function FilesSortPropEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    FilesSortPropEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
