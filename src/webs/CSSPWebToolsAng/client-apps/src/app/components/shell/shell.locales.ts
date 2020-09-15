import { ShellService } from 'src/app/components/shell/shell.service';
import { ShellModel } from 'src/app/components/shell/shell.models';

export function LoadLocalesShell(shellService: ShellService) {
  let shellModel: ShellModel = {
    AppTitle: 'CSSP Web Tools',
  }

  if ($localize.locale === 'fr-CA') {
    shellModel.AppTitle = "PCCSM Outils Web";
  }

  shellService.UpdateShell(shellModel);
}
