/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { ContactModelService } from './contactmodel.service';
import { LoadLocalesContactModelText } from './contactmodel.locales';
import { Subscription } from 'rxjs';
import { ContactModel } from '../../../models/generated/ContactModel.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-contactmodel-edit',
  templateUrl: './contactmodel-edit.component.html',
  styleUrls: ['./contactmodel-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactModelEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  contactmodelFormEdit: FormGroup;
  @Input() contactmodel: ContactModel = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public contactmodelService: ContactModelService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutContactModel(contactmodel: ContactModel) {
    this.sub = this.contactmodelService.PutContactModel(contactmodel).subscribe();
  }

  PostContactModel(contactmodel: ContactModel) {
    this.sub = this.contactmodelService.PostContactModel(contactmodel).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.contactmodel) {
      let formGroup: FormGroup = this.fb.group(
        {
          Contact: [
            {
              value: this.contactmodel.Contact,
              disabled: false
            }, [Validators.required]],
          ContactEmailModelList: [
            {
              value: this.contactmodel.ContactEmailModelList,
              disabled: false
            }, [Validators.required]],
          ContactTelModelList: [
            {
              value: this.contactmodel.ContactTelModelList,
              disabled: false
            }, [Validators.required]],
          ContactAddressModelList: [
            {
              value: this.contactmodel.ContactAddressModelList,
              disabled: false
            }, [Validators.required]],
          TVItemModel: [
            {
              value: this.contactmodel.TVItemModel,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.contactmodelFormEdit = formGroup
    }
  }
}
