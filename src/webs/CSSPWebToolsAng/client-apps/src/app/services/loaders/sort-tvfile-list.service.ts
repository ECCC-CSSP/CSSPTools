import { Injectable } from '@angular/core';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { TVFileModel } from 'src/app/models/generated/TVFileModel.model';
import { PredicateAscByService } from './predicate-asc-by.service';
import { PredicateDescByService } from './predicate-desc-by.service';
import { TVFileID_ServerFileName_Sort } from 'src/app/models/TVFileID_ServerFileName_Sort.model';

@Injectable({
  providedIn: 'root'
})
export class SortTVFileListService {
  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private predicateAscByService: PredicateAscByService,
    private predicateDescByService: PredicateDescByService) {

  }

  SortTVFileList(arr: WebBase[], arrFile: TVFileModel[], breadCrumb: WebBase[]): TVFileModel[] {
    if (!arrFile || arrFile.length == 0) return arrFile;
    if (!breadCrumb || breadCrumb.length == 0) return arrFile;

    let TVType: TVTypeEnum = breadCrumb[breadCrumb.length - 1].TVItemModel.TVItem.TVType;
    let AscDesc: AscDescEnum = AscDescEnum.Ascending;

    switch (TVType) {
      case TVTypeEnum.Root:
        {
          AscDesc = this.appStateService.AppState$.getValue().RootFilesSortOrder;
        }
        break;
      case TVTypeEnum.Country:
        {
          AscDesc = this.appStateService.AppState$.getValue().CountryFilesSortOrder;
        }
        break;
      case TVTypeEnum.Province:
        {
          AscDesc = this.appStateService.AppState$.getValue().ProvinceFilesSortOrder;
        }
        break;
      case TVTypeEnum.Area:
        {
          AscDesc = this.appStateService.AppState$.getValue().AreaFilesSortOrder;
        }
        break;
      case TVTypeEnum.Sector:
        {
          AscDesc = this.appStateService.AppState$.getValue().SectorFilesSortOrder;
        }
        break;
      case TVTypeEnum.Subsector:
        {
          AscDesc = this.appStateService.AppState$.getValue().SubsectorFilesSortOrder;
        }
        break;
      default:
        {
          alert(`${TVTypeEnum[TVType]} - Not Implemented Yet. See app-loaded.service.ts -- SortFileList function`);
        }
        break;
    }

    let tvFileSorted: TVFileModel[] = [];
    let arrFile2: TVFileID_ServerFileName_Sort[] = [];
    let sortable: TVFileID_ServerFileName_Sort[] = [];

    for (let i = 0; i < arrFile.length; i++) {
      sortable.push(<TVFileID_ServerFileName_Sort>{
        TVFileID: arrFile[i].TVFile.TVFileID,
        ServerFileName: arrFile[i].TVFile.ServerFileName.toLowerCase(),
      });
    }

    if (AscDesc == AscDescEnum.Ascending) {
      arrFile2 = sortable.sort(this.predicateAscByService.PredicateAscBy('ServerFileName'));
    }
    else {
      arrFile2 = sortable.sort(this.predicateDescByService.PredicateDescBy('ServerFileName'));
    }

    for (let i = 0; i < sortable.length; i++) {
      for (let j = 0; j < arrFile.length; j++) {
        if (arrFile2[i].TVFileID == arrFile[j].TVFile.TVFileID) {
          tvFileSorted.push(arrFile[j]);
          break;
        }
      }
    }

    return tvFileSorted;
  }
}
