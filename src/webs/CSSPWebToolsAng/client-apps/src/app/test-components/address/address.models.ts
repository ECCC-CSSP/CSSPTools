import { HttpRequestModel } from '../../models/http.model';
import { Address } from 'src/app/interfaces/generated/Address.interface';

export interface AddressTextModel {
    Title?: string
}

export interface AddressModel extends HttpRequestModel {
    AddressList: Address[];
    ObjKeys: string[];
}
