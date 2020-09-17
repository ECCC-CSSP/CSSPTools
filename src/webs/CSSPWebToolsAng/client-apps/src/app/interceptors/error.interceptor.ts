import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

import { WebApiNotFoundService } from '../pages/web-api-not-found';
import { WebApiNotFoundModel } from '../pages/web-api-not-found/web-api-not-found.models';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private router: Router, private webApiNotFoundService: WebApiNotFoundService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if (err.status === 0) {
                this.webApiNotFoundService.UpdateWebApiNotFound(<WebApiNotFoundModel> { url: request.url });
                this.router.navigateByUrl(`${ $localize.locale }/webapinotfound`);
                return;
            }
            
            return throwError(err);
        }))
    }
}