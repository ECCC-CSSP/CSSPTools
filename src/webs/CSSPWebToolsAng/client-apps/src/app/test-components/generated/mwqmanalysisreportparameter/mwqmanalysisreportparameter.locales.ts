/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { MWQMAnalysisReportParameterTextModel } from './mwqmanalysisreportparameter.models';
import { BehaviorSubject } from 'rxjs';

export function LoadLocalesMWQMAnalysisReportParameterText(mwqmanalysisreportparameterTextModel$: BehaviorSubject<MWQMAnalysisReportParameterTextModel>) {
    let mwqmanalysisreportparameterTextModel: MWQMAnalysisReportParameterTextModel = {
        Title: 'The title',
}

    if ($localize.locale === 'fr-CA') {
        mwqmanalysisreportparameterTextModel.Title = 'Le Titre';
    }

    mwqmanalysisreportparameterTextModel$.next(mwqmanalysisreportparameterTextModel);
}
