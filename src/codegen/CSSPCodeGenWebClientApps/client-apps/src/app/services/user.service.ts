import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserModel } from '../models/user.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

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

  Login(loginEmail: string, password: string, router: Router, language: string): void {
    this.UpdateUser(<UserModel>{ Loading: true });
    this.httpClient.post<UserModel>('/api/Auth/Token', { LoginEmail: loginEmail, Password: password }).subscribe((x) => {
      localStorage.setItem('currentUser', JSON.stringify(x));
      this.UpdateUser(x)
      this.UpdateUser(<UserModel>{ Loading: false });
      console.debug(x);
      router.navigateByUrl('', { skipLocationChange: true }).then(() => {
        router.navigate([`/${language}/login`]);
      });
    },
      (e: any) => {
        this.UpdateUser(<UserModel>{ Loading: false, Error: (<HttpErrorResponse>e).error.message });
        console.debug(e);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${language}/login`]);
        });
      }, () => {
        this.UpdateUser(<UserModel>{ Loading: false });
        console.debug("completed...");
      });
  }

  Logout(router: Router, language: string) {
    localStorage.removeItem('currentUser');
    this.ClearUser();
    router.navigateByUrl(`${language}`, { skipLocationChange: true }).then(() => {
      router.navigateByUrl('');
    });

  }

}
