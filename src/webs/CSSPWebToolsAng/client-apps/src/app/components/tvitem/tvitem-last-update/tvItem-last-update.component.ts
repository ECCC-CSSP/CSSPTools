import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ContactNameService } from 'src/app/services/contact/contact-name.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-tvitem-last-update',
  templateUrl: './tvitem-last-update.component.html',
  styleUrls: ['./tvitem-last-update.component.css']
})
export class TVItemLastUpdateComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public dateFormatService: DateFormatService,
    public contactNameService: ContactNameService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
