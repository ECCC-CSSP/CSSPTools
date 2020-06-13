/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { MapInfoTextModel } from './mapinfo.models';
import { MapInfoService } from './mapinfo.service';

export function LoadLocalesMapInfoText(mapinfoService: MapInfoService) {
    let mapinfoTextModel: MapInfoTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mapinfoTextModel.Title = 'Le Titre';
    }

    mapinfoService.mapinfoTextModel$.next(mapinfoTextModel);
}
