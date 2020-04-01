import { loadTranslations } from '@angular/localize';

export function LoadLocales() {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'code.generate': 'Générer',
    });
  }
  else {
    loadTranslations({
      'code.generate': 'Generate',
    });
  }
}
