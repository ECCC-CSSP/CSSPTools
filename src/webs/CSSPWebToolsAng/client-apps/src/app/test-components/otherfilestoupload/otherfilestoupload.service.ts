/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { OtherFilesToUploadTextModel, OtherFilesToUploadModel } from './otherfilestoupload.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesOtherFilesToUploadText } from './otherfilestoupload.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { OtherFilesToUpload } from 'src/app/models/generated/OtherFilesToUpload.model';

@Injectable({
  providedIn: 'root'
})
export class OtherFilesToUploadService {
  otherfilestouploadTextModel$: BehaviorSubject<OtherFilesToUploadTextModel> = new BehaviorSubject<OtherFilesToUploadTextModel>(<OtherFilesToUploadTextModel>{});
  otherfilestouploadModel$: BehaviorSubject<OtherFilesToUploadModel> = new BehaviorSubject<OtherFilesToUploadModel>(<OtherFilesToUploadModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesOtherFilesToUploadText(this);
    this.UpdateOtherFilesToUploadText(<OtherFilesToUploadTextModel>{ Title: "Something2 for text" });
  }

  UpdateOtherFilesToUploadText(otherfilestouploadTextModel: OtherFilesToUploadTextModel) {
    this.otherfilestouploadTextModel$.next(<OtherFilesToUploadTextModel>{ ...this.otherfilestouploadTextModel$.getValue(), ...otherfilestouploadTextModel });
  }

  UpdateOtherFilesToUploadModel(otherfilestouploadModel: OtherFilesToUploadModel) {
    this.otherfilestouploadModel$.next(<OtherFilesToUploadModel>{ ...this.otherfilestouploadModel$.getValue(), ...otherfilestouploadModel });
  }

  GetOtherFilesToUpload(router: Router) {
    let oldURL = router.url;
    this.UpdateOtherFilesToUploadModel(<OtherFilesToUploadModel>{ Working: true, Error: null });

    return this.httpClient.get<OtherFilesToUpload[]>('/api/OtherFilesToUpload').pipe(
      map((x: any) => {
        console.debug(`OtherFilesToUpload OK. Return: ${x}`);
        this.otherfilestouploadModel$.getValue().OtherFilesToUploadList = <OtherFilesToUpload[]>x;
        this.UpdateOtherFilesToUploadModel(this.otherfilestouploadModel$.getValue());
        this.UpdateOtherFilesToUploadModel(<OtherFilesToUploadModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateOtherFilesToUploadModel(<OtherFilesToUploadModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`OtherFilesToUpload ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
