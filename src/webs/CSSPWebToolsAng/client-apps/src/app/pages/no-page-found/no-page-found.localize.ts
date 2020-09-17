import { NoPageFoundService } from './no-page-found.service';
import { NoPageFoundModel } from './no-page-found.models';

export function LoadLocalesNoPageFound(noPageFoundService: NoPageFoundService) {
    let noPageFoundModel: NoPageFoundModel = {
        SorryPageNotFound: 'Sorry Page Not Found',
        Restart: 'Restart',
        GoBack: 'Go Back',
    }

    if ($localize.locale === 'fr-CA') {
        noPageFoundModel.SorryPageNotFound = 'Nos excuses. La page est introuvable';
        noPageFoundModel.Restart =  'Recommencer';
        noPageFoundModel.GoBack = 'Reculer d\'une page';
    }

    noPageFoundService.UpdateNoPageFound(noPageFoundModel);
}
