/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { MWQMAnalysisReportParameterTextModel } from './mwqmanalysisreportparameter.models';
import { MWQMAnalysisReportParameterService } from './mwqmanalysisreportparameter.service';

export function LoadLocalesMWQMAnalysisReportParameterText(mwqmanalysisreportparameterService: MWQMAnalysisReportParameterService) {
    let mwqmanalysisreportparameterTextModel: MWQMAnalysisReportParameterTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mwqmanalysisreportparameterTextModel.Title = 'Le Titre';
    }

    mwqmanalysisreportparameterService.mwqmanalysisreportparameterTextModel$.next(mwqmanalysisreportparameterTextModel);
}
