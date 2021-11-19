/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net5.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TranslationStatusEnum } from 'src/app/enums/generated/TranslationStatusEnum';

export class InfrastructureLanguage extends LastUpdate {
    Comment: string;
    DBCommand: DBCommandEnum;
    InfrastructureID: number;
    InfrastructureLanguageID: number;
    Language: LanguageEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    TranslationStatus: TranslationStatusEnum;
}
