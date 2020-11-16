import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { ContactNameService } from 'src/app/services/helpers/contact-name.service';

@Component({
  selector: 'app-last-udpate-tv-file-model',
  templateUrl: './last-update-tvfilemodel.component.html',
  styleUrls: ['./last-update-tvfilemodel.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LastUpdateTVFileModelComponent implements OnInit, OnDestroy {
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
