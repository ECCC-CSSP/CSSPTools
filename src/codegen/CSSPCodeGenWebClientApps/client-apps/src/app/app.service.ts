import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppModel } from './app.models';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  appModel$: BehaviorSubject<AppModel> = new BehaviorSubject<AppModel>(<AppModel>{});

  constructor() {
    this.Update(<AppModel>{ CurrentUrl: '', BaseApiUrl: 'http://localhost:4444/api/'});
   }

  Update(appModel: AppModel)
  {
    this.appModel$.next(<AppModel>{...this.appModel$.getValue(), ...appModel});
  }
}
