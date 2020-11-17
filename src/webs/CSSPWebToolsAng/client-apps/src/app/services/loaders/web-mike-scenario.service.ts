import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebMikeScenario } from 'src/app/models/generated/web/WebMikeScenario.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebMikeScenarioService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebMikeScenario(TVItemID: number, DoOther: boolean) {
        this.DoOther = DoOther;
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMikeScenario: {},
            MikeBoundaryConditionModelMeshList: [],
            MikeBoundaryConditionModelWebTideList: [],
            MikeScenario: {},
            MikeSourceModelList: [],
            BreadCrumbWebBaseList: [],
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingMIKEScenario[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMikeScenario/${TVItemID}/1`;
        return this.httpClient.get<WebMikeScenario>(url).pipe(
            map((x: any) => {
                this.UpdateWebMikeScenario(x);
                console.debug(x);
                if (DoOther) {
                    // nothing else to add in the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebMikeScenario(x: WebMikeScenario) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMikeScenario: x,
            MikeBoundaryConditionModelMeshList: x?.MikeBoundaryConditionModelMeshList,
            MikeBoundaryConditionModelWebTideList: x?.MikeBoundaryConditionModelWebTideList,
            MikeScenario: x?.MikeScenario,
            MikeSourceModelList: x?.MikeSourceModelList,
            BreadCrumbWebBaseList: x?.TVItemParentList,
        });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedMIKEScenario()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }
    }
}