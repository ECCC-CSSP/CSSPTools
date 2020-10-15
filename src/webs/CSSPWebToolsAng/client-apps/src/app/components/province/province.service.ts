import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesProvinceVar } from './province.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

import { WebProvince } from '../../models/generated/WebProvince.model';
import { ProvinceVar } from './province.models';
import { MapService } from '../../components/map';
import { AppService } from '../../app.service';
import { BreadCrumbVar } from '../../components/bread-crumb';
import { AppVar } from 'src/app/app.model';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {
  ProvinceVar$: BehaviorSubject<ProvinceVar> = new BehaviorSubject<ProvinceVar>(<ProvinceVar>{});

  constructor(public appService: AppService, private mapService: MapService, private httpClient: HttpClient) {
    LoadLocalesProvinceVar(this);
    this.UpdateProvinceVar(<ProvinceVar>{ ProvinceTitle: "Something for text" });
  }

  GetWebProvince(TVItemID: number) {
    this.UpdateProvinceVar(<ProvinceVar>{ Working: true });
    let url: string = `${this.appService.AppVar$.getValue().BaseApiUrl}en-CA/Read/WebProvince/${ TVItemID }/1`;
    return this.httpClient.get<WebProvince>(url).pipe(
      map((x: any) => {
        this.UpdateProvinceVar(<ProvinceVar>{ WebProvince: x, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateProvinceVar(<ProvinceVar>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateProvinceVar(provinceVar: ProvinceVar) {
    this.ProvinceVar$.next(<ProvinceVar>{ ...this.ProvinceVar$.getValue(), ...provinceVar });

    let ProvinceVarAreaList: ProvinceVar = <ProvinceVar>{ WebBaseAreaList: [] };

    if (this.appService.AppVar$?.getValue()?.InactVisible) {
      ProvinceVarAreaList = <ProvinceVar>{ WebBaseAreaList: this.ProvinceVar$?.getValue()?.WebProvince?.TVItemAreaList.filter((area) => { return area.TVItemModel.TVItem.IsActive == true }) };
    }
    else {
      ProvinceVarAreaList = <ProvinceVar>{ WebBaseAreaList: this.ProvinceVar$?.getValue()?.WebProvince?.TVItemAreaList };
    }

    this.ProvinceVar$.next(<ProvinceVar>{ ...this.ProvinceVar$.getValue(), ...ProvinceVarAreaList });

    this.appService.UpdateAppVar(<AppVar>{ BreadCrumbWebBaseList: this.ProvinceVar$.getValue()?.WebProvince?.TVItemParentList });
  }
}
