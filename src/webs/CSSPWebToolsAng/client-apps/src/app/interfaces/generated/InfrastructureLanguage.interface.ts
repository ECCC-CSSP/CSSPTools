/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularInterfacesGenerated\bin\Debug\netcoreapp3.1\AngularInterfacesGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.interface';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { TranslationStatusEnum } from '../../enums/generated/TranslationStatusEnum';

export interface InfrastructureLanguage extends LastUpdate {
    Comment: string;
    InfrastructureID: number;
    InfrastructureLanguageID: number;
    Language: LanguageEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    TranslationStatus: TranslationStatusEnum;
}
