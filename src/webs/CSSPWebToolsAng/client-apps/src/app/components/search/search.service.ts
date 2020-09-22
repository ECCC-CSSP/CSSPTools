import { Injectable } from '@angular/core';
import { SearchModel, SearchTextModel } from './search.models';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { LoadLocalesSearchText } from './search.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { TVItemLanguage } from 'src/app/models/generated/TVItemLanguage.model';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, switchMap } from 'rxjs/operators';
import { FormControl } from '@angular/forms';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { Router } from '@angular/router';
import { AppService } from 'src/app/services';
import { SearchResult } from 'src/app/models/searchresult';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  searchTextModel$: BehaviorSubject<SearchTextModel> = new BehaviorSubject<SearchTextModel>(<SearchTextModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesSearchText(this);
    this.UpdateSearchText(<SearchTextModel>{ Title: "Something for text" });
  }

  UpdateSearchText(searchTextModel: SearchTextModel) {
    this.searchTextModel$.next(<SearchTextModel>{ ...this.searchTextModel$.getValue(), ...searchTextModel });
  }

  GetSearch(myControl: FormControl) {
    return myControl.valueChanges.pipe(
      startWith(''),
      debounceTime(300),
      distinctUntilChanged(),
      switchMap(term => {
        term = ('' + term).trim();
        return term.length ? this.GetData(term) : [];
      }));
  }

  private GetData(val: string) {
    return this.httpClient.get(`/api/search/${val}/1`);
  }

  GetUrl(searchResult: SearchResult): string {
    switch (<TVTypeEnum>searchResult.TVItem.TVType) {
      case TVTypeEnum.Address:
        {
          return `address/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Area:
        {
          return `area/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.BoxModel:
        {
          return `boxmodel/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.ClimateSite:
        {
          return `climatesite/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Contact:
        {
          return `contact/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Country:
        {
          return `country/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Email:
        {
          return `email/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.File:
        {
          return `file/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.HydrometricSite:
        {
          return `hydrometricsite/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Infrastructure:
        {
          return `infrastructure/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.LabSheetInfo:
        {
          return `labsheet/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.MWQMRun:
        {
          return `mwqmrun/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.MWQMSite:
        {
          return `mwqmsite/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.MikeScenario:
        {
          return `mikescenario/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.MikeSource:
        {
          return `mikesource/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Municipality:
        {
          return `municipality/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.PolSourceSite:
        {
          return `polsourcesite/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Province:
        {
          return `province/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Root:
        {
          return `root/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.SamplingPlan:
        {
          return `samplingplan/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Sector:
        {
          return `sector/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Subsector:
        {
          return `subsector/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.Tel:
        {
          return `tel/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.TideSite:
        {
          return `tidesite/${ searchResult.TVItem.TVItemID }`;
        }
      case TVTypeEnum.VisualPlumesScenario:
        {
          return `visualplumesscenario/${ searchResult.TVItem.TVItemID }`;
        }
      default:
        {
          return ``;
        }
    }
  }
}
