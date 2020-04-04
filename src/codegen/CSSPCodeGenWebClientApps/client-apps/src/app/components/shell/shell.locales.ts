import { ShellService } from './shell.service';
import { ShellModel } from './shell.models';

export function LoadLocales(shellService: ShellService) {
  let shellModel: ShellModel = { 
    appTitle: 'ACA - Shell', 
    menuTitle: 'Opens menu with more options',
    showIcons: 'Show Icons',
    hideIcons: 'Hide Icons'
  }

  if ($localize.locale === 'fr-CA') {
    shellModel.appTitle = "ACA - Coquille";
    shellModel.menuTitle = 'Ouvre menu avec plus d\'options';
    shellModel.showIcons = 'Voir Icons';
    shellModel.hideIcons = 'Cacher Icons';
  }

  shellService.Update(shellModel);
}
