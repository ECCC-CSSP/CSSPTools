/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { DrogueRunTextModel }
from './droguerun.models';
import { DrogueRunService }
from './droguerun.service';

export function LoadLocalesDrogueRunText(droguerunService: DrogueRunService) {
    let droguerunTextModel: DrogueRunTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        droguerunTextModel.Title = 'Le Titre';
    }

    droguerunService.UpdateDrogueRunText(droguerunTextModel);
}
