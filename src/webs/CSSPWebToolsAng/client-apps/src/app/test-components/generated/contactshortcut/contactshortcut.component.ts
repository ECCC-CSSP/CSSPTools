/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { ContactShortcutService } from './contactshortcut.service';
import { LoadLocalesContactShortcutText } from './contactshortcut.locales';
import { Subscription } from 'rxjs';
import { ContactShortcut } from '../../../models/generated/ContactShortcut.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-contactshortcut',
  templateUrl: './contactshortcut.component.html',
  styleUrls: ['./contactshortcut.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactShortcutComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public contactshortcutService: ContactShortcutService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(contactshortcut: ContactShortcut) {
    if (this.IDToShow === contactshortcut.ContactShortcutID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(contactshortcut: ContactShortcut) {
    if (this.IDToShow === contactshortcut.ContactShortcutID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(contactshortcut: ContactShortcut) {
    if (this.IDToShow === contactshortcut.ContactShortcutID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = contactshortcut.ContactShortcutID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(contactshortcut: ContactShortcut) {
    if (this.IDToShow === contactshortcut.ContactShortcutID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = contactshortcut.ContactShortcutID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetContactShortcutList() {
    this.sub = this.contactshortcutService.GetContactShortcutList().subscribe();
  }

  DeleteContactShortcut(contactshortcut: ContactShortcut) {
    this.sub = this.contactshortcutService.DeleteContactShortcut(contactshortcut).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesContactShortcutText(this.contactshortcutService.contactshortcutTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
