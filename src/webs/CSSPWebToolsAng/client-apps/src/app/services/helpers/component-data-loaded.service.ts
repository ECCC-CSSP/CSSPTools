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

  DataLoadedCountry(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebCountry).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebCountry.constructor === Object);
  }

  DataLoadedProvince(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebProvince).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebProvince.constructor === Object
      && Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities.constructor === Object);
  }

  DataLoadedRoot(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebRoot).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebRoot.constructor === Object);
  }

  DataLoadedSector(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSector).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebSector.constructor === Object);
  }

  DataLoadedSubsector(): boolean {
    return !(Object.keys(this.appLoadedService.AppLoaded$.getValue()?.WebSubsector).length === 0
      && this.appLoadedService.AppLoaded$.getValue()?.WebSubsector.constructor === Object)
      && !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1980.constructor === Object)
      && !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample1990.constructor === Object)
      && !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2000.constructor === Object)
      && !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2010.constructor === Object)
      && !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2020.constructor === Object)
      && !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2030.constructor === Object)
      && !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2040.constructor === Object)
      && !(Object.keys(this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050).length === 0
        && this.appLoadedService.AppLoaded$.getValue().WebMWQMSample2050.constructor === Object)
  }

}
