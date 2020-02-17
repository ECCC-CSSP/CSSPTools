import { loadTranslations } from '@angular/localize';

export function LoadLocales(value: number) {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'register.BBB': `Ceci est BBB nombre ${value}`,
      'register.AAA': `Ceci est AAA`,
      'register.HelloID': `Ceci est HelloID`,
    });
  }
  else {
    loadTranslations({
      'register.BBB': `This is BBB number ${value}`,
      'register.AAA': `This is AAA`,
      'register.HelloID': `This is HelloID`,
    });
  }
}
