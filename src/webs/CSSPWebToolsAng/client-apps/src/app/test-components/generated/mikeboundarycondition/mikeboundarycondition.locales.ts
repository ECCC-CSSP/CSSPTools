/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { MikeBoundaryConditionTextModel }
from './mikeboundarycondition.models';
import { MikeBoundaryConditionService }
from './mikeboundarycondition.service';

export function LoadLocalesMikeBoundaryConditionText(mikeboundaryconditionService: MikeBoundaryConditionService) {
    let mikeboundaryconditionTextModel: MikeBoundaryConditionTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mikeboundaryconditionTextModel.Title = 'Le Titre';
    }

    mikeboundaryconditionService.UpdateMikeBoundaryConditionText(mikeboundaryconditionTextModel);
}