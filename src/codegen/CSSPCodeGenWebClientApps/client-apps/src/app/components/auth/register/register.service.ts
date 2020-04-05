import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { RegisterModel } from './register.models';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { LoginModel } from '../login';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  registerModel$: BehaviorSubject<RegisterModel> = new BehaviorSubject<RegisterModel>(<RegisterModel>{});

  constructor(private httpClient: HttpClient) {
    this.Update(<RegisterModel>{});
   }

  Update(registerModel: RegisterModel)
  {
    this.registerModel$.next({...this.registerModel$.getValue(), ...registerModel});
  }

  Register(registerModel: RegisterModel) {
    this.registerModel$.next({...this.registerModel$.getValue(), ...{ Loading: true }});
    this.httpClient.post<LoginModel>('/api/auth/register', { RegisterModel: registerModel }).subscribe((x) => {
      this.registerModel$.next(x);
    },
    (e: any) => {
      this.registerModel$.next({...this.registerModel$.getValue(), ...{ Error: (<HttpErrorResponse>e).message }});
      console.debug(e);
    }, () => {
      this.registerModel$.next({...this.registerModel$.getValue(), ...{ Loading: false }});
      console.debug("completed...");
    });
  }
}
