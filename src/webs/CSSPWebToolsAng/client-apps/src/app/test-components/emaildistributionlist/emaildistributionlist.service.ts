/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { EmailDistributionListTextModel, EmailDistributionListModel } from './emaildistributionlist.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesEmailDistributionListText } from './emaildistributionlist.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { EmailDistributionList } from 'src/app/models/generated/EmailDistributionList.model';

@Injectable({
  providedIn: 'root'
})
export class EmailDistributionListService {
  emaildistributionlistTextModel$: BehaviorSubject<EmailDistributionListTextModel> = new BehaviorSubject<EmailDistributionListTextModel>(<EmailDistributionListTextModel>{});
  emaildistributionlistModel$: BehaviorSubject<EmailDistributionListModel> = new BehaviorSubject<EmailDistributionListModel>(<EmailDistributionListModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesEmailDistributionListText(this);
    this.UpdateEmailDistributionListText(<EmailDistributionListTextModel>{ Title: "Something2 for text" });
  }

  UpdateEmailDistributionListText(emaildistributionlistTextModel: EmailDistributionListTextModel) {
    this.emaildistributionlistTextModel$.next(<EmailDistributionListTextModel>{ ...this.emaildistributionlistTextModel$.getValue(), ...emaildistributionlistTextModel });
  }

  UpdateEmailDistributionListModel(emaildistributionlistModel: EmailDistributionListModel) {
    this.emaildistributionlistModel$.next(<EmailDistributionListModel>{ ...this.emaildistributionlistModel$.getValue(), ...emaildistributionlistModel });
  }

  GetEmailDistributionList(router: Router) {
    let oldURL = router.url;
    this.UpdateEmailDistributionListModel(<EmailDistributionListModel>{ Working: true, Error: null });

    return this.httpClient.get<EmailDistributionList[]>('/api/EmailDistributionList').pipe(
      map((x: any) => {
        console.debug(`EmailDistributionList OK. Return: ${x}`);
        this.emaildistributionlistModel$.getValue().EmailDistributionListList = <EmailDistributionList[]>x;
        this.UpdateEmailDistributionListModel(this.emaildistributionlistModel$.getValue());
        this.UpdateEmailDistributionListModel(<EmailDistributionListModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateEmailDistributionListModel(<EmailDistributionListModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`EmailDistributionList ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
