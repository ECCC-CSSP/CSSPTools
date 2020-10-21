/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { VPScenarioTextModel } from './vpscenario.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesVPScenarioText } from './vpscenario.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { VPScenario } from '../../../models/generated/VPScenario.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class VPScenarioService {
  /* Variables */
  vpscenarioTextModel$: BehaviorSubject<VPScenarioTextModel> = new BehaviorSubject<VPScenarioTextModel>(<VPScenarioTextModel>{});
  vpscenarioListModel$: BehaviorSubject<VPScenario[]> = new BehaviorSubject<VPScenario[]>(<VPScenario[]>{});
  vpscenarioGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  vpscenarioPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  vpscenarioPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  vpscenarioDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesVPScenarioText(this.vpscenarioTextModel$);
    this.vpscenarioTextModel$.next(<VPScenarioTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetVPScenarioList() {
    this.httpClientService.BeforeHttpClient(this.vpscenarioGetModel$);

    return this.httpClient.get<VPScenario[]>('/api/VPScenario').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<VPScenario>(this.vpscenarioListModel$, this.vpscenarioGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<VPScenario>(this.vpscenarioListModel$, this.vpscenarioGetModel$, e);
      })))
    );
  }

  PutVPScenario(vpscenario: VPScenario) {
    this.httpClientService.BeforeHttpClient(this.vpscenarioPutModel$);

    return this.httpClient.put<VPScenario>('/api/VPScenario', vpscenario, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<VPScenario>(this.vpscenarioListModel$, this.vpscenarioPutModel$, x, HttpClientCommand.Put, vpscenario);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<VPScenario>(this.vpscenarioListModel$, this.vpscenarioPutModel$, e);
      })))
    );
  }

  PostVPScenario(vpscenario: VPScenario) {
    this.httpClientService.BeforeHttpClient(this.vpscenarioPostModel$);

    return this.httpClient.post<VPScenario>('/api/VPScenario', vpscenario, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<VPScenario>(this.vpscenarioListModel$, this.vpscenarioPostModel$, x, HttpClientCommand.Post, vpscenario);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<VPScenario>(this.vpscenarioListModel$, this.vpscenarioPostModel$, e);
      })))
    );
  }

  DeleteVPScenario(vpscenario: VPScenario) {
    this.httpClientService.BeforeHttpClient(this.vpscenarioDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/VPScenario/${ vpscenario.VPScenarioID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<VPScenario>(this.vpscenarioListModel$, this.vpscenarioDeleteModel$, x, HttpClientCommand.Delete, vpscenario);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<VPScenario>(this.vpscenarioListModel$, this.vpscenarioDeleteModel$, e);
      })))
    );
  }
}
