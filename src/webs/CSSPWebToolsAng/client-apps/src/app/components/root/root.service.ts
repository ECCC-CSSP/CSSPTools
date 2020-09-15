import { Injectable } from '@angular/core';
import { RootTextModel, WebRootModel } from './root.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRootText } from './root.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { WebRoot } from 'src/app/models/webroot';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RootService {
  rootTextModel$: BehaviorSubject<RootTextModel> = new BehaviorSubject<RootTextModel>(<RootTextModel>{});
  webRootModel$: BehaviorSubject<WebRootModel> = new BehaviorSubject<WebRootModel>(<WebRootModel>{});
  
  constructor(private httpClient: HttpClient) {
    LoadLocalesRootText(this);
    this.UpdateRootText(<RootTextModel>{ Title: "Something for text" });
  }

  GetWebRoot() {
    return this.httpClient.get<WebRoot>('/api/Read/WebRoot/0/1').pipe(
      map((x: any) => {
        this.UpdateWebRoot(<WebRootModel>{ WebRoot: x, Loading: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateWebRoot(<WebRootModel>{ Loading: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateRootText(rootTextModel: RootTextModel) {
    this.rootTextModel$.next(<RootTextModel>{ ...this.rootTextModel$.getValue(), ...rootTextModel });
  }

  UpdateWebRoot(webRootModel: WebRootModel) {
    this.webRootModel$.next(<WebRootModel>{ ...this.webRootModel$.getValue(), ...webRootModel });
  }
}
