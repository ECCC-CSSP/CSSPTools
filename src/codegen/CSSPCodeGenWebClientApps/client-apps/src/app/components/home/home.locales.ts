import { loadTranslations } from '@angular/localize';
import { HomeVar } from './home.component';

export function LoadLocales(homeVar: HomeVar) {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'home.Title': "Un Title de Home",
    });
  }
  else {
    loadTranslations({
      'home.Title': "Some Title from Home",
    });
  }

  homeVar.Title = $localize`:@@home.Title:`;

}
