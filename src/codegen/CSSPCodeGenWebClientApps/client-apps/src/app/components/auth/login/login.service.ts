import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { LoginModel } from '.';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  loginModel$: BehaviorSubject<LoginModel> = new BehaviorSubject<LoginModel>(<LoginModel>{});

  constructor(private httpClient: HttpClient) {
    this.Update(<LoginModel>(JSON.parse(localStorage.getItem('currentLoginModel'))));
   }

  Update(loginModel: LoginModel)
  {
    this.loginModel$.next({...this.loginModel$.getValue(), ...loginModel});
  }

  Login(loginModel: LoginModel) {
    this.loginModel$.next({...this.loginModel$.getValue(), ...{ Submitted: true, Loading: true }});
    this.httpClient.post<LoginModel>('/api/auth/login', { LoginEmail: loginModel.LoginEmail, Password: loginModel.Password }).subscribe((x) => {
      localStorage.setItem('currentLoginModel', JSON.stringify(x));
      this.loginModel$.next(x);
    },
    (e: any) => {
      this.loginModel$.next({...this.loginModel$.getValue(), ...{ Error: (<HttpErrorResponse>e).message }});
      console.debug(e);
    }, () => {
      this.loginModel$.next({...this.loginModel$.getValue(), ...{ Loading: false }});
      console.debug("completed...");
    });
  }

  Logout() {
      // remove user from local storage and set current user to null
      localStorage.removeItem('currentLoginModel');
      this.loginModel$.next(null);
  }
}