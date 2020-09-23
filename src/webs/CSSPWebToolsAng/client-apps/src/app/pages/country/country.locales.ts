import { CountryTextModel } from './country.models';
import { CountryService } from './country.service';

export function LoadLocalesCountryText(countryService: CountryService) {
  let countryTextModel: CountryTextModel = { 
    Title: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      countryTextModel.Title = 'Le Titre';
    }

  countryService.UpdateCountryText(countryTextModel);
}
