import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { RegisterModel } from './register.models';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { LoginModel } from '../login';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  registerModel$: BehaviorSubject<RegisterModel> = new BehaviorSubject<RegisterModel>(<RegisterModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateRegister(<RegisterModel>{});
   }

  UpdateRegister(registerModel: RegisterModel)
  {
    this.registerModel$.next({...this.registerModel$.getValue(), ...registerModel});
  }

  Register(registerModel: RegisterModel) {
    this.UpdateRegister(<RegisterModel>{ Loading: true });
    return this.httpClient.post<boolean>('/api/Auth/Register', { RegisterModel: registerModel }).pipe(
      map((x: any) => {
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateRegister(<RegisterModel>{ Loading: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  // Register(registerModel: RegisterModel) {
  //   this.registerModel$.next({...this.registerModel$.getValue(), ...{ Working: true }});
  //   return this.httpClient.post<LoginModel>('/api/auth/register', { RegisterModel: registerModel }).subscribe((x) => {
  //     this.registerModel$.next(x);
  //   },
  //   (e: any) => {
  //     this.registerModel$.next({...this.registerModel$.getValue(), ...{ Error: <HttpErrorResponse>e }});
  //     console.debug(e);
  //   }, () => {
  //     this.registerModel$.next({...this.registerModel$.getValue(), ...{ Working: false }});
  //     console.debug("completed...");
  //   });
  // }
}
