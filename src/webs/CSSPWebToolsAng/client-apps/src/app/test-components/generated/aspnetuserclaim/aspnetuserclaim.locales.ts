/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { AspNetUserClaimTextModel } from './aspnetuserclaim.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesAspNetUserClaimText(aspnetuserclaimTextModel$: BehaviorSubject<AspNetUserClaimTextModel>) {
    let aspnetuserclaimTextModel: AspNetUserClaimTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        aspnetuserclaimTextModel.Title = 'Le Titre';
    }

    aspnetuserclaimTextModel$.next(aspnetuserclaimTextModel);
}
