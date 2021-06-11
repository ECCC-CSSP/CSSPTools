import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';

@Injectable({
    providedIn: 'root'
})
export class PNGService {
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService) {
    }

    CreateTempPNG(pngBlob: Blob, chartFileName: string) {

        this.sub ? this.sub.unsubscribe() : null;

        this.sub = this.DoCreateTempPNG(pngBlob, chartFileName).subscribe();
    }

    private DoCreateTempPNG(pngBlob: Blob, chartFileName: string) {
        let languageEnum = GetLanguageEnum();

        this.appStateService.Status = `${this.appLanguageService.Saving[this.appLanguageService.LangID]} - ${chartFileName}`;
        this.appStateService.Working = true;

        const url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/CreateFile/CreateTempPNG`;

        var data = new FormData();
        data.append("mypic", pngBlob, chartFileName);

        return this.httpClient.post<any>(url, data).pipe(map((x: any) => { this.DoUpdateForCreateTempPNG(x, chartFileName); }), catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }

    private DoUpdateForCreateTempPNG(x: any, chartFileName) {
        let languageEnum = GetLanguageEnum();

        this.appStateService.Status = '';
        this.appStateService.Working = false;
        console.debug(x);

        const url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/DownloadTemp/${chartFileName}`;

        let a = document.createElement('a');
        a.href = url;
        a.click();
    }

    private DoError(e: any) {
        this.appStateService.Status = ''
        this.appStateService.Working = false
        this.appStateService.Error = <HttpErrorResponse>e;
        console.debug(e);
    }

}