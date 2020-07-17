/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { PreferenceTextModel } from './preference.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesPreferenceText } from './preference.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Preference } from '../../../models/generated/Preference.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class PreferenceService {
  /* Variables */
  preferenceTextModel$: BehaviorSubject<PreferenceTextModel> = new BehaviorSubject<PreferenceTextModel>(<PreferenceTextModel>{});
  preferenceListModel$: BehaviorSubject<Preference[]> = new BehaviorSubject<Preference[]>(<Preference[]>{});
  preferenceGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  preferencePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  preferencePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  preferenceDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesPreferenceText(this.preferenceTextModel$);
    this.preferenceTextModel$.next(<PreferenceTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetPreferenceList() {
    this.httpClientService.BeforeHttpClient(this.preferenceGetModel$);

    return this.httpClient.get<Preference[]>('/api/Preference').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Preference>(this.preferenceListModel$, this.preferenceGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Preference>(this.preferenceListModel$, this.preferenceGetModel$, e);
      })))
    );
  }

  PutPreference(preference: Preference) {
    this.httpClientService.BeforeHttpClient(this.preferencePutModel$);

    return this.httpClient.put<Preference>('/api/Preference', preference, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Preference>(this.preferenceListModel$, this.preferencePutModel$, x, HttpClientCommand.Put, preference);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<Preference>(this.preferenceListModel$, this.preferencePutModel$, e);
      })))
    );
  }

  PostPreference(preference: Preference) {
    this.httpClientService.BeforeHttpClient(this.preferencePostModel$);

    return this.httpClient.post<Preference>('/api/Preference', preference, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Preference>(this.preferenceListModel$, this.preferencePostModel$, x, HttpClientCommand.Post, preference);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Preference>(this.preferenceListModel$, this.preferencePostModel$, e);
      })))
    );
  }

  DeletePreference(preference: Preference) {
    this.httpClientService.BeforeHttpClient(this.preferenceDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/Preference/${ preference.PreferenceID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<Preference>(this.preferenceListModel$, this.preferenceDeleteModel$, x, HttpClientCommand.Delete, preference);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<Preference>(this.preferenceListModel$, this.preferenceDeleteModel$, e);
      })))
    );
  }
}
