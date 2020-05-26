import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { LoginModel } from '.';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  loginModel$: BehaviorSubject<LoginModel> = new BehaviorSubject<LoginModel>(<LoginModel>{});

  constructor() {
  }

  UpdateLogin(loginModel: LoginModel)
  {
    this.loginModel$.next({...this.loginModel$.getValue(), ...loginModel});
  }
}