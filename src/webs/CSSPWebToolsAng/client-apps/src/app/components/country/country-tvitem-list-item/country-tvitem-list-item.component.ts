import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-country-tvitem-list-item',
  templateUrl: './country-tvitem-list-item.component.html',
  styleUrls: ['./country-tvitem-list-item.component.css']
})
export class CountryTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];

  languageEnum = GetLanguageEnum();
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public sortTVItemListService: SortTVItemListService,
    public showTVItemService: ShowTVItemService) {
  }

  ngOnInit() {
    this.TVItemModelList = this.sortTVItemListService.SortTVItemList(this.TVItemModelList);
  }

  ngOnDestroy()
  {
  }

}
