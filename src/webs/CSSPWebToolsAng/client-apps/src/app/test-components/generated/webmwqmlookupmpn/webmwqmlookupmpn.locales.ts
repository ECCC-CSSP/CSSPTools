/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { WebMWQMLookupMPNTextModel } from './webmwqmlookupmpn.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesWebMWQMLookupMPNText(webmwqmlookupmpnTextModel$: BehaviorSubject<WebMWQMLookupMPNTextModel>) {
    let webmwqmlookupmpnTextModel: WebMWQMLookupMPNTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        webmwqmlookupmpnTextModel.Title = 'Le Titre';
    }

    webmwqmlookupmpnTextModel$.next(webmwqmlookupmpnTextModel);
}
