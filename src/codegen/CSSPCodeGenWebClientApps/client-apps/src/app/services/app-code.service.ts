import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppCode } from '../interfaces/app-code.interfaces';

@Injectable({
  providedIn: 'root'
})
export class AppCodeService {
  appCode$: BehaviorSubject<AppCode> = new BehaviorSubject<AppCode>(<AppCode>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.Update(<AppCode>{ buttonColor: 'primary' });
  } 
  Update(appCode: AppCode)
  {
    let appCodeTemp: AppCode = {...this.appCode$.getValue(), ...appCode};
    this.appCode$ = new BehaviorSubject<AppCode>(appCodeTemp);
  }
}
