import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
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
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMikeScenario(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
    
        this.sub ? this.sub.unsubscribe() : null;
    
        if (this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenario?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
          this.KeepWebMikeScenario();
        }
        else {
          this.sub = this.GetWebMikeScenario().subscribe();
        }
      }
    
    private GetWebMikeScenario() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMikeScenario: {},
            MikeBoundaryConditionModelMeshList: [],
            MikeBoundaryConditionModelWebTideList: [],
            MikeScenario: {},
            MikeSourceModelList: [],
            BreadCrumbMikeScenarioWebBaseList: [],
            BreadCrumbWebBaseList: []
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingMIKEScenario[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMikeScenario/${this.TVItemID}/1`;
        return this.httpClient.get<WebMikeScenario>(url).pipe(
            map((x: any) => {
                this.UpdateWebMikeScenario(x);
                console.debug(x);
                if (this.DoOther) {
                    // nothing else to add in the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private KeepWebMikeScenario() {
        this.UpdateWebMikeScenario(this.appLoadedService.AppLoaded$?.getValue()?.WebMikeScenario);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMikeScenario);
        if (this.DoOther) {
            // nothing else to add in the chain
        }
    }

    private UpdateWebMikeScenario(x: WebMikeScenario) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMikeScenario: x,
            MikeBoundaryConditionModelMeshList: x?.MikeBoundaryConditionModelMeshList,
            MikeBoundaryConditionModelWebTideList: x?.MikeBoundaryConditionModelWebTideList,
            MikeScenario: x?.MikeScenario,
            MikeSourceModelList: x?.MikeSourceModelList,
            BreadCrumbMikeScenarioWebBaseList: x?.TVItemParentList,
            BreadCrumbWebBaseList: x?.TVItemParentList
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