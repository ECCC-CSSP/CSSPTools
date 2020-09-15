import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { AppModel } from 'src/app/models';
import { Contact } from '../models/generated/Contact.model';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  appModel$: BehaviorSubject<AppModel> = new BehaviorSubject<AppModel>(<AppModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateApp(<AppModel>{ BaseApiUrl: 'https://localhost:44346/api/'});
   }

  UpdateApp(appModel: AppModel)
  {
    this.appModel$.next(<AppModel>{...this.appModel$.getValue(), ...appModel});
  }

}

 