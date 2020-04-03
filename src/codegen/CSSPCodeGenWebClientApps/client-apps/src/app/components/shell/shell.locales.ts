import { loadTranslations } from '@angular/localize';
import { ShellVar } from './shell.component';

export function LoadLocales(shellVar: ShellVar) {
  if ($localize.locale === 'fr-CA') {
    loadTranslations({
      'shell.appTitle': "ACA - Coquille",
      'shell.menuTitle': 'Ouvre menu avec plus d\'options',
      'shell.showIcons': 'Voir Icons',
      'shell.hideIcons': 'Cacher Icons'
    });
  }
  else {
    loadTranslations({
      'shell.appTitle': "ACA - Shell",
      'shell.menuTitle': 'Opens menu with more options',
      'shell.showIcons': 'Show Icons',
      'shell.hideIcons': 'Hide Icons'
    });
  }

  shellVar.appTitle = $localize`:@@shell.appTitle:`;
  shellVar.menuTitle = $localize`:@@shell.menuTitle:`;
  shellVar.showIcons = $localize`:@@shell.showIcons:`;
  shellVar.hideIcons = $localize`:@@shell.hideIcons:`;
}
