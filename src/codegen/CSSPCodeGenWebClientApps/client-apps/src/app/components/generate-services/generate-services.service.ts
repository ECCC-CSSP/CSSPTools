import { Injectable } from '@angular/core';
import { GenerateServicesModel } from './generate-services.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenerateServicesService {
  generateServicesModel$: BehaviorSubject<GenerateServicesModel> = new BehaviorSubject<GenerateServicesModel>(<GenerateServicesModel>{});

  constructor() {
    this.UpdateServices(<GenerateServicesModel>{ Title: 'allo' });
   }

  UpdateServices(generateServicesModel: GenerateServicesModel)
  {
    this.generateServicesModel$.next({...this.generateServicesModel$.getValue(), ...generateServicesModel});
  }
}
