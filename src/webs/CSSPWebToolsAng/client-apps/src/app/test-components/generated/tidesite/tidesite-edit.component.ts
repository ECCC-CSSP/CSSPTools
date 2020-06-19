/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { TideSiteService } from './tidesite.service';
import { LoadLocalesTideSiteText } from './tidesite.locales';
import { Subscription } from 'rxjs';
import { TideSite } from '../../../models/generated/TideSite.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-tidesite-edit',
  templateUrl: './tidesite-edit.component.html',
  styleUrls: ['./tidesite-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TideSiteEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  tidesiteFormEdit: FormGroup;
  @Input() tidesite: TideSite = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public tidesiteService: TideSiteService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutTideSite(tidesite: TideSite) {
    this.sub = this.tidesiteService.PutTideSite(tidesite).subscribe();
  }

  PostTideSite(tidesite: TideSite) {
    this.sub = this.tidesiteService.PostTideSite(tidesite).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesTideSiteText(this.tidesiteService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.tidesite) {
      let formGroup: FormGroup = this.fb.group(
        {
          TideSiteID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.tidesiteService.tidesiteListModel$.getValue()[0]?.TideSiteID)),
              disabled: false
            }, [  Validators.required ]],
          TideSiteTVItemID: [
            {
              value: this.tidesiteService.tidesiteListModel$.getValue()[0]?.TideSiteTVItemID,
              disabled: false
            }, [  Validators.required ]],
          TideSiteName: [
            {
              value: this.tidesiteService.tidesiteListModel$.getValue()[0]?.TideSiteName,
              disabled: false
            }, [  Validators.required, Validators.maxLength(100) ]],
          Province: [
            {
              value: this.tidesiteService.tidesiteListModel$.getValue()[0]?.Province,
              disabled: false
            }, [  Validators.required, Validators.minLength(2), Validators.maxLength(2) ]],
          sid: [
            {
              value: this.tidesiteService.tidesiteListModel$.getValue()[0]?.sid,
              disabled: false
            }, [  Validators.required, Validators.min(0), Validators.max(10000) ]],
          Zone: [
            {
              value: this.tidesiteService.tidesiteListModel$.getValue()[0]?.Zone,
              disabled: false
            }, [  Validators.required, Validators.min(0), Validators.max(10000) ]],
          LastUpdateDate_UTC: [
            {
              value: this.tidesiteService.tidesiteListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.tidesiteService.tidesiteListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
        }
      );

      this.tidesiteFormEdit = formGroup
    }
  }
}
