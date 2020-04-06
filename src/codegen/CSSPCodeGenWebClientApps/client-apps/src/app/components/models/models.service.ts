import { Injectable } from '@angular/core';
import { ModelsModel } from './models.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModelsService {
  modelsModel$: BehaviorSubject<ModelsModel> = new BehaviorSubject<ModelsModel>(<ModelsModel>{});

  constructor() {
    this.UpdateModels(<ModelsModel>{ Title: 'Some title' });
   }

  UpdateModels(modelsModel: ModelsModel)
  {
    this.modelsModel$.next({...this.modelsModel$.getValue(), ...modelsModel});
  }
}
