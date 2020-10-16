/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppService } from '../../app.service';
import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';
import { LanguageEnum } from './LanguageEnum';

export enum DailyOrHourlyDataEnum {
    Daily = 1,
    Hourly = 2,
}

export function DailyOrHourlyDataEnum_GetOrderedText(appService: AppService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appService.AppVar$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Daily (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Hourly (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Daily' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Hourly' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function DailyOrHourlyDataEnum_GetIDText(enumID: number, appService: AppService): string {
    let addressTypeEnunText: string;
    DailyOrHourlyDataEnum_GetOrderedText(appService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
