/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { SpillLanguageTextModel } from './spilllanguage.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesSpillLanguageText(spilllanguageTextModel$: BehaviorSubject<SpillLanguageTextModel>) {
    let spilllanguageTextModel: SpillLanguageTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        spilllanguageTextModel.Title = 'Le Titre';
    }

    spilllanguageTextModel$.next(spilllanguageTextModel);
}
