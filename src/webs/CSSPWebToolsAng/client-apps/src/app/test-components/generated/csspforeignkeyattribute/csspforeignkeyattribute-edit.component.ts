/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { CSSPForeignKeyAttributeService } from './csspforeignkeyattribute.service';
import { LoadLocalesCSSPForeignKeyAttributeText } from './csspforeignkeyattribute.locales';
import { Subscription } from 'rxjs';
import { CSSPForeignKeyAttribute } from '../../../models/generated/CSSPForeignKeyAttribute.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-csspforeignkeyattribute-edit',
  templateUrl: './csspforeignkeyattribute-edit.component.html',
  styleUrls: ['./csspforeignkeyattribute-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CSSPForeignKeyAttributeEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  csspforeignkeyattributeFormEdit: FormGroup;
  @Input() csspforeignkeyattribute: CSSPForeignKeyAttribute = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public csspforeignkeyattributeService: CSSPForeignKeyAttributeService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutCSSPForeignKeyAttribute(csspforeignkeyattribute: CSSPForeignKeyAttribute) {
    this.sub = this.csspforeignkeyattributeService.PutCSSPForeignKeyAttribute(csspforeignkeyattribute).subscribe();
  }

  PostCSSPForeignKeyAttribute(csspforeignkeyattribute: CSSPForeignKeyAttribute) {
    this.sub = this.csspforeignkeyattributeService.PostCSSPForeignKeyAttribute(csspforeignkeyattribute).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.csspforeignkeyattribute) {
      let formGroup: FormGroup = this.fb.group(
        {
          TableName: [
            {
              value: this.csspforeignkeyattribute.TableName,
              disabled: false
            }, [Validators.required]],
          FieldName: [
            {
              value: this.csspforeignkeyattribute.FieldName,
              disabled: false
            }, [Validators.required]],
          RequiresValidationContext: [
            {
              value: this.csspforeignkeyattribute.RequiresValidationContext,
              disabled: false
            }, [Validators.required]],
          ErrorMessage: [
            {
              value: this.csspforeignkeyattribute.ErrorMessage,
              disabled: false
            }, [Validators.required]],
          ErrorMessageResourceName: [
            {
              value: this.csspforeignkeyattribute.ErrorMessageResourceName,
              disabled: false
            }, [Validators.required]],
          ErrorMessageResourceType: [
            {
              value: this.csspforeignkeyattribute.ErrorMessageResourceType,
              disabled: false
            }, [Validators.required]],
          TypeId: [
            {
              value: this.csspforeignkeyattribute.TypeId,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.csspforeignkeyattributeFormEdit = formGroup
    }
  }
}
