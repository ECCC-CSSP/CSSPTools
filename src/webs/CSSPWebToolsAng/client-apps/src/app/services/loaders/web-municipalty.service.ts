import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { MapService } from 'src/app/services/map/map.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { AppLanguageService } from 'src/app/services/app-language.service';

@Injectable({
    providedIn: 'root'
})
export class WebMunicipalityService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private sortTVItemListService: SortTVItemListService,
        private structureTVFileListService: StructureTVFileListService,
        private mapService: MapService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMunicipality(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebMunicipality) {
            this.KeepWebMunicipality();
        }
        else {
            this.sub = this.GetWebMunicipality().subscribe();
        }
    }

    private GetWebMunicipality() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMunicipality: {},
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebMunicipality }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMunicipality/${this.TVItemID}`;
        return this.httpClient.get<WebMunicipality>(url).pipe(
            map((x: any) => {
                this.UpdateWebMunicipality(x);
                console.debug(x);
                if (this.DoOther) {
                    // nothing more to add in the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private KeepWebMunicipality() {
        this.UpdateWebMunicipality(this.appLoadedService.AppLoaded$?.getValue()?.WebMunicipality);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMunicipality);
        if (this.DoOther) {
            // nothing more to add in the chain
        }
    }

    private UpdateWebMunicipality(x: WebMunicipality) {
        // let TVItemMikeScenarioList: WebBase[] = [];

        // // doing CountryProvinceList
        // if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
        //     TVItemMikeScenarioList = x?.TVItemMikeScenarioList.filter((MIKEScenario) => { return MIKEScenario.TVItemModel.TVItem.IsActive == true });
        // }
        // else {
        //     TVItemMikeScenarioList = x?.TVItemMikeScenarioList;
        // }

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMunicipality: x,
            // MunicipalityFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
            // InfrastructureModelList: x?.InfrastructureModelList,
            // MunicipalityContactModelList: x?.MunicipalityContactModelList,
            // MunicipalityTVItemLinkList: x?.MunicipalityTVItemLinkList,
            // TVItemMikeScenarioList: this.sortTVItemListService.SortTVItemList(TVItemMikeScenarioList, x?.TVItemParentList),
            // BreadCrumbMunicipalityWebBaseList: x?.TVItemParentList,
            // BreadCrumbWebBaseList: x?.TVItemParentList
        });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebMunicipality()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }

        // let webBaseMunicipality: WebBase[] = <WebBase[]>[
        //     <WebBase>{ TVItemModel: this.appLoadedService.AppLoaded$.getValue().WebMunicipality.TVItemModel },
        // ];

        if (this.appStateService.AppState$.getValue().GoogleJSLoaded) {
            if (this.appStateService.AppState$.getValue().MunicipalitySubComponent == MunicipalitySubComponentEnum.Infrastructures) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    // ...this.appLoadedService.AppLoaded$.getValue().WebMunicipality.InfrastructureModelList,
                    // ...[this.appLoadedService.AppLoaded$.getValue().WebMunicipality.TVItemStatMapModel]
                ]);
            }

            if (this.appStateService.AppState$.getValue().MunicipalitySubComponent == MunicipalitySubComponentEnum.Contacts) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    // ...this.appLoadedService.AppLoaded$.getValue().WebMunicipality.InfrastructureModelList,
                    // ...[this.appLoadedService.AppLoaded$.getValue().WebMunicipality.TVItemStatMapModel]
                ]);
            }

            if (this.appStateService.AppState$.getValue().MunicipalitySubComponent == MunicipalitySubComponentEnum.MIKEScenarios) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    // ...this.appLoadedService.AppLoaded$.getValue().WebMunicipality.InfrastructureModelList,
                    // ...[this.appLoadedService.AppLoaded$.getValue().WebMunicipality.TVItemStatMapModel]
                ]);
            }

            if (this.appStateService.AppState$.getValue().MunicipalitySubComponent == MunicipalitySubComponentEnum.Files) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    // ...this.appLoadedService.AppLoaded$.getValue().WebMunicipality.InfrastructureModelList,
                    // ...[this.appLoadedService.AppLoaded$.getValue().WebMunicipality.TVItemStatMapModel]
                ]);
            }
        }
    }
}