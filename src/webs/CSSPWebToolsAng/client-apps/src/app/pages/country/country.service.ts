import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesCountryVar } from './country.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

import { WebCountry } from '../../models/generated/WebCountry.model';
import { MapService } from '../../components/map';
import { CountryVar } from '.';
import { AppService } from '../../app.service';
import { BreadCrumbVar } from 'src/app/components/bread-crumb';
import { AppVar } from 'src/app/app.model';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  CountryVar$: BehaviorSubject<CountryVar> = new BehaviorSubject<CountryVar>(<CountryVar>{});

  constructor(public appService: AppService, private mapService: MapService, private httpClient: HttpClient) {
    LoadLocalesCountryVar(this);
    this.UpdateCountryVar(<CountryVar>{ CountryTitle: "Something for text" });
  }

  GetWebCountry(TVItemID: number) {
    this.UpdateCountryVar(<CountryVar>{ Working: true });
    return this.httpClient.get<WebCountry>(`/api/Read/WebCountry/${ TVItemID }/1`).pipe(
      map((x: any) => {
        this.UpdateCountryVar(<CountryVar>{ WebCountry: x, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateCountryVar(<CountryVar>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateCountryVar(countryVar: CountryVar) {
    this.CountryVar$.next(<CountryVar>{ ...this.CountryVar$.getValue(), ...countryVar });

    let CountryVarProvinceList: CountryVar = <CountryVar>{ WebBaseProvinceList: [] };

    if (this.appService.AppVar$?.getValue()?.InactVisible) {
      CountryVarProvinceList = <CountryVar>{ WebBaseProvinceList: this.CountryVar$?.getValue()?.WebCountry?.TVItemProvinceList.filter((province) => { return province.TVItemModel.TVItem.IsActive == true }) };
    }
    else {
      CountryVarProvinceList = <CountryVar>{ WebBaseProvinceList: this.CountryVar$?.getValue()?.WebCountry?.TVItemProvinceList };
    }

    this.CountryVar$.next(<CountryVar>{ ...this.CountryVar$.getValue(), ...CountryVarProvinceList });

    this.appService.UpdateAppVar(<AppVar>{ BreadCrumbWebBaseList: this.CountryVar$.getValue()?.WebCountry?.TVItemParentList });
  }
}
