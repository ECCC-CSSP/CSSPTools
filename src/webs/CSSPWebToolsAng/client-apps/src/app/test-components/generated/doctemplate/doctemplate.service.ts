/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { DocTemplateTextModel } from './doctemplate.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesDocTemplateText } from './doctemplate.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { DocTemplate } from '../../../models/generated/DocTemplate.model';
import { HttpRequestModel } from '../../../models/HttpRequest.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class DocTemplateService {
  /* Variables */
  doctemplateTextModel$: BehaviorSubject<DocTemplateTextModel> = new BehaviorSubject<DocTemplateTextModel>(<DocTemplateTextModel>{});
  doctemplateListModel$: BehaviorSubject<DocTemplate[]> = new BehaviorSubject<DocTemplate[]>(<DocTemplate[]>{});
  doctemplateGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  doctemplatePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  doctemplatePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  doctemplateDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesDocTemplateText(this.doctemplateTextModel$);
    this.doctemplateTextModel$.next(<DocTemplateTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetDocTemplateList() {
    this.httpClientService.BeforeHttpClient(this.doctemplateGetModel$);

    return this.httpClient.get<DocTemplate[]>('/api/DocTemplate').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<DocTemplate>(this.doctemplateListModel$, this.doctemplateGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<DocTemplate>(this.doctemplateListModel$, this.doctemplateGetModel$, e);
      })))
    );
  }

  PutDocTemplate(doctemplate: DocTemplate) {
    this.httpClientService.BeforeHttpClient(this.doctemplatePutModel$);

    return this.httpClient.put<DocTemplate>('/api/DocTemplate', doctemplate, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<DocTemplate>(this.doctemplateListModel$, this.doctemplatePutModel$, x, HttpClientCommand.Put, doctemplate);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<DocTemplate>(this.doctemplateListModel$, this.doctemplatePutModel$, e);
      })))
    );
  }

  PostDocTemplate(doctemplate: DocTemplate) {
    this.httpClientService.BeforeHttpClient(this.doctemplatePostModel$);

    return this.httpClient.post<DocTemplate>('/api/DocTemplate', doctemplate, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<DocTemplate>(this.doctemplateListModel$, this.doctemplatePostModel$, x, HttpClientCommand.Post, doctemplate);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<DocTemplate>(this.doctemplateListModel$, this.doctemplatePostModel$, e);
      })))
    );
  }

  DeleteDocTemplate(doctemplate: DocTemplate) {
    this.httpClientService.BeforeHttpClient(this.doctemplateDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/DocTemplate/${ doctemplate.DocTemplateID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<DocTemplate>(this.doctemplateListModel$, this.doctemplateDeleteModel$, x, HttpClientCommand.Delete, doctemplate);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<DocTemplate>(this.doctemplateListModel$, this.doctemplateDeleteModel$, e);
      })))
    );
  }
}
