import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpErrorResponse, HttpClient, HttpEvent } from '@angular/common/http';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { GetLanguageEnum } from '../../enums/generated/LanguageEnum';
@Injectable({
  providedIn: 'root'
})

export class FileUploadService {
  errorMessage: string;
  languageEnum = GetLanguageEnum();

  SERVER_URL: string = "https://file.io/";

  constructor(private appLoadedService: AppLoadedService,
    private appStateService: AppStateService,
    private httpClient: HttpClient) { }

  public upload(formData) {
     const url: string = `${this.appLoadedService.BaseApiUrl}${this.languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Upload`;

    return this.httpClient.post<any>(url, formData, {
      reportProgress: true,
      observe: 'events'
    });
  }

  // Upload(name: string, file: File): Observable<HttpEvent<any>> {
  //   var formData: any = new FormData();
  //   formData.append("fileName", file);

  //   let url: string = `${this.appLoadedService.BaseApiUrl}${this.languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Upload`;

  //   return this.http.post<any>(url, formData, {
  //     reportProgress: true,
  //     observe: 'events'
  //   }).pipe(
  //     catchError(this.errorMgmt)
  //   )
  // }

  // errorMgmt(error: HttpErrorResponse) {
  //   let errorMessage = '';
  //   if (error.error instanceof ErrorEvent) {
  //     // Get client-side error
  //     errorMessage = error.error.message;
  //   } else {
  //     // Get server-side error
  //     errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
  //   }
  //   console.log(errorMessage);
  //   return throwError(errorMessage);
  // }

}