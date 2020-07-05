/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { AspNetUserTokenService } from './aspnetusertoken.service';
import { LoadLocalesAspNetUserTokenText } from './aspnetusertoken.locales';
import { Subscription } from 'rxjs';
import { AspNetUserToken } from '../../../models/generated/AspNetUserToken.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-aspnetusertoken-edit',
  templateUrl: './aspnetusertoken-edit.component.html',
  styleUrls: ['./aspnetusertoken-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AspNetUserTokenEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  aspnetusertokenFormEdit: FormGroup;
  @Input() aspnetusertoken: AspNetUserToken = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public aspnetusertokenService: AspNetUserTokenService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutAspNetUserToken(aspnetusertoken: AspNetUserToken) {
    this.sub = this.aspnetusertokenService.PutAspNetUserToken(aspnetusertoken).subscribe();
  }

  PostAspNetUserToken(aspnetusertoken: AspNetUserToken) {
    this.sub = this.aspnetusertokenService.PostAspNetUserToken(aspnetusertoken).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.aspnetusertoken) {
      let formGroup: FormGroup = this.fb.group(
        {
          UserId: [
            {
              value: this.aspnetusertoken.UserId,
              disabled: false
            }, [Validators.required, Validators.maxLength(450)]],
          LoginProvider: [
            {
              value: this.aspnetusertoken.LoginProvider,
              disabled: false
            }, [Validators.required, Validators.maxLength(128)]],
          Name: [
            {
              value: this.aspnetusertoken.Name,
              disabled: false
            }, [Validators.required, Validators.maxLength(128)]],
          Value: [
            {
              value: this.aspnetusertoken.Value,
              disabled: false
            }],
        }
      );

      this.aspnetusertokenFormEdit = formGroup
    }
  }
}