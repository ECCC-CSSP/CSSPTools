/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { TVTypeUserAuthorizationTextModel } from './tvtypeuserauthorization.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesTVTypeUserAuthorizationText(tvtypeuserauthorizationTextModel$: BehaviorSubject<TVTypeUserAuthorizationTextModel>) {
    let tvtypeuserauthorizationTextModel: TVTypeUserAuthorizationTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        tvtypeuserauthorizationTextModel.Title = 'Le Titre';
    }

    tvtypeuserauthorizationTextModel$.next(tvtypeuserauthorizationTextModel);
}
