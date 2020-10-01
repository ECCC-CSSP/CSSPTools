import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesProvinceText } from './province.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

import { WebProvince } from '../../models/generated/WebProvince.model';
import { ProvinceTextModel, WebBaseAreaModel, WebProvinceModel } from './province.models';
import { BreadCrumbModel } from 'src/app/models/BreadCrumb.model';
import { ShellService } from '../shell';
import { MapService } from 'src/app/components/map';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {
  ProvinceTextModel$: BehaviorSubject<ProvinceTextModel> = new BehaviorSubject<ProvinceTextModel>(<ProvinceTextModel>{});
  WebProvinceModel$: BehaviorSubject<WebProvinceModel> = new BehaviorSubject<WebProvinceModel>(<WebProvinceModel>{});
  WebAreaModel$: BehaviorSubject<WebBaseAreaModel> = new BehaviorSubject<WebBaseAreaModel>(<WebBaseAreaModel>{});

  constructor(public shellService: ShellService, private mapService: MapService, private httpClient: HttpClient) {
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
    this.shellService.UpdateBreadCrumbModel(<BreadCrumbModel>{ WebBaseList: this.WebProvinceModel$.getValue()?.WebProvince?.TVItemParentList });

    let webBaseAreaModel: WebBaseAreaModel = <WebBaseAreaModel>{ WebBaseAreaList: [] };

    if (this.shellService.ShellModel$?.getValue()?.ActiveVisible && this.shellService.ShellModel$?.getValue()?.InactVisible) {
      webBaseAreaModel = <WebBaseAreaModel>{ WebBaseAreaList: this.WebProvinceModel$?.getValue()?.WebProvince?.TVItemAreaList };
    }
    else if (this.shellService.ShellModel$?.getValue()?.ActiveVisible) {
      webBaseAreaModel = <WebBaseAreaModel>{ WebBaseAreaList: this.WebProvinceModel$?.getValue()?.WebProvince?.TVItemAreaList.filter((country) => { return country.TVItemModel.TVItem.IsActive == true }) };
    }
    else if (this.shellService.ShellModel$?.getValue()?.InactVisible) {
      webBaseAreaModel = <WebBaseAreaModel>{ WebBaseAreaList: this.WebProvinceModel$?.getValue()?.WebProvince?.TVItemAreaList.filter((country) => { return country.TVItemModel.TVItem.IsActive == false }) };
    }

    this.UpdateWebAreaModel(webBaseAreaModel);
  }

  UpdateWebAreaModel(webBaseAreaModel: WebBaseAreaModel) {
    this.WebAreaModel$.next(<WebBaseAreaModel>{ ...this.WebAreaModel$.getValue(), ...webBaseAreaModel });

    if (webBaseAreaModel.WebBaseAreaList != undefined  && webBaseAreaModel.WebBaseAreaList.length > 0) {
      this.mapService.FillMapMarkers(webBaseAreaModel.WebBaseAreaList);
  }
}

}
