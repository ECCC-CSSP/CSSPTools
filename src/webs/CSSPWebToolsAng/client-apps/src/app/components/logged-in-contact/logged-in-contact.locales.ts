import { AppService } from 'src/app/app.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { LoggedInContactVar } from './logged-in-contact.models';
import { LoggedInContactService } from './logged-in-contact.service';

export function LoadLocalesLoggedInContactText(appService: AppService, loggedInContactService: LoggedInContactService) {
  let loggedInContactVar: LoggedInContactVar = {
    LoggedInContactTitle: 'Yes The title',
  }

  if (appService.AppVar$.getValue().Language == LanguageEnum.fr) {
    loggedInContactVar.LoggedInContactTitle = 'Yes Le Titre';
  }

  loggedInContactService.UpdateLoggedInContactVar(loggedInContactVar);
}
