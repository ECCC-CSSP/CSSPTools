/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { WebAreaTextModel } from './webarea.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesWebAreaText(webareaTextModel$: BehaviorSubject<WebAreaTextModel>) {
    let webareaTextModel: WebAreaTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        webareaTextModel.Title = 'Le Titre';
    }

    webareaTextModel$.next(webareaTextModel);
}
