import { Injectable } from '@angular/core';
import { EnumsModel } from './enums.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EnumsService {
  enumsModel$: BehaviorSubject<EnumsModel> = new BehaviorSubject<EnumsModel>(<EnumsModel>{});

  constructor() {
    this.Update(<EnumsModel>{ Title: 'Title of the app' });
   }

   Update(enumsModel: EnumsModel)
  {
    this.enumsModel$.next(<EnumsModel>{...this.enumsModel$.getValue(), ...enumsModel});
  }
}
