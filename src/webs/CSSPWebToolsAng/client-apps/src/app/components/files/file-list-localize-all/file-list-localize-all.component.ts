import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModelByPurpose } from 'src/app/models/generated/web/TVFileModelByPurpose.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { FileLocalizeAllAzureFileService } from 'src/app/services/file';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-file-list-localize-all',
  templateUrl: './file-list-localize-all.component.html',
  styleUrls: ['./file-list-localize-all.component.css']
})
export class FileListLocalizeAllComponent implements OnInit, OnDestroy {
  @Input() TVType: TVTypeEnum;
  @Input() TVFileModelByPurposeList: TVFileModelByPurpose[];

  constructor(public appLanguageService: AppLanguageService,
    public appStateService: AppStateService,
    public fileLocalizeAllAzureFileService: FileLocalizeAllAzureFileService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  LocalizeAllFiles(tvFileModelByPurposeList: TVFileModelByPurpose[]) {
    let TVFileModelList: TVFileModel[] = [];
    for (let i = 0, countI = tvFileModelByPurposeList.length; i < countI; i++) {
      for (let j = 0, countJ = tvFileModelByPurposeList[i]?.TVFileModelList.length; j < countJ; j++) {
        TVFileModelList.push(tvFileModelByPurposeList[i]?.TVFileModelList[j]);
      }
    }

    this.fileLocalizeAllAzureFileService.AddTVFileModelList(TVFileModelList);
    this.fileLocalizeAllAzureFileService.LocalizeAllAzureFile(this.TVType);
  }
}
