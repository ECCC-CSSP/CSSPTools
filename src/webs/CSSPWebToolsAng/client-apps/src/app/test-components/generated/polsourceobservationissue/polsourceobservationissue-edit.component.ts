/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { PolSourceObservationIssueService } from './polsourceobservationissue.service';
import { LoadLocalesPolSourceObservationIssueText } from './polsourceobservationissue.locales';
import { Subscription } from 'rxjs';
import { PolSourceObservationIssue } from '../../../models/generated/PolSourceObservationIssue.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-polsourceobservationissue-edit',
  templateUrl: './polsourceobservationissue-edit.component.html',
  styleUrls: ['./polsourceobservationissue-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceObservationIssueEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  polsourceobservationissueFormEdit: FormGroup;
  @Input() polsourceobservationissue: PolSourceObservationIssue = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public polsourceobservationissueService: PolSourceObservationIssueService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutPolSourceObservationIssue(polsourceobservationissue: PolSourceObservationIssue) {
    this.sub = this.polsourceobservationissueService.PutPolSourceObservationIssue(polsourceobservationissue).subscribe();
  }

  PostPolSourceObservationIssue(polsourceobservationissue: PolSourceObservationIssue) {
    this.sub = this.polsourceobservationissueService.PostPolSourceObservationIssue(polsourceobservationissue).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.polsourceobservationissue) {
      let formGroup: FormGroup = this.fb.group(
        {
          PolSourceObservationIssueID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.polsourceobservationissue.PolSourceObservationIssueID)),
              disabled: false
            }, [Validators.required]],
          PolSourceObservationID: [
            {
              value: this.polsourceobservationissue.PolSourceObservationID,
              disabled: false
            }, [Validators.required]],
          ObservationInfo: [
            {
              value: this.polsourceobservationissue.ObservationInfo,
              disabled: false
            }, [Validators.required, Validators.maxLength(250)]],
          Ordinal: [
            {
              value: this.polsourceobservationissue.Ordinal,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000)]],
          ExtraComment: [
            {
              value: this.polsourceobservationissue.ExtraComment,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.polsourceobservationissue.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.polsourceobservationissue.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.polsourceobservationissueFormEdit = formGroup
    }
  }
}
