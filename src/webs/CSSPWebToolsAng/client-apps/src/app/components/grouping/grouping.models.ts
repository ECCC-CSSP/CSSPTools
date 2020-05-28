import { HttpRequestModel } from '../../models/http.model';

export interface GroupingTextModel {
    Title?: string
}

export interface GroupSourceGroupingModel extends HttpRequestModel {
    PolSourceGroupingList: PolSourceGrouping[];
    PolSourceGroupingLanguageList: PolSourceGroupingLanguage[];
}

export interface PolSourceGrouping {
    PolSourceGroupingID: number;
    CSSPID: number;
    GroupName: string;
    Child: string;
    Hide: string;
    LastUpdateDate_UTC: Date;
    LastUpdateContactTVItemID: number;
}

export interface PolSourceGroupingLanguage {
    PolSourceGroupingLanguageID: number;
    PolSourceGroupingID: number;
    Language: number;
    SourceName: string;
    SourceNameOrder: number;
    TranslationStatusSourceName: number;
    Init: string;
    TranslationStatusInit: number;
    Description: string;
    TranslationStatusDescription: number;
    Report: string;
    TranslationStatusReport: number;
    Text: string;
    TranslationStatusText: number;
    LastUpdateDate_UTC: Date;
    LastUpdateContactTVItemID: number;
}

export enum LanguageEnum {
    en = 1,
    fr = 2,
}

export enum TranslationStatusDescription {
    NotTranslated = 1,
    ElectronicallyTranslated = 2,
    Translated = 3,
}