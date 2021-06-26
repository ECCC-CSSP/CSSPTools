import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

@Component({
  selector: 'app-tvitem-modify',
  templateUrl: './tvitem-modify.component.html',
  styleUrls: ['./tvitem-modify.component.css']
})
export class TVItemModifyComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  formTVItemModify: FormGroup;

  get f() { return this.formTVItemModify.controls; }

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    private fb: FormBuilder) {

  }

  ngOnInit(): void {
    this.formTVItemModify = this.fb.group({
      TVText: [this.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText,
      [
        Validators.required,
        //Validators.email,
      ]],
    });
  }

  ngOnDestroy(): void {
  }

  Modify() {
    console.debug(this.formTVItemModify.value);
    console.debug(this.TVItemModel);
    alert(this.appLanguageService.NotImplementedYet[this.appLanguageService.LangID]);
  }

}
