/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LabSheetTubeMPNDetailTextModel }
from './labsheettubempndetail.models';
import { LabSheetTubeMPNDetailService }
from './labsheettubempndetail.service';

export function LoadLocalesLabSheetTubeMPNDetailText(labsheettubempndetailService: LabSheetTubeMPNDetailService) {
    let labsheettubempndetailTextModel: LabSheetTubeMPNDetailTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        labsheettubempndetailTextModel.Title = 'Le Titre';
    }

    labsheettubempndetailService.UpdateLabSheetTubeMPNDetailText(labsheettubempndetailTextModel);
}