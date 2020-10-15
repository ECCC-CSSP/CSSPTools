import { AppService } from 'src/app/app.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { CountryVar } from './country.models';
import { CountryService } from './country.service';

export function LoadLocalesCountryVar(appService: AppService, countryService: CountryService) {
  let countryVar: CountryVar = { 
    CountryTitle: 'The title',
}

  if (appService.AppVar$.getValue()?.Language == LanguageEnum.fr) {
      countryVar.CountryTitle = 'Le Titre';
    }

  countryService.UpdateCountryVar(countryVar);
}
