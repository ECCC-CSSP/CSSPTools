/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppService } from '../../app.service';
import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';
import { LanguageEnum } from './LanguageEnum';

export enum AerationTypeEnum {
    MechanicalAirLines = 1,
    MechanicalSurfaceMixers = 2,
}

export function AerationTypeEnum_GetOrderedText(appService: AppService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appService.AppVar$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Ligne d\'air méchanique' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Mélangeurs de surface mécaniques' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Mechanical Air Lines' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Mechanical Surface Mixers' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AerationTypeEnum_GetIDText(enumID: number, appService: AppService): string {
    let addressTypeEnunText: string;
    AerationTypeEnum_GetOrderedText(appService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
