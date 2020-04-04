import { Injectable } from '@angular/core';
import { ModelsModel } from './models.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModelsService {
  modelsModel$: BehaviorSubject<ModelsModel> = new BehaviorSubject<ModelsModel>(<ModelsModel>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.Update(<ModelsModel>{ Title: 'allo' });
  } 
  Update(modelsModel: ModelsModel)
  {
    let modelsModelTemp: ModelsModel = {...this.modelsModel$.getValue(), ...modelsModel};
    this.modelsModel$ = new BehaviorSubject<ModelsModel>(modelsModelTemp);
  }
}
