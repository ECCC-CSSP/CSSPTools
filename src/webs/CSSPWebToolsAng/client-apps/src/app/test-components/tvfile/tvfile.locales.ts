/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { TVFileTextModel }
from './tvfile.models';
import { TVFileService }
from './tvfile.service';

export function LoadLocalesTVFileText(tvfileService: TVFileService) {
    let tvfileTextModel: TVFileTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        tvfileTextModel.Title = 'Le Titre';
    }

    tvfileService.UpdateTVFileText(tvfileTextModel);
}
