/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LabSheetDetailTextModel } from './labsheetdetail.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesLabSheetDetailText(labsheetdetailTextModel$: BehaviorSubject<LabSheetDetailTextModel>) {
    let labsheetdetailTextModel: LabSheetDetailTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        labsheetdetailTextModel.Title = 'Le Titre';
    }

    labsheetdetailTextModel$.next(labsheetdetailTextModel);
}
