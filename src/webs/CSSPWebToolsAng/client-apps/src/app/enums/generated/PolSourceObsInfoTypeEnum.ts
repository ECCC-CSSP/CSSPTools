/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum PolSourceObsInfoTypeEnum {
    Description = 1,
    Report = 2,
    Text = 3,
    Initial = 4,
}

export function GetPolSourceObsInfoTypeEnum(): typeof PolSourceObsInfoTypeEnum
{
  return PolSourceObsInfoTypeEnum;
}

export function PolSourceObsInfoTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Description (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Report (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Text (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Initial (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Description' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Report' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Text' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Initial' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function PolSourceObsInfoTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let addressTypeEnunText: string;
    PolSourceObsInfoTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
