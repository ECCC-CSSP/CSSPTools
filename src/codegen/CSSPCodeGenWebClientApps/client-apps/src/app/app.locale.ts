import { loadTranslations } from '@angular/localize';

export function LoadLocales() {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
        'app.title': 'Applications Client de Angular',
    });
  }
  else {
    loadTranslations({
        'app.title': 'Angular Client Apps',
    });
  }
}
