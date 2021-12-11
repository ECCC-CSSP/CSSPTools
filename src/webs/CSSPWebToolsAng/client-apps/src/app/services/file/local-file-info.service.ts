import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { LocalFileInfo } from 'src/app/models/generated/models/LocalFileInfo.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from '../app/app-language.service';
import { AppStateService } from '../app/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class LocalFileInfoService {
    private sub: Subscription;
    private intervalId: any;

    Progress: number = 0;
    ParentTVItemID: number = 0;
    FileName: string = '';
    FileSize_kb: number = 0;

    constructor(private httpClient: HttpClient,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        public appStateService: AppStateService) {
    }

    GetLocalFileInfo(ParentTVItemID: number, FileName: string, FileSize_kb: number) {
        this.ParentTVItemID = ParentTVItemID;
        this.FileName = FileName;
        this.FileSize_kb = FileSize_kb;

        this.sub ? this.sub.unsubscribe() : null;
        this.sub = this.DoGetLocalFileInfo().subscribe();
    }

    private DoGetLocalFileInfo() {
        let languageEnum = GetLanguageEnum();

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/LocalFileInfo/GetLocalFileInfo/${this.ParentTVItemID}/${this.FileName}`;

        return this.httpClient.get<LocalFileInfo>(url).pipe(map((x: LocalFileInfo) => { this.DoGetLocalFileInfoUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoGetFileInfoError(e); }))));
    }

    private DoGetLocalFileInfoUpdate(x: LocalFileInfo) {
        if (this.intervalId) {
            clearInterval(this.intervalId);
        }

        this.Progress = x.Length / this.FileSize_kb * 100;
        
        if (this.Progress > 98) return;
        
        this.intervalId = setInterval(() => this.GetLocalFileInfo(this.ParentTVItemID, this.FileName, this.FileSize_kb), 500);
    }

    private DoGetFileInfoError(e: any) {
        this.Progress = 0;
    }
}
