/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { MWQMSampleLanguageTextModel }
from './mwqmsamplelanguage.models';
import { MWQMSampleLanguageService }
from './mwqmsamplelanguage.service';

export function LoadLocalesMWQMSampleLanguageText(mwqmsamplelanguageService: MWQMSampleLanguageService) {
    let mwqmsamplelanguageTextModel: MWQMSampleLanguageTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mwqmsamplelanguageTextModel.Title = 'Le Titre';
    }

    mwqmsamplelanguageService.UpdateMWQMSampleLanguageText(mwqmsamplelanguageTextModel);
}
