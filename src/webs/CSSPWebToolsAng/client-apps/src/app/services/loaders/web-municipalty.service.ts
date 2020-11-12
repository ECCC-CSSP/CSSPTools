import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/loaders/structure-tvfile-list.service';

@Injectable({
    providedIn: 'root'
})
export class WebMunicipalityService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private structureTVFileListService: StructureTVFileListService) {
    }

    GetWebMunicipality(TVItemID: number) {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMunicipality: {},
            InfrastructureModelList: [],
            MunicipalityContactModelList: [],
            MunicipalityTVItemLinkList: [],
            TVItemMikeScenarioList: [],
            BreadCrumbWebBaseList: [],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMunicipality/${TVItemID}/1`;
        return this.httpClient.get<WebMunicipality>(url).pipe(
            map((x: any) => {
                this.UpdateWebMunicipality(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebMunicipality(x: WebMunicipality) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMunicipality: x,
            InfrastructureModelList: x?.InfrastructureModelList,
            MunicipalityContactModelList: x?.MunicipalityContactModelList,
            MunicipalityTVItemLinkList: x?.MunicipalityTVItemLinkList,
            TVItemMikeScenarioList: x?.TVItemMikeScenarioList,
            BreadCrumbWebBaseList: x?.TVItemParentList,
            Working: false
        });
    }
}