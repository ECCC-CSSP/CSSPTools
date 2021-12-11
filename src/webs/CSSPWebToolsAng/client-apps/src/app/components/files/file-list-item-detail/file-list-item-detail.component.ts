import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetFilePurposeEnum } from 'src/app/enums/generated/FilePurposeEnum';
import { GetFileTypeEnum } from 'src/app/enums/generated/FileTypeEnum';

import { TVFileModel } from 'src/app/models/generated/models/TVFileModel.model';

@Component({
  selector: 'app-file-list-item-detail',
  templateUrl: './file-list-item-detail.component.html',
  styleUrls: ['./file-list-item-detail.component.css']
})
export class FileListItemDetailComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel = null;

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
