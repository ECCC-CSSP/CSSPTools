import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRootText } from './root.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

import { WebRoot } from '../../models/generated/WebRoot.model';
import { RootTextModel, WebBaseCountryModel, WebRootModel } from './root.models';
import { BreadCrumbModel } from '../../models/BreadCrumb.model';
import { ShellService } from '../shell';
import { MapModel, MapService } from 'src/app/components/map';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { WebBase } from 'src/app/models/generated/WebBase.model';

@Injectable({
  providedIn: 'root'
})
export class RootService {
  RootTextModel$: BehaviorSubject<RootTextModel> = new BehaviorSubject<RootTextModel>(<RootTextModel>{});
  WebRootModel$: BehaviorSubject<WebRootModel> = new BehaviorSubject<WebRootModel>(<WebRootModel>{});
  WebCountryModel$: BehaviorSubject<WebBaseCountryModel> = new BehaviorSubject<WebBaseCountryModel>(<WebBaseCountryModel>{});

  constructor(public shellService: ShellService, private mapService: MapService, private httpClient: HttpClient) {
    LoadLocalesRootText(this);
    this.UpdateRootTextModel(<RootTextModel>{ Title: "Something for text" });
  }

  GetWebRoot(TVItemID: number) {
    this.UpdateWebRootModel(<WebRootModel>{ Working: true });
    return this.httpClient.get<WebRoot>(`/api/Read/WebRoot/${TVItemID}/1`).pipe(
      map((x: any) => {
        this.UpdateWebRootModel(<WebRootModel>{ WebRoot: x, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateWebRootModel(<WebRootModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateRootTextModel(rootTextModel: RootTextModel) {
    this.RootTextModel$.next(<RootTextModel>{ ...this.RootTextModel$.getValue(), ...rootTextModel });
  }

  UpdateWebRootModel(webRootModel: WebRootModel) {
    this.WebRootModel$.next(<WebRootModel>{ ...this.WebRootModel$.getValue(), ...webRootModel });
    this.shellService.UpdateBreadCrumbModel(<BreadCrumbModel>{ WebBaseList: [] });

    let webBaseCountryModel: WebBaseCountryModel = <WebBaseCountryModel>{ WebBaseCountryList: [] };

    if (this.shellService.ShellModel$?.getValue()?.ActiveVisible && this.shellService.ShellModel$?.getValue()?.InactVisible) {
      webBaseCountryModel = <WebBaseCountryModel>{ WebBaseCountryList: this.WebRootModel$?.getValue()?.WebRoot?.TVItemCountryList };
    }
    else if (this.shellService.ShellModel$?.getValue()?.ActiveVisible) {
      webBaseCountryModel = <WebBaseCountryModel>{ WebBaseCountryList: this.WebRootModel$?.getValue()?.WebRoot?.TVItemCountryList.filter((country) => { return country.TVItemModel.TVItem.IsActive == true }) };
    }
    else if (this.shellService.ShellModel$?.getValue()?.InactVisible) {
      webBaseCountryModel = <WebBaseCountryModel>{ WebBaseCountryList: this.WebRootModel$?.getValue()?.WebRoot?.TVItemCountryList.filter((country) => { return country.TVItemModel.TVItem.IsActive == false }) };
    }

    this.UpdateWebCountryModel(webBaseCountryModel);
  }

  UpdateWebCountryModel(webBaseCountryModel: WebBaseCountryModel) {
    this.WebCountryModel$.next(<WebBaseCountryModel>{ ...this.WebCountryModel$.getValue(), ...webBaseCountryModel });
    if (webBaseCountryModel.WebBaseCountryList != undefined) {
      if (webBaseCountryModel.WebBaseCountryList != undefined && webBaseCountryModel.WebBaseCountryList.length > 0) {
        // this.mapService.FillMapMarkers(webBaseCountryModel.WebBaseCountryList);
        // this.mapService.FillMapPolygons(webBaseCountryModel.WebBaseCountryList);
      }
    }
  }
}
