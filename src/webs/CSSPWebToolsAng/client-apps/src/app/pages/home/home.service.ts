import { Injectable } from '@angular/core';
import { AdminContactModel, HomeTextModel } from './home.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesHomeText } from './home.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { WebContact } from '../../models/generated/WebContact.model';
import { Contact } from '../../models/generated/Contact.model';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  HomeTextModel$: BehaviorSubject<HomeTextModel> = new BehaviorSubject<HomeTextModel>(<HomeTextModel>{});
  AdminContactModel$: BehaviorSubject<AdminContactModel> = new BehaviorSubject<AdminContactModel>(<AdminContactModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesHomeText(this);
    this.UpdateHomeTextModel(<HomeTextModel>{ Title: "Something for text" });
    this.UpdateAdminContactModel(<AdminContactModel>{ AdminList: [] });
  }

  GetAdminContactList() {
    this.UpdateAdminContactModel(<AdminContactModel>{ Working: true });
    return this.httpClient.get<WebContact>(`/api/Read/WebContact/0/1`).pipe(
      map((x: WebContact) => {
        let adminList: Contact[] = x.ContactList.filter(contact => contact.IsAdmin == true);
        this.UpdateAdminContactModel(<AdminContactModel>{ AdminList: adminList, Working: false });
        console.debug(adminList);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAdminContactModel(<AdminContactModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateHomeTextModel(homeTextModel: HomeTextModel) {
    this.HomeTextModel$.next(<HomeTextModel>{ ...this.HomeTextModel$.getValue(), ...homeTextModel });
  }

  UpdateAdminContactModel(adminContactModel: AdminContactModel) {
    this.AdminContactModel$.next(<AdminContactModel>{ ...this.AdminContactModel$.getValue(), ...adminContactModel });
  }

}
