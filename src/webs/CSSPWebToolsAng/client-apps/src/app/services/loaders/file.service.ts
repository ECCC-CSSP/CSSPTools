import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

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
        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/download/${ParentTVItemID}/${FileName}`;
        this.httpClient.get<Blob>(url).pipe(
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