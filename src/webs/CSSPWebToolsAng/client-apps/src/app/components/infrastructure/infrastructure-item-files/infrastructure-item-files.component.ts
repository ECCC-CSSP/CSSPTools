import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FilePurposeEnum_GetIDText } from 'src/app/enums/generated/FilePurposeEnum';
import { FilesSortPropEnum, GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { InfrastructureModelPath } from 'src/app/models/generated/web/InfrastructureModelPath.model';
import { TVFileModelByPurpose } from 'src/app/models/generated/web/TVFileModelByPurpose.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileIconService, FileSortByPropService, ShowTVFileService, TVFileModelByPurposeService } from 'src/app/services/file';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-infrastructure-item-files',
  templateUrl: './infrastructure-item-files.component.html',
  styleUrls: ['./infrastructure-item-files.component.css']
})
export class InfrastructureItemFilesComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;
  

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
    this.TVFileModelByPurposeList = this.tvFileModelByPurposeService.GetSortedTVFileModelByPurposeList(TVTypeEnum.Infrastructure, this.InfrastructureModelPath.InfrastructureModel.TVFileModelList);
  }

  GetFilePurposeEnum_GetIDText(filePurposeEnum: number): string {
    return FilePurposeEnum_GetIDText(filePurposeEnum, this.appLanguageService);
  }
}
