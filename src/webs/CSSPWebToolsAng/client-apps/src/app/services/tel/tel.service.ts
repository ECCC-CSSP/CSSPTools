import { Injectable } from '@angular/core';
import { TelModel } from 'src/app/models/generated/web/TelModel.model';
import { AppLoadedService } from '../app/app-loaded.service';
import { AppStateService } from '../app/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class TelService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
  ) {
  }

  GetTelModel(tvItemID: number): TelModel {
    if (this.appLoadedService.WebAllTels == undefined)
    {
      return <TelModel>{};
    }
    let telModelList: TelModel[] = this.appLoadedService.WebAllTels.TelModelList.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemID);
    if (telModelList == null || telModelList == undefined || telModelList.length == 0) {
      return <TelModel>{};
    }
    return telModelList[0];
  }

}
