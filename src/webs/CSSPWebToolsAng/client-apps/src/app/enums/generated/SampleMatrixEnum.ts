/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum SampleMatrixEnum {
    W = 1,
    S = 2,
    B = 3,
    MPNQ = 4,
    SampleMatrix5 = 5,
    SampleMatrix6 = 6,
    Water = 7,
}

export function GetSampleMatrixEnum(): typeof SampleMatrixEnum
{
  return SampleMatrixEnum;
}

export function SampleMatrixEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'W (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'S (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'B (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'MPNQ (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Sample Matrix 5 (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Sample Matrix 6 (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Water (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'W' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'S' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'B' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'MPNQ' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Sample Matrix 5' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Sample Matrix 6' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Water' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function SampleMatrixEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let SampleMatrixEnumText: string;
    SampleMatrixEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            SampleMatrixEnumText = e.EnumText;
            return false;
        }
    });

    return SampleMatrixEnumText;
}
