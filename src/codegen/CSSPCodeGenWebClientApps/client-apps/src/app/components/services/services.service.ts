import { Injectable } from '@angular/core';
import { ServicesModel } from './services.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  servicesModel$: BehaviorSubject<ServicesModel> = new BehaviorSubject<ServicesModel>(<ServicesModel>{});

  constructor() {
    this.UpdateServices(<ServicesModel>{ Title: 'allo' });
   }

  UpdateServices(servicesModel: ServicesModel)
  {
    this.servicesModel$.next({...this.servicesModel$.getValue(), ...servicesModel});
  }
}
