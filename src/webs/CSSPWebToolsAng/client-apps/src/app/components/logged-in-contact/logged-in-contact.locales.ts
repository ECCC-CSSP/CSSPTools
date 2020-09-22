import { LoggedInContactTextModel } from './logged-in-contact.models';
import { LoggedInContactService } from './logged-in-contact.service';

export function LoadLocalesLoggedInContactText(loggedInContactService: LoggedInContactService) {
  let loggedInContactTextModel: LoggedInContactTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    loggedInContactTextModel.Title = 'Yes Le Titre';
  }

  loggedInContactService.UpdateLoggedInContactText(loggedInContactTextModel);
}
