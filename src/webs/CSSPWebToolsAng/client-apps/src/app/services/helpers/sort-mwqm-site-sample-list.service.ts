import { Injectable } from '@angular/core';
import { PredicateDescByService } from 'src/app/services/helpers/predicate-desc-by.service';
import { DateFormatService } from './date-format.service';
import { MWQMSampleModel } from 'src/app/models/generated/models/MWQMSampleModel.model';
import { TVItemID_TVText_Sort } from 'src/app/models/generated/models/TVItemID_TVText_Sort.model';

@Injectable({
    providedIn: 'root'
})
export class SortMWQMSiteSampleModelListService {
    constructor(private predicateDescByService: PredicateDescByService,
        private dateFormatService: DateFormatService) {
    }

    SortMWQMSiteSampleModelListDescByDate(arr: MWQMSampleModel[]): MWQMSampleModel[] {
        if (!arr || arr?.length == 0) return arr;

        let mwqmSampleModelSorted: MWQMSampleModel[] = [];
        let arr2: TVItemID_TVText_Sort[] = [];
        let sortable: TVItemID_TVText_Sort[] = [];

        for (let i = 0; i < arr?.length; i++) {
            sortable.push(<TVItemID_TVText_Sort>{
                TVItemID: arr[i].MWQMSample.MWQMSampleID,
                TVText:  `${ this.dateFormatService.GetMWQMSampleDateTime_LocalDigit(arr[i].MWQMSample)}`.toLowerCase(),
            });
        }

        arr2 = sortable.sort(this.predicateDescByService.PredicateDescBy('TVText'));

        for (let i = 0; i < sortable?.length; i++) {
            for (let j = 0; j < arr?.length; j++) {
                if (arr2[i].TVItemID == arr[j].MWQMSample.MWQMSampleID) {
                    mwqmSampleModelSorted.push(arr[j]);
                    break;
                }
            }
        }

        return mwqmSampleModelSorted;
    }
}
