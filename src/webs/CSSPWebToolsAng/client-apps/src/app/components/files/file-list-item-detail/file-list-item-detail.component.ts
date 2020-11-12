import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetFilePurposeEnum } from 'src/app/enums/generated/FilePurposeEnum';
import { GetFileTypeEnum } from 'src/app/enums/generated/FileTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';

@Component({
  selector: 'app-file-list-item-detail',
  templateUrl: './file-list-item-detail.component.html',
  styleUrls: ['./file-list-item-detail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListItemDetailComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel = null;
  @Input() AppState: AppState;
  fileTypeEnum = GetFileTypeEnum();
  filePurposeEnum = GetFilePurposeEnum();
  
  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }


}
