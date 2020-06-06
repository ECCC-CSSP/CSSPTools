/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { HelpDocTextModel }
from './helpdoc.models';
import { HelpDocService }
from './helpdoc.service';

export function LoadLocalesHelpDocText(helpdocService: HelpDocService) {
    let helpdocTextModel: HelpDocTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        helpdocTextModel.Title = 'Le Titre';
    }

    helpdocService.UpdateHelpDocText(helpdocTextModel);
}
