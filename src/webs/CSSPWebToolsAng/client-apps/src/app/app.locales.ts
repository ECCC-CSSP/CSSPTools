import { AppService } from './app.service';
import { AppVar } from './app.model';

export function LoadLocalesApp(appService: AppService) {
  let appVar: AppVar = {
    //AppName: 'CSSP Web Tools',
  }

  if ($localize.locale === 'fr-CA') {
    //appVar.AppName = "PCCSM Outils Web";
  }

  appService.UpdateAppVar(appVar);
}
