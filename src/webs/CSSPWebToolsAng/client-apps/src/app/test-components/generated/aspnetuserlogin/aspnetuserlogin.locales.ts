/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AspNetUserLoginTextModel } from './aspnetuserlogin.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesAspNetUserLoginText(aspnetuserloginTextModel$: BehaviorSubject<AspNetUserLoginTextModel>) {
    let aspnetuserloginTextModel: AspNetUserLoginTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        aspnetuserloginTextModel.Title = 'Le Titre';
    }

    aspnetuserloginTextModel$.next(aspnetuserloginTextModel);
}
