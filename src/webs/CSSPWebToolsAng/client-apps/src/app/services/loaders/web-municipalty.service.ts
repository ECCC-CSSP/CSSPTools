import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemLink } from 'src/app/models/generated/db/TVItemLink.model';
import { ContactModel } from 'src/app/models/generated/web/ContactModel.model';
import { InfrastructureModel } from 'src/app/models/generated/web/InfrastructureModel.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { MapService } from '../map/map.service';
import { SortTVItemListService } from '../helpers/sort-tvitem-list.service';
import { AppLanguageService } from '../app-language.service';

@Injectable({
    providedIn: 'root'
})
export class WebMunicipalityService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private sortTVItemListService: SortTVItemListService,
        private structureTVFileListService: StructureTVFileListService,
        private mapService: MapService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebMunicipality(TVItemID: number, DoOther: boolean) {
        this.DoOther = this.DoOther;
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMunicipality: {},
            InfrastructureModelList: [],
            MunicipalityContactModelList: [],
            MunicipalityTVItemLinkList: [],
            TVItemMikeScenarioList: [],
            BreadCrumbWebBaseList: [],
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingMunicipality[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMunicipality/${TVItemID}/1`;
        return this.httpClient.get<WebMunicipality>(url).pipe(
            map((x: any) => {
                this.UpdateWebMunicipality(x);
                console.debug(x);
                if (DoOther) {
                    // nothing more to add in the chain
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebMunicipality(x: WebMunicipality) {
        let TVItemMikeScenarioList: WebBase[] = [];

        // doing CountryProvinceList
        if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
            TVItemMikeScenarioList = x?.TVItemMikeScenarioList.filter((MIKEScenario) => { return MIKEScenario.TVItemModel.TVItem.IsActive == true });
        }
        else {
            TVItemMikeScenarioList = x?.TVItemMikeScenarioList;
        }

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMunicipality: x,
            MunicipalityFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
            InfrastructureModelList: x?.InfrastructureModelList,
            MunicipalityContactModelList: x?.MunicipalityContactModelList,
            MunicipalityTVItemLinkList: x?.MunicipalityTVItemLinkList,
            TVItemMikeScenarioList: this.sortTVItemListService.SortTVItemList(TVItemMikeScenarioList, x?.TVItemParentList),
            BreadCrumbWebBaseList: x?.TVItemParentList,
        });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedMunicipality()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }

        let webBaseMunicipality: WebBase[] = <WebBase[]>[
            <WebBase>{ TVItemModel: this.appLoadedService.AppLoaded$.getValue().WebMunicipality.TVItemModel },
          ];
      
        if (this.appStateService.AppState$.getValue().MunicipalitySubComponent == MunicipalitySubComponentEnum.Infrastructures) {
            this.mapService.ClearMap();
            this.mapService.DrawObjects([
                ...this.appLoadedService.AppLoaded$.getValue().InfrastructureModelList,
                ...webBaseMunicipality
            ]);
        }

        if (this.appStateService.AppState$.getValue().MunicipalitySubComponent == MunicipalitySubComponentEnum.Contacts) {
            this.mapService.ClearMap();
            this.mapService.DrawObjects([
                ...this.appLoadedService.AppLoaded$.getValue().InfrastructureModelList,
                ...webBaseMunicipality
            ]);
        }

        if (this.appStateService.AppState$.getValue().MunicipalitySubComponent == MunicipalitySubComponentEnum.MIKEScenarios) {
            this.mapService.ClearMap();
            this.mapService.DrawObjects([
                ...this.appLoadedService.AppLoaded$.getValue().InfrastructureModelList,
                ...webBaseMunicipality
            ]);
        }

        if (this.appStateService.AppState$.getValue().MunicipalitySubComponent == MunicipalitySubComponentEnum.Files) {
            this.mapService.ClearMap();
            this.mapService.DrawObjects([
                ...this.appLoadedService.AppLoaded$.getValue().InfrastructureModelList,
                ...webBaseMunicipality
            ]);
        }

    }
}