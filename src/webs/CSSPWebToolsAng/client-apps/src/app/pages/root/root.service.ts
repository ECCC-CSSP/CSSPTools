import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRootText } from './root.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

import { WebRoot } from '../../models/generated/WebRoot.model';
import { RootTextModel, WebRootModel } from './root.models';

@Injectable({
  providedIn: 'root'
})
export class RootService {
  RootTextModel$: BehaviorSubject<RootTextModel> = new BehaviorSubject<RootTextModel>(<RootTextModel>{});
  WebRootModel$: BehaviorSubject<WebRootModel> = new BehaviorSubject<WebRootModel>(<WebRootModel>{});
  
  constructor(private httpClient: HttpClient) {
    LoadLocalesRootText(this);
    this.UpdateRootText(<RootTextModel>{ Title: "Something for text" });
  }

  GetWebRoot() {
    this.UpdateWebRoot(<WebRootModel>{ Working: true });
    return this.httpClient.get<WebRoot>('/api/Read/WebRoot/0/1').pipe(
      map((x: any) => {
        this.UpdateWebRoot(<WebRootModel>{ WebRoot: x, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateWebRoot(<WebRootModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateRootText(rootTextModel: RootTextModel) {
    this.RootTextModel$.next(<RootTextModel>{ ...this.RootTextModel$.getValue(), ...rootTextModel });
  }

  UpdateWebRoot(webRootModel: WebRootModel) {
    this.WebRootModel$.next(<WebRootModel>{ ...this.WebRootModel$.getValue(), ...webRootModel });
  }
}
