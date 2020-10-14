import { RootVar } from './root.models';
import { RootService } from './root.service';

export function LoadLocalesRootVar(rootService: RootService) {
  let rootVar: RootVar = { 
    RootTitle: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      rootVar.RootTitle = 'Le Titre';
    }

  rootService.UpdateRootVar(rootVar);
}
