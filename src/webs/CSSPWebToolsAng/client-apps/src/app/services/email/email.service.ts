import { Injectable } from '@angular/core';
import { EmailModel } from 'src/app/models/generated/web/EmailModel.model';
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

  GetEmailModel(tvItemID: number): EmailModel {
    if (this.appLoadedService.WebAllEmails == undefined)
    {
      return <EmailModel>{};
    }
    let emailModelList: EmailModel[] = this.appLoadedService.WebAllEmails.EmailModelList.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemID);
    if (emailModelList == null || emailModelList == undefined || emailModelList.length == 0) {
      return <EmailModel>{};
    }
    return emailModelList[0];
  }

}
