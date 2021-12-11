import { Injectable } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';

@Injectable({
  providedIn: 'root'
})
export class StatCountService {

  constructor() {
  }

  GetStatCount(tvItemModel: TVItemModel, tvType?: TVTypeEnum): string {
    let count = 0;
    if (tvItemModel) {
      if (tvType == null) { 
        tvItemModel.TVItemStatList.filter((c) => { count += c.ChildCount });
      }
      else {
        let tvItemStat = tvItemModel.TVItemStatList.filter((c) => { return c.TVType == tvType });
        if (tvItemStat?.length > 0) {
          count = tvItemStat[0].ChildCount;
        }
      }
    }
    
    return count.toString();
  }
}
