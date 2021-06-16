import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-file-list-item-create',
  templateUrl: './file-list-item-create.component.html',
  styleUrls: ['./file-list-item-create.component.css']
})
export class FileListItemCreateComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
