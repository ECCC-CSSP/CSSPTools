/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { PolSourceSiteEffectTermTextModel } from './polsourcesiteeffectterm.models';
import { PolSourceSiteEffectTermService } from './polsourcesiteeffectterm.service';

export function LoadLocalesPolSourceSiteEffectTermText(polsourcesiteeffecttermService: PolSourceSiteEffectTermService) {
    let polsourcesiteeffecttermTextModel: PolSourceSiteEffectTermTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        polsourcesiteeffecttermTextModel.Title = 'Le Titre';
    }

    polsourcesiteeffecttermService.polsourcesiteeffecttermTextModel$.next(polsourcesiteeffecttermTextModel);
}
