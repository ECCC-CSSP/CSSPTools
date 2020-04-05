import { ShellService } from './shell.service';
import { ShellModel } from './shell.models';

export function LoadLocales(shellService: ShellService) {
  let shellModel: ShellModel = { 
    AppTitle: 'ACA - Shell', 
    ShowIcons: 'Show Icons',
    HideIcons: 'Hide Icons',
    Login: "Login"
  }

  if ($localize.locale === 'fr-CA') {
    shellModel.AppTitle = "ACA - Coquille";
    shellModel.ShowIcons = 'Voir Icons';
    shellModel.HideIcons = 'Cacher Icons';
    shellModel.Login = 'Connextion';
  }

  shellService.Update(shellModel);
}
