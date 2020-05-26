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
import { UserService } from '../services/user.service';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

  constructor(private appService: AppService, private userService: UserService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${this.userService.userModel$.value.Token}`
      },
      url: request.url.replace('/api/', this.appService.appModel$.value.BaseApiUrl + $localize.locale + '/'),
    });

    return next.handle(request);
  }
}
