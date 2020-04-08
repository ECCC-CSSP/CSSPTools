import { Injectable } from '@angular/core';
import { GenerateEnumsModel } from './generate-enums.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenerateEnumsService {
  generateEnumsModel$: BehaviorSubject<GenerateEnumsModel> = new BehaviorSubject<GenerateEnumsModel>(<GenerateEnumsModel>{});

  constructor() {
    this.UpdateEnums(<GenerateEnumsModel>{ Title: 'Title of the app' });
   }

   UpdateEnums(generateEnumsModel: GenerateEnumsModel)
  {
    this.generateEnumsModel$.next(<GenerateEnumsModel>{...this.generateEnumsModel$.getValue(), ...generateEnumsModel});
  }
}
