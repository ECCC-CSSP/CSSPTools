import { Injectable } from '@angular/core';
import { PredicateDescByService } from 'src/app/services/helpers/predicate-desc-by.service';
import { DateFormatService } from './date-format.service';
import { MWQMRunModel } from 'src/app/models/generated/web/MWQMRunModel.model';
import { TVItemID_TVText_Sort } from 'src/app/models/generated/web/TVItemID_TVText_Sort.model';

@Injectable({
    providedIn: 'root'
})
export class SortMWQMRunListService {
    constructor(private predicateDescByService: PredicateDescByService,
        private dateFormatService: DateFormatService) {
    }

    SortMWQMRunListDescByDate(arr: MWQMRunModel[]): MWQMRunModel[] {
        if (!arr || arr?.length == 0) return arr;

        let mwqmRunSorted: MWQMRunModel[] = [];
        let arr2: TVItemID_TVText_Sort[] = [];
        let sortable: TVItemID_TVText_Sort[] = [];

        for (let i = 0; i < arr?.length; i++) {
            sortable.push(<TVItemID_TVText_Sort>{
                TVItemID: arr[i].MWQMRun.MWQMRunID,
                TVText: `${ this.dateFormatService.GetMWQMRunDateTime_LocalDigit(arr[i].MWQMRun)}`.toLowerCase(),
            });
        }

        arr2 = sortable.sort(this.predicateDescByService.PredicateDescBy('TVText'));

        for (let i = 0; i < sortable?.length; i++) {
            for (let j = 0; j < arr?.length; j++) {
                if (arr2[i].TVItemID == arr[j].MWQMRun.MWQMRunID) {
                    mwqmRunSorted.push(arr[j]);
                    break;
                }
            }
        }

        return mwqmRunSorted;
    }
}
