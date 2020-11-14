import { Injectable } from '@angular/core';
import { Contact } from 'src/app/models/generated/db/Contact.model';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from '../app-loaded.service';

@Injectable({
  providedIn: 'root'
})
export class ContactNameService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService) {
  }

  GetContactNameTVItemModel(tvItemModel: TVItemModel) {
    return this.GetContactName(tvItemModel.TVItem.LastUpdateContactTVItemID);
  }

  GetContactNameTVFileModel(tvFileModel: TVFileModel) {
    return this.GetContactName(tvFileModel.TVFile.LastUpdateContactTVItemID);
  }

  private GetContactName(LastUpdateContactTVItemID: number)
  {
    if (this.appLoadedService.AppLoaded$?.getValue()?.WebContact) {
      const contactList: Contact[] = this.appLoadedService.AppLoaded$?.getValue()?.WebContact.ContactList.filter((c) => { return c.ContactTVItemID == LastUpdateContactTVItemID });
      if (contactList && contactList.length > 0) {
        return `${contactList[0].FirstName} ${contactList[0].LastName}`;
      }
      else {
        return this.appLanguageService.AppLanguage?.ContactNotFound[this.appStateService.AppState$?.getValue().Language];
      }
    }
    else {
      return this.appLanguageService.AppLanguage?.ContactNotFound[this.appStateService.AppState$?.getValue().Language];
    }
  }
}
