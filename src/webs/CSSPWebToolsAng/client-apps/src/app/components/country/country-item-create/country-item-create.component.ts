import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-country-item-create',
  templateUrl: './country-item-create.component.html',
  styleUrls: ['./country-item-create.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryItemCreateComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;

  formCountryCreate: FormGroup;

  get f() { return this.formCountryCreate.controls; }

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    private fb: FormBuilder) {

  }

  ngOnInit(): void {
    this.formCountryCreate = this.fb.group({
      TVText: ['',
      [
        Validators.required,
        //Validators.email,
      ]],
    });
  }

  ngOnDestroy(): void {
  }

  Create()
  {
    console.debug(this.formCountryCreate.value);
    console.debug(this.TVItemModel);
  }

}
