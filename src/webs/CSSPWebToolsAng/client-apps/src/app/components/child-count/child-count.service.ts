import { getTreeControlFunctionsMissingError } from '@angular/cdk/tree';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { ChildCountModel, ChildCountTextModel } from './child-count.models';

@Injectable({
  providedIn: 'root'
})
export class ChildCountService {
  ChildCountTextModel$: BehaviorSubject<ChildCountTextModel> = new BehaviorSubject<ChildCountTextModel>(<ChildCountTextModel>{});

  constructor() {
    this.UpdateChildCountTextModel(<ChildCountTextModel>{});
  }

  UpdateChildCountTextModel(childCountTextModel: ChildCountTextModel) {
    this.ChildCountTextModel$.next(<ChildCountTextModel>{ ...this.ChildCountTextModel$.getValue(), ...childCountTextModel });
  }

  GetCount(tvItemModel: TVItemModel, tvType?: TVTypeEnum): number {
    let count = 0;
    if (tvType == null) {
      tvItemModel.TVItemStatList.filter((c) => { count += c.ChildCount });
    }
    else {
      var tvItemStat = tvItemModel.TVItemStatList.filter((c) => { return c.TVType == tvType });
      if (tvItemStat.length > 0) {
        count = tvItemStat[0].ChildCount;
      }
    }

    return count;
  }
}
