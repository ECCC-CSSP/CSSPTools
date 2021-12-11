/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net6.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TranslationStatusEnum } from 'src/app/enums/generated/TranslationStatusEnum';

export class MWQMSampleLanguage extends LastUpdate {
    DBCommand: DBCommandEnum;
    Language: LanguageEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    MWQMSampleID: number;
    MWQMSampleLanguageID: number;
    MWQMSampleNote: string;
    TranslationStatus: TranslationStatusEnum;
}
