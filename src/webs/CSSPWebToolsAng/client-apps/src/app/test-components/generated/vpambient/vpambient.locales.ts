/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { VPAmbientTextModel } from './vpambient.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesVPAmbientText(vpambientTextModel$: BehaviorSubject<VPAmbientTextModel>) {
    let vpambientTextModel: VPAmbientTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        vpambientTextModel.Title = 'Le Titre';
    }

    vpambientTextModel$.next(vpambientTextModel);
}
