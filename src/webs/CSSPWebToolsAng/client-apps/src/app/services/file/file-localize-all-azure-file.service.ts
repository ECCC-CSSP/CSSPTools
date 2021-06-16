import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from '../app/app-language.service';

@Injectable({
    providedIn: 'root'
})
export class FileLocalizeAllAzureFileService {
    private sub: Subscription;

    progress: number = 0;
    Working?: boolean = false;
    Error?: HttpErrorResponse = null;
    Status?: string = '';
    TotalFilesCount: number = 0;
    CurrentFilesCount: number = 0;
    CurrentFileName: string = '';
    TVFileModelList: TVFileModel[] = [];

    constructor(private httpClient: HttpClient,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService) {
    }

    LocalizeAllAzureFile(tvFileModelList: TVFileModel[]) {
        this.TVFileModelList = tvFileModelList;
        this.LocalizeAzureFile();
    }

    private LocalizeAzureFile() {
        if (this.TVFileModelList.length > 0) {
            this.sub ? this.sub.unsubscribe() : null;
            this.sub = this.DoLocalizeAzureFile(this.TVFileModelList[0]).subscribe();
        }
    }

    private DoLocalizeAzureFile(tvFileModel: TVFileModel) {
        let languageEnum = GetLanguageEnum();
        let ParentTVItemID = tvFileModel.TVItem.ParentID;
        let FileName = tvFileModel.TVFile.ServerFileName;

        this.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]}`;
        this.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/localizeazurefile/${ParentTVItemID}/${FileName}`;

        return this.httpClient.get<boolean>(url).pipe(map((x: boolean) => { this.DoLocalizeAzureFileUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoLocalizeAzureFileError(e); }))));
    }

    private DoLocalizeAzureFileUpdate(x: boolean) {
        if (!x) {
            this.Error = new HttpErrorResponse({ error: `File: ${this.TVFileModelList[0].TVFile.ServerFileName} not downloaded`, status: 403 });
        }
        else {
            this.TVFileModelList.shift();
            if (this.TVFileModelList.length > 0) {

            }
            else {
                this.Status = '';
                this.Working = false;
                console.debug(x);
            }
        }
    }

    private DoLocalizeAzureFileError(e: any) {
        this.Status = ''
        this.Working = false
        this.Error = <HttpErrorResponse>e;
        console.debug(e);
    }
}
