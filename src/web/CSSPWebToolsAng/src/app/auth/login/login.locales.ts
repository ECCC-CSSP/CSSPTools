import { loadTranslations } from '@angular/localize';

export function LoadLocales(value: number) {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'login.BBB': `Ceci est BBB nombre ${value}`,
      'login.AAA': `Ceci est AAA`,
      'login.HelloID': `Ceci est HelloID`,
    });
  }
  else {
    loadTranslations({
      'login.BBB': `This is BBB number ${value}`,
      'login.AAA': `This is AAA`,
      'login.HelloID': `This is HelloID`,
    });
  }
}
