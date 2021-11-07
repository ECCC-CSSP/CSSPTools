import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { FileLocalizeSwitchService } from '.';
import { AppLanguageService } from '../app/app-language.service';
import { AppStateService } from '../app/app-state.service';
import { TogglesService } from '../helpers/toggles.service';
import { LocalFileInfoService } from './local-file-info.service';

@Injectable({
    providedIn: 'root'
})
export class FileLocalizeAllAzureFileService {
    private sub: Subscription;
    private tvType: TVTypeEnum;

    Cancel = false;
    StartTotalFilesCount: number = 0;
    TVFileModelList: TVFileModel[] = [];
    TotalFileSize: number = 0;

    constructor(private httpClient: HttpClient,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        public appStateService: AppStateService,
        private toggleService: TogglesService,
        private fileLocalizeSwitchService: FileLocalizeSwitchService,
        private localFileInfoService: LocalFileInfoService) {
    }

    LocalizeAllAzureFile(tvType: TVTypeEnum) {
        this.Cancel = false;
        this.tvType = tvType;

        if (this.TVFileModelList != undefined && this.TVFileModelList?.length > 0) {
            this.LocalizeAzureFile();
        }
    }

    CancelLocalizeAllAzureFile() {
        this.Cancel = true;
        this.sub ? this.sub.unsubscribe() : null;
        this.appStateService.Status = '';
        this.appStateService.Working = false;
        this.TotalFileSize = 0;
        this.StartTotalFilesCount = 0;
        this.TVFileModelList = [];
}

    AddTVFileModelList(tvFileModelList: TVFileModel[]) {
        let TempTotalFileSize: number = 0;
        for (let i = 0, count = tvFileModelList.length; i < count; i++) {
            let tvFileModelListExist: TVFileModel[] = this.TVFileModelList.filter(c => c.TVItemModel.TVItem.TVItemID == tvFileModelList[i].TVItemModel.TVItem.TVItemID);

            if (tvFileModelListExist == undefined || tvFileModelListExist.length == 0) {
                this.TVFileModelList.push(tvFileModelList[i]);
            }
        }

        for (let i = 0, count = this.TVFileModelList.length; i < count; i++) {
            TempTotalFileSize += this.TVFileModelList[i].TVFile?.FileSize_kb;
        }

        this.TotalFileSize = TempTotalFileSize;
        this.StartTotalFilesCount = this.TVFileModelList.length;
    }


    private LocalizeAzureFile() {
        if (this.TVFileModelList.length > 0) {
            this.sub ? this.sub.unsubscribe() : null;
            this.sub = this.DoLocalizeAzureFile().subscribe();
        }
    }

    private DoLocalizeAzureFile() {
        let languageEnum = GetLanguageEnum();
        let ParentTVItemID = this.TVFileModelList[0].TVItemModel.TVItem.ParentID;
        let FileName = encodeURI(this.TVFileModelList[0].TVFile?.ServerFileName).replace('#', '%23');
        let FileSize_kb = this.TVFileModelList[0].TVFile?.FileSize_kb;

        FileName = FileName.replace('.mdf', '.mmdf');

        this.localFileInfoService.GetLocalFileInfo(ParentTVItemID, FileName, FileSize_kb);

        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/localizeazurefile/${ParentTVItemID}/${FileName}`;

        return this.httpClient.get<boolean>(url).pipe(map((x: boolean) => { this.DoLocalizeAzureFileUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoLocalizeAzureFileError(e); }))));
    }

    private DoLocalizeAzureFileUpdate(x: boolean) {
        this.fileLocalizeSwitchService.DoFileLocalizeSwitch(this.tvType, this.TVFileModelList[0], x);
        this.TVFileModelList.shift();
        if (this.TVFileModelList.length > 0 && !this.Cancel) {            
            this.LocalizeAllAzureFile(this.tvType);
        }
        else {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
            this.TotalFileSize = 0;
            this.StartTotalFilesCount = 0;
            console.debug(x);

            this.toggleService.ReloadPage();
        }
    }

    private DoLocalizeAzureFileError(e: any) {
        this.fileLocalizeSwitchService.DoFileLocalizeSwitch(this.tvType, this.TVFileModelList[0], false);
        this.TVFileModelList.shift();
        if (this.TVFileModelList.length > 0 && !this.Cancel) {
            this.LocalizeAllAzureFile(this.tvType);
        }
        else {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
            this.TotalFileSize = 0;
            this.StartTotalFilesCount = 0;

            this.toggleService.ReloadPage();
        }

    }

}
