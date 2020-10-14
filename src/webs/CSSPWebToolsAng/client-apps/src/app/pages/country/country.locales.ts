import { CountryVar } from './country.models';
import { CountryService } from './country.service';

export function LoadLocalesCountryVar(countryService: CountryService) {
  let countryVar: CountryVar = { 
    CountryTitle: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      countryVar.CountryTitle = 'Le Titre';
    }

  countryService.UpdateCountryVar(countryVar);
}
