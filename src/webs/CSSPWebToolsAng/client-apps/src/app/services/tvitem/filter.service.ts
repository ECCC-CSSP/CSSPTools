import { Injectable } from '@angular/core';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  constructor(private appStateService: AppStateService) {
  }

  FilterTVItemModelList(tvItemModelList: TVItemModel[]) {
    if (!(typeof (tvItemModelList) == "undefined" || tvItemModelList == null)) {
      if (!this.appStateService.UserPreference.InactVisible) {
        return tvItemModelList.filter(c => c.TVItem.IsActive == true);
      }
    }

    return tvItemModelList;
  }
}
