import { Injectable } from '@angular/core';
import { AppLoadedService } from '../app-loaded.service';

@Injectable({
  providedIn: 'root'
})
export class ComponentDataLoadedService {

  constructor(private appLoadedService: AppLoadedService) {
  }

  DataLoadedWebAllAddresses(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllAddresses === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllAddresses).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllAddresses.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllContacts(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllContacts === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllContacts).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllContacts.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllCountries(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllEmails(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllEmails === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllEmails).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllEmails.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllHelpDocs(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllMunicipalities(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllMWQMLookupMPNs(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllMWQMLookupMPNs === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllMWQMLookupMPNs).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllMWQMLookupMPNs.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebPolSourceGroupings(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceGroupings === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceGroupings).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceGroupings.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebPolSourceSiteEffectTerms(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceSiteEffectTerms === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceSiteEffectTerms).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceSiteEffectTerms.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllProvinces(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllReportTypes(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllReportTypes === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllReportTypes).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllReportTypes.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllTels(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllTels === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllTels).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllTels.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebAllTideLocations(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllTideLocations === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllTideLocations).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllTideLocations.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebArea(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebArea === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebArea).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebArea.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebClimateSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebClimateSites === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebClimateSites).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebClimateSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebCountry(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebCountry === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebCountry).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebCountry.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebDrogueRuns(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebDrogueRuns === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebDrogueRuns).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebDrogueRuns.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebHelpDocs(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebHydrometricSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSites === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSites).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebHydrometricSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebLabSheets(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebLabSheets === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebLabSheets).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebLabSheets.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebMikeScenarios(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenarios === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenarios).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMikeScenarios.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebMunicipality(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMunicipality === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMunicipality).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMunicipality.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebMWQMRuns(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRuns === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRuns).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRuns.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebMWQMSamples1980_2020(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSamples1980_2020 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSamples1980_2020).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSamples1980_2020.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue
  }

  DataLoadedWebMWQMSamples2021_2060(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSamples2021_2060 === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSamples2021_2060).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSamples2021_2060.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue
  }

  DataLoadedWebMWQMSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSites === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSites).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebPolSourceSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSites === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSites).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebPolSourceSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }


  DataLoadedWebProvince(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebProvince === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebProvince).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebProvince.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebRoot(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebRoot === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebRoot).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebRoot.constructor === Object)) {
      AllTrue = false;
    }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllContacts === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllContacts).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllContacts.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllCountries.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllProvinces.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllMunicipalities.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllHelpDocs.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllMWQMLookupMPNs === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllMWQMLookupMPNs).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllMWQMLookupMPNs.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceGroupings === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceGroupings).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceGroupings.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceSiteEffectTerms === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceSiteEffectTerms).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllPolSourceSiteEffectTerms.constructor === Object)) {
    //   AllTrue == false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllReportTypes === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllReportTypes).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllReportTypes.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue()?.WebAllTideLocations === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebAllTideLocations).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue()?.WebAllTideLocations.constructor === Object)) {
    //   AllTrue == false;
    // }

    return AllTrue;
  }

  DataLoadedWebSector(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebSector === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSector).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebSector.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }

  DataLoadedWebSubsector(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebSubsector === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSubsector).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebSubsector.constructor === Object)) {
      AllTrue = false;
    }
    // if (this.appLoadedService.AppLoaded$.getValue().WebMWQMSite === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSite).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue().WebMWQMSite.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue().WebMWQMRun === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMRun).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue().WebMWQMRun.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue().WebPolSourceSite === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebPolSourceSite).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue().WebPolSourceSite.constructor === Object)) {
    //   AllTrue = false;
    // }
    // if (this.appLoadedService.AppLoaded$.getValue().WebDrogueRun === undefined
    //   || (Object.keys(this.appLoadedService.AppLoaded$.getValue().WebDrogueRun).length === 0
    //     && this.appLoadedService.AppLoaded$.getValue().WebDrogueRun.constructor === Object)) {
    //   AllTrue == false;
    // }

    return AllTrue;
  }

  DataLoadedWebTideSites(): boolean {
    let AllTrue: boolean = true;
    if (this.appLoadedService.AppLoaded$.getValue()?.WebTideSites === undefined
      || (Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebTideSites).length === 0
        && this.appLoadedService.AppLoaded$.getValue()?.WebTideSites.constructor === Object)) {
      AllTrue = false;
    }

    return AllTrue;
  }
}
