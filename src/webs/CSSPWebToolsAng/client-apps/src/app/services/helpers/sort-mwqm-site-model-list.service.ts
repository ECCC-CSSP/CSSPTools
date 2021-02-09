import { Injectable } from '@angular/core';
import { AppStateService } from '../app-state.service';
import { PredicateAscByService } from 'src/app/services/helpers/predicate-asc-by.service';
import { TVItemID_TVText_Sort } from 'src/app/models/TVItemID_TVText_Sort.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';

@Injectable({
    providedIn: 'root'
})
export class SortMWQMSiteModelListService {
    constructor(private predicateAscByService: PredicateAscByService,
        private appStateService: AppStateService) {
    }

    SortMWQMSiteModelListByTVTextAsc(arr: MWQMSiteModel[]): MWQMSiteModel[] {
        let language: number = <number>this.appStateService.AppState$.getValue().Language;

        if (!arr || arr.length == 0) return arr;

        let mwqmSiteModelSorted: MWQMSiteModel[] = [];
        let arr2: TVItemID_TVText_Sort[] = [];
        let sortable: TVItemID_TVText_Sort[] = [];

        for (let i = 0; i < arr.length; i++) {
            sortable.push(<TVItemID_TVText_Sort>{
                TVItemID: arr[i].TVItemModel.TVItem.TVItemID,
                TVText: arr[i].TVItemModel.TVItemLanguageList[language].TVText,
            });
        }

        arr2 = sortable.sort(this.predicateAscByService.PredicateAscBy('TVText'));

        for (let i = 0; i < sortable.length; i++) {
            for (let j = 0; j < arr.length; j++) {
                if (arr2[i].TVItemID == arr[j].TVItemModel.TVItem.TVItemID) {
                    mwqmSiteModelSorted.push(arr[j]);
                    break;
                }
            }
        }

        return mwqmSiteModelSorted;
    }
}