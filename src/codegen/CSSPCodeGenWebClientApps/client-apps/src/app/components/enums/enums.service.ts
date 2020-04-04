import { Injectable } from '@angular/core';
import { EnumsModel } from './enums.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EnumsService {
  enumsModel$: BehaviorSubject<EnumsModel> = new BehaviorSubject<EnumsModel>(<EnumsModel>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.Update(<EnumsModel>{ Title: 'allo' });
  } 
  Update(enumsModel: EnumsModel)
  {
    let enumsModelTemp: EnumsModel = {...this.enumsModel$.getValue(), ...enumsModel};
    this.enumsModel$ = new BehaviorSubject<EnumsModel>(enumsModelTemp);
  }
}
