import { Injectable } from '@angular/core';
import { GenerateEnumsModel } from './generate-enums.models';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class GenerateEnumsService {
  generateEnumsModel$: BehaviorSubject<GenerateEnumsModel> = new BehaviorSubject<GenerateEnumsModel>(<GenerateEnumsModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateEnums(<GenerateEnumsModel>{ Working: false });
  }

  UpdateEnums(generateEnumsModel: GenerateEnumsModel) {
    this.generateEnumsModel$.next(<GenerateEnumsModel>{ ...this.generateEnumsModel$.getValue(), ...generateEnumsModel });
  }

  SendEnumsCommand(router: Router, command: GenerateEnumsType)
  {
    let oldURL = router.url;
    this.UpdateEnums(<GenerateEnumsModel>{ Working: true, Error: null, Status: '' });
    return this.httpClient.post<ActionReturn>('/api/GenerateEnums', { Command: command }).pipe(
      map((x: any) => {
        console.debug(`${command} OK. Return: ${x.Return}`);
        this.UpdateEnums(<GenerateEnumsModel>{ Working: false, Error: null, Status: (<ActionReturn>x).OKText });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });    
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateEnums(<GenerateEnumsModel>{ Working: false, Error: <HttpErrorResponse>e, Status: '' });
        console.debug(`${command} ERROR. Return: ${this.generateEnumsModel$.value.Error}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });    
       }))) 
      //,
      // finalize(() => {
      //   this.UpdateEnums(<GenerateEnumsModel>{ Working: false });
      //   console.debug(`${command} COMPLETED`);
      // })
    );
  }

  CompareEnumsAndOldEnums(router: Router) {
    return this.SendEnumsCommand(router, 'CompareEnumsAndOldEnums');
  }

  EnumsGenerated_cs(router: Router) {
    return this.SendEnumsCommand(router, 'EnumsGenerated_cs');
  }

  EnumsTestGenerated_cs(router: Router) {
    return this.SendEnumsCommand(router, 'EnumsTestGenerated_cs');
  }

  GeneratePolSourceEnumCodeFiles(router: Router) {
    return this.SendEnumsCommand(router, 'GeneratePolSourceEnumCodeFiles');
  }
}

export interface ActionReturn {
  OKText: string;
  ErrorText: string;
}

export type GenerateEnumsType = 'CompareEnumsAndOldEnums' | 'EnumsGenerated_cs' | 'EnumsTestGenerated_cs' | 'GeneratePolSourceEnumCodeFiles';