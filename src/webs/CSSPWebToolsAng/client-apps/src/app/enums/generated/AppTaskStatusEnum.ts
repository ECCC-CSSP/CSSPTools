/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum AppTaskStatusEnum {
    Created = 1,
    Running = 2,
    Completed = 3,
    Cancelled = 4,
}

export function GetAppTaskStatusEnum(): typeof AppTaskStatusEnum
{
  return AppTaskStatusEnum;
}

export function AppTaskStatusEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Créé' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'En traitement' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Terminé' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Annulé' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Created' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Running' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Completed' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Cancelled' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AppTaskStatusEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let AppTaskStatusEnumText: string;
    AppTaskStatusEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            AppTaskStatusEnumText = e.EnumText;
            return false;
        }
    });

    return AppTaskStatusEnumText;
}
