/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppService } from '../../app.service';
import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';
import { LanguageEnum } from './LanguageEnum';

export enum WebTypeYearEnum {
    Year1980 = 1,
    Year1990 = 2,
    Year2000 = 3,
    Year2010 = 4,
    Year2020 = 5,
    Year2030 = 6,
    Year2040 = 7,
    Year2050 = 8,
}

export function WebTypeYearEnum_GetOrderedText(appService: AppService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appService.AppVar$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'WebTypeYear1980 (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'WebTypeYear1990 (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'WebTypeYear2000 (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'WebTypeYear2010 (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'WebTypeYear2020 (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'WebTypeYear2030 (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'WebTypeYear2040 (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'WebTypeYear2050 (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'WebTypeYear1980' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'WebTypeYear1990' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'WebTypeYear2000' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'WebTypeYear2010' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'WebTypeYear2020' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'WebTypeYear2030' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'WebTypeYear2040' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'WebTypeYear2050' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function WebTypeYearEnum_GetIDText(enumID: number, appService: AppService): string {
    let addressTypeEnunText: string;
    WebTypeYearEnum_GetOrderedText(appService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
