/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { InfrastructureTextModel }
from './infrastructure.models';
import { InfrastructureService }
from './infrastructure.service';

export function LoadLocalesInfrastructureText(infrastructureService: InfrastructureService) {
    let infrastructureTextModel: InfrastructureTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        infrastructureTextModel.Title = 'Le Titre';
    }

    infrastructureService.UpdateInfrastructureText(infrastructureTextModel);
}
