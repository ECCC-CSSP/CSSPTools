import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from '../app/app-language.service';

@Injectable({
    providedIn: 'root'
})
export class FileGetAzureFileSizeService {
    private sub: Subscription;
    

    AzureFileSize: number = 0;
    Working?: boolean = false;
    Error?: HttpErrorResponse = null;
    Status?: string = '';

    constructor(private httpClient: HttpClient,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService) {
    }

    GetAzureFileSize(tvFileModel: TVFileModel) {
        this.sub ? this.sub.unsubscribe() : null;
        this.sub = this.DoGetAzureFileSize(tvFileModel).subscribe();
    }

    private DoGetAzureFileSize(tvFileModel: TVFileModel) {
        let languageEnum = GetLanguageEnum();
        let ParentTVItemID = tvFileModel.TVItem.ParentID;
        let FileName = tvFileModel.TVFile.ServerFileName;

        this.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]}`;
        this.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/getazurefilesize/${ParentTVItemID}/${FileName}`;

        return this.httpClient.get<number>(url).pipe(map((x: number) => { this.DoGetAzureFileSizeUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoGetAzureFileSizeError(e); }))));
    }

    private DoGetAzureFileSizeUpdate(x: number) {
        this.AzureFileSize = x;
        this.Status = '';
        this.Working = false;
        console.debug(x);
    }

    private DoGetAzureFileSizeError(e: any) {
        this.AzureFileSize = 0;
        this.Status = ''
        this.Working = false
        this.Error = <HttpErrorResponse>e;
        console.debug(e);
    }
}
