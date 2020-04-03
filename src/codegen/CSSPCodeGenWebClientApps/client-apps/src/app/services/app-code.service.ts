import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppCode } from '../interfaces/app-code.interfaces';

@Injectable({
  providedIn: 'root'
})
export class AppCodeService {
  appCode$: BehaviorSubject<AppCode> = new BehaviorSubject<AppCode>(<AppCode>{});

  constructor() { }

  ClearAppCode()
  {
    this.appCode$ = new BehaviorSubject<AppCode>(<AppCode>{});
  }
}
