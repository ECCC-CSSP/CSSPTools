import { Injectable } from '@angular/core';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { AppLanguageService } from '../app/app-language.service';

@Injectable({
  providedIn: 'root'
})
export class TVItemService {

  constructor(private appLanguageService: AppLanguageService) {
  }

  GetDBCommandClass(TVItemModel) {
    switch (TVItemModel.TVItem.DBCommand) {
      case DBCommandEnum.Created:
        return 'tvItemCreatedColor';
      case DBCommandEnum.Modified:
        return 'tvItemModifiedColor';
      case DBCommandEnum.Deleted:
        return 'tvItemDeletedColor';
      default:
        return '';
    }
  }

  GetTitleOfDBCommand(TVItemModel) {
    switch (TVItemModel.TVItem.DBCommand) {
      case DBCommandEnum.Created:
        return this.appLanguageService.ItemIsCreatedLocal[this.appLanguageService.LangID];
      case DBCommandEnum.Modified:
        return this.appLanguageService.ItemIsModifiedLocal[this.appLanguageService.LangID];
      case DBCommandEnum.Deleted:
        return this.appLanguageService.ItemIsDeletedLocal[this.appLanguageService.LangID];
      default:
        return '';
    }
  }
}
