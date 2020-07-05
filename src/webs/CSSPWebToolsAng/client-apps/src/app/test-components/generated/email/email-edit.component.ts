/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { EmailService } from './email.service';
import { LoadLocalesEmailText } from './email.locales';
import { Subscription } from 'rxjs';
import { EmailTypeEnum_GetOrderedText } from '../../../enums/generated/EmailTypeEnum';
import { Email } from '../../../models/generated/Email.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-email-edit',
  templateUrl: './email-edit.component.html',
  styleUrls: ['./email-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmailEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  emailTypeList: EnumIDAndText[];
  emailFormEdit: FormGroup;
  @Input() email: Email = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public emailService: EmailService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutEmail(email: Email) {
    this.sub = this.emailService.PutEmail(email).subscribe();
  }

  PostEmail(email: Email) {
    this.sub = this.emailService.PostEmail(email).subscribe();
  }

  ngOnInit(): void {
    this.emailTypeList = EmailTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.email) {
      let formGroup: FormGroup = this.fb.group(
        {
          EmailID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.email.EmailID)),
              disabled: false
            }, [Validators.required]],
          EmailTVItemID: [
            {
              value: this.email.EmailTVItemID,
              disabled: false
            }, [Validators.required]],
          EmailAddress: [
            {
              value: this.email.EmailAddress,
              disabled: false
            }, [Validators.required, Validators.email, Validators.maxLength(255)]],
          EmailType: [
            {
              value: this.email.EmailType,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.email.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.email.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.emailFormEdit = formGroup
    }
  }
}
