/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { MWQMSubsectorLanguageTextModel } from './mwqmsubsectorlanguage.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesMWQMSubsectorLanguageText(mwqmsubsectorlanguageTextModel$: BehaviorSubject<MWQMSubsectorLanguageTextModel>) {
    let mwqmsubsectorlanguageTextModel: MWQMSubsectorLanguageTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mwqmsubsectorlanguageTextModel.Title = 'Le Titre';
    }

    mwqmsubsectorlanguageTextModel$.next(mwqmsubsectorlanguageTextModel);
}
