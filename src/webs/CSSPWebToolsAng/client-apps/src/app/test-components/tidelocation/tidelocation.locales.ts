/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { TideLocationTextModel }
from './tidelocation.models';
import { TideLocationService }
from './tidelocation.service';

export function LoadLocalesTideLocationText(tidelocationService: TideLocationService) {
    let tidelocationTextModel: TideLocationTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        tidelocationTextModel.Title = 'Le Titre';
    }

    tidelocationService.UpdateTideLocationText(tidelocationTextModel);
}
