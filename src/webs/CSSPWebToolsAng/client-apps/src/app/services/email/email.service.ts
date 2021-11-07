import { Injectable } from '@angular/core';
import { Email } from 'src/app/models/generated/db/Email.model';
import { AppLoadedService } from '../app/app-loaded.service';
import { AppStateService } from '../app/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
  ) {
  }

  GetEmail(tvItemID: number): Email {
    if (this.appLoadedService.WebAllEmails == undefined)
    {
      return <Email>{};
    }
    let emailList: Email[] = this.appLoadedService.WebAllEmails.EmailList.filter(c => c.EmailTVItemID == tvItemID);
    if (emailList == null || emailList == undefined || emailList.length == 0) {
      return <Email>{};
    }
    return emailList[0];
  }

}
