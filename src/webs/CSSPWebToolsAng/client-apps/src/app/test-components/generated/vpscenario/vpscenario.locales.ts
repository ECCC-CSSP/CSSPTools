/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { VPScenarioTextModel } from './vpscenario.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesVPScenarioText(vpscenarioTextModel$: BehaviorSubject<VPScenarioTextModel>) {
    let vpscenarioTextModel: VPScenarioTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        vpscenarioTextModel.Title = 'Le Titre';
    }

    vpscenarioTextModel$.next(vpscenarioTextModel);
}
