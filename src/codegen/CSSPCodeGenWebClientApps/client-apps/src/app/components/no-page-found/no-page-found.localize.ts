import { AppNoPageFoundService } from 'src/app/services/app-no-page-found.service';
import { AppNoPageFound } from 'src/app/interfaces/app-no-page-found.interfaces';

export function LoadLocales(appNoPageFoundService: AppNoPageFoundService) {
    let appNoPageFound: AppNoPageFound = {
        Title: 'Hello english',
    }

    if ($localize.locale === 'fr-CA') {
        appNoPageFound.Title = 'Bonjour français';
    }

    appNoPageFoundService.Update(appNoPageFound);
}
