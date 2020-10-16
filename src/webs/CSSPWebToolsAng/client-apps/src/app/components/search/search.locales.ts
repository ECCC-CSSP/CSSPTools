import { AppService } from 'src/app/app.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { SearchVar } from './search.models';
import { SearchService } from './search.service';

export function LoadLocalesSearchVar(appService: AppService, searchService: SearchService) {
  let searchVar: SearchVar = { 
    SearchTitle: 'Yes The title',
}

  if (appService.AppVar$.getValue().Language == LanguageEnum.fr) {
      searchVar.SearchTitle = 'Yes Le Titre';
    }

  searchService.UpdateSearchVar(searchVar);
}
