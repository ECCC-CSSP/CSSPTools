import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-country-item-modify',
  templateUrl: './country-item-modify.component.html',
  styleUrls: ['./country-item-modify.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryItemModifyComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;

  formCountryModify: FormGroup;
  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService,
    private fb: FormBuilder) {

  }

  ngOnInit(): void {
    this.formCountryModify = this.fb.group({
      TVText: [ this.TVItemModel.TVItemLanguageList[<number>this.appStateService.AppState$.getValue().Language].TVText,
      [
        Validators.required,
        //Validators.email,
      ]],
    });
  }

  ngOnDestroy(): void {
  }

  Modify()
  {
    console.debug(this.formCountryModify.value);
    console.debug(this.TVItemModel);
  }

}