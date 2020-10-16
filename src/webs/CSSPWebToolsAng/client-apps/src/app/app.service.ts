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
import { TopComponentEnum } from './enums/TopComponentEnum';
import { ShellSubComponentEnum } from './enums/ShellSubComponentEnum';
import { RootSubComponentEnum } from './enums/RootSubComponentEnum';
import { CountrySubComponentEnum } from './enums/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from './enums/ProvinceSubComponentEnum';
import { MapSizeEnum } from './enums/MapSizeEnum';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  AppVar$: BehaviorSubject<AppVar> = new BehaviorSubject<AppVar>(<AppVar>{});

  constructor(private httpClient: HttpClient) {
    //let url = 'https://localhost:4447/api/';
    let url = 'https://localhost:44346/api/';

    this.UpdateAppVar(<AppVar>{
      TopComponent: TopComponentEnum.Home,
      ShellSubComponent: ShellSubComponentEnum.Root,
      RootSubComponent: RootSubComponentEnum.Countries,
      CountrySubComponent: CountrySubComponentEnum.Provinces,
      ProvinceSubComponent: ProvinceSubComponentEnum.Areas,
      CurrentTVItemID: 0,
      Language: LanguageEnum.en,
      BaseApiUrl: url,
      LoggedInContact: null,

      DetailVisible: false,
      EditVisible: false,
      InactVisible: false,
      MapVisible: false,
      MenuVisible: false,

      MapSize: MapSizeEnum.Size50,

      BreadCrumbVar: null,
      WebContact: null,
      AdminContactList: null,
    });
  }

  GetLoggedInContact() {
    this.UpdateAppVar(<AppVar>{ Working: true });
    let url: string = `${this.AppVar$.getValue().BaseApiUrl}en-CA/LoggedInContact`;
    return this.httpClient.get<Contact>(url).pipe(
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

  GetWebContact() {
    this.UpdateAppVar(<AppVar>{ Working: true });
    let url: string = `${this.AppVar$.getValue().BaseApiUrl}en-CA/Read/WebContact/0/1`;
    return this.httpClient.get<WebContact>(url).pipe(
      map((x: WebContact) => {
        let adminList: Contact[] = x.ContactList.filter(contact => contact.IsAdmin == true);
        this.UpdateAppVar(<AppVar>{ WebContact: x, AdminContactList: adminList, Working: false });
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
    let url: string = `${this.AppVar$.getValue().BaseApiUrl}Preference`;
    return this.httpClient.get<Preference[]>(url).pipe(
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

  UpdateAppVar(appVar: AppVar) {
    this.AppVar$.next(<AppVar>{ ...this.AppVar$.getValue(), ...appVar });
  }

  GetTVType(tvType: TVTypeEnum) {
    return tvType;
  }

  SetSubPage(tvItemModel: TVItemModel) {
    this.UpdateAppVar(<AppVar>{ ShellSubComponent: this.GetSubPage(tvItemModel.TVItem), CurrentTVItemID: tvItemModel.TVItem.TVItemID });
  }

  GetSubPage(tvItem: TVItem): ShellSubComponentEnum {
    switch (<TVTypeEnum>tvItem.TVType) {
      // case TVTypeEnum.Address:
      //   {
      //     return `address`;
      //   }
      // case TVTypeEnum.Area:
      //   {
      //     return `area`;
      //   }
      // case TVTypeEnum.BoxModel:
      //   {
      //     return `boxmodel`;
      //   }
      // case TVTypeEnum.ClimateSite:
      //   {
      //     return `climatesite`;
      //   }
      // case TVTypeEnum.Contact:
      //   {
      //     return `contact`;
      //   }
      case TVTypeEnum.Country:
        {
          return ShellSubComponentEnum.Country;
        }
      // case TVTypeEnum.Email:
      //   {
      //     return `email`;
      //   }
      // case TVTypeEnum.File:
      //   {
      //     return `file`;
      //   }
      // case TVTypeEnum.HydrometricSite:
      //   {
      //     return `hydrometricsite`;
      //   }
      // case TVTypeEnum.Infrastructure:
      //   {
      //     return `infrastructure`;
      //   }
      // case TVTypeEnum.LabSheetInfo:
      //   {
      //     return `labsheet`;
      //   }
      // case TVTypeEnum.MWQMRun:
      //   {
      //     return `mwqmrun`;
      //   }
      // case TVTypeEnum.MWQMSite:
      //   {
      //     return `mwqmsite`;
      //   }
      // case TVTypeEnum.MikeScenario:
      //   {
      //     return `mikescenario`;
      //   }
      // case TVTypeEnum.MikeSource:
      //   {
      //     return `mikesource`;
      //   }
      // case TVTypeEnum.Municipality:
      //   {
      //     return `municipality`;
      //   }
      // case TVTypeEnum.PolSourceSite:
      //   {
      //     return `polsourcesite`;
      //   }
      case TVTypeEnum.Province:
        {
          return ShellSubComponentEnum.Province;
        }
      case TVTypeEnum.Root:
        {
          return ShellSubComponentEnum.Root;
        }
      // case TVTypeEnum.SamplingPlan:
      //   {
      //     return `samplingplan`;
      //   }
      case TVTypeEnum.Sector:
        {
          return ShellSubComponentEnum.Sector;
        }
      case TVTypeEnum.Subsector:
        {
          return ShellSubComponentEnum.Subsector;
        }
      // case TVTypeEnum.Tel:
      //   {
      //     return `tel`;
      //   }
      // case TVTypeEnum.TideSite:
      //   {
      //     return `tidesite`;
      //   }
      // case TVTypeEnum.VisualPlumesScenario:
      //   {
      //     return `visualplumesscenario`;
      //   }
      default:
        {
          return ShellSubComponentEnum.Root;
        }
    }
  }

  GetTypeText(tvType: number) {
    return TVTypeEnum_GetIDText(tvType, this);
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
