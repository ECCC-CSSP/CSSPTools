import { Injectable } from '@angular/core';
import { AppLoadedService } from '../app-loaded.service';

@Injectable({
  providedIn: 'root'
})
export class ComponentDataLoadedService {

  constructor(private appLoadedService: AppLoadedService) {
  }

  DataLoadedArea(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebArea).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebArea.constructor === Object);
  }

  DataLoadedClimateData(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebClimateDataValue).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebClimateDataValue.constructor === Object);
  }

  DataLoadedClimateSite(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite.constructor === Object);
  }

  DataLoadedContact(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebContact).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebContact.constructor === Object);
  }

  DataLoadedCountry(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebCountry).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebCountry.constructor === Object);
  }

  DataLoadedDrogueRun(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebDrogueRun).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebDrogueRun.constructor === Object);
  }

  DataLoadedHelpDoc(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc.constructor === Object);
  }

  DataLoadedHydrometricData(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricDataValue).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricDataValue.constructor === Object);
  }

  DataLoadedHydrometricSite(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite.constructor === Object);
  }

  DataLoadedMIKEScenario(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenario).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenario.constructor === Object);
  }

  DataLoadedMunicipalities(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities.constructor === Object);
  }

  DataLoadedMunicipality(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMunicipality).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebMunicipality.constructor === Object);
  }

  DataLoadedMWQMLookupMPN(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN.constructor === Object);
  }

  DataLoadedMWQMSample(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050.constructor === Object);
  }

  DataLoadedMWQMSample1980To1990(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980.constructor === Object);
  }

  DataLoadedMWQMSample1990To2000(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990.constructor === Object);
  }

  DataLoadedMWQMSample2000To2010(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000.constructor === Object);
  }

  DataLoadedMWQMSample2010To2020(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010.constructor === Object);
  }

  DataLoadedMWQMSample2020To2030(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020.constructor === Object);
  }

  DataLoadedMWQMSample2030To2040(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030.constructor === Object);
  }

  DataLoadedMWQMSample2040To2050(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040.constructor === Object);
  }

  DataLoadedMWQMSample2050To2060(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050.constructor === Object);
  }

  DataLoadedMWQMRun(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRun).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRun.constructor === Object);
  }

  DataLoadedMWQMSite(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSite).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSite.constructor === Object);
  }

  DataLoadedPolSourceSite(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSite).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSite.constructor === Object);
  }

  DataLoadedPolSourceGrouping(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping.constructor === Object);
  }

  DataLoadedPolSourceSiteEffectTerm(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm.constructor === Object);
  }

  DataLoadedProvince(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebProvince).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebProvince.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite.constructor === Object);
  }

  DataLoadedReportType(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebReportType).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebReportType.constructor === Object);
  }

  DataLoadedRoot(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebRoot).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebRoot.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebContact).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebContact.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebReportType).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebReportType.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation.constructor === Object);
  }

  DataLoadedSamplingPlan(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSamplingPlan).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebSamplingPlan.constructor === Object);
  }

  DataLoadedSector(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSector).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebSector.constructor === Object);
  }

  DataLoadedSubsector(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSubsector).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebSubsector.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSite).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSite.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMRun).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMRun.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebPolSourceSite).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebPolSourceSite.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebDrogueRun).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebDrogueRun.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050).length === 0
      && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050.constructor === Object);
  }

  DataLoadedTideLocation(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation.constructor === Object);
  }
}
