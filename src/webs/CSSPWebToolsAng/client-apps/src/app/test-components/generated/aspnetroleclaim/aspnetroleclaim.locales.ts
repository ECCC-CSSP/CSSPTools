/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { AspNetRoleClaimTextModel } from './aspnetroleclaim.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesAspNetRoleClaimText(aspnetroleclaimTextModel$: BehaviorSubject<AspNetRoleClaimTextModel>) {
    let aspnetroleclaimTextModel: AspNetRoleClaimTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        aspnetroleclaimTextModel.Title = 'Le Titre';
    }

    aspnetroleclaimTextModel$.next(aspnetroleclaimTextModel);
}
