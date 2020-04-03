import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppShell } from '../interfaces/app-shell.interfaces';

@Injectable({
  providedIn: 'root'
})
export class AppShellService {
  appShell$: BehaviorSubject<AppShell> = new BehaviorSubject<AppShell>(<AppShell>{});

  constructor() { }

  Clear()
  {
    this.appShell$ = new BehaviorSubject<AppShell>(<AppShell>{});
  }

  Update(appShell: AppShell)
  {
    let appShellTemp: AppShell = {...this.appShell$.getValue(), ...appShell};
    this.appShell$ = new BehaviorSubject<AppShell>(appShellTemp);
  }
}
