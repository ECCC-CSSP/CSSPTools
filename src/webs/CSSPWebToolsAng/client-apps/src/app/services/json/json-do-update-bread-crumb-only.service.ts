import { Injectable } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { MonitoringStatsModel } from 'src/app/models/generated/web/MonitoringStatsModel.model';


@Injectable({
    providedIn: 'root'
})
export class JsonDoUpdateBreadCrumbOnlyService {
    
    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    DoUpdateBreadCrumbOnly(WebType: WebTypeEnum) {
        switch (WebType) {
            case WebTypeEnum.WebArea:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebArea.TVItemModelParentList;
                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentAreaTVItemID)[0];
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebCountry.TVItemModelParentList;
                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsCountry?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentCountryTVItemID)[0];
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebMunicipality.TVItemModelParentList;
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebProvince.TVItemModelParentList;
                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentProvinceTVItemID)[0];
                }
                break;
            case WebTypeEnum.WebRoot: {
                this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebRoot.TVItemModelParentList;
                this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
            }
                break;
            case WebTypeEnum.WebSector:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebSector.TVItemModelParentList;
                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentSectorTVItemID)[0];
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    this.appLoadedService.BreadCrumbTVItemModelList = this.appLoadedService.WebSubsector.TVItemModelParentList;
                    this.appLoadedService.MonitoringStatsModel = this.appLoadedService?.WebMonitoringRoutineStatsProvince?.MonitoringStatsModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.appStateService.UserPreference.CurrentSubsectorTVItemID)[0];
                }
                break;
            default:
                break;
        }
    }
}