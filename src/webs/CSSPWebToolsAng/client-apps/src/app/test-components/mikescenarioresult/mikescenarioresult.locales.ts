/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { MikeScenarioResultTextModel }
from './mikescenarioresult.models';
import { MikeScenarioResultService }
from './mikescenarioresult.service';

export function LoadLocalesMikeScenarioResultText(mikescenarioresultService: MikeScenarioResultService) {
    let mikescenarioresultTextModel: MikeScenarioResultTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mikescenarioresultTextModel.Title = 'Le Titre';
    }

    mikescenarioresultService.UpdateMikeScenarioResultText(mikescenarioresultTextModel);
}
