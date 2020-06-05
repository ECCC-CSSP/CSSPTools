import { AddressTextModel } from './address.models';
import { AddressService } from './address.service';

export function LoadLocalesAddressText(addressService: AddressService) {
  let addressTextModel: AddressTextModel = { 
    Title: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      addressTextModel.Title = 'Le Titre';
    }

  addressService.UpdateAddressText(addressTextModel);
}
