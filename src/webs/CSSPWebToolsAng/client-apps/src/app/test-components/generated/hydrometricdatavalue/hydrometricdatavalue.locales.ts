/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { HydrometricDataValueTextModel }
from './hydrometricdatavalue.models';
import { HydrometricDataValueService }
from './hydrometricdatavalue.service';

export function LoadLocalesHydrometricDataValueText(hydrometricdatavalueService: HydrometricDataValueService) {
    let hydrometricdatavalueTextModel: HydrometricDataValueTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        hydrometricdatavalueTextModel.Title = 'Le Titre';
    }

    hydrometricdatavalueService.UpdateHydrometricDataValueText(hydrometricdatavalueTextModel);
}