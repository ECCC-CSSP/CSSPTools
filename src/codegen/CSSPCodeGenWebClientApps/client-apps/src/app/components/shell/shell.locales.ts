import { loadTranslations } from '@angular/localize';

export function LoadLocales() {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'shell.title': "ACA - Coquille",
      'shell.hello': 'Bonjour',
      'shell.opencode': 'Ouvrir code'
    });
  }
  else {
    loadTranslations({
      'shell.title': "ACA - Shell",
      'shell.hello': 'Hello',
      'shell.opencode': 'Open code'
    });
  }
}
