import { loadTranslations } from '@angular/localize';
import { AppVar } from './app.component';

export function LoadLocales(appVar: AppVar) {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'app.AppTitle': "ACA - Coquille",
      'app.OpenCode': 'Ouvrir code',
      'app.OpenMenuOptions': 'Ouvre un menu avec options'
    });
  }
  else {
    loadTranslations({
      'app.AppTitle': "ACA - Shell",
      'app.OpenCode': 'Open code',
      'app.OpenMenuOptions': 'Opens menu with options'
    });
  }

  appVar.AppTitle = $localize`:@@shell.AppTitle:`;
  appVar.OpenCode = $localize`:@@shell.OpenCode:`;
  appVar.OpenCode = $localize`:@@shell.OpenMenuOptions:`;

}
