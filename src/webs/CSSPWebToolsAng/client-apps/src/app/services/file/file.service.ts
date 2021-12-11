import { Injectable } from '@angular/core';
import { FileTypeEnum, GetFileTypeEnum } from 'src/app/enums/generated/FileTypeEnum';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVFileModel } from 'src/app/models/generated/models/TVFileModel.model';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from '../app/app-language.service';
import { AppLoadedService } from '../app/app-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class FileService {

    constructor(private appStateService: AppStateService,
        private appLanguageService: AppLanguageService,
        private appLoadedService: AppLoadedService) {
    }

    GetURL(tvFileModel: TVFileModel): string {
        let ParentTVItemID = tvFileModel.TVItemModel.TVItem.ParentID;
        let FileName = encodeURI(tvFileModel.TVFile?.ServerFileName).replace('#', '%23');

        let url: string = `${this.appLoadedService.BaseApiUrl}${LanguageEnum[this.appLanguageService.Language]}-CA/Download/${ParentTVItemID}/${FileName}`;

        return url;
    }

    IsImage(tvFileModel: TVFileModel): boolean {

        switch (tvFileModel.TVFile.FileType) {
            case FileTypeEnum.GIF:
            case FileTypeEnum.JPEG:
            case FileTypeEnum.JPG:
            case FileTypeEnum.PNG:
                {
                    return true;
                }
            default:
                {
                    return false;
                }
        }
    }

}
