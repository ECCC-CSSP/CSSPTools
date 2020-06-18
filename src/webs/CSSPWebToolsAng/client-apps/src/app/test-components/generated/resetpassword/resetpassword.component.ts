/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { ResetPasswordService } from './resetpassword.service';
import { LoadLocalesResetPasswordText } from './resetpassword.locales';
import { Subscription } from 'rxjs';
import { ResetPassword } from '../../../models/generated/ResetPassword.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  styleUrls: ['./resetpassword.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ResetPasswordComponent implements OnInit, OnDestroy {
  sub: Subscription;
  resetpasswordFormPut: FormGroup;
  resetpasswordFormPost: FormGroup;

  constructor(public resetpasswordService: ResetPasswordService, private router: Router, private httpClientService: HttpClientService, private fb: FormBuilder) {
    httpClientService.oldURL = router.url;
  }

  GetResetPasswordList() {
    this.sub = this.resetpasswordService.GetResetPasswordList().subscribe();
  }

  PutResetPassword(resetpassword: ResetPassword) {
    this.sub = this.resetpasswordService.PutResetPassword(resetpassword).subscribe();
  }

  PostResetPassword(resetpassword: ResetPassword) {
    this.sub = this.resetpasswordService.PostResetPassword(resetpassword).subscribe();
  }

  DeleteResetPassword(resetpassword: ResetPassword) {
    this.sub = this.resetpasswordService.DeleteResetPassword(resetpassword).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesResetPasswordText(this.resetpasswordService);
    this.FillFormBuilderGroup(HttpClientCommand.Post);
    this.FillFormBuilderGroup(HttpClientCommand.Put);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.resetpasswordService.resetpasswordListModel$.getValue().length) {
      let formGroup: FormGroup = this.fb.group(
        {
          ResetPasswordID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.resetpasswordService.resetpasswordListModel$.getValue()[0]?.ResetPasswordID)),
              disabled: false
            }, [  Validators.required ]],
          Email: [
            {
              value: this.resetpasswordService.resetpasswordListModel$.getValue()[0]?.Email,
              disabled: false
            }, [  Validators.required, Validators.email, Validators.maxLength(256) ]],
          ExpireDate_Local: [
            {
              value: this.resetpasswordService.resetpasswordListModel$.getValue()[0]?.ExpireDate_Local,
              disabled: false
            }, [  Validators.required ]],
          Code: [
            {
              value: this.resetpasswordService.resetpasswordListModel$.getValue()[0]?.Code,
              disabled: false
            }, [  Validators.required, Validators.maxLength(8) ]],
          LastUpdateDate_UTC: [
            {
              value: this.resetpasswordService.resetpasswordListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.resetpasswordService.resetpasswordListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
        }
      );

      if (httpClientCommand === HttpClientCommand.Post) {
        this.resetpasswordFormPost = formGroup
      }
      else {
        this.resetpasswordFormPut = formGroup;
      }
    }
  }
}
