import { Injectable } from '@angular/core';
import { PredicateDescByService } from 'src/app/services/helpers/predicate-desc-by.service';
import { TVItemID_TVText_Sort } from 'src/app/models/TVItemID_TVText_Sort.model';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { DateFormatService } from './date-format.service';

@Injectable({
    providedIn: 'root'
})
export class SortMWQMSiteSampleListService {
    constructor(private predicateDescByService: PredicateDescByService,
        private dateFormatService: DateFormatService) {
    }

    SortMWQMSiteSampleListDescByDate(arr: MWQMSample[]): MWQMSample[] {
        if (!arr || arr.length == 0) return arr;

        let mwqmSampleSorted: MWQMSample[] = [];
        let arr2: TVItemID_TVText_Sort[] = [];
        let sortable: TVItemID_TVText_Sort[] = [];

        for (let i = 0; i < arr.length; i++) {
            sortable.push(<TVItemID_TVText_Sort>{
                TVItemID: arr[i].MWQMSampleID,
                TVText:  `${ this.dateFormatService.GetMWQMSampleDateTime_LocalDigit(arr[i])}`.toLowerCase(),
            });
        }

        arr2 = sortable.sort(this.predicateDescByService.PredicateDescBy('TVText'));

        for (let i = 0; i < sortable.length; i++) {
            for (let j = 0; j < arr.length; j++) {
                if (arr2[i].TVItemID == arr[j].MWQMSampleID) {
                    mwqmSampleSorted.push(arr[j]);
                    break;
                }
            }
        }

        return mwqmSampleSorted;
    }
}
