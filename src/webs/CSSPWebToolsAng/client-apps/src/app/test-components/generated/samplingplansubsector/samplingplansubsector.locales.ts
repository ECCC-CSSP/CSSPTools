/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { SamplingPlanSubsectorTextModel }
from './samplingplansubsector.models';
import { SamplingPlanSubsectorService }
from './samplingplansubsector.service';

export function LoadLocalesSamplingPlanSubsectorText(samplingplansubsectorService: SamplingPlanSubsectorService) {
    let samplingplansubsectorTextModel: SamplingPlanSubsectorTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        samplingplansubsectorTextModel.Title = 'Le Titre';
    }

    samplingplansubsectorService.UpdateSamplingPlanSubsectorText(samplingplansubsectorTextModel);
}