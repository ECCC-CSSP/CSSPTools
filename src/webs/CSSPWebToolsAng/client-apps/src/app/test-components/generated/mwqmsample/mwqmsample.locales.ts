/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { MWQMSampleTextModel } from './mwqmsample.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesMWQMSampleText(mwqmsampleTextModel$: BehaviorSubject<MWQMSampleTextModel>) {
    let mwqmsampleTextModel: MWQMSampleTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mwqmsampleTextModel.Title = 'Le Titre';
    }

    mwqmsampleTextModel$.next(mwqmsampleTextModel);
}
