import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRootVar } from './root.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { WebRoot } from '../../models/generated/WebRoot.model';
import { RootVar } from './root.models';
import { MapService } from '../../components/map';
import { AppService } from '../../app.service';

@Injectable({
  providedIn: 'root'
})
export class RootService {
  RootVar$: BehaviorSubject<RootVar> = new BehaviorSubject<RootVar>(<RootVar>{});

  constructor(public appService: AppService, private mapService: MapService, private httpClient: HttpClient) {
    LoadLocalesRootVar(appService, this);
    this.UpdateRootVar(<RootVar>{ RootTitle: "Something for text" });
  }

  GetWebRoot(TVItemID: number) {
    this.UpdateRootVar(<RootVar>{ Working: true });
    let url: string = `${ this.appService.AppVar$.getValue().BaseApiUrl }en-CA/Read/WebRoot/${TVItemID}/1`;
    return this.httpClient.get<WebRoot>(url).pipe(
      map((x: any) => {
        this.UpdateRootVar(<RootVar>{ WebRoot: x, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateRootVar(<RootVar>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateRootVar(rootVar: RootVar) {
    this.RootVar$.next(<RootVar>{ ...this.RootVar$.getValue(), ...rootVar });

    let RootVarCountryList: RootVar = <RootVar>{ WebBaseCountryList: [] };

    if (this.appService.AppVar$?.getValue()?.InactVisible) {
      RootVarCountryList = <RootVar>{ WebBaseCountryList: this.RootVar$?.getValue()?.WebRoot?.TVItemCountryList.filter((country) => { return country.TVItemModel.TVItem.IsActive == true }) };
    }
    else {
      RootVarCountryList = <RootVar>{ WebBaseCountryList: this.RootVar$?.getValue()?.WebRoot?.TVItemCountryList };
    }

    this.RootVar$.next(<RootVar>{ ...this.RootVar$.getValue(), ...RootVarCountryList });

  }

}
