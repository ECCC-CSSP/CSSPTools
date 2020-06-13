/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { EmailDistributionListContactService } from './emaildistributionlistcontact.service';
import { LoadLocalesEmailDistributionListContactText } from './emaildistributionlistcontact.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EmailDistributionListContact } from '../../../models/generated/EmailDistributionListContact.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-emaildistributionlistcontact',
  templateUrl: './emaildistributionlistcontact.component.html',
  styleUrls: ['./emaildistributionlistcontact.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmailDistributionListContactComponent implements OnInit, OnDestroy {
  sub: Subscription;
  emaildistributionlistcontactFormPut: FormGroup;
  emaildistributionlistcontactFormPost: FormGroup;

  constructor(public emaildistributionlistcontactService: EmailDistributionListContactService, public router: Router, public fb: FormBuilder) { }

  GetEmailDistributionListContactList() {
    this.sub = this.emaildistributionlistcontactService.GetEmailDistributionListContactList(this.router).subscribe();
  }

  PutEmailDistributionListContact(emaildistributionlistcontact: EmailDistributionListContact) {
    this.sub = this.emaildistributionlistcontactService.PutEmailDistributionListContact(emaildistributionlistcontact, this.router).subscribe();
  }

  PostEmailDistributionListContact(emaildistributionlistcontact: EmailDistributionListContact) {
    this.sub = this.emaildistributionlistcontactService.PostEmailDistributionListContact(emaildistributionlistcontact, this.router).subscribe();
  }

  DeleteEmailDistributionListContact(emaildistributionlistcontact: EmailDistributionListContact) {
    this.sub = this.emaildistributionlistcontactService.DeleteEmailDistributionListContact(emaildistributionlistcontact, this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesEmailDistributionListContactText(this.emaildistributionlistcontactService);
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.emaildistributionlistcontactService.emaildistributionlistcontactList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          EmailDistributionListContactID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.EmailDistributionListContactID ?? '')),
              disabled: false
            }, Validators.required],
          EmailDistributionListID: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.EmailDistributionListID ?? '',
              disabled: false
            }, Validators.required],
          IsCC: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.IsCC ?? '',
              disabled: false
            }, Validators.required],
          Name: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.Name ?? '',
              disabled: false
            }, Validators.required],
          Email: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.Email ?? '',
              disabled: false
            }, Validators.required],
          CMPRainfallSeasonal: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.CMPRainfallSeasonal ?? '',
              disabled: false
            }, Validators.required],
          CMPWastewater: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.CMPWastewater ?? '',
              disabled: false
            }, Validators.required],
          EmergencyWeather: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.EmergencyWeather ?? '',
              disabled: false
            }, Validators.required],
          EmergencyWastewater: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.EmergencyWastewater ?? '',
              disabled: false
            }, Validators.required],
          ReopeningAllTypes: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.ReopeningAllTypes ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateDate_UTC: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.LastUpdateDate_UTC ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateContactTVItemID: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactList[0]?.LastUpdateContactTVItemID ?? '',
              disabled: false
            }, Validators.required],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.emaildistributionlistcontactFormPost = formGroup
      }
      else {
        this.emaildistributionlistcontactFormPut = formGroup;
      }
    }
  }
}
