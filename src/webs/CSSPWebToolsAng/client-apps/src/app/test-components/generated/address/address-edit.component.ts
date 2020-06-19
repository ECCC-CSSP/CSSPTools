/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { AddressService } from './address.service';
import { LoadLocalesAddressText } from './address.locales';
import { Subscription } from 'rxjs';
import { AddressTypeEnum_GetOrderedText } from '../../../enums/generated/AddressTypeEnum';
import { StreetTypeEnum_GetOrderedText } from '../../../enums/generated/StreetTypeEnum';
import { Address } from '../../../models/generated/Address.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddressEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  addressTypeList: EnumIDAndText[];
  streetTypeList: EnumIDAndText[];
  addressFormEdit: FormGroup;
  @Input() address: Address = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public addressService: AddressService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutAddress(address: Address) {
    this.sub = this.addressService.PutAddress(address).subscribe();
  }

  PostAddress(address: Address) {
    this.sub = this.addressService.PostAddress(address).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesAddressText(this.addressService);
    this.addressTypeList = AddressTypeEnum_GetOrderedText();
    this.streetTypeList = StreetTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.address) {
      let formGroup: FormGroup = this.fb.group(
        {
          AddressID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.addressService.addressListModel$.getValue()[0]?.AddressID)),
              disabled: false
            }, [  Validators.required ]],
          AddressTVItemID: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.AddressTVItemID,
              disabled: false
            }, [  Validators.required ]],
          AddressType: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.AddressType,
              disabled: false
            }, [  Validators.required ]],
          CountryTVItemID: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.CountryTVItemID,
              disabled: false
            }, [  Validators.required ]],
          ProvinceTVItemID: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.ProvinceTVItemID,
              disabled: false
            }, [  Validators.required ]],
          MunicipalityTVItemID: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.MunicipalityTVItemID,
              disabled: false
            }, [  Validators.required ]],
          StreetName: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.StreetName,
              disabled: false
            }, [  Validators.maxLength(200) ]],
          StreetNumber: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.StreetNumber,
              disabled: false
            }, [  Validators.maxLength(50) ]],
          StreetType: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.StreetType,
              disabled: false
            }],
          PostalCode: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.PostalCode,
              disabled: false
            }, [  Validators.minLength(6), Validators.maxLength(11) ]],
          GoogleAddressText: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.GoogleAddressText,
              disabled: false
            }, [  Validators.minLength(10), Validators.maxLength(200) ]],
          LastUpdateDate_UTC: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.addressService.addressListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
        }
      );

      this.addressFormEdit = formGroup
    }
  }
}
