import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AddressService } from 'src/app/services/address/address.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { PolSourceSiteService } from 'src/app/services/helpers/pol-source-site.service';

@Component({
  selector: 'app-pol-source-site-item-view-info',
  templateUrl: './pol-source-site-item-view-info.component.html',
  styleUrls: ['./pol-source-site-item-view-info.component.css']
})
export class PolSourceSiteItemViewInfoComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public polSourceSiteService: PolSourceSiteService,
    public addressService: AddressService
    ) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
