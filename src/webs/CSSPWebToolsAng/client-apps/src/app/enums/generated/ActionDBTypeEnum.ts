/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from '../../services/app-state.service';
import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';
import { LanguageEnum } from './LanguageEnum';

export enum ActionDBTypeEnum {
    Create = 1,
    Read = 2,
    Update = 3,
    Delete = 4,
}

export function GetActionDBTypeEnum(): typeof ActionDBTypeEnum
{
  return ActionDBTypeEnum;
}

export function ActionDBTypeEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Créer' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Lire' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Mettre à jour' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Effacer' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Create' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Read' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Update' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Delete' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ActionDBTypeEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    ActionDBTypeEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
