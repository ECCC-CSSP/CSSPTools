/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { ContactService } from './contact.service';
import { LoadLocalesContactText } from './contact.locales';
import { Subscription } from 'rxjs';
import { ContactTitleEnum_GetOrderedText } from '../../../enums/generated/ContactTitleEnum';
import { Contact } from '../../../models/generated/Contact.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  styleUrls: ['./contact-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  contactTitleList: EnumIDAndText[];
  contactFormEdit: FormGroup;
  @Input() contact: Contact = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public contactService: ContactService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutContact(contact: Contact) {
    this.sub = this.contactService.PutContact(contact).subscribe();
  }

  PostContact(contact: Contact) {
    this.sub = this.contactService.PostContact(contact).subscribe();
  }

  ngOnInit(): void {
    this.contactTitleList = ContactTitleEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.contact) {
      let formGroup: FormGroup = this.fb.group(
        {
          ContactID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.contact.ContactID)),
              disabled: false
            }, [Validators.required]],
          Id: [
            {
              value: this.contact.Id,
              disabled: false
            }, [Validators.required, Validators.maxLength(128)]],
          ContactTVItemID: [
            {
              value: this.contact.ContactTVItemID,
              disabled: false
            }, [Validators.required]],
          LoginEmail: [
            {
              value: this.contact.LoginEmail,
              disabled: false
            }, [Validators.required, Validators.email, Validators.minLength(6), Validators.maxLength(255)]],
          FirstName: [
            {
              value: this.contact.FirstName,
              disabled: false
            }, [Validators.required, Validators.maxLength(100)]],
          LastName: [
            {
              value: this.contact.LastName,
              disabled: false
            }, [Validators.required, Validators.maxLength(100)]],
          Initial: [
            {
              value: this.contact.Initial,
              disabled: false
            }, [Validators.maxLength(50)]],
          WebName: [
            {
              value: this.contact.WebName,
              disabled: false
            }, [Validators.required, Validators.maxLength(100)]],
          ContactTitle: [
            {
              value: this.contact.ContactTitle,
              disabled: false
            }],
          IsAdmin: [
            {
              value: this.contact.IsAdmin,
              disabled: false
            }, [Validators.required]],
          EmailValidated: [
            {
              value: this.contact.EmailValidated,
              disabled: false
            }, [Validators.required]],
          Disabled: [
            {
              value: this.contact.Disabled,
              disabled: false
            }, [Validators.required]],
          IsNew: [
            {
              value: this.contact.IsNew,
              disabled: false
            }, [Validators.required]],
          SamplingPlanner_ProvincesTVItemID: [
            {
              value: this.contact.SamplingPlanner_ProvincesTVItemID,
              disabled: false
            }, [Validators.maxLength(200)]],
          Token: [
            {
              value: this.contact.Token,
              disabled: false
            }, [Validators.maxLength(255)]],
          LastUpdateDate_UTC: [
            {
              value: this.contact.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.contact.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.contactFormEdit = formGroup
    }
  }
}
