/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { WebRootService } from './webroot.service';
import { LoadLocalesWebRootText } from './webroot.locales';
import { Subscription } from 'rxjs';
import { WebRoot } from '../../../models/generated/WebRoot.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-webroot-edit',
  templateUrl: './webroot-edit.component.html',
  styleUrls: ['./webroot-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WebRootEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  webrootFormEdit: FormGroup;
  @Input() webroot: WebRoot = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public webrootService: WebRootService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutWebRoot(webroot: WebRoot) {
    this.sub = this.webrootService.PutWebRoot(webroot).subscribe();
  }

  PostWebRoot(webroot: WebRoot) {
    this.sub = this.webrootService.PostWebRoot(webroot).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.webroot) {
      let formGroup: FormGroup = this.fb.group(
        {
          TVItemCountryList: [
            {
              value: this.webroot.TVItemCountryList,
              disabled: false
            }, [Validators.required]],
          TVItemLanguageCountryList: [
            {
              value: this.webroot.TVItemLanguageCountryList,
              disabled: false
            }, [Validators.required]],
          TVItemStatCountryList: [
            {
              value: this.webroot.TVItemStatCountryList,
              disabled: false
            }, [Validators.required]],
          MapInfoCountryList: [
            {
              value: this.webroot.MapInfoCountryList,
              disabled: false
            }, [Validators.required]],
          MapInfoPointCountryList: [
            {
              value: this.webroot.MapInfoPointCountryList,
              disabled: false
            }, [Validators.required]],
          TVItem: [
            {
              value: this.webroot.TVItem,
              disabled: false
            }, [Validators.required]],
          TVItemLanguageList: [
            {
              value: this.webroot.TVItemLanguageList,
              disabled: false
            }, [Validators.required]],
          TVItemLinkList: [
            {
              value: this.webroot.TVItemLinkList,
              disabled: false
            }, [Validators.required]],
          TVItemStatList: [
            {
              value: this.webroot.TVItemStatList,
              disabled: false
            }, [Validators.required]],
          MapInfoList: [
            {
              value: this.webroot.MapInfoList,
              disabled: false
            }, [Validators.required]],
          MapInfoPointList: [
            {
              value: this.webroot.MapInfoPointList,
              disabled: false
            }, [Validators.required]],
          TVFileList: [
            {
              value: this.webroot.TVFileList,
              disabled: false
            }, [Validators.required]],
          TVFileLanguageList: [
            {
              value: this.webroot.TVFileLanguageList,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.webrootFormEdit = formGroup
    }
  }
}
