/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { WebPolSourceGroupingTextModel } from './webpolsourcegrouping.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesWebPolSourceGroupingText(webpolsourcegroupingTextModel$: BehaviorSubject<WebPolSourceGroupingTextModel>) {
    let webpolsourcegroupingTextModel: WebPolSourceGroupingTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        webpolsourcegroupingTextModel.Title = 'Le Titre';
    }

    webpolsourcegroupingTextModel$.next(webpolsourcegroupingTextModel);
}
