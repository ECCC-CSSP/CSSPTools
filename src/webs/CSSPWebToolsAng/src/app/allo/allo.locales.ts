import { loadTranslations } from '@angular/localize';

export function LoadLocales(value: number) {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'allo.BBB': `Ceci est BBB nombre ${value}`,
      'allo.AAA': `Ceci est AAA`,
      'allo.HelloID': `Ceci est HelloID`,
    });
  }
  else {
    loadTranslations({
      'allo.BBB': `This is BBB number ${value}`,
      'allo.AAA': `This is AAA`,
      'allo.HelloID': `This is HelloID`,
    });
  }
}
