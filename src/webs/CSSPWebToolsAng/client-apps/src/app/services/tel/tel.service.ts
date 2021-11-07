import { Injectable } from '@angular/core';
import { Tel } from 'src/app/models/generated/db/Tel.model';
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

  GetTel(tvItemID: number): Tel {
    if (this.appLoadedService.WebAllTels == undefined)
    {
      return <Tel>{};
    }
    let telList: Tel[] = this.appLoadedService.WebAllTels.TelList.filter(c => c.TelTVItemID == tvItemID);
    if (telList == null || telList == undefined || telList.length == 0) {
      return <Tel>{};
    }
    return telList[0];
  }

}
