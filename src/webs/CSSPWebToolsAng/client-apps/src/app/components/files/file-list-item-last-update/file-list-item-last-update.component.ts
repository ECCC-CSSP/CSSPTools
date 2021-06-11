import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ContactNameService } from 'src/app/services/contact/contact-name.service';

@Component({
  selector: 'app-file-list-item-last-update',
  templateUrl: './file-list-item-last-update.component.html',
  styleUrls: ['./file-list-item-last-update.component.css']
})
export class FileListItemLastUpdateComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public contactNameService: ContactNameService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
