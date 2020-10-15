import { AppService } from 'src/app/app.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { RootVar } from './root.models';
import { RootService } from './root.service';

export function LoadLocalesRootVar(appService: AppService, rootService: RootService) {
  let rootVar: RootVar = { 
    RootTitle: 'The title',
}

  if (appService.AppVar$.getValue().Language == LanguageEnum.fr) {
      rootVar.RootTitle = 'Le Titre';
    }

  rootService.UpdateRootVar(rootVar);
}
