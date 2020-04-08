import { Injectable } from '@angular/core';
import { GenerateModelsModel } from './generate-models.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenerateModelsService {
  generateModelsModel$: BehaviorSubject<GenerateModelsModel> = new BehaviorSubject<GenerateModelsModel>(<GenerateModelsModel>{});

  constructor() {
    this.UpdateModels(<GenerateModelsModel>{ Title: 'Some title' });
   }

  UpdateModels(generateModelsModel: GenerateModelsModel)
  {
    this.generateModelsModel$.next({...this.generateModelsModel$.getValue(), ...generateModelsModel});
  }
}
