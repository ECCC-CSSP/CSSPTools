import { ShellService } from 'src/app/components/shell/shell.service';
import { ShellModel } from 'src/app/components/shell/shell.models';

export function LoadLocalesShell(shellService: ShellService) {
  let shellModel: ShellModel = {
    AppTitle: 'CSSP Web Tools',
    ShowIcons: 'Show Icons',
    HideIcons: 'Hide Icons',
    Login: "Login",
    Register: 'Register',
    Logout: 'Logout',
  }

  if ($localize.locale === 'fr-CA') {
    shellModel.AppTitle = "PCCSM Outils Web";
    shellModel.ShowIcons = 'Voir Icons';
    shellModel.HideIcons = 'Cacher Icons';
    shellModel.Login = 'Connextion';
    shellModel.Register = 'S\'inscrire';
    shellModel.Logout = 'Déconnextion';
  }

  shellService.UpdateShell(shellModel);
}
