import { getTreeControlFunctionsMissingError } from '@angular/cdk/tree';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { ChildCountModel, ChildCountTextModel } from './child-count.models';

@Injectable({
  providedIn: 'any'
})
export class ChildCountService {
  ChildCountTextModel$: BehaviorSubject<ChildCountTextModel> = new BehaviorSubject<ChildCountTextModel>(<ChildCountTextModel>{});
  ChildCountModel$: BehaviorSubject<ChildCountModel> = new BehaviorSubject<ChildCountModel>(<ChildCountModel>{});

  constructor() {
    this.UpdateChildCountTextModel(<ChildCountTextModel>{});
    this.UpdateChildCountModel(<ChildCountModel>{});
  }

  UpdateChildCountTextModel(childCountTextModel: ChildCountTextModel) {
    this.ChildCountTextModel$.next(<ChildCountTextModel>{ ...this.ChildCountTextModel$.getValue(), ...childCountTextModel });
  }

  UpdateChildCountModel(childCountModel: ChildCountModel) {
    this.ChildCountModel$.next(<ChildCountModel>{ ...this.ChildCountModel$.getValue(), ...childCountModel });
  }

  FillCount(tvItemModel: TVItemModel, tvType?: TVTypeEnum): void {
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

    this.UpdateChildCountModel(<ChildCountModel>{ Count: count });
  }
}
