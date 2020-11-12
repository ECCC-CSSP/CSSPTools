/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from 'src/app/services/app-state.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ExcelExportShowDataTypeEnum {
    FecalColiform = 1,
    Temperature = 2,
    Salinity = 3,
    P90 = 4,
    GemetricMean = 5,
    Median = 6,
    PercOfP90Over43 = 7,
    PercOfP90Over260 = 8,
}

export function GetExcelExportShowDataTypeEnum(): typeof ExcelExportShowDataTypeEnum
{
  return ExcelExportShowDataTypeEnum;
}

export function ExcelExportShowDataTypeEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Fecal Coliform (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Temperature (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Salinity (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'P90 (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Gemetric Mean (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Median (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Percent of P90 > 43 (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Percent of P90 > 260 (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Fecal Coliform' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Temperature' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Salinity' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'P90' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Gemetric Mean' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Median' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Percent of P90 > 43' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Percent of P90 > 260' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ExcelExportShowDataTypeEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    ExcelExportShowDataTypeEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
