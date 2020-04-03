import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppRoot } from '../interfaces/app-root.interfaces';

@Injectable({
  providedIn: 'root'
})
export class AppRootService {
  appRoot$: BehaviorSubject<AppRoot> = new BehaviorSubject<AppRoot>(<AppRoot>{});

  constructor() { }

  ClearAppRoot()
  {
    this.appRoot$ = new BehaviorSubject<AppRoot>(<AppRoot>{}); 
  }
}
