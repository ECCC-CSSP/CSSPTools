/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { DeviceCodeService } from './devicecode.service';
import { LoadLocalesDeviceCodeText } from './devicecode.locales';
import { Subscription } from 'rxjs';
import { DeviceCode } from '../../../models/generated/DeviceCode.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-devicecode',
  templateUrl: './devicecode.component.html',
  styleUrls: ['./devicecode.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DeviceCodeComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public devicecodeService: DeviceCodeService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(devicecode: DeviceCode) {
    if (this.IDToShow === devicecode.DeviceCodeID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(devicecode: DeviceCode) {
    if (this.IDToShow === devicecode.DeviceCodeID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(devicecode: DeviceCode) {
    if (this.IDToShow === devicecode.DeviceCodeID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = devicecode.DeviceCodeID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(devicecode: DeviceCode) {
    if (this.IDToShow === devicecode.DeviceCodeID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = devicecode.DeviceCodeID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetDeviceCodeList() {
    this.sub = this.devicecodeService.GetDeviceCodeList().subscribe();
  }

  DeleteDeviceCode(devicecode: DeviceCode) {
    this.sub = this.devicecodeService.DeleteDeviceCode(devicecode).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesDeviceCodeText(this.devicecodeService.devicecodeTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}