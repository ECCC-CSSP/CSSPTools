import { Injectable } from '@angular/core';
import { GenerateWebAPIModel } from './generate-web-api.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenerateWebAPIService {
  generateWebAPIModel$: BehaviorSubject<GenerateWebAPIModel> = new BehaviorSubject<GenerateWebAPIModel>(<GenerateWebAPIModel>{});

  constructor() {
    this.UpdateWebAPI(<GenerateWebAPIModel>{ Title: 'Title of the app' });
   }

   UpdateWebAPI(generateWebAPIModel: GenerateWebAPIModel)
  {
    this.generateWebAPIModel$.next(<GenerateWebAPIModel>{...this.generateWebAPIModel$.getValue(), ...generateWebAPIModel});
  }
}
