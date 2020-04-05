import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppService } from '../app.service';
import { AppModel } from '../app.models';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

  constructor(private appService: AppService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let appModel: AppModel = this.appService.appModel$.getValue();
    request = request.clone({
      // setHeaders: {
      //   Authorization: `Bearer ${currentUser.token}`
      // },
      url: request.url.replace('/api/', appModel.BaseApiUrl),
    });

    return next.handle(request);
  }
}
