import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppService } from '../services/app.service';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

  constructor(private appService: AppService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = request.clone({
      url: request.url.replace('/api/', this.appService.appModel$.getValue().BaseApiUrl + $localize.locale + '/'),
    });

    return next.handle(request);
  }
}
