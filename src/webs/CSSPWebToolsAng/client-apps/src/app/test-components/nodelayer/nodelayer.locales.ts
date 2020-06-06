/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NodeLayerTextModel }
from './nodelayer.models';
import { NodeLayerService }
from './nodelayer.service';

export function LoadLocalesNodeLayerText(nodelayerService: NodeLayerService) {
    let nodelayerTextModel: NodeLayerTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        nodelayerTextModel.Title = 'Le Titre';
    }

    nodelayerService.UpdateNodeLayerText(nodelayerTextModel);
}
