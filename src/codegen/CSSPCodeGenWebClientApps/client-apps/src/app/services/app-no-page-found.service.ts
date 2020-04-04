import { Injectable } from '@angular/core';
import { AppNoPageFound } from '../interfaces/app-no-page-found.interfaces';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppNoPageFoundService {
  appNoPageFound$: BehaviorSubject<AppNoPageFound> = new BehaviorSubject<AppNoPageFound>(<AppNoPageFound>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.Update(<AppNoPageFound>{ title: 'bonjour' });
  } 
  Update(appNoPageFound: AppNoPageFound)
  {
    let appNoPageFoundTemp: AppNoPageFound = {...this.appNoPageFound$.getValue(), ...appNoPageFound};
    this.appNoPageFound$ = new BehaviorSubject<AppNoPageFound>(appNoPageFoundTemp);
  }
}
