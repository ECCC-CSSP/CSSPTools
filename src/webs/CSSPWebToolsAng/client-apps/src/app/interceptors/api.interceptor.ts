import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ShellService } from '../pages/shell';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

  constructor(private shellService: ShellService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = request.clone({
      url: request.url.replace('/api/', this.shellService.ShellModel$.getValue().BaseApiUrl + $localize.locale + '/'),
    });

    return next.handle(request);
  }
}
