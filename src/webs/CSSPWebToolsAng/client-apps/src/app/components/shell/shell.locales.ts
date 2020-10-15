import { ShellService } from './shell.service';
import { ShellVar } from './shell.models';
import { AppService } from 'src/app/app.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export function LoadLocalesShell(appService: AppService, shellService: ShellService) {
  let shellVar: ShellVar = {
    ShellTitle: 'CSSP Web Tools',
  }

  if (appService.AppVar$?.getValue()?.Language == LanguageEnum.fr) {
    shellVar.ShellTitle = "PCCSM Outils Web";
  }

  shellService.UpdateShellVar(shellVar);
}
