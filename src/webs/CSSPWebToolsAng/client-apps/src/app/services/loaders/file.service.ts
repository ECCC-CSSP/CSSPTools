import { _isNumberValue } from '@angular/cdk/coercion';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, tap } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class FileService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    DownloadFile(ParentTVItemID: number, FileName: string) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: true });
        let options = {
            headers: null,
            observe: 'events',
            param: null,
            reportProgress: true,
            responseType: 'blob',
            withCredential: false,
        };
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/download/${ParentTVItemID}/${FileName}`;
        this.httpClient.get<Blob>(url, options).pipe(
            map((x: any) => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false });
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        ).subscribe();
    }
}