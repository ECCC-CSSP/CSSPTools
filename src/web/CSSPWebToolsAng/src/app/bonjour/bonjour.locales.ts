import { loadTranslations } from '@angular/localize';

export function LoadLocales(value: number) {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'bonjour.BBB': `Ceci est BBB nombre ${value}`,
      'bonjour.HelloID': 'bonjour français',
    });
  }
  else {
    loadTranslations({
      'bonjour.BBB': `This is BBB number ${value}`,
      'bonjour.HelloID': 'hi English',
    });
  }
}
