/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { TVFullTextTextModel }
from './tvfulltext.models';
import { TVFullTextService }
from './tvfulltext.service';

export function LoadLocalesTVFullTextText(tvfulltextService: TVFullTextService) {
    let tvfulltextTextModel: TVFullTextTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        tvfulltextTextModel.Title = 'Le Titre';
    }

    tvfulltextService.UpdateTVFullTextText(tvfulltextTextModel);
}
