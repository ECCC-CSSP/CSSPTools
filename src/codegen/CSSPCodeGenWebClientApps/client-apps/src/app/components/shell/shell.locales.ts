import { loadTranslations } from '@angular/localize';
import { AppShellService } from 'src/app/services/app-shell.service';
import { AppShell } from 'src/app/interfaces/app-shell.interfaces';

export function LoadLocales(appShellService: AppShellService) {
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

  let appShell: AppShell = { 
    appTitle: $localize`:@@shell.appTitle:`, 
    menuTitle: $localize`:@@shell.menuTitle:`,
    showIcons: $localize`:@@shell.showIcons:`,
    hideIcons: $localize`:@@shell.hideIcons:`
  }
  appShellService.Update(appShell);
}
