/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from 'src/app/services/app-state.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum MapInfoDrawTypeEnum {
    Point = 1,
    Polyline = 2,
    Polygon = 3,
}

export function GetMapInfoDrawTypeEnum(): typeof MapInfoDrawTypeEnum
{
  return MapInfoDrawTypeEnum;
}

export function MapInfoDrawTypeEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Point (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Polyline (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Polygon (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Point' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Polyline' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Polygon' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function MapInfoDrawTypeEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    MapInfoDrawTypeEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
