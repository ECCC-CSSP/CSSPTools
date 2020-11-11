/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LabSheetTextModel } from './labsheet.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesLabSheetText(labsheetTextModel$: BehaviorSubject<LabSheetTextModel>) {
    let labsheetTextModel: LabSheetTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        labsheetTextModel.Title = 'Le Titre';
    }

    labsheetTextModel$.next(labsheetTextModel);
}
