import { Injectable } from '@angular/core';
import { HomeTextModel } from './home.models';
import { BehaviorSubject } from 'rxjs';
import { LoadLocalesHomeText } from './home.locales';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  homeTextModel$: BehaviorSubject<HomeTextModel> = new BehaviorSubject<HomeTextModel>(<HomeTextModel>{});
  
  constructor() {
    LoadLocalesHomeText(this);
    this.UpdateHomeText(<HomeTextModel>{ Title: "Something for text" });
  }

  UpdateHomeText(homeTextModel: HomeTextModel) {
    this.homeTextModel$.next(<HomeTextModel>{ ...this.homeTextModel$.getValue(), ...homeTextModel });
  }

  // LoadLocalesHomeText() {
  //   let homeTextModel: HomeTextModel = {
  //     Title: 'The Title',
  //   }

  //   if ($localize.locale === 'fr-CA') {
  //     homeTextModel.Title = 'Le Titre';
  //   }
  // }
}
