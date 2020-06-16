/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMLookupMPNService } from './mwqmlookupmpn.service';
import { LoadLocalesMWQMLookupMPNText } from './mwqmlookupmpn.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MWQMLookupMPN } from '../../../models/generated/MWQMLookupMPN.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-mwqmlookupmpn',
  templateUrl: './mwqmlookupmpn.component.html',
  styleUrls: ['./mwqmlookupmpn.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMLookupMPNComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mwqmlookupmpnFormPut: FormGroup;
  mwqmlookupmpnFormPost: FormGroup;

  constructor(public mwqmlookupmpnService: MWQMLookupMPNService, public router: Router, public fb: FormBuilder) { }

  GetMWQMLookupMPNList() {
    this.sub = this.mwqmlookupmpnService.GetMWQMLookupMPNList(this.router).subscribe();
  }

  PutMWQMLookupMPN(mwqmlookupmpn: MWQMLookupMPN) {
    this.sub = this.mwqmlookupmpnService.PutMWQMLookupMPN(mwqmlookupmpn, this.router).subscribe();
  }

  PostMWQMLookupMPN(mwqmlookupmpn: MWQMLookupMPN) {
    this.sub = this.mwqmlookupmpnService.PostMWQMLookupMPN(mwqmlookupmpn, this.router).subscribe();
  }

  DeleteMWQMLookupMPN(mwqmlookupmpn: MWQMLookupMPN) {
    this.sub = this.mwqmlookupmpnService.DeleteMWQMLookupMPN(mwqmlookupmpn, this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesMWQMLookupMPNText(this.mwqmlookupmpnService);
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.mwqmlookupmpnService.mwqmlookupmpnList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMLookupMPNID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.mwqmlookupmpnService.mwqmlookupmpnList[0]?.MWQMLookupMPNID)),
              disabled: false
            }, [ Validators.required ]],
          Tubes10: [
            {
              value: this.mwqmlookupmpnService.mwqmlookupmpnList[0]?.Tubes10,
              disabled: false
            }, [ Validators.required ]],
          Tubes1: [
            {
              value: this.mwqmlookupmpnService.mwqmlookupmpnList[0]?.Tubes1,
              disabled: false
            }, [ Validators.required ]],
          Tubes01: [
            {
              value: this.mwqmlookupmpnService.mwqmlookupmpnList[0]?.Tubes01,
              disabled: false
            }, [ Validators.required ]],
          MPN_100ml: [
            {
              value: this.mwqmlookupmpnService.mwqmlookupmpnList[0]?.MPN_100ml,
              disabled: false
            }, [ Validators.required ]],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmlookupmpnService.mwqmlookupmpnList[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [ Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmlookupmpnService.mwqmlookupmpnList[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [ Validators.required ]],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.mwqmlookupmpnFormPost = formGroup
      }
      else {
        this.mwqmlookupmpnFormPut = formGroup;
      }
    }
  }
}
