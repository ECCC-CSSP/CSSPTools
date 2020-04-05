import { Injectable } from '@angular/core';
import { ServicesModel } from './services.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  servicesModel$: BehaviorSubject<ServicesModel> = new BehaviorSubject<ServicesModel>(<ServicesModel>{});

  constructor() {
    this.Update(<ServicesModel>{ Title: 'allo' });
   }

  Update(servicesModel: ServicesModel)
  {
    this.servicesModel$.next({...this.servicesModel$.getValue(), ...servicesModel});
  }
}
