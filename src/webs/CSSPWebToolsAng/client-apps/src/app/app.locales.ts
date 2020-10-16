import { AppService } from './app.service';
import { AppVar } from './app.model';
import { LanguageEnum } from './enums/generated/LanguageEnum';

export function LoadLocalesApp(appService: AppService) {
  let appVar: AppVar = {
    //AppName: 'CSSP Web Tools',
  }

  if (appService.AppVar$.getValue().Language == LanguageEnum.fr) {
    //appVar.AppName = "PCCSM Outils Web";
  }

  appService.UpdateAppVar(appVar);
}
