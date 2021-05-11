import { Injectable } from '@angular/core';
import { AppLoadedService } from '../app-loaded.service';

@Injectable({
  providedIn: 'root'
})
export class ComponentDataLoadedService {

  constructor(private appLoadedService: AppLoadedService) {
  }

  DataIsLoaded(obj: any) {
    return (obj === undefined || (Object.keys(obj).length === 0 && obj.constructor === Object)) ? false : true;
  }

  // DataLoadedWebAllAddresses(): boolean {
  //   let obj: any = this.appLoadedService.WebAllAddresses;
  //   if (obj === undefined
  //     || (Object.keys(obj).length === 0
  //       && obj.constructor === Object)) {
  //     return false;
  //   }

  //   return true;
  // }

  DataLoadedWebAllContacts(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllContacts === undefined
      || (Object.keys(this.appLoadedService.WebAllContacts).length === 0
        && this.appLoadedService.WebAllContacts.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllCountries(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllCountries === undefined
      || (Object.keys(this.appLoadedService.WebAllCountries).length === 0
        && this.appLoadedService.WebAllCountries.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllEmails(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllEmails === undefined
      || (Object.keys(this.appLoadedService.WebAllEmails).length === 0
        && this.appLoadedService.WebAllEmails.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllHelpDocs(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllHelpDocs === undefined
      || (Object.keys(this.appLoadedService.WebAllHelpDocs).length === 0
        && this.appLoadedService.WebAllHelpDocs.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllMunicipalities(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllMunicipalities === undefined
      || (Object.keys(this.appLoadedService.WebAllMunicipalities).length === 0
        && this.appLoadedService.WebAllMunicipalities.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllMWQMLookupMPNs(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllMWQMLookupMPNs === undefined
      || (Object.keys(this.appLoadedService.WebAllMWQMLookupMPNs).length === 0
        && this.appLoadedService.WebAllMWQMLookupMPNs.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllPolSourceGroupings(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllPolSourceGroupings === undefined
      || (Object.keys(this.appLoadedService.WebAllPolSourceGroupings).length === 0
        && this.appLoadedService.WebAllPolSourceGroupings.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllPolSourceSiteEffectTerms(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllPolSourceSiteEffectTerms === undefined
      || (Object.keys(this.appLoadedService.WebAllPolSourceSiteEffectTerms).length === 0
        && this.appLoadedService.WebAllPolSourceSiteEffectTerms.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllProvinces(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllProvinces === undefined
      || (Object.keys(this.appLoadedService.WebAllProvinces).length === 0
        && this.appLoadedService.WebAllProvinces.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllReportTypes(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllReportTypes === undefined
      || (Object.keys(this.appLoadedService.WebAllReportTypes).length === 0
        && this.appLoadedService.WebAllReportTypes.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllTels(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllTels === undefined
      || (Object.keys(this.appLoadedService.WebAllTels).length === 0
        && this.appLoadedService.WebAllTels.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllTideLocations(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllTideLocations === undefined
      || (Object.keys(this.appLoadedService.WebAllTideLocations).length === 0
        && this.appLoadedService.WebAllTideLocations.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebArea(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebArea === undefined
      || (Object.keys(this.appLoadedService.WebArea).length === 0
        && this.appLoadedService.WebArea.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebClimateSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebClimateSites === undefined
      || (Object.keys(this.appLoadedService.WebClimateSites).length === 0
        && this.appLoadedService.WebClimateSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebCountry(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebCountry === undefined
      || (Object.keys(this.appLoadedService.WebCountry).length === 0
        && this.appLoadedService.WebCountry.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebDrogueRuns(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebDrogueRuns === undefined
      || (Object.keys(this.appLoadedService.WebDrogueRuns).length === 0
        && this.appLoadedService.WebDrogueRuns.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebHelpDocs(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebAllHelpDocs === undefined
      || (Object.keys(this.appLoadedService.WebAllHelpDocs).length === 0
        && this.appLoadedService.WebAllHelpDocs.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebHydrometricSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebHydrometricSites === undefined
      || (Object.keys(this.appLoadedService.WebHydrometricSites).length === 0
        && this.appLoadedService.WebHydrometricSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebLabSheets(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebLabSheets === undefined
      || (Object.keys(this.appLoadedService.WebLabSheets).length === 0
        && this.appLoadedService.WebLabSheets.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebMikeScenarios(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebMikeScenarios === undefined
      || (Object.keys(this.appLoadedService.WebMikeScenarios).length === 0
        && this.appLoadedService.WebMikeScenarios.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebMunicipality(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebMunicipality === undefined
      || (Object.keys(this.appLoadedService.WebMunicipality).length === 0
        && this.appLoadedService.WebMunicipality.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebMWQMRuns(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebMWQMRuns === undefined
      || (Object.keys(this.appLoadedService.WebMWQMRuns).length === 0
        && this.appLoadedService.WebMWQMRuns.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebMWQMSamples1980_2020(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebMWQMSamples1980_2020 === undefined
      || (Object.keys(this.appLoadedService.WebMWQMSamples1980_2020).length === 0
        && this.appLoadedService.WebMWQMSamples1980_2020.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue
  }

  DataLoadedWebMWQMSamples2021_2060(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebMWQMSamples2021_2060 === undefined
      || (Object.keys(this.appLoadedService.WebMWQMSamples2021_2060).length === 0
        && this.appLoadedService.WebMWQMSamples2021_2060.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue
  }

  DataLoadedWebMWQMSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebMWQMSites === undefined
      || (Object.keys(this.appLoadedService.WebMWQMSites).length === 0
        && this.appLoadedService.WebMWQMSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebPolSourceSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebPolSourceSites === undefined
      || (Object.keys(this.appLoadedService.WebPolSourceSites).length === 0
        && this.appLoadedService.WebPolSourceSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }


  DataLoadedWebProvince(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebProvince === undefined
      || (Object.keys(this.appLoadedService.WebProvince).length === 0
        && this.appLoadedService.WebProvince.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebRoot(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebRoot === undefined
      || (Object.keys(this.appLoadedService.WebRoot).length === 0
        && this.appLoadedService.WebRoot.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebSector(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebSector === undefined
      || (Object.keys(this.appLoadedService.WebSector).length === 0
        && this.appLoadedService.WebSector.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebSubsector(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebSubsector === undefined
      || (Object.keys(this.appLoadedService.WebSubsector).length === 0
        && this.appLoadedService.WebSubsector.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebTideSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.WebTideSites === undefined
      || (Object.keys(this.appLoadedService.WebTideSites).length === 0
        && this.appLoadedService.WebTideSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }
}
