/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.model';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { TranslationStatusEnum } from '../../enums/generated/TranslationStatusEnum';

export class MWQMRunLanguage extends LastUpdate {
    Language: LanguageEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    MWQMRunID: number;
    MWQMRunLanguageID: number;
    RunComment: string;
    RunWeatherComment: string;
    TranslationStatusRunComment: TranslationStatusEnum;
    TranslationStatusRunWeatherComment: TranslationStatusEnum;
}
