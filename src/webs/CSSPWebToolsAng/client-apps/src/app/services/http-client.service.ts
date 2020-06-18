import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpRequestModel } from '../models';
import { BehaviorSubject } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { HttpClientCommand } from '../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {
  oldURL: string;

  /* Constructors */
  constructor(private router: Router) {
    this.oldURL = router.url;
  }

  BeforeHttpClient(httpRequestModel$: BehaviorSubject<HttpRequestModel>) {
    httpRequestModel$.next(<HttpRequestModel>{ Working: true, Error: null, Status: null });
  }

  DoCatchError<T>(listModel$: BehaviorSubject<T[]>, httpRequestModel$: BehaviorSubject<HttpRequestModel>, e: any) {
    listModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });
    this.DoReload();
  }

  DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  DoSuccess<T>(listModel$: BehaviorSubject<T[]>, httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: HttpClientCommand, t?: T) {
    if (command === HttpClientCommand.Get) {
      listModel$.next(<T[]>x);
    }
    if (command === HttpClientCommand.Put) {
      listModel$.getValue()[0] = <T>x;
    }
    if (command === HttpClientCommand.Post) {
      listModel$.getValue().push(<T>x);
    }
    if (command === HttpClientCommand.Delete) {
      const index = listModel$.getValue().indexOf(t);
      listModel$.getValue().splice(index, 1);
    }

    listModel$.next(listModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.DoReload();
  }

}
