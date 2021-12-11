import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';

@Component({
  selector: 'app-tvitem-create',
  templateUrl: './tvitem-create.component.html',
  styleUrls: ['./tvitem-create.component.css']
})
export class TVItemCreateComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;


  formTVItemCreate: FormGroup;

  get f() { return this.formTVItemCreate.controls; }

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    private fb: FormBuilder) {

  }

  ngOnInit(): void {
    this.formTVItemCreate = this.fb.group({
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
    console.debug(this.formTVItemCreate.value);
    console.debug(this.TVItemModel);
    alert(this.appLanguageService.NotImplementedYet[this.appLanguageService.LangID]);
  }

}
