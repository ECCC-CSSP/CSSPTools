/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppService } from '../../app.service';
import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';
import { LanguageEnum } from './LanguageEnum';

export enum SamplingPlanTypeEnum {
    Subsector = 1,
    Municipality = 2,
}

export function SamplingPlanTypeEnum_GetOrderedText(appService: AppService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appService.AppVar$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Subsector (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Municipality (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Subsector' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Municipality' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function SamplingPlanTypeEnum_GetIDText(enumID: number, appService: AppService): string {
    let addressTypeEnunText: string;
    SamplingPlanTypeEnum_GetOrderedText(appService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
