import { Injectable } from '@angular/core';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { PredicateAscByService } from 'src/app/services/helpers/predicate-asc-by.service';
import { FilePurposeEnum_GetOrderedText } from 'src/app/enums/generated/FilePurposeEnum';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { AppLanguageService } from '../app/app-language.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppStateService } from '../app/app-state.service';
import { FilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { DateFormatService } from '../helpers/date-format.service';
import { PredicateDescByService } from '../helpers/predicate-desc-by.service';
import { TVFileID_Text_Sort } from 'src/app/models/generated/web/TVFileID_Text_Sort.model';
import { TVFileModelByPurpose } from 'src/app/models/generated/web/TVFileModelByPurpose.model';
import { AppLoadedService } from '../app/app-loaded.service';
import { FileSortByPropService } from '.';
import { AppTextService } from '../helpers/app-text.service';

@Injectable({
  providedIn: 'root'
})
export class TVFileModelByPurposeService {
  constructor(private appLanguageService: AppLanguageService,
    private appLoadedService: AppLoadedService,
    private appStateService: AppStateService,
    private dateFormateService: DateFormatService,
    private predicateAscByService: PredicateAscByService,
    private predicateDescByService: PredicateDescByService,
    public fileSortByPropService: FileSortByPropService,
    public appTextService: AppTextService) {
  }

  GetSortedTVFileModelByPurposeList(tvType: TVTypeEnum, preFilledTVFileModelList: TVFileModel[] = []): TVFileModelByPurpose[] {
    let tvFileModelByPurposeList: TVFileModelByPurpose[] = [];
    let arrFile2: TVFileID_Text_Sort[] = [];
    let sortable: TVFileID_Text_Sort[] = [];
    let enumIDAndTextList: EnumIDAndText[] = FilePurposeEnum_GetOrderedText(this.appLanguageService);
    let Asc: boolean = true;

    let TVFileModelList: TVFileModel[] = [];

    if (preFilledTVFileModelList.length > 0) {
      for (let i = 0, count = preFilledTVFileModelList.length; i < count; i++) {
        TVFileModelList.push(preFilledTVFileModelList[i]);
      }
    }

    if (TVFileModelList.length == 0) {
      TVFileModelList = this.GetTVFileModelList(tvType);
    }

    for (let i = 0, count = enumIDAndTextList?.length; i < count; i++) {
      let tvFileModelList: TVFileModel[] = [];
      let tvFileModelSortedList: TVFileModel[] = [];
      for (let j = 0; j < TVFileModelList?.length; j++) {
        if (enumIDAndTextList[i].EnumID == TVFileModelList[j].TVFile?.FilePurpose) {
          tvFileModelList.push(TVFileModelList[j]);
        }
      }
      if (tvFileModelList?.length > 0) {

        for (let k = 0; k < tvFileModelList?.length; k++) {

          let TextToSort: string = '';
          let FilesSortProp: FilesSortPropEnum = FilesSortPropEnum.FileName;

          FilesSortProp = this.fileSortByPropService.GetFileSortByProp(tvType);

          if (FilesSortProp == FilesSortPropEnum.FileDate) {
            Asc = false;
          }

          TextToSort = this.GetTextToSort(tvFileModelList[k], FilesSortProp, Asc);

          sortable.push(<TVFileID_Text_Sort>{
            TVFileID: tvFileModelList[k].TVFile?.TVFileID,
            TextToSort: TextToSort,
          });
        }

        if (Asc) {
          arrFile2 = sortable.sort(this.predicateAscByService.PredicateAscBy('TextToSort'));
        }
        else {
          arrFile2 = sortable.sort(this.predicateDescByService.PredicateDescBy('TextToSort'));
        }

        for (let k = 0; k < sortable?.length; k++) {
          for (let l = 0; l < tvFileModelList?.length; l++) {
            if (arrFile2[k].TVFileID == tvFileModelList[l].TVFile?.TVFileID) {
              tvFileModelSortedList.push(tvFileModelList[l]);
              break;
            }
          }
        }

        let tvFileModelByPurpose: TVFileModelByPurpose = new TVFileModelByPurpose();
        tvFileModelByPurpose.FilePurpose = tvFileModelSortedList[0].TVFile?.FilePurpose;
        tvFileModelByPurpose.TVFileModelList = tvFileModelSortedList;

        tvFileModelByPurposeList.push(tvFileModelByPurpose);
      }
    }

    return tvFileModelByPurposeList;
  }

  private GetTextToSort(tvFileModel: TVFileModel, FilesSortProp: FilesSortPropEnum, Asc: boolean): string {
    switch (FilesSortProp) {
      case FilesSortPropEnum.FileName:
        {
          return tvFileModel.TVFile?.ServerFileName.toLowerCase();
        }
        break;
      case FilesSortPropEnum.FileType:
        {
          return `${tvFileModel.TVFile?.ServerFileName.substring(tvFileModel.TVFile?.ServerFileName.indexOf('.')).toLowerCase()}_${tvFileModel.TVFile?.ServerFileName.toLocaleLowerCase()}`;
        }
        break;
      case FilesSortPropEnum.FileSize:
        {
          return `${this.appTextService.pad(tvFileModel.TVFile?.FileSize_kb, 20).toString().toLowerCase()}_${tvFileModel.TVFile?.ServerFileName.toLocaleLowerCase()}`;
        }
        break;
      case FilesSortPropEnum.FileDate:
        {
          Asc = false;
          return `${this.dateFormateService.GetTVFileCreateDateTime_LocalDigit(tvFileModel.TVFile).toLowerCase()}_${tvFileModel.TVFile?.ServerFileName.toLocaleLowerCase()}`;
        }
        break;
      default:
        break;
    }
  }

  private GetTVFileModelList(tvType: TVTypeEnum): TVFileModel[] {
    switch (tvType) {
      case TVTypeEnum.Area:
        {
          return this.appLoadedService.WebArea?.TVFileModelList;
        }
        break;
      case TVTypeEnum.Country:
        {
          return this.appLoadedService.WebCountry?.TVFileModelList;
        }
        break;
      case TVTypeEnum.Municipality:
        {
          return this.appLoadedService.WebMunicipality?.TVFileModelList;
        }
        break;
      case TVTypeEnum.Province:
        {
          return this.appLoadedService.WebProvince?.TVFileModelList;
        }
        break;
      case TVTypeEnum.Root:
        {
          return this.appLoadedService.WebRoot?.TVFileModelList;
        }
        break;
      case TVTypeEnum.Sector:
        {
          return this.appLoadedService.WebSector?.TVFileModelList;
        }
      case TVTypeEnum.Subsector:
        {
          return this.appLoadedService.WebSubsector?.TVFileModelList;
        }
      default:
        {
          return [];
        }
    }
  }
 
}