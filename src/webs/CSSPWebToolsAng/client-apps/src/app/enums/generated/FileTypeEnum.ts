/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net6.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/models/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum FileTypeEnum {
    DFS0 = 1,
    DFS1 = 2,
    DFSU = 3,
    KMZ = 4,
    LOG = 5,
    M21FM = 6,
    M3FM = 7,
    MDF = 8,
    MESH = 9,
    XLSX = 10,
    DOCX = 11,
    PDF = 12,
    JPG = 13,
    JPEG = 14,
    GIF = 15,
    PNG = 16,
    HTML = 17,
    TXT = 18,
    XYZ = 19,
    KML = 20,
    CSV = 21,
    WMV = 22,
}

export function GetFileTypeEnum(): typeof FileTypeEnum
{
  return FileTypeEnum;
}

export function FileTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'DFS0 (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'DFS1 (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'DFSU (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'KMZ (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'LOG (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'M21FM (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'M3FM (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'MDF (fr)' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'MESH (fr)' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'XLSX (fr)' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'DOCX (fr)' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'PDF (fr)' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'JPG (fr)' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'JPEG (fr)' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'GIF (fr)' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'PNG (fr)' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'HTML (fr)' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'TXT (fr)' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'XYZ (fr)' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'KML (fr)' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'CSV' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'WMV' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'DFS0' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'DFS1' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'DFSU' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'KMZ' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'LOG' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'M21FM' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'M3FM' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'MDF' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'MESH' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'XLSX' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'DOCX' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'PDF' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'JPG' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'JPEG' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'GIF' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'PNG' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'HTML' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'TXT' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'XYZ' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'KML' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'CSV' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'WMV' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function FileTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let FileTypeEnumText: string;
    FileTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            FileTypeEnumText = e.EnumText;
            return false;
        }
    });

    return FileTypeEnumText;
}
