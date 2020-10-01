import { MapTextModel } from './map.models';
import { MapService } from './map.service';

export function LoadLocalesMapText(mapService: MapService) {
  let mapTextModel: MapTextModel = { 
    Title: 'Yes The title',
}

  if ($localize.locale === 'fr-CA') {
      mapTextModel.Title = 'Yes Le Titre';
    }

  mapService.UpdateMapTextModel(mapTextModel);
}
