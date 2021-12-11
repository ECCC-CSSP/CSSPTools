import { Injectable } from '@angular/core';
import { PredicateAscByService } from 'src/app/services/helpers/predicate-asc-by.service';
import { AppLanguageService } from '../app/app-language.service';
import { TVItemID_TVText_Sort } from 'src/app/models/generated/models/TVItemID_TVText_Sort.model';
import { MikeSourceModel } from 'src/app/models/generated/models/MikeSourceModel.model';

@Injectable({
    providedIn: 'root'
})
export class SortMikeScenarioModelListService {
    constructor(private predicateAscByService: PredicateAscByService,
        private appLanguageService: AppLanguageService) {
    }

    SortMikeSourceModelListByTVTextAsc(arr: MikeSourceModel[]): MikeSourceModel[] {
        let language: number = <number>this.appLanguageService.Language;

        if (!arr || arr?.length == 0) return arr;

        let mikeSourceModelSorted: MikeSourceModel[] = [];
        let arr2: TVItemID_TVText_Sort[] = [];
        let sortable: TVItemID_TVText_Sort[] = [];

        for (let i = 0, count = arr?.length; i < count; i++) {
            let pre: string = arr[i].MikeSource.Include ? (!arr[i].MikeSource.IsRiver ? 'a' : 'b') : 'c';
            sortable.push(<TVItemID_TVText_Sort>{
                TVItemID: arr[i].TVItemModel.TVItem.TVItemID,
                TVText: pre + arr[i].TVItemModel.TVItemLanguageList[language]?.TVText,
            });
        }

        arr2 = sortable.sort(this.predicateAscByService.PredicateAscBy('TVText'));

        for (let i = 0, count = sortable?.length; i < count; i++) {
            for (let j = 0; j < arr?.length; j++) {
                if (arr2[i].TVItemID == arr[j].TVItemModel.TVItem.TVItemID) {
                    mikeSourceModelSorted.push(arr[j]);
                    break;
                }
            }
        }

        return mikeSourceModelSorted;
    }
}
