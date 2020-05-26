import { Injectable } from '@angular/core';
import { WebApiNotFoundModel } from './web-api-not-found.models';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WebApiNotFoundService {
  webApiNotFoundModel$: BehaviorSubject<WebApiNotFoundModel> = new BehaviorSubject<WebApiNotFoundModel>(<WebApiNotFoundModel>{});

  constructor() {
    this.Init();
   }

  Init()
  {
    this.UpdateWebApiNotFound(<WebApiNotFoundModel>{ /* add initial properties here */ });
  } 
  UpdateWebApiNotFound(webApiNotFoundModel: WebApiNotFoundModel)
  {
    let webApiNotFoundModelTemp: WebApiNotFoundModel = {...this.webApiNotFoundModel$.getValue(), ...webApiNotFoundModel};
    this.webApiNotFoundModel$ = new BehaviorSubject<WebApiNotFoundModel>(webApiNotFoundModelTemp);
  }
}
