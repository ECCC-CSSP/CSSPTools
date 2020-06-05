import { HttpRequestModel } from '../../models/http.model';
import { Address } from 'src/app/models/generated/Address.model';

export interface AddressTextModel {
    Title?: string
}

export interface AddressModel extends HttpRequestModel {
    AddressList: Address[];
}
