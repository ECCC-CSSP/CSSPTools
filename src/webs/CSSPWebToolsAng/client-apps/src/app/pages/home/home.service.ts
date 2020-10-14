import { Injectable } from '@angular/core';
import { HomeVar } from './home.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesHomeText } from './home.locales';
import { AppService } from '../../app.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  HomeVar$: BehaviorSubject<HomeVar> = new BehaviorSubject<HomeVar>(<HomeVar>{});

  constructor() {
    LoadLocalesHomeText(this);
    this.UpdateHomeVar(<HomeVar>{ HomeTitle: "Something for text" });
  }

  UpdateHomeVar(homeVar: HomeVar) {
    this.HomeVar$.next(<HomeVar>{ ...this.HomeVar$.getValue(), ...homeVar });
  }
}
