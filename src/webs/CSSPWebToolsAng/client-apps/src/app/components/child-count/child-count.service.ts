import { getTreeControlFunctionsMissingError } from '@angular/cdk/tree';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { TVTypeEnum } from '../../enums/generated/TVTypeEnum';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { ChildCountVar } from './child-count.models';

@Injectable({
  providedIn: 'root'
})
export class ChildCountService {
  ChildCountVar$: BehaviorSubject<ChildCountVar> = new BehaviorSubject<ChildCountVar>(<ChildCountVar>{});

  constructor() {
    this.UpdateChildCountVar(<ChildCountVar>{});
  }

  UpdateChildCountVar(childCountVar: ChildCountVar) {
    this.ChildCountVar$.next(<ChildCountVar>{ ...this.ChildCountVar$.getValue(), ...childCountVar });
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
