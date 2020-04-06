import { Injectable } from '@angular/core';
import { NoPageFoundModel } from './no-page-found.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NoPageFoundService {
  noPageFoundModel$: BehaviorSubject<NoPageFoundModel> = new BehaviorSubject<NoPageFoundModel>(<NoPageFoundModel>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.UpdateNoPageFound(<NoPageFoundModel>{ /* add initial properties here */ });
  } 
  UpdateNoPageFound(noPageFoundModel: NoPageFoundModel)
  {
    let noPageFoundModelTemp: NoPageFoundModel = {...this.noPageFoundModel$.getValue(), ...noPageFoundModel};
    this.noPageFoundModel$ = new BehaviorSubject<NoPageFoundModel>(noPageFoundModelTemp);
  }
}
