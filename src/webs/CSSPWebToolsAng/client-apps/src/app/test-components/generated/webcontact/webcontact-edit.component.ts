/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { WebContactService } from './webcontact.service';
import { LoadLocalesWebContactText } from './webcontact.locales';
import { Subscription } from 'rxjs';
import { WebContact } from '../../../models/generated/WebContact.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-webcontact-edit',
  templateUrl: './webcontact-edit.component.html',
  styleUrls: ['./webcontact-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WebContactEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  webcontactFormEdit: FormGroup;
  @Input() webcontact: WebContact = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public webcontactService: WebContactService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutWebContact(webcontact: WebContact) {
    this.sub = this.webcontactService.PutWebContact(webcontact).subscribe();
  }

  PostWebContact(webcontact: WebContact) {
    this.sub = this.webcontactService.PostWebContact(webcontact).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.webcontact) {
      let formGroup: FormGroup = this.fb.group(
        {
          ContactList: [
            {
              value: this.webcontact.ContactList,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.webcontactFormEdit = formGroup
    }
  }
}
