import { Input } from '@angular/core';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FilePurposeEnum_GetIDText } from 'src/app/enums/generated/FilePurposeEnum';
import { FilesSortPropEnum, GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { MikeScenarioModel } from 'src/app/models/generated/web/MikeScenarioModel.model';
import { TVFileModelByPurpose } from 'src/app/models/generated/web/TVFileModelByPurpose.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileIconService, FileSortByPropService, ShowTVFileService, TVFileModelByPurposeService } from 'src/app/services/file';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-mike-scenario-item-view-files',
  templateUrl: './mike-scenario-item-view-files.component.html',
  styleUrls: ['./mike-scenario-item-view-files.component.css']
})
export class MikeScenarioItemViewFilesComponent implements OnInit, OnDestroy {
  @Input() MikeScenarioModel: MikeScenarioModel;

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
    this.SetFileSortByProp(this.fileSortByPropService.GetFileSortByProp(TVTypeEnum.Infrastructure));
  }

  ngOnDestroy(): void {
  }

  SetFileSortByProp(filesSortByProp: FilesSortPropEnum)
  {
    this.fileSortByPropService.SetFileSortByProp(TVTypeEnum.Infrastructure, filesSortByProp);
    this.FilesSortByProp = filesSortByProp;
    this.TVFileModelByPurposeList = this.tvFileModelByPurposeService.GetSortedTVFileModelByPurposeList(TVTypeEnum.Infrastructure, this.MikeScenarioModel.TVFileModelList);
  }

  GetFilePurposeEnum_GetIDText(filePurposeEnum: number): string {
    return FilePurposeEnum_GetIDText(filePurposeEnum, this.appLanguageService);
  }
}
