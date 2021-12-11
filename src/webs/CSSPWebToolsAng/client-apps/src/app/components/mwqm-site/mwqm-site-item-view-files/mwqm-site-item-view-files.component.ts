import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FilePurposeEnum_GetIDText } from 'src/app/enums/generated/FilePurposeEnum';
import { FilesSortPropEnum, GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { MWQMSiteModel } from 'src/app/models/generated/models/MWQMSiteModel.model';
import { TVFileModelByPurpose } from 'src/app/models/generated/models/TVFileModelByPurpose.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileIconService, FileSortByPropService, ShowTVFileService, TVFileModelByPurposeService } from 'src/app/services/file';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-mwqm-site-item-view-files',
  templateUrl: './mwqm-site-item-view-files.component.html',
  styleUrls: ['./mwqm-site-item-view-files.component.css']
})
export class MWQMSiteItemViewFilesComponent implements OnInit, OnDestroy {
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
    this.SetFileSortByProp(this.fileSortByPropService.GetFileSortByProp(TVTypeEnum.MWQMSite));
  }

  ngOnDestroy(): void {
  }

  SetFileSortByProp(filesSortByProp: FilesSortPropEnum) {
    this.fileSortByPropService.SetFileSortByProp(TVTypeEnum.MWQMSite, filesSortByProp);
    this.FilesSortByProp = filesSortByProp;
    let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.TVItemID == this.TVItemModel.TVItem.TVItemID);
    if (MWQMSiteModelList != undefined && MWQMSiteModelList.length > 0) {
      this.TVFileModelByPurposeList = this.tvFileModelByPurposeService.GetSortedTVFileModelByPurposeList(TVTypeEnum.Infrastructure, MWQMSiteModelList[0].TVFileModelList);
    }
  }

  GetFilePurposeEnum_GetIDText(filePurposeEnum: number): string {
    return FilePurposeEnum_GetIDText(filePurposeEnum, this.appLanguageService);
  }
}
