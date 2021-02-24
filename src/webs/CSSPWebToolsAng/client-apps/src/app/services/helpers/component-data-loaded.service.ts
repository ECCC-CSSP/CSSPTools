import { Injectable } from '@angular/core';
import { AppLoadedService } from '../app-loaded.service';

@Injectable({
  providedIn: 'root'
})
export class ComponentDataLoadedService {

  constructor(private appLoadedService: AppLoadedService) {
  }

  DataLoadedAllCountries(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedAllMunicipalities(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedAllProvinces(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedArea(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebArea === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebArea).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebArea.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedClimateData(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebClimateDataValue === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebClimateDataValue).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebClimateDataValue.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedClimateSite(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedContact(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebContact === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebContact).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebContact.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedCountry(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebCountry === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebCountry).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebCountry.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedDrogueRun(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebDrogueRun === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebDrogueRun).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebDrogueRun.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedHelpDoc(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedHydrometricData(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricDataValue === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricDataValue).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricDataValue.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedHydrometricSite(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMIKEScenario(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenario === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenario).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenario.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMunicipalities(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMunicipality(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMunicipality === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMunicipality).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMunicipality.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMLookupMPN(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMSample(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue
  }

  DataLoadedMWQMSample1980To1990(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMSample1990To2000(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMSample2000To2010(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMSample2010To2020(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMSample2020To2030(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMSample2030To2040(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMSample2040To2050(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMSample2050To2060(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMRun(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRun === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRun).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRun.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedMWQMSite(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSite === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSite).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSite.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedPolSourceSite(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSite === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSite).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSite.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedPolSourceGrouping(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedPolSourceSiteEffectTerm(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedProvince(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebProvince === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebProvince).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebProvince.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebClimateSite.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSite.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedReportType(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebReportType === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebReportType).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebReportType.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedRoot(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebRoot === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebRoot).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebRoot.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebContact === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebContact).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebContact.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebHelpDoc.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMLookupMPN.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceGrouping.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSiteEffectTerm.constructor === Object)) {
      AllTrue == false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebReportType === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebReportType).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebReportType.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation.constructor === Object)) {
      AllTrue == false;
    }

    return AllTrue;
  }

  DataLoadedSamplingPlan(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebSamplingPlan === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSamplingPlan).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebSamplingPlan.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedSector(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebSector === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSector).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebSector.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedSubsector(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebSubsector === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSubsector).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebSubsector.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSite === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSite).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSite.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMRun === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMRun).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMRun.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebPolSourceSite === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebPolSourceSite).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebPolSourceSite.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebDrogueRun === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebDrogueRun).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebDrogueRun.constructor === Object)) {
      AllTrue == false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040.constructor === Object)) {
      AllTrue = false;
    }
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedTideLocation(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebTideLocation.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }
}
