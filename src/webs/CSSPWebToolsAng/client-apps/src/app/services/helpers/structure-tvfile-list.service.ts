import { Injectable } from '@angular/core';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { PredicateAscByService } from 'src/app/services/helpers/predicate-asc-by.service';
import { FilePurposeEnum_GetOrderedText } from 'src/app/enums/generated/FilePurposeEnum';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { AppLanguageService } from '../app-language.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppStateService } from '../app-state.service';
import { FilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { DateFormatService } from './date-format.service';
import { PredicateDescByService } from './predicate-desc-by.service';
import { TVFileID_Text_Sort } from 'src/app/models/generated/web/TVFileID_Text_Sort.model';

@Injectable({
  providedIn: 'root'
})
export class StructureTVFileListService {
  constructor(private appLanguageService: AppLanguageService,
    private appStateService: AppStateService,
    private dateFormateService: DateFormatService,
    private predicateAscByService: PredicateAscByService,
    private predicateDescByService: PredicateDescByService) {
  }

  StructureTVFileList(tvTypeEnum: TVTypeEnum, TVFileModelList: TVFileModel[]): TVFileModel[][] {
    if (!TVFileModelList) return [[]];

    let tvFileModelListList: TVFileModel[][] = [[]];
    let arrFile2: TVFileID_Text_Sort[] = [];
    let sortable: TVFileID_Text_Sort[] = [];
    let enumIDAndTextList: EnumIDAndText[] = FilePurposeEnum_GetOrderedText(this.appLanguageService);
    let Asc: boolean = true;

    for (let i = 0; i < enumIDAndTextList?.length; i++) {
      let tvFileModelList: TVFileModel[] = [];
      let tvFileModelSortedList: TVFileModel[] = [];
      for (let j = 0; j < TVFileModelList?.length; j++) {
        if (enumIDAndTextList[i].EnumID == TVFileModelList[j].TVFile.FilePurpose) {
          tvFileModelList.push(TVFileModelList[j]);
        }
      }
      if (tvFileModelList?.length > 0) {

        for (let k = 0; k < tvFileModelList?.length; k++) {

          let TextToSort: string = '';
          let FilesSortProp: FilesSortPropEnum = FilesSortPropEnum.FileName;
          switch (tvTypeEnum) {
            case TVTypeEnum.Area:
              {
                FilesSortProp = this.appStateService.UserPreference.AreaFilesSortByProp;
              }
              break;
            case TVTypeEnum.Country:
              {
                FilesSortProp = this.appStateService.UserPreference.CountryFilesSortByProp;
              }
              break;
            case TVTypeEnum.Municipality:
              {
                FilesSortProp = this.appStateService.UserPreference.MunicipalityFilesSortByProp;
              }
              break;
            case TVTypeEnum.Province:
              {
                FilesSortProp = this.appStateService.UserPreference.ProvinceFilesSortByProp;
              }
              break;
            case TVTypeEnum.Root:
              {
                FilesSortProp = this.appStateService.UserPreference.RootFilesSortByProp;
              }
              break;
            case TVTypeEnum.Sector:
              {
                FilesSortProp = this.appStateService.UserPreference.SectorFilesSortByProp;
              }
            case TVTypeEnum.Subsector:
              {
                FilesSortProp = this.appStateService.UserPreference.SubsectorFilesSortByProp;
              }
            default:
              break;
          }

          switch (FilesSortProp) {
            case FilesSortPropEnum.FileName:
              {
                TextToSort = tvFileModelList[k].TVFile.ServerFileName.toLowerCase();
              }
              break;
            case FilesSortPropEnum.FileType:
              {
                TextToSort = `${tvFileModelList[k].TVFile.ServerFileName.substring(tvFileModelList[k].TVFile.ServerFileName.indexOf('.')).toLowerCase()}_${tvFileModelList[k].TVFile.ServerFileName.toLocaleLowerCase()}`;
              }
              break;
            case FilesSortPropEnum.FileSize:
              {
                TextToSort = `${this.pad(tvFileModelList[k].TVFile.FileSize_kb, 20).toString().toLowerCase()}_${tvFileModelList[k].TVFile.ServerFileName.toLocaleLowerCase()}`;
              }
              break;
            case FilesSortPropEnum.FileDate:
              {
                Asc = false;
                TextToSort = `${this.dateFormateService.GetTVFileCreateDateTime_LocalDigit(tvFileModelList[k].TVFile).toLowerCase()}_${tvFileModelList[k].TVFile.ServerFileName.toLocaleLowerCase()}`;
              }
              break;
            default:
              break;
          }

          sortable.push(<TVFileID_Text_Sort>{
            TVFileID: tvFileModelList[k].TVFile.TVFileID,
            TextToSort: TextToSort,
          });
        }

        if (Asc)
        {
          arrFile2 = sortable.sort(this.predicateAscByService.PredicateAscBy('TextToSort'));
        }
        else{
          arrFile2 = sortable.sort(this.predicateDescByService.PredicateDescBy('TextToSort'));
        }

        for (let k = 0; k < sortable?.length; k++) {
          for (let l = 0; l < tvFileModelList?.length; l++) {
            if (arrFile2[k].TVFileID == tvFileModelList[l].TVFile.TVFileID) {
              tvFileModelSortedList.push(tvFileModelList[l]);
              break;
            }
          }
        }

        tvFileModelListList.push(tvFileModelSortedList);
      }
    }

    return tvFileModelListList;
  }

  pad(n: number, width: number, z?: string) {
    z = z || '0';
    let nn = n + '';
    return nn?.length >= width ? nn : new Array(width - nn?.length + 1).join(z) + nn;
  }
}