import { loadTranslations } from '@angular/localize';

export function LoadLocales() {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'code.generate': 'Générer',
      'code.opencode': 'Ouvrire le code',
      'code.gettheweather': 'Aller chercher météo',
      'code.getmoreweather': 'Aller chercher plus de météo',
      'code.clearweather': 'Videz les données',
    });
  }
  else {
    loadTranslations({
      'code.generate': 'Generate',
      'code.opencode': 'Open code',
      'code.gettheweather': 'Get Weather',
      'code.getmoreweather': 'Get More Weather',
      'code.clearweather': 'Empty the data',
    });
  }
}
