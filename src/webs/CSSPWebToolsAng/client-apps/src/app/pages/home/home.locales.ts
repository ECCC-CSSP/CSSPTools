import { HomeVar } from './home.models';
import { HomeService } from './home.service';

export function LoadLocalesHomeText(homeService: HomeService) {
  let homeVar: HomeVar = { 
    HomeTitle: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      homeVar.HomeTitle = 'Le Titre';
    }

  homeService.UpdateHomeVar(homeVar);
}
