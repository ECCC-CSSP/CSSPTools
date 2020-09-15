import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Contact } from '../../models/generated/Contact.model';
import { LanguageEnum } from '../grouping';
import { ShellModel } from './shell.models';

@Injectable({
  providedIn: 'root'
})
export class ShellService {
  shellModel$: BehaviorSubject<ShellModel> = new BehaviorSubject<ShellModel>(<ShellModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateShell(<ShellModel>{ Language: $localize.locale == "fr-CA" ? LanguageEnum.fr : LanguageEnum.en });
   }

   GetLoggedInContact() {
    return this.httpClient.get<Contact>('/api/LoggedInContact').pipe(
      map((x: any) => {
        this.UpdateShell(<ShellModel>{ Contact: x, Loading: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateShell(<ShellModel>{ Loading: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateShell(shellModel: ShellModel)
  {
    this.shellModel$.next(<ShellModel>{...this.shellModel$.getValue(), ...shellModel});
  }
}
