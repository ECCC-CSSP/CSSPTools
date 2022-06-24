import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';

import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { CountryService } from 'src/app/services/dblocal/country.service';
import { WebRoot } from 'src/app/models/generated/models/WebRoot.model';

@Component({
  selector: 'app-tvitem-modify',
  templateUrl: './tvitem-modify.component.html',
  styleUrls: ['./tvitem-modify.component.css']
})
export class TVItemModifyComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  formTVItemModify: UntypedFormGroup;

  tvTypeEnum = GetTVTypeEnum();

  get f() { return this.formTVItemModify.controls; }

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    private fb: UntypedFormBuilder,
    private countryService: CountryService) {

  }

  ngOnInit(): void {
    this.formTVItemModify = this.fb.group({
      TVItemID: [this.TVItemModel.TVItem.TVItemID],
      TVType: [this.TVItemModel.TVItem.TVType],
      TVTextEN: [this.TVItemModel.TVItemLanguageList[0]?.TVText,
      [
        Validators.required,
      ]],
      TVTextFR: [this.TVItemModel.TVItemLanguageList[1]?.TVText,
      [
        Validators.required,
      ]],
    });
  }

  ngOnDestroy(): void {
  }

  Modify() {
    if (this.formTVItemModify.value.TVType == this.tvTypeEnum.Country) {
      this.appStateService.ShowTVItemModelList = [];
      this.countryService.ModifyTVTextCountry(this.formTVItemModify.value.TVItemID, this.formTVItemModify.value.TVType,
        this.formTVItemModify.value.TVTextEN, this.formTVItemModify.value.TVTextFR);
      this.appLoadedService.WebRoot = <WebRoot>{};
    }
    else {
      alert(this.appLanguageService.NotImplementedYet[this.appLanguageService.LangID] + '\r\n' +
        this.tvTypeEnum[this.formTVItemModify.value.TVType].toString());
    }
  }

}
