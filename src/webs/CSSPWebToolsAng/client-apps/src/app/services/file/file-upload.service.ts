import { HttpClient, HttpErrorResponse, HttpEvent, HttpEventType } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from '../app/app-language.service';
import { AppStateService } from '../app/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class FileUploadService {
    private sub: Subscription;

    progress: number = 0;

    constructor(private httpClient: HttpClient,
        public appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService) {
    }

    UploadFile(formData: FormData) {
        this.sub ? this.sub.unsubscribe() : null;
        this.appStateService.Working = true;
        this.appStateService.Error = null;
        this.appStateService.Status = '';
        this.progress = 0;
        this.sub = this.DoUploadFile(formData).subscribe((event: HttpEvent<any>) => {
            switch (event.type) {
                case HttpEventType.Sent:
                    {
                        console.log('Request has been made!');
                    }
                    break;
                case HttpEventType.ResponseHeader:
                    {
                        console.log('Response header has been received!');
                    }
                    break;
                case HttpEventType.UploadProgress:
                    {
                        this.progress = Math.round(event.loaded / event.total * 100);
                        console.log(`Uploaded! ${this.progress}%`);
                    }
                    break;
                case HttpEventType.Response:
                    {
                        console.log('User successfully created!', event.body);
                        setTimeout(() => {
                            this.progress = 0;
                        }, 1500);
                    }
                    break;
                default:
                    break;
            }
        })
    }

    private DoUploadFile(formData) {
        let languageEnum = GetLanguageEnum();
        const url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Upload`;

        return this.httpClient.post<any>(url, formData, {
            reportProgress: true,
            observe: 'events'
        }).pipe(catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }

    private DoError(e: any) {
        this.appStateService.Status = ''
        this.appStateService.Working = false
        this.appStateService.Error = <HttpErrorResponse>e;
        this.progress = 0;
        console.debug(e);
    }
}
