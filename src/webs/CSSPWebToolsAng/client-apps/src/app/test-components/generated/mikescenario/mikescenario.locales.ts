/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { MikeScenarioTextModel } from './mikescenario.models';
import { MikeScenarioService } from './mikescenario.service';

export function LoadLocalesMikeScenarioText(mikescenarioService: MikeScenarioService) {
    let mikescenarioTextModel: MikeScenarioTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mikescenarioTextModel.Title = 'Le Titre';
    }

    mikescenarioService.mikescenarioTextModel$.next(mikescenarioTextModel);
}
