/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { RegisterTextModel, RegisterModel } from './register.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRegisterText } from './register.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Register } from 'src/app/models/generated/Register.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  registerTextModel$: BehaviorSubject<RegisterTextModel> = new BehaviorSubject<RegisterTextModel>(<RegisterTextModel>{});
  registerModel$: BehaviorSubject<RegisterModel> = new BehaviorSubject<RegisterModel>(<RegisterModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesRegisterText(this);
    this.UpdateRegisterText(<RegisterTextModel>{ Title: "Something2 for text" });
  }

  UpdateRegisterText(registerTextModel: RegisterTextModel) {
    this.registerTextModel$.next(<RegisterTextModel>{ ...this.registerTextModel$.getValue(), ...registerTextModel });
  }

  UpdateRegisterModel(registerModel: RegisterModel) {
    this.registerModel$.next(<RegisterModel>{ ...this.registerModel$.getValue(), ...registerModel });
  }

  GetRegister(router: Router) {
    let oldURL = router.url;
    this.UpdateRegisterModel(<RegisterModel>{ Working: true, Error: null });

    return this.httpClient.get<Register[]>('/api/Register').pipe(
      map((x: any) => {
        console.debug(`Register OK. Return: ${x}`);
        this.registerModel$.getValue().RegisterList = <Register[]>x;
        this.UpdateRegisterModel(this.registerModel$.getValue());
        this.UpdateRegisterModel(<RegisterModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateRegisterModel(<RegisterModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`Register ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
