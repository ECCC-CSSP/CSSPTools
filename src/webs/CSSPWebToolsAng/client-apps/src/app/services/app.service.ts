import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppModel, HttpRequestModel } from 'src/app/models';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  appModel$: BehaviorSubject<AppModel> = new BehaviorSubject<AppModel>(<AppModel>{});

  constructor() {
    this.Update(<AppModel>{ BaseApiUrl: 'http://localhost:4444/api/'});
   }

  Update(appModel: AppModel)
  {
    this.appModel$.next(<AppModel>{...this.appModel$.getValue(), ...appModel});
  }
}

 