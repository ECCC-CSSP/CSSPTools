/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AddressService } from './address.service';
import { LoadLocalesAddressText } from './address.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AddressTypeEnum_GetIDText, AddressTypeEnum_GetOrderedText } from '../../../enums/generated/AddressTypeEnum';
import { StreetTypeEnum_GetIDText, StreetTypeEnum_GetOrderedText } from '../../../enums/generated/StreetTypeEnum';
import { Address } from '../../../models/generated/Address.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from 'src/app/models/enumidandtext.model';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddressComponent implements OnInit, OnDestroy {
  sub: Subscription;
  addressTypeList: EnumIDAndText[];
  streetTypeList: EnumIDAndText[];
  addressFormPut: FormGroup;
  addressFormPost: FormGroup;

  constructor(public addressService: AddressService, public router: Router, public fb: FormBuilder) { }

  GetAddressList() {
    this.sub = this.addressService.GetAddressList(this.router).subscribe();
  }

  PutAddress(address: Address) {
    this.sub = this.addressService.PutAddress(address, this.router).subscribe();
  }

  PostAddress(address: Address) {
    this.sub = this.addressService.PostAddress(address, this.router).subscribe();
  }

  DeleteAddress(address: Address) {
    this.sub = this.addressService.DeleteAddress(address, this.router).subscribe();
  }

  GetAddressTypeEnumText(enumID: number) {
    return AddressTypeEnum_GetIDText(enumID)
  }

  GetStreetTypeEnumText(enumID: number) {
    return StreetTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesAddressText(this.addressService);
    this.addressTypeList = AddressTypeEnum_GetOrderedText();
    this.streetTypeList = StreetTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.addressService.addressList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          AddressID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.addressService.addressList[0]?.AddressID ?? '')),
              disabled: false
            }, Validators.required],
          AddressTVItemID: [
            {
              value: this.addressService.addressList[0]?.AddressTVItemID ?? '',
              disabled: false
            }, Validators.required],
          AddressType: [
            {
              value: this.addressService.addressList[0]?.AddressType ?? '',
              disabled: false
            }, Validators.required],
          CountryTVItemID: [
            {
              value: this.addressService.addressList[0]?.CountryTVItemID ?? '',
              disabled: false
            }, Validators.required],
          ProvinceTVItemID: [
            {
              value: this.addressService.addressList[0]?.ProvinceTVItemID ?? '',
              disabled: false
            }, Validators.required],
          MunicipalityTVItemID: [
            {
              value: this.addressService.addressList[0]?.MunicipalityTVItemID ?? '',
              disabled: false
            }, Validators.required],
          StreetName: [
            {
              value: this.addressService.addressList[0]?.StreetName ?? '',
              disabled: false
            }, Validators.required],
          StreetNumber: [
            {
              value: this.addressService.addressList[0]?.StreetNumber ?? '',
              disabled: false
            }, Validators.required],
          StreetType: [
            {
              value: this.addressService.addressList[0]?.StreetType ?? '',
              disabled: false
            }, Validators.required],
          PostalCode: [
            {
              value: this.addressService.addressList[0]?.PostalCode ?? '',
              disabled: false
            }, Validators.required],
          GoogleAddressText: [
            {
              value: this.addressService.addressList[0]?.GoogleAddressText ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateDate_UTC: [
            {
              value: this.addressService.addressList[0]?.LastUpdateDate_UTC ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateContactTVItemID: [
            {
              value: this.addressService.addressList[0]?.LastUpdateContactTVItemID ?? '',
              disabled: false
            }, Validators.required],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.addressFormPost = formGroup
      }
      else {
        this.addressFormPut = formGroup;
      }
    }
  }
}
