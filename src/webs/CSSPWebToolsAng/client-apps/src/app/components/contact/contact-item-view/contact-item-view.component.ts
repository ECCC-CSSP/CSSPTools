import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-contact-item-view',
  templateUrl: './contact-item-view.component.html',
  styleUrls: ['./contact-item-view.component.css']
})
export class ContactItemViewComponent implements OnInit, OnDestroy {
  @Input() MunicipalityTVItemModel: TVItemModel;
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
