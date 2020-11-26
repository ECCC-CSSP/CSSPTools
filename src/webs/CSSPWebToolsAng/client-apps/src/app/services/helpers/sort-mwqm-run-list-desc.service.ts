import { Injectable } from '@angular/core';
import { AppStateService } from '../app-state.service';
import { PredicateAscByService } from 'src/app/services/helpers/predicate-asc-by.service';
import { PredicateDescByService } from 'src/app/services/helpers/predicate-desc-by.service';
import { TVItemID_TVText_Sort } from 'src/app/models/TVItemID_TVText_Sort.model';
import { MWQMRun } from 'src/app/models/generated/db/MWQMRun.model';
import { DateFormatService } from './date-format.service';

@Injectable({
    providedIn: 'root'
})
export class SortMWQMRunListService {
    constructor(private predicateDescByService: PredicateDescByService,
        private dateFormatService: DateFormatService) {
    }

    SortMWQMRunListDescByDate(arr: MWQMRun[]): MWQMRun[] {
        if (!arr || arr.length == 0) return arr;

        let mwqmRunSorted: MWQMRun[] = [];
        let arr2: TVItemID_TVText_Sort[] = [];
        let sortable: TVItemID_TVText_Sort[] = [];

        for (let i = 0; i < arr.length; i++) {
            sortable.push(<TVItemID_TVText_Sort>{
                TVItemID: arr[i].MWQMRunID,
                TVText: `${ this.dateFormatService.GetMWQMRunDateTime_LocalDigit(arr[i])}`.toLowerCase(),
            });
        }

        arr2 = sortable.sort(this.predicateDescByService.PredicateDescBy('TVText'));

        for (let i = 0; i < sortable.length; i++) {
            for (let j = 0; j < arr.length; j++) {
                if (arr2[i].TVItemID == arr[j].MWQMRunID) {
                    mwqmRunSorted.push(arr[j]);
                    break;
                }
            }
        }

        return mwqmRunSorted;
    }
}
