import { Injectable } from '@angular/core';
import { GenerateAngularModel } from './generate-angular.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenerateAngularService {
  generateAngularModel$: BehaviorSubject<GenerateAngularModel> = new BehaviorSubject<GenerateAngularModel>(<GenerateAngularModel>{});

  constructor() {
    this.UpdateAngular(<GenerateAngularModel>{ Title: 'Title of the app' });
   }

   UpdateAngular(generateAngularModel: GenerateAngularModel)
  {
    this.generateAngularModel$.next(<GenerateAngularModel>{...this.generateAngularModel$.getValue(), ...generateAngularModel});
  }
}
