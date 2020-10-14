import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { TVTypeEnum, TVTypeEnum_GetIDText } from './enums/generated/TVTypeEnum';
import { TVItem } from './models/generated/TVItem.model';
import { TVItemModel } from './models/generated/TVItemModel.model';
import { LanguageEnum } from './enums/generated/LanguageEnum';
import { catchError, map } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Preference } from './models/generated/Preference.model';
import { AppVar } from './app.model';
import { WebContact } from './models/generated/WebContact.model';
import { Contact } from './models/generated/Contact.model';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  AppVar$: BehaviorSubject<AppVar> = new BehaviorSubject<AppVar>(<AppVar>{});

  constructor(private httpClient: HttpClient) {
    //let url = 'https://localhost:4447/api/';
    let url = 'https://localhost:44346/api/';

    if (true) {
      this.UpdateAppVar(<AppVar>{
        Language: $localize.locale == "fr-CA" ? LanguageEnum.fr : LanguageEnum.en,
        BaseApiUrl: url,
        LoggedInContact: null,

        DetailVisible: false,
        EditVisible: false,
        FileVisible: false,
        InactVisible: false,
        MapVisible: false,
        MenuVisible: false,

        Size30: false,
        Size40: false,
        Size50: true,
        Size60: false,
        Size70: false,
        MapSizeClass: 'mapSize50',

        HybridVisible: true,
        SatelliteVisible: false,
        RoadmapVisible: false,
        TerrainVisible: false,
        mapTypeId: google.maps.MapTypeId.HYBRID,

        TVTypeRoot: TVTypeEnum.Root,
        TVTypeCountry: TVTypeEnum.Country,
        TVTypeProvince: TVTypeEnum.Province,
        TVTypeArea: TVTypeEnum.Area,
        TVTypeSector: TVTypeEnum.Sector,
        TVTypeSubsector: TVTypeEnum.Subsector,
        TVTypeMWQMSite: TVTypeEnum.MWQMSite,
        TVTypeMWQMRun: TVTypeEnum.MWQMRun,
        TVTypePolSourcSite: TVTypeEnum.PolSourceSite,
        TVTypeMikeScenario: TVTypeEnum.MikeScenario,
        TVTypeMunicipality: TVTypeEnum.Municipality,
        TVTypeMWQMSiteSample: TVTypeEnum.MWQMSiteSample,

        BreadCrumbVar: null,
        WebContact: null,
        AdminContactList: null,
      });

      //localStorage.setItem("AppVar", 't');
    }
  }

  GetLoggedInContact() {
    if (!this.AppVar$.getValue().LoggedInContact) {
      this.UpdateAppVar(<AppVar>{ Working: true });
      return this.httpClient.get<Contact>('/api/LoggedInContact').pipe(
        map((x: any) => {
          this.UpdateAppVar(<AppVar>{ LoggedInContact: x, Working: false });
          console.debug(x);
        }),
        catchError(e => of(e).pipe(map(e => {
          this.UpdateAppVar(<AppVar>{ Working: false, Error: <HttpErrorResponse>e });
          console.debug(e);
        })))
      );
    }
  }

  GetWebContact() {
    this.UpdateAppVar(<AppVar>{ Working: true });
    return this.httpClient.get<WebContact>(`/api/Read/WebContact/0/1`).pipe(
      map((x: WebContact) => {
        let adminList: Contact[] = x.ContactList.filter(contact => contact.IsAdmin == true);
        this.UpdateAppVar(<AppVar>{ WebContact: x, AdminContactList: adminList, Working: false });
        localStorage.setItem('GetWebContact', 't');
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppVar(<AppVar>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  GetPreference() {
    this.UpdateAppVar(<AppVar>{ Working: true });
    return this.httpClient.get<Preference[]>(`/api/Preference`).pipe(
      map((x: any) => {
        this.UpdateAppVar(<AppVar>{ Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppVar(<AppVar>{ Working: false });
        console.debug(e);
      })))
    );
  }

  SetProperties(property: string) {
    property == 'detail' ? this.UpdateAppVar(<AppVar>{ DetailVisible: !this.AppVar$.getValue().DetailVisible }) : null;
    property == 'edit' ? this.UpdateAppVar(<AppVar>{ EditVisible: !this.AppVar$.getValue().EditVisible }) : null;
    property == 'file' ? this.UpdateAppVar(<AppVar>{ FileVisible: !this.AppVar$.getValue().FileVisible }) : null;
    property == 'inact' ? this.UpdateAppVar(<AppVar>{ InactVisible: !this.AppVar$.getValue().InactVisible }) : null;
    property == 'map' ? this.UpdateAppVar(<AppVar>{ MapVisible: !this.AppVar$.getValue().MapVisible }) : null;
    property == 'menu' ? this.UpdateAppVar(<AppVar>{ MenuVisible: !this.AppVar$.getValue().MenuVisible }) : null;
    property == 'size30' ? this.UpdateAppVar(<AppVar>{ Size30: true, Size40: false, Size50: false, Size60: false, Size70: false, MapSizeClass: 'mapSize30' }) : null;
    property == 'size40' ? this.UpdateAppVar(<AppVar>{ Size30: false, Size40: true, Size50: false, Size60: false, Size70: false, MapSizeClass: 'mapSize40' }) : null;
    property == 'size60' ? this.UpdateAppVar(<AppVar>{ Size30: false, Size40: false, Size50: false, Size60: true, Size70: false, MapSizeClass: 'mapSize60' }) : null;
    property == 'size70' ? this.UpdateAppVar(<AppVar>{ Size30: false, Size40: false, Size50: false, Size60: false, Size70: true, MapSizeClass: 'mapSize70' }) : null;
    property == 'size50' ? this.UpdateAppVar(<AppVar>{ Size30: false, Size40: false, Size50: true, Size60: false, Size70: false, MapSizeClass: 'mapSize50' }) : null;
    property == 'satellite' ? this.UpdateAppVar(<AppVar>{ HybridVisible: false, SatelliteVisible: true, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.SATELLITE }) : null;
    property == 'terrain' ? this.UpdateAppVar(<AppVar>{ HybridVisible: false, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: true, mapTypeId: google.maps.MapTypeId.TERRAIN }) : null;
    property == 'roadmap' ? this.UpdateAppVar(<AppVar>{ HybridVisible: false, SatelliteVisible: false, RoadmapVisible: true, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.ROADMAP }) : null;
    property == 'hybrid' ? this.UpdateAppVar(<AppVar>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.HYBRID }) : null;
  }

  UpdateAppVar(appVar: AppVar) {
    this.AppVar$.next(<AppVar>{ ...this.AppVar$.getValue(), ...appVar });
  }

  GetTVType(tvType: TVTypeEnum) {
    return tvType;
  }

  GetLink(tvItemModel: TVItemModel) {
    return $localize.locale + '/' + this.GetUrl(tvItemModel.TVItem);
  }

  GetTypeText(tvType: number) {
    return TVTypeEnum_GetIDText(tvType);
  }

  GetUrl(tvItem: TVItem): string {
    switch (<TVTypeEnum>tvItem.TVType) {
      case TVTypeEnum.Address:
        {
          return `address/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Area:
        {
          return `area/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.BoxModel:
        {
          return `boxmodel/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.ClimateSite:
        {
          return `climatesite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Contact:
        {
          return `contact/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Country:
        {
          return `country/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Email:
        {
          return `email/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.File:
        {
          return `file/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.HydrometricSite:
        {
          return `hydrometricsite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Infrastructure:
        {
          return `infrastructure/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.LabSheetInfo:
        {
          return `labsheet/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.MWQMRun:
        {
          return `mwqmrun/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.MWQMSite:
        {
          return `mwqmsite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.MikeScenario:
        {
          return `mikescenario/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.MikeSource:
        {
          return `mikesource/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Municipality:
        {
          return `municipality/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.PolSourceSite:
        {
          return `polsourcesite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Province:
        {
          return `province/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Root:
        {
          return `root/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.SamplingPlan:
        {
          return `samplingplan/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Sector:
        {
          return `sector/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Subsector:
        {
          return `subsector/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Tel:
        {
          return `tel/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.TideSite:
        {
          return `tidesite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.VisualPlumesScenario:
        {
          return `visualplumesscenario/${tvItem.TVItemID}`;
        }
      default:
        {
          return ``;
        }
    }
  }

  GetTypeIcon(tvType: number) {
    switch (<TVTypeEnum>tvType) {
      case TVTypeEnum.Address:
        {
          return 'add_alert';
        }
      case TVTypeEnum.Area:
        {
          return 'all_out';
        }
      case TVTypeEnum.BoxModel:
        {
          return 'inbox';
        }
      case TVTypeEnum.ClimateSite:
        {
          return 'book';
        }
      case TVTypeEnum.Contact:
        {
          return 'article';
        }
      case TVTypeEnum.Country:
        {
          return 'build';
        }
      case TVTypeEnum.Email:
        {
          return 'email';
        }
      case TVTypeEnum.File:
        {
          return 'attach_file';
        }
      case TVTypeEnum.HydrometricSite:
        {
          return 'soap';
        }
      case TVTypeEnum.Infrastructure:
        {
          return 'opacity';
        }
      case TVTypeEnum.LabSheetInfo:
        {
          return 'label';
        }
      case TVTypeEnum.MWQMRun:
        {
          return 'directions_run';
        }
      case TVTypeEnum.MWQMSite:
        {
          return 'attach_money';
        }
      case TVTypeEnum.MikeScenario:
        {
          return 'agriculture';
        }
      case TVTypeEnum.MikeSource:
        {
          return 'source';
        }
      case TVTypeEnum.Municipality:
        {
          return 'location_city';
        }
      case TVTypeEnum.PolSourceSite:
        {
          return 'poll';
        }
      case TVTypeEnum.Province:
        {
          return 'public';
        }
      case TVTypeEnum.Root:
        {
          return 'room';
        }
      case TVTypeEnum.SamplingPlan:
        {
          return 'update';
        }
      case TVTypeEnum.Sector:
        {
          return 'security';
        }
      case TVTypeEnum.Subsector:
        {
          return 'directions_subway';
        }
      case TVTypeEnum.Tel:
        {
          return 'settings_cell';
        }
      case TVTypeEnum.TideSite:
        {
          return 'tour';
        }
      case TVTypeEnum.VisualPlumesScenario:
        {
          return 'vpn_key';
        }
      default:
        {
          return 'home';
        }
    }
  }

}
