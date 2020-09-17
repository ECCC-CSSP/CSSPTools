import { RootTextModel } from './root.models';
import { RootService } from './root.service';

export function LoadLocalesRootText(rootService: RootService) {
  let rootTextModel: RootTextModel = { 
    Title: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      rootTextModel.Title = 'Le Titre';
    }

  rootService.UpdateRootText(rootTextModel);
}
