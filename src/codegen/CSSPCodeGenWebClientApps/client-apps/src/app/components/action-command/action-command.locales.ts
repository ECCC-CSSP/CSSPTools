import { ActionCommandService } from './action-command.service';
import { ActionCommandModel } from './action-command.models';

export function LoadLocalesActionCommand(actionCommandService: ActionCommandService) {
  let actionCommandModel: ActionCommandModel = { 
    CurrentStatus: 'Current Status',
    WorkingText: 'Working...',
}

  if ($localize.locale === 'fr-CA') {
      actionCommandModel.CurrentStatus = 'États actuel';
      actionCommandModel.WorkingText = 'Traitement en cour';
    }

  actionCommandService.UpdateActionCommand(actionCommandModel);
}
