/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { TVFileLanguageTextModel } from './tvfilelanguage.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesTVFileLanguageText(tvfilelanguageTextModel$: BehaviorSubject<TVFileLanguageTextModel>) {
    let tvfilelanguageTextModel: TVFileLanguageTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        tvfilelanguageTextModel.Title = 'Le Titre';
    }

    tvfilelanguageTextModel$.next(tvfilelanguageTextModel);
}
