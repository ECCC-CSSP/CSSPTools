import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { AppModel } from '../models';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  appModel$: BehaviorSubject<AppModel> = new BehaviorSubject<AppModel>(<AppModel>{});
  preference$: BehaviorSubject<AppModel> = new BehaviorSubject<AppModel>(<AppModel>{});
  constructor(private httpClient: HttpClient) {
    //this.UpdateApp(<AppModel>{ BaseApiUrl: 'https://localhost:4447/api/'});
    this.UpdateApp(<AppModel>{ BaseApiUrl: 'https://localhost:44346/api/'});
   }

  UpdateApp(appModel: AppModel)
  {
    this.appModel$.next(<AppModel>{...this.appModel$.getValue(), ...appModel});
  }

}

 