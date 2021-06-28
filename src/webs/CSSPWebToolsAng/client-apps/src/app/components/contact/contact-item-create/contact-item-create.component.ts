import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-contact-item-create',
  templateUrl: './contact-item-create.component.html',
  styleUrls: ['./contact-item-create.component.css']
})
export class ContactItemCreateComponent implements OnInit, OnDestroy {
  @Input() MunicipalityTVItemModel: TVItemModel;
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
