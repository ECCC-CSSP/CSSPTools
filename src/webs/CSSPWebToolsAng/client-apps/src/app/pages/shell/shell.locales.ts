import { ShellService } from './shell.service';
import { ShellModel } from './shell.models';

export function LoadLocalesShell(shellService: ShellService) {
  let shellModel: ShellModel = {
    AppTitle: 'CSSP Web Tools',
  }

  if ($localize.locale === 'fr-CA') {
    shellModel.AppTitle = "PCCSM Outils Web";
  }

  shellService.UpdateShell(shellModel);
}
