/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { TideSiteTextModel } from './tidesite.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesTideSiteText(tidesiteTextModel$: BehaviorSubject<TideSiteTextModel>) {
    let tidesiteTextModel: TideSiteTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        tidesiteTextModel.Title = 'Le Titre';
    }

    tidesiteTextModel$.next(tidesiteTextModel);
}
