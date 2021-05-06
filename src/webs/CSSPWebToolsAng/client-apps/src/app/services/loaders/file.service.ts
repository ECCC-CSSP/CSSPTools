import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';

@Injectable({
    providedIn: 'root'
})
export class FileService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService) {
    }

    DownloadFile(ParentTVItemID: number, FileName: string) {
        this.appStateService.Working = true;
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/download/${ParentTVItemID}/${FileName}`;
        this.httpClient.get<Blob>(url).pipe(
            map((x: any) => {
                this.appStateService.Working = false;
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.Status = ''
                this.appStateService.Working = false
                this.appStateService.Error = <HttpErrorResponse>e;
                console.debug(e);
            })))
        ).subscribe();
    }
}