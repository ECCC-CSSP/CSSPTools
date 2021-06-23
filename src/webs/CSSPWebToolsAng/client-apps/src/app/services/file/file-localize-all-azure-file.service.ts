import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { LocalFileInfo } from 'src/app/models/generated/web/LocalFileInfo.model';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { FileLocalizeSwitchService } from '.';
import { AppLanguageService } from '../app/app-language.service';
import { AppStateService } from '../app/app-state.service';
import { TogglesService } from '../helpers/toggles.service';

@Injectable({
    providedIn: 'root'
})
export class FileLocalizeAllAzureFileService {
    private sub: Subscription;
    private intervalId: any;
    private tvType: TVTypeEnum;

    Progress: number = 0;
    StartTotalFilesCount: number = 0;
    TVFileModelList: TVFileModel[] = [];
    TotalFileSize: number = 0;

    constructor(private httpClient: HttpClient,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        public appStateService: AppStateService,
        private toggleService: TogglesService,
        private fileLocalizeSwitchService: FileLocalizeSwitchService) {
    }

    LocalizeAllAzureFile(tvType: TVTypeEnum) {
        this.tvType = tvType;

        if (this.TVFileModelList != undefined && this.TVFileModelList?.length > 0) {
            this.LocalizeAzureFile();
        }
    }

    AddTVFileModelList(tvFileModelList: TVFileModel[]) {
        let TempTotalFileSize: number = 0;
        for (let i = 0, count = tvFileModelList.length; i < count; i++) {
            let tvFileModelListExist: TVFileModel[] = this.TVFileModelList.filter(c => c.TVItem.TVItemID == tvFileModelList[i].TVItem.TVItemID);

            if (tvFileModelListExist == undefined || tvFileModelListExist.length == 0) {
                this.TVFileModelList.push(tvFileModelList[i]);
            }
        }

        for (let i = 0, count = this.TVFileModelList.length; i < count; i++) {
            TempTotalFileSize += this.TVFileModelList[i].TVFile.FileSize_kb;
        }

        this.TotalFileSize = TempTotalFileSize;
        this.StartTotalFilesCount = this.TVFileModelList.length;
    }

    GetLocalFileInfo() {
        if (this.TVFileModelList.length > 0) {
            this.sub ? this.sub.unsubscribe() : null;
            this.sub = this.DoGetLocalFileInfo().subscribe();
        }
    }

    private DoGetLocalFileInfo() {
        let languageEnum = GetLanguageEnum();
        let ParentTVItemID = this.TVFileModelList[0].TVItem.ParentID;
        let FileName = this.TVFileModelList[0].TVFile.ServerFileName;

        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/GetLocalFileInfo/${ParentTVItemID}/${FileName}`;

        return this.httpClient.get<LocalFileInfo>(url).pipe(map((x: LocalFileInfo) => { this.DoGetLocalFileInfoUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoLocalizeAzureFileError(e); }))));
    }

    private DoGetLocalFileInfoUpdate(x: LocalFileInfo) {
        if (this.intervalId) {
            clearInterval(this.intervalId);
        }

        this.Progress = x.Length / this.TVFileModelList[0].TVFile.FileSize_kb * 100;
        this.intervalId = setInterval(() => this.GetLocalFileInfo(), 10000);
    }

    private LocalizeAzureFile() {
        if (this.TVFileModelList.length > 0) {
            this.sub ? this.sub.unsubscribe() : null;
            this.sub = this.DoLocalizeAzureFile().subscribe();
        }
    }

    private DoLocalizeAzureFile() {
        let languageEnum = GetLanguageEnum();
        let ParentTVItemID = this.TVFileModelList[0].TVItem.ParentID;
        let FileName = this.TVFileModelList[0].TVFile.ServerFileName;

        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/localizeazurefile/${ParentTVItemID}/${FileName}`;

        return this.httpClient.get<boolean>(url).pipe(map((x: boolean) => { this.DoLocalizeAzureFileUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoLocalizeAzureFileError(e); }))));
    }

    private DoLocalizeAzureFileUpdate(x: boolean) {
        // if (!x) {
        //     this.appStateService.Error = new HttpErrorResponse({ error: `File: ${this.TVFileModelList[0].TVFile.ServerFileName} not downloaded`, status: 403 });
        // }

        this.fileLocalizeSwitchService.DoFileLocalizeSwitch(this.tvType, this.TVFileModelList[0], x);
        this.TVFileModelList.shift();
        if (this.TVFileModelList.length > 0) {
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
        // this.appStateService.Error = <HttpErrorResponse>e;
        // console.debug(e);

        this.fileLocalizeSwitchService.DoFileLocalizeSwitch(this.tvType, this.TVFileModelList[0], false);
        this.TVFileModelList.shift();
        if (this.TVFileModelList.length > 0) {
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
