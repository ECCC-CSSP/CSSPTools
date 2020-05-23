import { ActionCommandService } from './action-command.service';
import { ActionCommandTextModel } from './action-command.models';

export function LoadLocalesActionCommandText(actionCommandService: ActionCommandService) {
  let actionCommandTextModel: ActionCommandTextModel = { 
    CurrentStatus: 'Current Status',
    WorkingText: 'Working...',
}

  if ($localize.locale === 'fr-CA') {
      actionCommandTextModel.CurrentStatus = 'États actuel';
      actionCommandTextModel.WorkingText = 'Traitement en cour';
    }

  actionCommandService.UpdateActionCommandText(actionCommandTextModel);
}
