/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { ContactShortcutService } from './contactshortcut.service';
import { LoadLocalesContactShortcutText } from './contactshortcut.locales';
import { Subscription } from 'rxjs';
import { ContactShortcut } from '../../../models/generated/ContactShortcut.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-contactshortcut-edit',
  templateUrl: './contactshortcut-edit.component.html',
  styleUrls: ['./contactshortcut-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactShortcutEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  contactshortcutFormEdit: FormGroup;
  @Input() contactshortcut: ContactShortcut = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public contactshortcutService: ContactShortcutService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutContactShortcut(contactshortcut: ContactShortcut) {
    this.sub = this.contactshortcutService.PutContactShortcut(contactshortcut).subscribe();
  }

  PostContactShortcut(contactshortcut: ContactShortcut) {
    this.sub = this.contactshortcutService.PostContactShortcut(contactshortcut).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesContactShortcutText(this.contactshortcutService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.contactshortcut) {
      let formGroup: FormGroup = this.fb.group(
        {
          ContactShortcutID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.contactshortcut.ContactShortcutID)),
              disabled: false
            }, [Validators.required]],
          ContactID: [
            {
              value: this.contactshortcut.ContactID,
              disabled: false
            }, [Validators.required]],
          ShortCutText: [
            {
              value: this.contactshortcut.ShortCutText,
              disabled: false
            }, [Validators.required, Validators.maxLength(100)]],
          ShortCutAddress: [
            {
              value: this.contactshortcut.ShortCutAddress,
              disabled: false
            }, [Validators.required, Validators.maxLength(200)]],
          LastUpdateDate_UTC: [
            {
              value: this.contactshortcut.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.contactshortcut.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.contactshortcutFormEdit = formGroup
    }
  }
}
