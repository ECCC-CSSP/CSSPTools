import { Injectable } from '@angular/core';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { UserModel } from '../models/user.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { map, catchError } from 'rxjs/operators';
import { RegisterModel } from '../components/auth/register/register.models';
import { LoginModel } from '../components/auth/login';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  userModel$: BehaviorSubject<UserModel> = new BehaviorSubject<UserModel>(<UserModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateUser(<UserModel>(JSON.parse(localStorage.getItem('currentUser'))));
  }

  UpdateUser(userModel: UserModel) {
    this.userModel$.next({ ...this.userModel$.getValue(), ...userModel });
  }

  ClearUser() {
    this.userModel$ = new BehaviorSubject<UserModel>(<UserModel>{});
  }
  
  Login(loginEmail: string, password: string, router: Router, language: string, returnUrl: string) {
    this.UpdateUser(<UserModel>{ Loading: true });
    return this.httpClient.post<UserModel>('/api/Auth/Token', { LoginEmail: loginEmail, Password: password }).pipe(
      map((x: any) => {
        localStorage.setItem('currentUser', JSON.stringify(x));
        this.UpdateUser(x);
        this.UpdateUser(<UserModel>{ Loading: false });
        console.debug(x);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([returnUrl]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateUser(<UserModel>{ Loading: false, Error: <HttpErrorResponse>e });
        console.debug(e);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([returnUrl]);
        });
      })))
    );
  }

  Logout(router: Router, language: string) {
    localStorage.removeItem('currentUser');
    this.ClearUser();
    router.navigateByUrl(`${language}`, { skipLocationChange: true }).then(() => {
      router.navigateByUrl('');
    });
  }
}
