import { Injectable } from '@angular/core';
import { ServicesModel } from './services.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  servicesModel$: BehaviorSubject<ServicesModel> = new BehaviorSubject<ServicesModel>(<ServicesModel>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.Update(<ServicesModel>{ Title: 'allo' });
  } 
  Update(servicesModel: ServicesModel)
  {
    let servicesModelTemp: ServicesModel = {...this.servicesModel$.getValue(), ...servicesModel};
    this.servicesModel$ = new BehaviorSubject<ServicesModel>(servicesModelTemp);
  }
}
