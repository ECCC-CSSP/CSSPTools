/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { RainExceedanceClimateSiteTextModel } from './rainexceedanceclimatesite.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesRainExceedanceClimateSiteText(rainexceedanceclimatesiteTextModel$: BehaviorSubject<RainExceedanceClimateSiteTextModel>) {
    let rainexceedanceclimatesiteTextModel: RainExceedanceClimateSiteTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        rainexceedanceclimatesiteTextModel.Title = 'Le Titre';
    }

    rainexceedanceclimatesiteTextModel$.next(rainexceedanceclimatesiteTextModel);
}
