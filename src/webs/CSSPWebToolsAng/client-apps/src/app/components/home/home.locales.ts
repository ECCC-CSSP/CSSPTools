import { AppService } from 'src/app/app.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { HomeVar } from './home.models';
import { HomeService } from './home.service';

export function LoadLocalesHomeText(appService: AppService, homeService: HomeService) {
  let homeVar: HomeVar = { 
    HomeTitle: 'The title',
}

  if (appService.AppVar$.getValue().Language == LanguageEnum.fr) {
      homeVar.HomeTitle = 'Le Titre';
    }

  homeService.UpdateHomeVar(homeVar);
}
