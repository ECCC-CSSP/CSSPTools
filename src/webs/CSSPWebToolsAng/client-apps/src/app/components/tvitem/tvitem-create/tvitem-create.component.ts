import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';

import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { GetTVTypeEnum, TVTypeEnum, TVTypeEnum_GetIDText } from 'src/app/enums/generated/TVTypeEnum';
import { CountryService } from 'src/app/services/dblocal/country.service';
import { WebRoot } from 'src/app/models/generated/models/WebRoot.model';

@Component({
  selector: 'app-tvitem-create',
  templateUrl: './tvitem-create.component.html',
  styleUrls: ['./tvitem-create.component.css']
})
export class TVItemCreateComponent implements OnInit, OnDestroy {
  @Input() ParentTVItemID: number;
  @Input() TVType: TVTypeEnum;

  tvTypeEnum = GetTVTypeEnum();


  formTVItemCreate: UntypedFormGroup;

  get f() { return this.formTVItemCreate.controls; }

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    private fb: UntypedFormBuilder,
    private countryService: CountryService) {

  }

  ngOnInit(): void {
    this.formTVItemCreate = this.fb.group({
      ParentTVItemID: [this.ParentTVItemID],
      TVType: [this.TVType],
    });
    this.GetTVTypeEnum_GetIDText(this.TVType);
  }

  ngOnDestroy(): void {
  }

  Create() {
    if (this.formTVItemCreate.value.TVType == this.tvTypeEnum.Country) {
      this.countryService.AddCountry(this.formTVItemCreate.value.ParentTVItemID, this.formTVItemCreate.value.TVType);
      this.appLoadedService.WebRoot = <WebRoot>{};
    }
    else {
      alert(this.appLanguageService.NotImplementedYet[this.appLanguageService.LangID] + '\r\n' +
      this.tvTypeEnum[this.formTVItemCreate.value.TVType].toString());
    }
  }

  GetTVTypeEnum_GetIDText(TVType: TVTypeEnum): string {
    return TVTypeEnum_GetIDText(TVType, this.appLanguageService);
  }
}
