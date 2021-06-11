import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from '../app/app-language.service';

@Injectable({
    providedIn: 'root'
})
export class UploadFileService {

    constructor(private httpClient: HttpClient,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService) {
    }

    UploadFile(formData) {
        let languageEnum = GetLanguageEnum();
        const url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Upload`;

        return this.httpClient.post<any>(url, formData, {
            reportProgress: true,
            observe: 'events'
        });
    }
}
