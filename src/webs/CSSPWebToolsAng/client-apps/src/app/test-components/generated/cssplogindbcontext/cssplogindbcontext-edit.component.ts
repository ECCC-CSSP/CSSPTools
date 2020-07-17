/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { CSSPLoginDBContextService } from './cssplogindbcontext.service';
import { LoadLocalesCSSPLoginDBContextText } from './cssplogindbcontext.locales';
import { Subscription } from 'rxjs';
import { CSSPLoginDBContext } from '../../../models/generated/CSSPLoginDBContext.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-cssplogindbcontext-edit',
  templateUrl: './cssplogindbcontext-edit.component.html',
  styleUrls: ['./cssplogindbcontext-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CSSPLoginDBContextEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  cssplogindbcontextFormEdit: FormGroup;
  @Input() cssplogindbcontext: CSSPLoginDBContext = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public cssplogindbcontextService: CSSPLoginDBContextService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutCSSPLoginDBContext(cssplogindbcontext: CSSPLoginDBContext) {
    this.sub = this.cssplogindbcontextService.PutCSSPLoginDBContext(cssplogindbcontext).subscribe();
  }

  PostCSSPLoginDBContext(cssplogindbcontext: CSSPLoginDBContext) {
    this.sub = this.cssplogindbcontextService.PostCSSPLoginDBContext(cssplogindbcontext).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.cssplogindbcontext) {
      let formGroup: FormGroup = this.fb.group(
        {
          AspNetUsers: [
            {
              value: this.cssplogindbcontext.AspNetUsers,
              disabled: false
            }, [Validators.required]],
          Contacts: [
            {
              value: this.cssplogindbcontext.Contacts,
              disabled: false
            }, [Validators.required]],
          Preferences: [
            {
              value: this.cssplogindbcontext.Preferences,
              disabled: false
            }, [Validators.required]],
          Database: [
            {
              value: this.cssplogindbcontext.Database,
              disabled: false
            }, [Validators.required]],
          ChangeTracker: [
            {
              value: this.cssplogindbcontext.ChangeTracker,
              disabled: false
            }, [Validators.required]],
          Model: [
            {
              value: this.cssplogindbcontext.Model,
              disabled: false
            }, [Validators.required]],
          ContextId: [
            {
              value: this.cssplogindbcontext.ContextId,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.cssplogindbcontextFormEdit = formGroup
    }
  }
}
