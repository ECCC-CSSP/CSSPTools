import { ShellService } from './shell.service';
import { ShellModel } from './shell.models';

export function LoadLocalesShell(shellService: ShellService) {
  let shellModel: ShellModel = { 
    AppTitle: 'ACA - Shell', 
    ShowIcons: 'Show Icons',
    HideIcons: 'Hide Icons',
    Login: "Login",
    Register: 'Register'
  }

  if ($localize.locale === 'fr-CA') {
    shellModel.AppTitle = "ACA - Coquille";
    shellModel.ShowIcons = 'Voir Icons';
    shellModel.HideIcons = 'Cacher Icons';
    shellModel.Login = 'Connextion';
    shellModel.Register = 'S\'inscrire'
  }

  shellService.UpdateShell(shellModel);
}
