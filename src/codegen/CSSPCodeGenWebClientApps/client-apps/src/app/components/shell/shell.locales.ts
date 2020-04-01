import { loadTranslations } from '@angular/localize';

export function LoadLocales() {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'shell.hello': 'Bonjour',
    });
  }
  else {
    loadTranslations({
      'shell.hello': 'Hello',
    });
  }
}
