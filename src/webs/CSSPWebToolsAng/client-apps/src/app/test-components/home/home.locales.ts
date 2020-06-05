import { HomeTextModel } from './home.models';
import { HomeService } from './home.service';

export function LoadLocalesHomeText(homeService: HomeService) {
  let homeTextModel: HomeTextModel = { 
    Title: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      homeTextModel.Title = 'Le Titre';
    }

  homeService.UpdateHomeText(homeTextModel);
}
