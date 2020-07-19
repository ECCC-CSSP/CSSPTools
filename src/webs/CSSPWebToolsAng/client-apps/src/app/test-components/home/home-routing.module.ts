/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { AuthGuard } from '../../guards';

const routes: Routes = [
  {
    path: '', component: HomeComponent, canActivate: [AuthGuard], children: [
      { path: 'applicationdbcontext', loadChildren: () => import('../../test-components/generated/applicationdbcontext/applicationdbcontext.module').then(mod => mod.ApplicationDbContextModule) },
      { path: 'applicationuser', loadChildren: () => import('../../test-components/generated/applicationuser/applicationuser.module').then(mod => mod.ApplicationUserModule) },
      { path: 'basecontext', loadChildren: () => import('../../test-components/generated/basecontext/basecontext.module').then(mod => mod.BaseContextModule) },
      { path: 'csspdblocalcontext', loadChildren: () => import('../../test-components/generated/csspdblocalcontext/csspdblocalcontext.module').then(mod => mod.CSSPDBLocalContextModule) },
      { path: 'csspfilesmanagementdbcontext', loadChildren: () => import('../../test-components/generated/csspfilesmanagementdbcontext/csspfilesmanagementdbcontext.module').then(mod => mod.CSSPFilesManagementDBContextModule) },
      { path: 'cssplogindbcontext', loadChildren: () => import('../../test-components/generated/cssplogindbcontext/cssplogindbcontext.module').then(mod => mod.CSSPLoginDBContextModule) },
      { path: 'basemodelservice', loadChildren: () => import('../../test-components/generated/basemodelservice/basemodelservice.module').then(mod => mod.BaseModelServiceModule) },
      { path: 'webarea', loadChildren: () => import('../../test-components/generated/webarea/webarea.module').then(mod => mod.WebAreaModule) },
      { path: 'webbase', loadChildren: () => import('../../test-components/generated/webbase/webbase.module').then(mod => mod.WebBaseModule) },
      { path: 'webclimatedatavalue', loadChildren: () => import('../../test-components/generated/webclimatedatavalue/webclimatedatavalue.module').then(mod => mod.WebClimateDataValueModule) },
      { path: 'webclimatesite', loadChildren: () => import('../../test-components/generated/webclimatesite/webclimatesite.module').then(mod => mod.WebClimateSiteModule) },
      { path: 'webcontact', loadChildren: () => import('../../test-components/generated/webcontact/webcontact.module').then(mod => mod.WebContactModule) },
      { path: 'webcountry', loadChildren: () => import('../../test-components/generated/webcountry/webcountry.module').then(mod => mod.WebCountryModule) },
      { path: 'webdroguerun', loadChildren: () => import('../../test-components/generated/webdroguerun/webdroguerun.module').then(mod => mod.WebDrogueRunModule) },
      { path: 'webhelpdoc', loadChildren: () => import('../../test-components/generated/webhelpdoc/webhelpdoc.module').then(mod => mod.WebHelpDocModule) },
      { path: 'webhydrometricdatavalue', loadChildren: () => import('../../test-components/generated/webhydrometricdatavalue/webhydrometricdatavalue.module').then(mod => mod.WebHydrometricDataValueModule) },
      { path: 'webhydrometricsite', loadChildren: () => import('../../test-components/generated/webhydrometricsite/webhydrometricsite.module').then(mod => mod.WebHydrometricSiteModule) },
      { path: 'webmikescenario', loadChildren: () => import('../../test-components/generated/webmikescenario/webmikescenario.module').then(mod => mod.WebMikeScenarioModule) },
      { path: 'webmunicipalities', loadChildren: () => import('../../test-components/generated/webmunicipalities/webmunicipalities.module').then(mod => mod.WebMunicipalitiesModule) },
      { path: 'webmunicipality', loadChildren: () => import('../../test-components/generated/webmunicipality/webmunicipality.module').then(mod => mod.WebMunicipalityModule) },
      { path: 'webmwqmlookupmpn', loadChildren: () => import('../../test-components/generated/webmwqmlookupmpn/webmwqmlookupmpn.module').then(mod => mod.WebMWQMLookupMPNModule) },
      { path: 'webmwqmrun', loadChildren: () => import('../../test-components/generated/webmwqmrun/webmwqmrun.module').then(mod => mod.WebMWQMRunModule) },
      { path: 'webmwqmsite', loadChildren: () => import('../../test-components/generated/webmwqmsite/webmwqmsite.module').then(mod => mod.WebMWQMSiteModule) },
      { path: 'webpolsourcegrouping', loadChildren: () => import('../../test-components/generated/webpolsourcegrouping/webpolsourcegrouping.module').then(mod => mod.WebPolSourceGroupingModule) },
      { path: 'webpolsourcesite', loadChildren: () => import('../../test-components/generated/webpolsourcesite/webpolsourcesite.module').then(mod => mod.WebPolSourceSiteModule) },
      { path: 'webprovince', loadChildren: () => import('../../test-components/generated/webprovince/webprovince.module').then(mod => mod.WebProvinceModule) },
      { path: 'webreporttype', loadChildren: () => import('../../test-components/generated/webreporttype/webreporttype.module').then(mod => mod.WebReportTypeModule) },
      { path: 'webroot', loadChildren: () => import('../../test-components/generated/webroot/webroot.module').then(mod => mod.WebRootModule) },
      { path: 'webmwqmsample', loadChildren: () => import('../../test-components/generated/webmwqmsample/webmwqmsample.module').then(mod => mod.WebMWQMSampleModule) },
      { path: 'websamplingplan', loadChildren: () => import('../../test-components/generated/websamplingplan/websamplingplan.module').then(mod => mod.WebSamplingPlanModule) },
      { path: 'websector', loadChildren: () => import('../../test-components/generated/websector/websector.module').then(mod => mod.WebSectorModule) },
      { path: 'websubsector', loadChildren: () => import('../../test-components/generated/websubsector/websubsector.module').then(mod => mod.WebSubsectorModule) },
      { path: 'webtidelocation', loadChildren: () => import('../../test-components/generated/webtidelocation/webtidelocation.module').then(mod => mod.WebTideLocationModule) },
      { path: 'address', loadChildren: () => import('../../test-components/generated/address/address.module').then(mod => mod.AddressModule) },
      { path: 'apperrlog', loadChildren: () => import('../../test-components/generated/apperrlog/apperrlog.module').then(mod => mod.AppErrLogModule) },
      { path: 'apptask', loadChildren: () => import('../../test-components/generated/apptask/apptask.module').then(mod => mod.AppTaskModule) },
      { path: 'apptasklanguage', loadChildren: () => import('../../test-components/generated/apptasklanguage/apptasklanguage.module').then(mod => mod.AppTaskLanguageModule) },
      { path: 'aspnetrole', loadChildren: () => import('../../test-components/generated/aspnetrole/aspnetrole.module').then(mod => mod.AspNetRoleModule) },
      { path: 'aspnetroleclaim', loadChildren: () => import('../../test-components/generated/aspnetroleclaim/aspnetroleclaim.module').then(mod => mod.AspNetRoleClaimModule) },
      { path: 'aspnetuserclaim', loadChildren: () => import('../../test-components/generated/aspnetuserclaim/aspnetuserclaim.module').then(mod => mod.AspNetUserClaimModule) },
      { path: 'aspnetuserlogin', loadChildren: () => import('../../test-components/generated/aspnetuserlogin/aspnetuserlogin.module').then(mod => mod.AspNetUserLoginModule) },
      { path: 'aspnetuserrole', loadChildren: () => import('../../test-components/generated/aspnetuserrole/aspnetuserrole.module').then(mod => mod.AspNetUserRoleModule) },
      { path: 'aspnetusertoken', loadChildren: () => import('../../test-components/generated/aspnetusertoken/aspnetusertoken.module').then(mod => mod.AspNetUserTokenModule) },
      { path: 'boxmodel', loadChildren: () => import('../../test-components/generated/boxmodel/boxmodel.module').then(mod => mod.BoxModelModule) },
      { path: 'boxmodellanguage', loadChildren: () => import('../../test-components/generated/boxmodellanguage/boxmodellanguage.module').then(mod => mod.BoxModelLanguageModule) },
      { path: 'boxmodelresult', loadChildren: () => import('../../test-components/generated/boxmodelresult/boxmodelresult.module').then(mod => mod.BoxModelResultModule) },
      { path: 'classification', loadChildren: () => import('../../test-components/generated/classification/classification.module').then(mod => mod.ClassificationModule) },
      { path: 'climatedatavalue', loadChildren: () => import('../../test-components/generated/climatedatavalue/climatedatavalue.module').then(mod => mod.ClimateDataValueModule) },
      { path: 'climatesite', loadChildren: () => import('../../test-components/generated/climatesite/climatesite.module').then(mod => mod.ClimateSiteModule) },
      { path: 'contact', loadChildren: () => import('../../test-components/generated/contact/contact.module').then(mod => mod.ContactModule) },
      { path: 'contactpreference', loadChildren: () => import('../../test-components/generated/contactpreference/contactpreference.module').then(mod => mod.ContactPreferenceModule) },
      { path: 'contactshortcut', loadChildren: () => import('../../test-components/generated/contactshortcut/contactshortcut.module').then(mod => mod.ContactShortcutModule) },
      { path: 'csspfile', loadChildren: () => import('../../test-components/generated/csspfile/csspfile.module').then(mod => mod.CSSPFileModule) },
      { path: 'devicecode', loadChildren: () => import('../../test-components/generated/devicecode/devicecode.module').then(mod => mod.DeviceCodeModule) },
      { path: 'doctemplate', loadChildren: () => import('../../test-components/generated/doctemplate/doctemplate.module').then(mod => mod.DocTemplateModule) },
      { path: 'droguerun', loadChildren: () => import('../../test-components/generated/droguerun/droguerun.module').then(mod => mod.DrogueRunModule) },
      { path: 'droguerunposition', loadChildren: () => import('../../test-components/generated/droguerunposition/droguerunposition.module').then(mod => mod.DrogueRunPositionModule) },
      { path: 'email', loadChildren: () => import('../../test-components/generated/email/email.module').then(mod => mod.EmailModule) },
      { path: 'emaildistributionlist', loadChildren: () => import('../../test-components/generated/emaildistributionlist/emaildistributionlist.module').then(mod => mod.EmailDistributionListModule) },
      { path: 'emaildistributionlistcontact', loadChildren: () => import('../../test-components/generated/emaildistributionlistcontact/emaildistributionlistcontact.module').then(mod => mod.EmailDistributionListContactModule) },
      { path: 'emaildistributionlistcontactlanguage', loadChildren: () => import('../../test-components/generated/emaildistributionlistcontactlanguage/emaildistributionlistcontactlanguage.module').then(mod => mod.EmailDistributionListContactLanguageModule) },
      { path: 'emaildistributionlistlanguage', loadChildren: () => import('../../test-components/generated/emaildistributionlistlanguage/emaildistributionlistlanguage.module').then(mod => mod.EmailDistributionListLanguageModule) },
      { path: 'helpdoc', loadChildren: () => import('../../test-components/generated/helpdoc/helpdoc.module').then(mod => mod.HelpDocModule) },
      { path: 'hydrometricdatavalue', loadChildren: () => import('../../test-components/generated/hydrometricdatavalue/hydrometricdatavalue.module').then(mod => mod.HydrometricDataValueModule) },
      { path: 'hydrometricsite', loadChildren: () => import('../../test-components/generated/hydrometricsite/hydrometricsite.module').then(mod => mod.HydrometricSiteModule) },
      { path: 'infrastructure', loadChildren: () => import('../../test-components/generated/infrastructure/infrastructure.module').then(mod => mod.InfrastructureModule) },
      { path: 'infrastructurelanguage', loadChildren: () => import('../../test-components/generated/infrastructurelanguage/infrastructurelanguage.module').then(mod => mod.InfrastructureLanguageModule) },
      { path: 'labsheet', loadChildren: () => import('../../test-components/generated/labsheet/labsheet.module').then(mod => mod.LabSheetModule) },
      { path: 'labsheetdetail', loadChildren: () => import('../../test-components/generated/labsheetdetail/labsheetdetail.module').then(mod => mod.LabSheetDetailModule) },
      { path: 'labsheettubempndetail', loadChildren: () => import('../../test-components/generated/labsheettubempndetail/labsheettubempndetail.module').then(mod => mod.LabSheetTubeMPNDetailModule) },
      { path: 'log', loadChildren: () => import('../../test-components/generated/log/log.module').then(mod => mod.LogModule) },
      { path: 'mapinfo', loadChildren: () => import('../../test-components/generated/mapinfo/mapinfo.module').then(mod => mod.MapInfoModule) },
      { path: 'mapinfopoint', loadChildren: () => import('../../test-components/generated/mapinfopoint/mapinfopoint.module').then(mod => mod.MapInfoPointModule) },
      { path: 'mikeboundarycondition', loadChildren: () => import('../../test-components/generated/mikeboundarycondition/mikeboundarycondition.module').then(mod => mod.MikeBoundaryConditionModule) },
      { path: 'mikescenario', loadChildren: () => import('../../test-components/generated/mikescenario/mikescenario.module').then(mod => mod.MikeScenarioModule) },
      { path: 'mikescenarioresult', loadChildren: () => import('../../test-components/generated/mikescenarioresult/mikescenarioresult.module').then(mod => mod.MikeScenarioResultModule) },
      { path: 'mikesource', loadChildren: () => import('../../test-components/generated/mikesource/mikesource.module').then(mod => mod.MikeSourceModule) },
      { path: 'mikesourcestartend', loadChildren: () => import('../../test-components/generated/mikesourcestartend/mikesourcestartend.module').then(mod => mod.MikeSourceStartEndModule) },
      { path: 'mwqmanalysisreportparameter', loadChildren: () => import('../../test-components/generated/mwqmanalysisreportparameter/mwqmanalysisreportparameter.module').then(mod => mod.MWQMAnalysisReportParameterModule) },
      { path: 'mwqmlookupmpn', loadChildren: () => import('../../test-components/generated/mwqmlookupmpn/mwqmlookupmpn.module').then(mod => mod.MWQMLookupMPNModule) },
      { path: 'mwqmrun', loadChildren: () => import('../../test-components/generated/mwqmrun/mwqmrun.module').then(mod => mod.MWQMRunModule) },
      { path: 'mwqmrunlanguage', loadChildren: () => import('../../test-components/generated/mwqmrunlanguage/mwqmrunlanguage.module').then(mod => mod.MWQMRunLanguageModule) },
      { path: 'mwqmsample', loadChildren: () => import('../../test-components/generated/mwqmsample/mwqmsample.module').then(mod => mod.MWQMSampleModule) },
      { path: 'mwqmsamplelanguage', loadChildren: () => import('../../test-components/generated/mwqmsamplelanguage/mwqmsamplelanguage.module').then(mod => mod.MWQMSampleLanguageModule) },
      { path: 'mwqmsite', loadChildren: () => import('../../test-components/generated/mwqmsite/mwqmsite.module').then(mod => mod.MWQMSiteModule) },
      { path: 'mwqmsitestartenddate', loadChildren: () => import('../../test-components/generated/mwqmsitestartenddate/mwqmsitestartenddate.module').then(mod => mod.MWQMSiteStartEndDateModule) },
      { path: 'mwqmsubsector', loadChildren: () => import('../../test-components/generated/mwqmsubsector/mwqmsubsector.module').then(mod => mod.MWQMSubsectorModule) },
      { path: 'mwqmsubsectorlanguage', loadChildren: () => import('../../test-components/generated/mwqmsubsectorlanguage/mwqmsubsectorlanguage.module').then(mod => mod.MWQMSubsectorLanguageModule) },
      { path: 'persistedgrant', loadChildren: () => import('../../test-components/generated/persistedgrant/persistedgrant.module').then(mod => mod.PersistedGrantModule) },
      { path: 'polsourcegrouping', loadChildren: () => import('../../test-components/generated/polsourcegrouping/polsourcegrouping.module').then(mod => mod.PolSourceGroupingModule) },
      { path: 'polsourcegroupinglanguage', loadChildren: () => import('../../test-components/generated/polsourcegroupinglanguage/polsourcegroupinglanguage.module').then(mod => mod.PolSourceGroupingLanguageModule) },
      { path: 'polsourceobservation', loadChildren: () => import('../../test-components/generated/polsourceobservation/polsourceobservation.module').then(mod => mod.PolSourceObservationModule) },
      { path: 'polsourceobservationissue', loadChildren: () => import('../../test-components/generated/polsourceobservationissue/polsourceobservationissue.module').then(mod => mod.PolSourceObservationIssueModule) },
      { path: 'polsourcesite', loadChildren: () => import('../../test-components/generated/polsourcesite/polsourcesite.module').then(mod => mod.PolSourceSiteModule) },
      { path: 'polsourcesiteeffect', loadChildren: () => import('../../test-components/generated/polsourcesiteeffect/polsourcesiteeffect.module').then(mod => mod.PolSourceSiteEffectModule) },
      { path: 'polsourcesiteeffectterm', loadChildren: () => import('../../test-components/generated/polsourcesiteeffectterm/polsourcesiteeffectterm.module').then(mod => mod.PolSourceSiteEffectTermModule) },
      { path: 'preference', loadChildren: () => import('../../test-components/generated/preference/preference.module').then(mod => mod.PreferenceModule) },
      { path: 'rainexceedance', loadChildren: () => import('../../test-components/generated/rainexceedance/rainexceedance.module').then(mod => mod.RainExceedanceModule) },
      { path: 'rainexceedanceclimatesite', loadChildren: () => import('../../test-components/generated/rainexceedanceclimatesite/rainexceedanceclimatesite.module').then(mod => mod.RainExceedanceClimateSiteModule) },
      { path: 'ratingcurve', loadChildren: () => import('../../test-components/generated/ratingcurve/ratingcurve.module').then(mod => mod.RatingCurveModule) },
      { path: 'ratingcurvevalue', loadChildren: () => import('../../test-components/generated/ratingcurvevalue/ratingcurvevalue.module').then(mod => mod.RatingCurveValueModule) },
      { path: 'reportsection', loadChildren: () => import('../../test-components/generated/reportsection/reportsection.module').then(mod => mod.ReportSectionModule) },
      { path: 'reporttype', loadChildren: () => import('../../test-components/generated/reporttype/reporttype.module').then(mod => mod.ReportTypeModule) },
      { path: 'resetpassword', loadChildren: () => import('../../test-components/generated/resetpassword/resetpassword.module').then(mod => mod.ResetPasswordModule) },
      { path: 'samplingplan', loadChildren: () => import('../../test-components/generated/samplingplan/samplingplan.module').then(mod => mod.SamplingPlanModule) },
      { path: 'samplingplanemail', loadChildren: () => import('../../test-components/generated/samplingplanemail/samplingplanemail.module').then(mod => mod.SamplingPlanEmailModule) },
      { path: 'samplingplansubsector', loadChildren: () => import('../../test-components/generated/samplingplansubsector/samplingplansubsector.module').then(mod => mod.SamplingPlanSubsectorModule) },
      { path: 'samplingplansubsectorsite', loadChildren: () => import('../../test-components/generated/samplingplansubsectorsite/samplingplansubsectorsite.module').then(mod => mod.SamplingPlanSubsectorSiteModule) },
      { path: 'spill', loadChildren: () => import('../../test-components/generated/spill/spill.module').then(mod => mod.SpillModule) },
      { path: 'spilllanguage', loadChildren: () => import('../../test-components/generated/spilllanguage/spilllanguage.module').then(mod => mod.SpillLanguageModule) },
      { path: 'tel', loadChildren: () => import('../../test-components/generated/tel/tel.module').then(mod => mod.TelModule) },
      { path: 'tidedatavalue', loadChildren: () => import('../../test-components/generated/tidedatavalue/tidedatavalue.module').then(mod => mod.TideDataValueModule) },
      { path: 'tidelocation', loadChildren: () => import('../../test-components/generated/tidelocation/tidelocation.module').then(mod => mod.TideLocationModule) },
      { path: 'tidesite', loadChildren: () => import('../../test-components/generated/tidesite/tidesite.module').then(mod => mod.TideSiteModule) },
      { path: 'tvfile', loadChildren: () => import('../../test-components/generated/tvfile/tvfile.module').then(mod => mod.TVFileModule) },
      { path: 'tvfilelanguage', loadChildren: () => import('../../test-components/generated/tvfilelanguage/tvfilelanguage.module').then(mod => mod.TVFileLanguageModule) },
      { path: 'tvitem', loadChildren: () => import('../../test-components/generated/tvitem/tvitem.module').then(mod => mod.TVItemModule) },
      { path: 'tvitemlanguage', loadChildren: () => import('../../test-components/generated/tvitemlanguage/tvitemlanguage.module').then(mod => mod.TVItemLanguageModule) },
      { path: 'tvitemlink', loadChildren: () => import('../../test-components/generated/tvitemlink/tvitemlink.module').then(mod => mod.TVItemLinkModule) },
      { path: 'tvitemstat', loadChildren: () => import('../../test-components/generated/tvitemstat/tvitemstat.module').then(mod => mod.TVItemStatModule) },
      { path: 'tvitemuserauthorization', loadChildren: () => import('../../test-components/generated/tvitemuserauthorization/tvitemuserauthorization.module').then(mod => mod.TVItemUserAuthorizationModule) },
      { path: 'tvtypeuserauthorization', loadChildren: () => import('../../test-components/generated/tvtypeuserauthorization/tvtypeuserauthorization.module').then(mod => mod.TVTypeUserAuthorizationModule) },
      { path: 'useofsite', loadChildren: () => import('../../test-components/generated/useofsite/useofsite.module').then(mod => mod.UseOfSiteModule) },
      { path: 'vpambient', loadChildren: () => import('../../test-components/generated/vpambient/vpambient.module').then(mod => mod.VPAmbientModule) },
      { path: 'vpresult', loadChildren: () => import('../../test-components/generated/vpresult/vpresult.module').then(mod => mod.VPResultModule) },
      { path: 'vpscenario', loadChildren: () => import('../../test-components/generated/vpscenario/vpscenario.module').then(mod => mod.VPScenarioModule) },
      { path: 'vpscenariolanguage', loadChildren: () => import('../../test-components/generated/vpscenariolanguage/vpscenariolanguage.module').then(mod => mod.VPScenarioLanguageModule) },
      { path: 'csspforeignkeyattribute', loadChildren: () => import('../../test-components/generated/csspforeignkeyattribute/csspforeignkeyattribute.module').then(mod => mod.CSSPForeignKeyAttributeModule) },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
