import { loadTranslations } from '@angular/localize';

export function LoadLocales() {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'shell.language': 'Français',
    });
  }
  else {
    loadTranslations({
      'shell.language': 'English',
    });
  }
}
