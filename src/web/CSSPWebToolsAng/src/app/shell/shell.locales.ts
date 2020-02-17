import { loadTranslations } from '@angular/localize';

export function LoadLocales(rouge: string) {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'shell.AAA': 'Français',
      'shell.HelloID': `Bonjour ceci est ${rouge} traduits`
    });
  }
  else {
    loadTranslations({
      'shell.AAA': 'English',
      'shell.HelloID': `Hi this ${rouge} is translated`
    });
  }
}
