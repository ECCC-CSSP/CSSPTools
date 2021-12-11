import { Injectable } from '@angular/core';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { ContactModel } from 'src/app/models/generated/models/ContactModel.model';
import { TVFileModel } from 'src/app/models/generated/models/TVFileModel.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from '../app/app-loaded.service';
import { JsonDataIsLoadedService } from '../json/json-data-is-loaded.service';

@Injectable({
  providedIn: 'root'
})
export class ContactNameService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    private jsonDataIsLoadedService: JsonDataIsLoadedService) {
  }

  GetContactNameTVItemModel(tvItemModel: TVItemModel) {
    return this.GetContactName(tvItemModel?.TVItem?.LastUpdateContactTVItemID);
  }

  GetContactNameTVFileModel(tvFileModel: TVFileModel) {
    return this.GetContactName(tvFileModel?.TVFile?.LastUpdateContactTVItemID);
  }

  private GetContactName(LastUpdateContactTVItemID: number)
  {
    if (this.jsonDataIsLoadedService.DataIsLoaded(WebTypeEnum.WebAllContacts)) {
      let contactModelList: ContactModel[] = this.appLoadedService.WebAllContacts.ContactModelList.filter(c => c.Contact != null && c.Contact.ContactTVItemID == LastUpdateContactTVItemID);
      if (contactModelList != null && contactModelList?.length > 0) {
        return `${contactModelList[0].Contact.FirstName} ${contactModelList[0].Contact.LastName}`;
      }
      else {
        return this.appLanguageService.ContactNotFound[this.appLanguageService.LangID];
      }
    }
    else {
      return this.appLanguageService.ContactNotFound[this.appLanguageService.LangID];
    }
  }
}
