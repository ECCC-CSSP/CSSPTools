/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { CSSPDBLocalContextService } from './csspdblocalcontext.service';
import { LoadLocalesCSSPDBLocalContextText } from './csspdblocalcontext.locales';
import { Subscription } from 'rxjs';
import { CSSPDBLocalContext } from '../../../models/generated/CSSPDBLocalContext.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-csspdblocalcontext-edit',
  templateUrl: './csspdblocalcontext-edit.component.html',
  styleUrls: ['./csspdblocalcontext-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CSSPDBLocalContextEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  csspdblocalcontextFormEdit: FormGroup;
  @Input() csspdblocalcontext: CSSPDBLocalContext = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public csspdblocalcontextService: CSSPDBLocalContextService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutCSSPDBLocalContext(csspdblocalcontext: CSSPDBLocalContext) {
    this.sub = this.csspdblocalcontextService.PutCSSPDBLocalContext(csspdblocalcontext).subscribe();
  }

  PostCSSPDBLocalContext(csspdblocalcontext: CSSPDBLocalContext) {
    this.sub = this.csspdblocalcontextService.PostCSSPDBLocalContext(csspdblocalcontext).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.csspdblocalcontext) {
      let formGroup: FormGroup = this.fb.group(
        {
          Addresses: [
            {
              value: this.csspdblocalcontext.Addresses,
              disabled: false
            }, [Validators.required]],
          AppErrLogs: [
            {
              value: this.csspdblocalcontext.AppErrLogs,
              disabled: false
            }, [Validators.required]],
          AppTasks: [
            {
              value: this.csspdblocalcontext.AppTasks,
              disabled: false
            }, [Validators.required]],
          AppTaskLanguages: [
            {
              value: this.csspdblocalcontext.AppTaskLanguages,
              disabled: false
            }, [Validators.required]],
          AspNetUsers: [
            {
              value: this.csspdblocalcontext.AspNetUsers,
              disabled: false
            }, [Validators.required]],
          BoxModels: [
            {
              value: this.csspdblocalcontext.BoxModels,
              disabled: false
            }, [Validators.required]],
          BoxModelLanguages: [
            {
              value: this.csspdblocalcontext.BoxModelLanguages,
              disabled: false
            }, [Validators.required]],
          BoxModelResults: [
            {
              value: this.csspdblocalcontext.BoxModelResults,
              disabled: false
            }, [Validators.required]],
          Classifications: [
            {
              value: this.csspdblocalcontext.Classifications,
              disabled: false
            }, [Validators.required]],
          ClimateDataValues: [
            {
              value: this.csspdblocalcontext.ClimateDataValues,
              disabled: false
            }, [Validators.required]],
          ClimateSites: [
            {
              value: this.csspdblocalcontext.ClimateSites,
              disabled: false
            }, [Validators.required]],
          Contacts: [
            {
              value: this.csspdblocalcontext.Contacts,
              disabled: false
            }, [Validators.required]],
          ContactPreferences: [
            {
              value: this.csspdblocalcontext.ContactPreferences,
              disabled: false
            }, [Validators.required]],
          ContactShortcuts: [
            {
              value: this.csspdblocalcontext.ContactShortcuts,
              disabled: false
            }, [Validators.required]],
          DeviceCodes: [
            {
              value: this.csspdblocalcontext.DeviceCodes,
              disabled: false
            }, [Validators.required]],
          DocTemplates: [
            {
              value: this.csspdblocalcontext.DocTemplates,
              disabled: false
            }, [Validators.required]],
          DrogueRuns: [
            {
              value: this.csspdblocalcontext.DrogueRuns,
              disabled: false
            }, [Validators.required]],
          DrogueRunPositions: [
            {
              value: this.csspdblocalcontext.DrogueRunPositions,
              disabled: false
            }, [Validators.required]],
          Emails: [
            {
              value: this.csspdblocalcontext.Emails,
              disabled: false
            }, [Validators.required]],
          EmailDistributionLists: [
            {
              value: this.csspdblocalcontext.EmailDistributionLists,
              disabled: false
            }, [Validators.required]],
          EmailDistributionListLanguages: [
            {
              value: this.csspdblocalcontext.EmailDistributionListLanguages,
              disabled: false
            }, [Validators.required]],
          EmailDistributionListContacts: [
            {
              value: this.csspdblocalcontext.EmailDistributionListContacts,
              disabled: false
            }, [Validators.required]],
          EmailDistributionListContactLanguages: [
            {
              value: this.csspdblocalcontext.EmailDistributionListContactLanguages,
              disabled: false
            }, [Validators.required]],
          HelpDocs: [
            {
              value: this.csspdblocalcontext.HelpDocs,
              disabled: false
            }, [Validators.required]],
          HydrometricDataValues: [
            {
              value: this.csspdblocalcontext.HydrometricDataValues,
              disabled: false
            }, [Validators.required]],
          HydrometricSites: [
            {
              value: this.csspdblocalcontext.HydrometricSites,
              disabled: false
            }, [Validators.required]],
          Infrastructures: [
            {
              value: this.csspdblocalcontext.Infrastructures,
              disabled: false
            }, [Validators.required]],
          InfrastructureLanguages: [
            {
              value: this.csspdblocalcontext.InfrastructureLanguages,
              disabled: false
            }, [Validators.required]],
          LabSheetDetails: [
            {
              value: this.csspdblocalcontext.LabSheetDetails,
              disabled: false
            }, [Validators.required]],
          LabSheetTubeMPNDetails: [
            {
              value: this.csspdblocalcontext.LabSheetTubeMPNDetails,
              disabled: false
            }, [Validators.required]],
          LabSheets: [
            {
              value: this.csspdblocalcontext.LabSheets,
              disabled: false
            }, [Validators.required]],
          Logs: [
            {
              value: this.csspdblocalcontext.Logs,
              disabled: false
            }, [Validators.required]],
          MapInfoPoints: [
            {
              value: this.csspdblocalcontext.MapInfoPoints,
              disabled: false
            }, [Validators.required]],
          MapInfos: [
            {
              value: this.csspdblocalcontext.MapInfos,
              disabled: false
            }, [Validators.required]],
          MikeBoundaryConditions: [
            {
              value: this.csspdblocalcontext.MikeBoundaryConditions,
              disabled: false
            }, [Validators.required]],
          MikeScenarioResults: [
            {
              value: this.csspdblocalcontext.MikeScenarioResults,
              disabled: false
            }, [Validators.required]],
          MikeScenarios: [
            {
              value: this.csspdblocalcontext.MikeScenarios,
              disabled: false
            }, [Validators.required]],
          MikeSourceStartEnds: [
            {
              value: this.csspdblocalcontext.MikeSourceStartEnds,
              disabled: false
            }, [Validators.required]],
          MWQMAnalysisReportParameters: [
            {
              value: this.csspdblocalcontext.MWQMAnalysisReportParameters,
              disabled: false
            }, [Validators.required]],
          MikeSources: [
            {
              value: this.csspdblocalcontext.MikeSources,
              disabled: false
            }, [Validators.required]],
          MWQMLookupMPNs: [
            {
              value: this.csspdblocalcontext.MWQMLookupMPNs,
              disabled: false
            }, [Validators.required]],
          MWQMRunLanguages: [
            {
              value: this.csspdblocalcontext.MWQMRunLanguages,
              disabled: false
            }, [Validators.required]],
          MWQMRuns: [
            {
              value: this.csspdblocalcontext.MWQMRuns,
              disabled: false
            }, [Validators.required]],
          MWQMSampleLanguages: [
            {
              value: this.csspdblocalcontext.MWQMSampleLanguages,
              disabled: false
            }, [Validators.required]],
          MWQMSamples: [
            {
              value: this.csspdblocalcontext.MWQMSamples,
              disabled: false
            }, [Validators.required]],
          MWQMSiteStartEndDates: [
            {
              value: this.csspdblocalcontext.MWQMSiteStartEndDates,
              disabled: false
            }, [Validators.required]],
          MWQMSites: [
            {
              value: this.csspdblocalcontext.MWQMSites,
              disabled: false
            }, [Validators.required]],
          MWQMSubsectorLanguages: [
            {
              value: this.csspdblocalcontext.MWQMSubsectorLanguages,
              disabled: false
            }, [Validators.required]],
          MWQMSubsectors: [
            {
              value: this.csspdblocalcontext.MWQMSubsectors,
              disabled: false
            }, [Validators.required]],
          PersistedGrants: [
            {
              value: this.csspdblocalcontext.PersistedGrants,
              disabled: false
            }, [Validators.required]],
          PolSourceGroupingLanguages: [
            {
              value: this.csspdblocalcontext.PolSourceGroupingLanguages,
              disabled: false
            }, [Validators.required]],
          PolSourceGroupings: [
            {
              value: this.csspdblocalcontext.PolSourceGroupings,
              disabled: false
            }, [Validators.required]],
          PolSourceObservationIssues: [
            {
              value: this.csspdblocalcontext.PolSourceObservationIssues,
              disabled: false
            }, [Validators.required]],
          PolSourceObservations: [
            {
              value: this.csspdblocalcontext.PolSourceObservations,
              disabled: false
            }, [Validators.required]],
          PolSourceSites: [
            {
              value: this.csspdblocalcontext.PolSourceSites,
              disabled: false
            }, [Validators.required]],
          PolSourceSiteEffects: [
            {
              value: this.csspdblocalcontext.PolSourceSiteEffects,
              disabled: false
            }, [Validators.required]],
          PolSourceSiteEffectTerms: [
            {
              value: this.csspdblocalcontext.PolSourceSiteEffectTerms,
              disabled: false
            }, [Validators.required]],
          RatingCurveValues: [
            {
              value: this.csspdblocalcontext.RatingCurveValues,
              disabled: false
            }, [Validators.required]],
          RainExceedances: [
            {
              value: this.csspdblocalcontext.RainExceedances,
              disabled: false
            }, [Validators.required]],
          RainExceedanceClimateSites: [
            {
              value: this.csspdblocalcontext.RainExceedanceClimateSites,
              disabled: false
            }, [Validators.required]],
          RatingCurves: [
            {
              value: this.csspdblocalcontext.RatingCurves,
              disabled: false
            }, [Validators.required]],
          ResetPasswords: [
            {
              value: this.csspdblocalcontext.ResetPasswords,
              disabled: false
            }, [Validators.required]],
          ReportSections: [
            {
              value: this.csspdblocalcontext.ReportSections,
              disabled: false
            }, [Validators.required]],
          ReportTypes: [
            {
              value: this.csspdblocalcontext.ReportTypes,
              disabled: false
            }, [Validators.required]],
          SamplingPlanSubsectorSites: [
            {
              value: this.csspdblocalcontext.SamplingPlanSubsectorSites,
              disabled: false
            }, [Validators.required]],
          SamplingPlanSubsectors: [
            {
              value: this.csspdblocalcontext.SamplingPlanSubsectors,
              disabled: false
            }, [Validators.required]],
          SamplingPlanEmails: [
            {
              value: this.csspdblocalcontext.SamplingPlanEmails,
              disabled: false
            }, [Validators.required]],
          SamplingPlans: [
            {
              value: this.csspdblocalcontext.SamplingPlans,
              disabled: false
            }, [Validators.required]],
          SpillLanguages: [
            {
              value: this.csspdblocalcontext.SpillLanguages,
              disabled: false
            }, [Validators.required]],
          Spills: [
            {
              value: this.csspdblocalcontext.Spills,
              disabled: false
            }, [Validators.required]],
          Tels: [
            {
              value: this.csspdblocalcontext.Tels,
              disabled: false
            }, [Validators.required]],
          TideDataValues: [
            {
              value: this.csspdblocalcontext.TideDataValues,
              disabled: false
            }, [Validators.required]],
          TideLocations: [
            {
              value: this.csspdblocalcontext.TideLocations,
              disabled: false
            }, [Validators.required]],
          TideSites: [
            {
              value: this.csspdblocalcontext.TideSites,
              disabled: false
            }, [Validators.required]],
          TVFileLanguages: [
            {
              value: this.csspdblocalcontext.TVFileLanguages,
              disabled: false
            }, [Validators.required]],
          TVFiles: [
            {
              value: this.csspdblocalcontext.TVFiles,
              disabled: false
            }, [Validators.required]],
          TVItems: [
            {
              value: this.csspdblocalcontext.TVItems,
              disabled: false
            }, [Validators.required]],
          TVItemLanguages: [
            {
              value: this.csspdblocalcontext.TVItemLanguages,
              disabled: false
            }, [Validators.required]],
          TVItemLinks: [
            {
              value: this.csspdblocalcontext.TVItemLinks,
              disabled: false
            }, [Validators.required]],
          TVItemStats: [
            {
              value: this.csspdblocalcontext.TVItemStats,
              disabled: false
            }, [Validators.required]],
          TVItemUserAuthorizations: [
            {
              value: this.csspdblocalcontext.TVItemUserAuthorizations,
              disabled: false
            }, [Validators.required]],
          TVTypeUserAuthorizations: [
            {
              value: this.csspdblocalcontext.TVTypeUserAuthorizations,
              disabled: false
            }, [Validators.required]],
          UseOfSites: [
            {
              value: this.csspdblocalcontext.UseOfSites,
              disabled: false
            }, [Validators.required]],
          VPAmbients: [
            {
              value: this.csspdblocalcontext.VPAmbients,
              disabled: false
            }, [Validators.required]],
          VPResults: [
            {
              value: this.csspdblocalcontext.VPResults,
              disabled: false
            }, [Validators.required]],
          VPScenarioLanguages: [
            {
              value: this.csspdblocalcontext.VPScenarioLanguages,
              disabled: false
            }, [Validators.required]],
          VPScenarios: [
            {
              value: this.csspdblocalcontext.VPScenarios,
              disabled: false
            }, [Validators.required]],
          Database: [
            {
              value: this.csspdblocalcontext.Database,
              disabled: false
            }, [Validators.required]],
          ChangeTracker: [
            {
              value: this.csspdblocalcontext.ChangeTracker,
              disabled: false
            }, [Validators.required]],
          Model: [
            {
              value: this.csspdblocalcontext.Model,
              disabled: false
            }, [Validators.required]],
          ContextId: [
            {
              value: this.csspdblocalcontext.ContextId,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.csspdblocalcontextFormEdit = formGroup
    }
  }
}
