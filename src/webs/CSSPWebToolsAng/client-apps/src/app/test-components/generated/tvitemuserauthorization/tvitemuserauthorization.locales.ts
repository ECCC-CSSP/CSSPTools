/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { TVItemUserAuthorizationTextModel } from './tvitemuserauthorization.models';
import { TVItemUserAuthorizationService } from './tvitemuserauthorization.service';

export function LoadLocalesTVItemUserAuthorizationText(tvitemuserauthorizationService: TVItemUserAuthorizationService) {
    let tvitemuserauthorizationTextModel: TVItemUserAuthorizationTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        tvitemuserauthorizationTextModel.Title = 'Le Titre';
    }

    tvitemuserauthorizationService.tvitemuserauthorizationTextModel$.next(tvitemuserauthorizationTextModel);
}
