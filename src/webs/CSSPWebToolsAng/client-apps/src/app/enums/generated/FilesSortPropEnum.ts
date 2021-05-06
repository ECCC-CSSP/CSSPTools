/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

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

export function FilesSortPropEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
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

export function FilesSortPropEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let addressTypeEnunText: string;
    FilesSortPropEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
