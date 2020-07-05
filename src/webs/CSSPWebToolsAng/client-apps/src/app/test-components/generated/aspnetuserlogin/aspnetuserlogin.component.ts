/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AspNetUserLoginService } from './aspnetuserlogin.service';
import { LoadLocalesAspNetUserLoginText } from './aspnetuserlogin.locales';
import { Subscription } from 'rxjs';
import { AspNetUserLogin } from '../../../models/generated/AspNetUserLogin.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-aspnetuserlogin',
  templateUrl: './aspnetuserlogin.component.html',
  styleUrls: ['./aspnetuserlogin.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AspNetUserLoginComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public aspnetuserloginService: AspNetUserLoginService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(aspnetuserlogin: AspNetUserLogin) {
    if (this.IDToShow === aspnetuserlogin.AspNetUserLoginID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(aspnetuserlogin: AspNetUserLogin) {
    if (this.IDToShow === aspnetuserlogin.AspNetUserLoginID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(aspnetuserlogin: AspNetUserLogin) {
    if (this.IDToShow === aspnetuserlogin.AspNetUserLoginID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = aspnetuserlogin.AspNetUserLoginID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(aspnetuserlogin: AspNetUserLogin) {
    if (this.IDToShow === aspnetuserlogin.AspNetUserLoginID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = aspnetuserlogin.AspNetUserLoginID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetAspNetUserLoginList() {
    this.sub = this.aspnetuserloginService.GetAspNetUserLoginList().subscribe();
  }

  DeleteAspNetUserLogin(aspnetuserlogin: AspNetUserLogin) {
    this.sub = this.aspnetuserloginService.DeleteAspNetUserLogin(aspnetuserlogin).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesAspNetUserLoginText(this.aspnetuserloginService.aspnetuserloginTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
