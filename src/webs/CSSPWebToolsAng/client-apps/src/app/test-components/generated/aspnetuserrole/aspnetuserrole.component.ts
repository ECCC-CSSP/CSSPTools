/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AspNetUserRoleService } from './aspnetuserrole.service';
import { LoadLocalesAspNetUserRoleText } from './aspnetuserrole.locales';
import { Subscription } from 'rxjs';
import { AspNetUserRole } from '../../../models/generated/AspNetUserRole.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-aspnetuserrole',
  templateUrl: './aspnetuserrole.component.html',
  styleUrls: ['./aspnetuserrole.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AspNetUserRoleComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public aspnetuserroleService: AspNetUserRoleService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(aspnetuserrole: AspNetUserRole) {
    if (this.IDToShow === aspnetuserrole.AspNetUserRoleID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(aspnetuserrole: AspNetUserRole) {
    if (this.IDToShow === aspnetuserrole.AspNetUserRoleID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(aspnetuserrole: AspNetUserRole) {
    if (this.IDToShow === aspnetuserrole.AspNetUserRoleID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = aspnetuserrole.AspNetUserRoleID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(aspnetuserrole: AspNetUserRole) {
    if (this.IDToShow === aspnetuserrole.AspNetUserRoleID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = aspnetuserrole.AspNetUserRoleID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetAspNetUserRoleList() {
    this.sub = this.aspnetuserroleService.GetAspNetUserRoleList().subscribe();
  }

  DeleteAspNetUserRole(aspnetuserrole: AspNetUserRole) {
    this.sub = this.aspnetuserroleService.DeleteAspNetUserRole(aspnetuserrole).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesAspNetUserRoleText(this.aspnetuserroleService.aspnetuserroleTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
