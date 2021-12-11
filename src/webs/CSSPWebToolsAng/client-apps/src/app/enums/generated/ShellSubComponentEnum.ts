/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net6.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/models/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ShellSubComponentEnum {
    Area = 1,
    Country = 2,
    MikeScenario = 3,
    Municipality = 4,
    MWQMRun = 5,
    MWQMSite = 6,
    PolSourceSite = 7,
    Province = 8,
    Root = 9,
    Sector = 10,
    Subsector = 11,
}

export function GetShellSubComponentEnum(): typeof ShellSubComponentEnum
{
  return ShellSubComponentEnum;
}

export function ShellSubComponentEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Area (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Country (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Scénario MIKE' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Municipality (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'MWQMRun (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'MWQMSite (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'PolSourceSite (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Province (fr)' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Root (fr)' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Sector (fr)' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Subsector (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Area' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Country' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'MIKE Scenario' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Municipality' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'MWQMRun' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'MWQMSite' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'PolSourceSite' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Province' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Root' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Sector' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Subsector' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ShellSubComponentEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let ShellSubComponentEnumText: string;
    ShellSubComponentEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            ShellSubComponentEnumText = e.EnumText;
            return false;
        }
    });

    return ShellSubComponentEnumText;
}
