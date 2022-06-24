import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';

import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { GetTVTypeEnum, TVTypeEnum, TVTypeEnum_GetIDText } from 'src/app/enums/generated/TVTypeEnum';
import { CountryService } from 'src/app/services/dblocal/country.service';
import { WebRoot } from 'src/app/models/generated/models/WebRoot.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';

@Component({
  selector: 'app-tvitem-delete',
  templateUrl: './tvitem-delete.component.html',
  styleUrls: ['./tvitem-delete.component.css']
})
export class TVItemDeleteComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  tvTypeEnum = GetTVTypeEnum();

  formTVItemDelete: UntypedFormGroup;

  get f() { return this.formTVItemDelete.controls; }

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    private fb: UntypedFormBuilder,
    private countryService: CountryService,
    private showTVItemService: ShowTVItemService) {

  }

  ngOnInit(): void {
    this.formTVItemDelete = this.fb.group({
      TVItemID: [this.TVItemModel.TVItem.TVItemID],
      TVType: [this.TVItemModel.TVItem.TVType],
    });
    this.GetTVTypeEnum_GetIDText(this.TVItemModel.TVItem.TVItemID);
  }

  ngOnDestroy(): void {
  }

  Delete() {
    if (this.formTVItemDelete.value.TVType == this.tvTypeEnum.Country) {
      this.appStateService.ShowTVItemModelList = [];
      this.countryService.DeleteCountry(this.formTVItemDelete.value.TVItemID, this.formTVItemDelete.value.TVType);
      this.appLoadedService.WebRoot = <WebRoot>{};
    }
    else {
      alert(this.appLanguageService.NotImplementedYet[this.appLanguageService.LangID] + '\r\n' +
      this.tvTypeEnum[this.formTVItemDelete.value.TVType].toString());
    }
  }

  GetTVTypeEnum_GetIDText(TVType: TVTypeEnum): string {
    return TVTypeEnum_GetIDText(TVType, this.appLanguageService);
  }
}
