import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesProvinceText } from './province.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

import { WebProvince } from '../../models/generated/WebProvince.model';
import { ProvinceTextModel, WebProvinceModel } from './province.models';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {
  ProvinceTextModel$: BehaviorSubject<ProvinceTextModel> = new BehaviorSubject<ProvinceTextModel>(<ProvinceTextModel>{});
  WebProvinceModel$: BehaviorSubject<WebProvinceModel> = new BehaviorSubject<WebProvinceModel>(<WebProvinceModel>{});
  
  constructor(private httpClient: HttpClient) {
    LoadLocalesProvinceText(this);
    this.UpdateProvinceText(<ProvinceTextModel>{ Title: "Something for text" });
  }

  GetWebProvince(TVItemID: number) {
    this.UpdateWebProvince(<WebProvinceModel>{ Working: true });
    return this.httpClient.get<WebProvince>(`/api/Read/WebProvince/${ TVItemID }/1`).pipe(
      map((x: any) => {
        this.UpdateWebProvince(<WebProvinceModel>{ WebProvince: x, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateWebProvince(<WebProvinceModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateProvinceText(ProvinceTextModel: ProvinceTextModel) {
    this.ProvinceTextModel$.next(<ProvinceTextModel>{ ...this.ProvinceTextModel$.getValue(), ...ProvinceTextModel });
  }

  UpdateWebProvince(WebProvinceModel: WebProvinceModel) {
    this.WebProvinceModel$.next(<WebProvinceModel>{ ...this.WebProvinceModel$.getValue(), ...WebProvinceModel });
  }
}
