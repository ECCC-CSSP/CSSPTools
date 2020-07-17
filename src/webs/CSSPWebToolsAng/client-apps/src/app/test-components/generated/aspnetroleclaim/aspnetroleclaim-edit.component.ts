/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { AspNetRoleClaimService } from './aspnetroleclaim.service';
import { LoadLocalesAspNetRoleClaimText } from './aspnetroleclaim.locales';
import { Subscription } from 'rxjs';
import { AspNetRoleClaim } from '../../../models/generated/AspNetRoleClaim.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-aspnetroleclaim-edit',
  templateUrl: './aspnetroleclaim-edit.component.html',
  styleUrls: ['./aspnetroleclaim-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AspNetRoleClaimEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  aspnetroleclaimFormEdit: FormGroup;
  @Input() aspnetroleclaim: AspNetRoleClaim = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public aspnetroleclaimService: AspNetRoleClaimService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutAspNetRoleClaim(aspnetroleclaim: AspNetRoleClaim) {
    this.sub = this.aspnetroleclaimService.PutAspNetRoleClaim(aspnetroleclaim).subscribe();
  }

  PostAspNetRoleClaim(aspnetroleclaim: AspNetRoleClaim) {
    this.sub = this.aspnetroleclaimService.PostAspNetRoleClaim(aspnetroleclaim).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.aspnetroleclaim) {
      let formGroup: FormGroup = this.fb.group(
        {
          Id: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.aspnetroleclaim.Id)),
              disabled: false
            }, [Validators.required]],
          RoleId: [
            {
              value: this.aspnetroleclaim.RoleId,
              disabled: false
            }, [Validators.required, Validators.maxLength(450)]],
          ClaimType: [
            {
              value: this.aspnetroleclaim.ClaimType,
              disabled: false
            }],
          ClaimValue: [
            {
              value: this.aspnetroleclaim.ClaimValue,
              disabled: false
            }],
        }
      );

      this.aspnetroleclaimFormEdit = formGroup
    }
  }
}
