/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppTaskLanguageTextModel } from './apptasklanguage.models';
import { AppTaskLanguageService } from './apptasklanguage.service';

export function LoadLocalesAppTaskLanguageText(apptasklanguageService: AppTaskLanguageService) {
    let apptasklanguageTextModel: AppTaskLanguageTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        apptasklanguageTextModel.Title = 'Le Titre';
    }

    apptasklanguageService.apptasklanguageTextModel$.next(apptasklanguageTextModel);
}
