/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { MapInfoTextModel } from './mapinfo.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesMapInfoText(mapinfoTextModel$: BehaviorSubject<MapInfoTextModel>) {
    let mapinfoTextModel: MapInfoTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mapinfoTextModel.Title = 'Le Titre';
    }

    mapinfoTextModel$.next(mapinfoTextModel);
}
