/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { EmailDistributionListContactService } from './emaildistributionlistcontact.service';
import { LoadLocalesEmailDistributionListContactText } from './emaildistributionlistcontact.locales';
import { Subscription } from 'rxjs';
import { EmailDistributionListContact } from '../../../models/generated/EmailDistributionListContact.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-emaildistributionlistcontact-edit',
  templateUrl: './emaildistributionlistcontact-edit.component.html',
  styleUrls: ['./emaildistributionlistcontact-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmailDistributionListContactEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  emaildistributionlistcontactFormEdit: FormGroup;
  @Input() emaildistributionlistcontact: EmailDistributionListContact = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public emaildistributionlistcontactService: EmailDistributionListContactService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutEmailDistributionListContact(emaildistributionlistcontact: EmailDistributionListContact) {
    this.sub = this.emaildistributionlistcontactService.PutEmailDistributionListContact(emaildistributionlistcontact).subscribe();
  }

  PostEmailDistributionListContact(emaildistributionlistcontact: EmailDistributionListContact) {
    this.sub = this.emaildistributionlistcontactService.PostEmailDistributionListContact(emaildistributionlistcontact).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesEmailDistributionListContactText(this.emaildistributionlistcontactService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.emaildistributionlistcontact) {
      let formGroup: FormGroup = this.fb.group(
        {
          EmailDistributionListContactID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.EmailDistributionListContactID)),
              disabled: false
            }, [Validators.required]],
          EmailDistributionListID: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.EmailDistributionListID,
              disabled: false
            }, [Validators.required]],
          IsCC: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.IsCC,
              disabled: false
            }, [Validators.required]],
          Name: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.Name,
              disabled: false
            }, [Validators.required, Validators.maxLength(100)]],
          Email: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.Email,
              disabled: false
            }, [Validators.required, Validators.email, Validators.maxLength(200)]],
          CMPRainfallSeasonal: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.CMPRainfallSeasonal,
              disabled: false
            }, [Validators.required]],
          CMPWastewater: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.CMPWastewater,
              disabled: false
            }, [Validators.required]],
          EmergencyWeather: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.EmergencyWeather,
              disabled: false
            }, [Validators.required]],
          EmergencyWastewater: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.EmergencyWastewater,
              disabled: false
            }, [Validators.required]],
          ReopeningAllTypes: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.ReopeningAllTypes,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.emaildistributionlistcontactFormEdit = formGroup
    }
  }
}
