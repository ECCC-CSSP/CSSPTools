import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { LoginModel, UserModel } from '.';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ShellService } from '../../shell';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  loginModel$: BehaviorSubject<LoginModel> = new BehaviorSubject<LoginModel>(<LoginModel>{});
  userModel$: BehaviorSubject<UserModel> = new BehaviorSubject<UserModel>(<UserModel>{});

  constructor(private httpClient: HttpClient, private shellService: ShellService) {
    this.UpdateUser(<UserModel>(JSON.parse(localStorage.getItem('currentUser'))));
  }

  UpdateLogin(loginModel: LoginModel)
  {
    this.loginModel$.next({...this.loginModel$.getValue(), ...loginModel});
  }
  UpdateUser(userModel: UserModel)
  {
    this.userModel$.next({...this.userModel$.getValue(), ...userModel});
  }

  Login(loginEmail: string, password: string): void {
    this.userModel$.next({...this.userModel$.getValue(), ...{ Submitted: true, Loading: true }});
    this.httpClient.post<UserModel>('/api/auth/login', { LoginEmail: loginEmail, Password: password }).subscribe((x) => {
      localStorage.setItem('currentUser', JSON.stringify(x));
      this.userModel$.next({...this.userModel$.getValue(), ...x})
      this.userModel$.next(x);
      this.shellService.shellModel$.value.UserModel = x;
      this.shellService.shellModel$.next(this.shellService.shellModel$.getValue());
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