import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppShell } from '../interfaces/app-shell.interfaces';

@Injectable({
  providedIn: 'root'
})
export class AppShellService {
  appShell$: BehaviorSubject<AppShell> = new BehaviorSubject<AppShell>(<AppShell>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.Update(<AppShell>{ isEnglish: true, leftIconsVisible: true });
  } 
  Update(appShell: AppShell)
  {
    let appShellTemp: AppShell = {...this.appShell$.getValue(), ...appShell};
    this.appShell$ = new BehaviorSubject<AppShell>(appShellTemp);
  }
}
