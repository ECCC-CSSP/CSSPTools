/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { EmailDistributionListService } from './emaildistributionlist.service';
import { LoadLocalesEmailDistributionListText } from './emaildistributionlist.locales';
import { Subscription } from 'rxjs';
import { EmailDistributionList } from '../../../models/generated/EmailDistributionList.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-emaildistributionlist-edit',
  templateUrl: './emaildistributionlist-edit.component.html',
  styleUrls: ['./emaildistributionlist-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmailDistributionListEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  emaildistributionlistFormEdit: FormGroup;
  @Input() emaildistributionlist: EmailDistributionList = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public emaildistributionlistService: EmailDistributionListService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutEmailDistributionList(emaildistributionlist: EmailDistributionList) {
    this.sub = this.emaildistributionlistService.PutEmailDistributionList(emaildistributionlist).subscribe();
  }

  PostEmailDistributionList(emaildistributionlist: EmailDistributionList) {
    this.sub = this.emaildistributionlistService.PostEmailDistributionList(emaildistributionlist).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesEmailDistributionListText(this.emaildistributionlistService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.emaildistributionlist) {
      let formGroup: FormGroup = this.fb.group(
        {
          EmailDistributionListID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.emaildistributionlistService.emaildistributionlistListModel$.getValue()[0]?.EmailDistributionListID)),
              disabled: false
            }, [  Validators.required ]],
          ParentTVItemID: [
            {
              value: this.emaildistributionlistService.emaildistributionlistListModel$.getValue()[0]?.ParentTVItemID,
              disabled: false
            }, [  Validators.required ]],
          Ordinal: [
            {
              value: this.emaildistributionlistService.emaildistributionlistListModel$.getValue()[0]?.Ordinal,
              disabled: false
            }, [  Validators.required, Validators.min(0), Validators.max(1000) ]],
          LastUpdateDate_UTC: [
            {
              value: this.emaildistributionlistService.emaildistributionlistListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.emaildistributionlistService.emaildistributionlistListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
        }
      );

      this.emaildistributionlistFormEdit = formGroup
    }
  }
}
