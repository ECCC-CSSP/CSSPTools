import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ContactNameService } from 'src/app/services/helpers/contact-name.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-last-udpate-tv-item-model',
  templateUrl: './last-update-tvitemmodel.component.html',
  styleUrls: ['./last-update-tvitemmodel.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LastUpdateTVItemModelComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public dateFormatService: DateFormatService,
    public contactNameService: ContactNameService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
