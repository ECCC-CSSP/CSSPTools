/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { SamplingPlanSubsectorTextModel } from './samplingplansubsector.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesSamplingPlanSubsectorText(samplingplansubsectorTextModel$: BehaviorSubject<SamplingPlanSubsectorTextModel>) {
    let samplingplansubsectorTextModel: SamplingPlanSubsectorTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        samplingplansubsectorTextModel.Title = 'Le Titre';
    }

    samplingplansubsectorTextModel$.next(samplingplansubsectorTextModel);
}
