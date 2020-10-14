import { ShellService } from './shell.service';
import { ShellVar } from './shell.models';

export function LoadLocalesShell(shellService: ShellService) {
  let shellVar: ShellVar = {
    ShellTitle: 'CSSP Web Tools',
  }

  if ($localize.locale === 'fr-CA') {
    shellVar.ShellTitle = "PCCSM Outils Web";
  }

  shellService.UpdateShellVar(shellVar);
}
