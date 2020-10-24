import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebMikeScenario } from 'src/app/models/generated/WebMikeScenario.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebMikeScenarioService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebMikeScenario(TVItemID: number) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMikeScenario: {},
            MikeBoundaryConditionModelMeshList: [],
            MikeBoundaryConditionModelWebTideList: [],
            MikeScenario: {},
            MikeSourceModelList: [],
            BreadCrumbWebBaseList: [],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebMikeScenario/${TVItemID}/1`;
        return this.httpClient.get<WebMikeScenario>(url).pipe(
            map((x: any) => {
                this.UpdateWebMikeScenario(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
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
            Working: false
        });
    }
}