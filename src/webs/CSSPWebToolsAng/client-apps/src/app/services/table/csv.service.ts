import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TableConvertToCSVModel } from 'src/app/models/generated/web/TableConvertToCSVModel.model';

@Injectable({
    providedIn: 'root'
})
export class CSVService {
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService) {
    }

    CreateTempCSV(tableConvertToCSVModel: TableConvertToCSVModel) {

        this.sub ? this.sub.unsubscribe() : null;

        this.sub = this.DoCreateTempCSV(tableConvertToCSVModel).subscribe();
    }

    private DoCreateTempCSV(tableConvertToCSVModel: TableConvertToCSVModel) {
        let languageEnum = GetLanguageEnum();

        this.appStateService.Status = `${this.appLanguageService.Saving[this.appLanguageService.LangID]} - ${tableConvertToCSVModel.TableFileName}`;
        this.appStateService.Working = true;

        const url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/CreateFile/CreateTempCSV`;

        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            })
        };

        return this.httpClient.post<any>(url, JSON.stringify(tableConvertToCSVModel), httpOptions).pipe(map((x: any) => { this.DoUpdateForCreateTempCSV(x, tableConvertToCSVModel); }), catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }

    private DoUpdateForCreateTempCSV(x: any, tableConvertToCSVModel: TableConvertToCSVModel) {
        let languageEnum = GetLanguageEnum();

        this.appStateService.Status = '';
        this.appStateService.Working = false;
        console.debug(x);

        const url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/DownloadTemp/${tableConvertToCSVModel.TableFileName}`;

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