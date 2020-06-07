/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { ClassificationTextModel }
from './classification.models';
import { ClassificationService }
from './classification.service';

export function LoadLocalesClassificationText(classificationService: ClassificationService) {
    let classificationTextModel: ClassificationTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        classificationTextModel.Title = 'Le Titre';
    }

    classificationService.UpdateClassificationText(classificationTextModel);
}