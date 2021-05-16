import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FilePurposeEnum_GetIDText } from 'src/app/enums/generated/FilePurposeEnum';
import { FilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.css']
})
export class FileListComponent implements OnInit, OnDestroy {
  @Input() TVFileModelListList: TVFileModel[][];
  @Input() FilesSortByProp: FilesSortPropEnum;

  constructor(public appLanguageService: AppLanguageService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  GetFilePurposeEnum_GetIDText(filePurposeEnum: number): string {
    return FilePurposeEnum_GetIDText(filePurposeEnum, this.appLanguageService);
  }
}
