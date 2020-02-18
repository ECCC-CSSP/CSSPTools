import { loadTranslations } from '@angular/localize';

export function LoadLocales() {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'shell.CSSPWebTools': 'CSSP Web Tools (fr)',
      'shell.Francais': `Français (fr)`,
      'shell.English': `English (fr)`
    });
  }
  else {
    loadTranslations({
      'shell.CSSPWebTools': 'CSSP Web Tools',
      'shell.Francais': `Français`,
      'shell.English': `English`
    });
  }
}
