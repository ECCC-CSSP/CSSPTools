import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

@Component({
  selector: 'app-province-item-create',
  templateUrl: './province-item-create.component.html',
  styleUrls: ['./province-item-create.component.css']
})
export class ProvinceItemCreateComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;


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
