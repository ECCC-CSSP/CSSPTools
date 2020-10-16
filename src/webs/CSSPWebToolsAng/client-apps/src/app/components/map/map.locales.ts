import { AppService } from 'src/app/app.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapVar } from './map.models';
import { MapService } from './map.service';

export function LoadLocalesMapText(appService: AppService, mapService: MapService) {
  let mapVar: MapVar = {
    MapTitle: 'Yes The title',
  }

  if (appService.AppVar$.getValue().Language == LanguageEnum.fr) {
    mapVar.MapTitle = 'Yes Le Titre';
  }

  mapService.UpdateMapVar(mapVar);
}
