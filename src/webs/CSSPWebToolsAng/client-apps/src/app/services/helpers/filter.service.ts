import { Injectable } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  constructor(private appStateService: AppStateService) {
  }

  FilterTVItemModelList(tvItemModelList: TVItemModel[]) {
    if (!(typeof(tvItemModelList) == "undefined" || tvItemModelList == null)) {
      if (!this.appStateService.UserPreference.InactVisible) {
        return tvItemModelList.filter(c => c.TVItem.IsActive == true);
      }
    }

    return tvItemModelList;
  }
}
