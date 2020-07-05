/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { AspNetRoleService } from './aspnetrole.service';
import { LoadLocalesAspNetRoleText } from './aspnetrole.locales';
import { Subscription } from 'rxjs';
import { AspNetRole } from '../../../models/generated/AspNetRole.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-aspnetrole-edit',
  templateUrl: './aspnetrole-edit.component.html',
  styleUrls: ['./aspnetrole-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AspNetRoleEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  aspnetroleFormEdit: FormGroup;
  @Input() aspnetrole: AspNetRole = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public aspnetroleService: AspNetRoleService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutAspNetRole(aspnetrole: AspNetRole) {
    this.sub = this.aspnetroleService.PutAspNetRole(aspnetrole).subscribe();
  }

  PostAspNetRole(aspnetrole: AspNetRole) {
    this.sub = this.aspnetroleService.PostAspNetRole(aspnetrole).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.aspnetrole) {
      let formGroup: FormGroup = this.fb.group(
        {
          Id: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.aspnetrole.Id)),
              disabled: false
            }, [Validators.required, Validators.maxLength(450)]],
          Name: [
            {
              value: this.aspnetrole.Name,
              disabled: false
            }, [Validators.maxLength(256)]],
          NormalizeName: [
            {
              value: this.aspnetrole.NormalizeName,
              disabled: false
            }, [Validators.maxLength(256)]],
          ConcurrencyStamp: [
            {
              value: this.aspnetrole.ConcurrencyStamp,
              disabled: false
            }],
        }
      );

      this.aspnetroleFormEdit = formGroup
    }
  }
}
