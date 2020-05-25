import { WebApiNotFoundService } from './web-api-not-found.service';
import { WebApiNotFoundModel } from './web-api-not-found.models';

export function LoadLocalesWebApiNotFound(webApiNotFoundService: WebApiNotFoundService) {
    let webApiNotFoundModel: WebApiNotFoundModel = {
        SorryWebApiNotFound: 'Sorry Web API Not Found',
        Restart: 'Restart',
        GoBack: 'Go Back',
    }

    if ($localize.locale === 'fr-CA') {
        webApiNotFoundModel.SorryWebApiNotFound = 'Nos excuses. Web API est introuvable';
        webApiNotFoundModel.Restart =  'Recommencer';
        webApiNotFoundModel.GoBack = 'Reculer d\'une page';
    }

    webApiNotFoundService.UpdateWebApiNotFound(webApiNotFoundModel);
}
