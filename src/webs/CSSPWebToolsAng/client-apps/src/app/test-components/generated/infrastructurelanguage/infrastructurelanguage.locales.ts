/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { InfrastructureLanguageTextModel } from './infrastructurelanguage.models';
import { InfrastructureLanguageService } from './infrastructurelanguage.service';

export function LoadLocalesInfrastructureLanguageText(infrastructurelanguageService: InfrastructureLanguageService) {
    let infrastructurelanguageTextModel: InfrastructureLanguageTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        infrastructurelanguageTextModel.Title = 'Le Titre';
    }

    infrastructurelanguageService.infrastructurelanguageTextModel$.next(infrastructurelanguageTextModel);
}
