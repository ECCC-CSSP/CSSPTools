import { Injectable } from '@angular/core';
import { AppStateService } from '../app-state.service';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { PredicateAscByService } from 'src/app/services/loaders/predicate-asc-by.service';
import { PredicateDescByService } from 'src/app/services/loaders/predicate-desc-by.service';
import { TVItemID_TVText_Sort } from 'src/app/models/TVItemID_TVText_Sort.model';

@Injectable({
    providedIn: 'root'
})
export class SortTVItemListService {
    constructor(private appStateService: AppStateService,
        private predicateAscByService: PredicateAscByService,
        private predicateDescByService: PredicateDescByService) {
    }

    SortTVItemList(arr: WebBase[], breadCrumb: WebBase[]): WebBase[] {
        if (!arr || arr.length == 0) return arr;
        if (!breadCrumb || breadCrumb.length == 0) return arr;

        let TVType: TVTypeEnum = breadCrumb[breadCrumb.length - 1].TVItemModel?.TVItem.TVType;
        let TVTypeOfList: TVTypeEnum = arr[0].TVItemModel?.TVItem.TVType;
        let lang: LanguageEnum = this.appStateService.AppState$.getValue().Language;
        let AscDesc: AscDescEnum = AscDescEnum.Ascending;

        switch (TVType) {
            case TVTypeEnum.Root:
                {
                    switch (TVTypeOfList) {
                        case TVTypeEnum.Country:
                            {
                                AscDesc = this.appStateService.AppState$.getValue().RootCountriesSortOrder;
                            }
                            break;
                        default:
                            {
                                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Root`);
                            }
                            break;
                    }
                }
                break;
            case TVTypeEnum.Country:
                {
                    switch (TVTypeOfList) {
                        case TVTypeEnum.Province:
                            {
                                AscDesc = this.appStateService.AppState$.getValue().CountryProvincesSortOrder;
                            }
                            break;
                        default:
                            {
                                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Country`);
                            }
                            break;
                    }
                }
                break;
            case TVTypeEnum.Province:
                {
                    switch (TVTypeOfList) {
                        case TVTypeEnum.Area:
                            {
                                AscDesc = this.appStateService.AppState$.getValue().ProvinceAreasSortOrder;
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                AscDesc = this.appStateService.AppState$.getValue().ProvinceMunicipalitiesSortOrder;
                            }
                            break;
                        default:
                            {
                                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Province`);
                            }
                            break;
                    }
                }
                break;
            case TVTypeEnum.Area:
                {
                    switch (TVTypeOfList) {
                        case TVTypeEnum.Sector:
                            {
                                AscDesc = this.appStateService.AppState$.getValue().AreaSectorsSortOrder;
                            }
                            break;
                        default:
                            {
                                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Area`);
                            }
                            break;
                    }
                }
                break;
            case TVTypeEnum.Sector:
                {
                    switch (TVTypeOfList) {
                        case TVTypeEnum.Subsector:
                            {
                                AscDesc = this.appStateService.AppState$.getValue().SectorSubsectorsSortOrder;
                            }
                            break;
                        default:
                            {
                                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Sector`);
                            }
                            break;
                    }
                }
                break;
            case TVTypeEnum.Subsector:
                {
                    switch (TVTypeOfList) {
                        case TVTypeEnum.MWQMSite:
                            {
                                AscDesc = this.appStateService.AppState$.getValue().SubsectorMWQMSitesSortOrder;
                            }
                            break;
                        case TVTypeEnum.MWQMRun:
                            {
                                AscDesc = this.appStateService.AppState$.getValue().SubsectorMWQMRunsSortOrder;
                            }
                            break;
                        case TVTypeEnum.PolSourceSite:
                            {
                                AscDesc = this.appStateService.AppState$.getValue().SubsectorPolSourceSitesSortOrder;
                            }
                            break;
                        default:
                            {
                                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Subsector`);
                            }
                            break;
                    }
                }
                break;
            default:
                {
                    alert(`${TVTypeEnum[TVType]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function`);
                }
                break;
        }

        let webBaseSorted: WebBase[] = [];
        let arr2: TVItemID_TVText_Sort[] = [];
        let sortable: TVItemID_TVText_Sort[] = [];

        for (let i = 0; i < arr.length; i++) {
            sortable.push(<TVItemID_TVText_Sort>{
                TVItemID: arr[i].TVItemModel.TVItem.TVItemID,
                TVText: lang == LanguageEnum.fr ? arr[i].TVItemModel.TVItemLanguageFR.TVText.toLowerCase() : arr[i].TVItemModel.TVItemLanguageEN.TVText.toLowerCase()
            });
        }

        if (AscDesc == AscDescEnum.Ascending) {
            arr2 = sortable.sort(this.predicateAscByService.PredicateAscBy('TVText'));
        }
        else {
            arr2 = sortable.sort(this.predicateDescByService.PredicateDescBy('TVText'));
        }

        for (let i = 0; i < sortable.length; i++) {
            for (let j = 0; j < arr.length; j++) {
                if (arr2[i].TVItemID == arr[j].TVItemModel.TVItem.TVItemID) {
                    webBaseSorted.push(arr[j]);
                    break;
                }
            }
        }

        return webBaseSorted;
    }
}
