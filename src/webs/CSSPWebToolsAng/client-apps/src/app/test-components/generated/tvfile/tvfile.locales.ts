/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { TVFileTextModel } from './tvfile.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesTVFileText(tvfileTextModel$: BehaviorSubject<TVFileTextModel>) {
    let tvfileTextModel: TVFileTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        tvfileTextModel.Title = 'Le Titre';
    }

    tvfileTextModel$.next(tvfileTextModel);
}
