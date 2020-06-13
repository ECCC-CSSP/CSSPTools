/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { RatingCurveTextModel } from './ratingcurve.models';
import { RatingCurveService } from './ratingcurve.service';

export function LoadLocalesRatingCurveText(ratingcurveService: RatingCurveService) {
    let ratingcurveTextModel: RatingCurveTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        ratingcurveTextModel.Title = 'Le Titre';
    }

    ratingcurveService.ratingcurveTextModel$.next(ratingcurveTextModel);
}
