/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { ClimateSiteTextModel } from './climatesite.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesClimateSiteText(climatesiteTextModel$: BehaviorSubject<ClimateSiteTextModel>) {
    let climatesiteTextModel: ClimateSiteTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        climatesiteTextModel.Title = 'Le Titre';
    }

    climatesiteTextModel$.next(climatesiteTextModel);
}
