/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { ClassificationTextModel } from './classification.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesClassificationText(classificationTextModel$: BehaviorSubject<ClassificationTextModel>) {
    let classificationTextModel: ClassificationTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        classificationTextModel.Title = 'Le Titre';
    }

    classificationTextModel$.next(classificationTextModel);
}
