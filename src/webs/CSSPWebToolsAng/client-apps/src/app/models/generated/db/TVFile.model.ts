/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net6.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { FilePurposeEnum } from 'src/app/enums/generated/FilePurposeEnum';
import { FileTypeEnum } from 'src/app/enums/generated/FileTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

export class TVFile extends LastUpdate {
    ClientFilePath: string;
    DBCommand: DBCommandEnum;
    FileCreatedDate_UTC: Date;
    FileInfo: string;
    FilePurpose: FilePurposeEnum;
    FileSize_kb: number;
    FileType: FileTypeEnum;
    FromWater?: boolean;
    Language: LanguageEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    Parameters: string;
    ReportTypeID?: number;
    ServerFileName: string;
    ServerFilePath: string;
    TemplateTVType?: TVTypeEnum;
    TVFileID: number;
    TVFileTVItemID: number;
    Year?: number;
}
