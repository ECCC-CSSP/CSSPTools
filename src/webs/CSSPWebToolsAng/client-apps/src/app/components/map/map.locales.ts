import { MapVar } from './map.models';
import { MapService } from './map.service';

export function LoadLocalesMapText(mapService: MapService) {
  let mapVar: MapVar = {
    MapTitle: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    mapVar.MapTitle = 'Yes Le Titre';
  }

  mapService.UpdateMapVar(mapVar);
}
