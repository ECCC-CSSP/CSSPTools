/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { CSSPForeignKeyAttributeService } from './csspforeignkeyattribute.service';
import { LoadLocalesCSSPForeignKeyAttributeText } from './csspforeignkeyattribute.locales';
import { Subscription } from 'rxjs';
import { CSSPForeignKeyAttribute } from '../../../models/generated/CSSPForeignKeyAttribute.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-csspforeignkeyattribute',
  templateUrl: './csspforeignkeyattribute.component.html',
  styleUrls: ['./csspforeignkeyattribute.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CSSPForeignKeyAttributeComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public csspforeignkeyattributeService: CSSPForeignKeyAttributeService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(csspforeignkeyattribute: CSSPForeignKeyAttribute) {
    if (this.IDToShow === csspforeignkeyattribute.CSSPForeignKeyAttributeID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(csspforeignkeyattribute: CSSPForeignKeyAttribute) {
    if (this.IDToShow === csspforeignkeyattribute.CSSPForeignKeyAttributeID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(csspforeignkeyattribute: CSSPForeignKeyAttribute) {
    if (this.IDToShow === csspforeignkeyattribute.CSSPForeignKeyAttributeID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = csspforeignkeyattribute.CSSPForeignKeyAttributeID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(csspforeignkeyattribute: CSSPForeignKeyAttribute) {
    if (this.IDToShow === csspforeignkeyattribute.CSSPForeignKeyAttributeID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = csspforeignkeyattribute.CSSPForeignKeyAttributeID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetCSSPForeignKeyAttributeList() {
    this.sub = this.csspforeignkeyattributeService.GetCSSPForeignKeyAttributeList().subscribe();
  }

  DeleteCSSPForeignKeyAttribute(csspforeignkeyattribute: CSSPForeignKeyAttribute) {
    this.sub = this.csspforeignkeyattributeService.DeleteCSSPForeignKeyAttribute(csspforeignkeyattribute).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesCSSPForeignKeyAttributeText(this.csspforeignkeyattributeService.csspforeignkeyattributeTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}