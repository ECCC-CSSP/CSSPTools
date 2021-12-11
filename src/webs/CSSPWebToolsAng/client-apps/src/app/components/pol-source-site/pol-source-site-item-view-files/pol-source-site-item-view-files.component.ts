import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FilePurposeEnum_GetIDText } from 'src/app/enums/generated/FilePurposeEnum';
import { FilesSortPropEnum, GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { PolSourceSiteModel } from 'src/app/models/generated/models/PolSourceSiteModel.model';
import { TVFileModelByPurpose } from 'src/app/models/generated/models/TVFileModelByPurpose.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileIconService, FileSortByPropService, ShowTVFileService, TVFileModelByPurposeService } from 'src/app/services/file';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-pol-source-site-item-view-files',
  templateUrl: './pol-source-site-item-view-files.component.html',
  styleUrls: ['./pol-source-site-item-view-files.component.css']
})
export class PolSourceSiteItemViewFilesComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  
  languageEnum = GetLanguageEnum();
  filesSortByProp = GetFilesSortPropEnum();
  tvType = GetTVTypeEnum();

  TVFileModelByPurposeList: TVFileModelByPurpose[] = [];
  FilesSortByProp: FilesSortPropEnum;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public showTVFileService: ShowTVFileService,
    public fileIconService: FileIconService,
    public dateFormatService: DateFormatService,
    public tvFileModelByPurposeService: TVFileModelByPurposeService,
    public fileSortByPropService: FileSortByPropService) { }

    ngOnInit(): void {
      this.SetFileSortByProp(this.fileSortByPropService.GetFileSortByProp(TVTypeEnum.PolSourceSite));
    }
  
    ngOnDestroy(): void {
    }
  
    SetFileSortByProp(filesSortByProp: FilesSortPropEnum) {
      this.fileSortByPropService.SetFileSortByProp(TVTypeEnum.PolSourceSite, filesSortByProp);
      this.FilesSortByProp = filesSortByProp;
      let PolSourceSiteModelList: PolSourceSiteModel[] = this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList.filter(c => c.TVItemModel.TVItem.TVItemID == this.TVItemModel.TVItem.TVItemID);
      if (PolSourceSiteModelList != undefined && PolSourceSiteModelList.length > 0) {
        this.TVFileModelByPurposeList = this.tvFileModelByPurposeService.GetSortedTVFileModelByPurposeList(TVTypeEnum.Infrastructure, PolSourceSiteModelList[0].TVFileModelList);
      }
    }
  
    GetFilePurposeEnum_GetIDText(filePurposeEnum: number): string {
      return FilePurposeEnum_GetIDText(filePurposeEnum, this.appLanguageService);
    }
  }
  