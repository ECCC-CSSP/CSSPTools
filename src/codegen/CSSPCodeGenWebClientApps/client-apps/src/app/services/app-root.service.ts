import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppRoot } from '../interfaces/app-root.interfaces';

@Injectable({
  providedIn: 'root'
})
export class AppRootService {
  appRoot$: BehaviorSubject<AppRoot> = new BehaviorSubject<AppRoot>(<AppRoot>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.Update(<AppRoot>{ CurrentURL: '' });
  }
  Update(appRoot: AppRoot)
  {
    let appRootTemp: AppRoot = {...this.appRoot$.getValue(), ...appRoot};
    this.appRoot$ = new BehaviorSubject<AppRoot>(appRootTemp);
  }
}
