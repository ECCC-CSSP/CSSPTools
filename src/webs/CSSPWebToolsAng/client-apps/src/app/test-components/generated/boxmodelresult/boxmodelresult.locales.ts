/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { BoxModelResultTextModel } from './boxmodelresult.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesBoxModelResultText(boxmodelresultTextModel$: BehaviorSubject<BoxModelResultTextModel>) {
    let boxmodelresultTextModel: BoxModelResultTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        boxmodelresultTextModel.Title = 'Le Titre';
    }

    boxmodelresultTextModel$.next(boxmodelresultTextModel);
}
