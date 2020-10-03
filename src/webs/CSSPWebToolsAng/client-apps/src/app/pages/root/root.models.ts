import { HttpRequestModel } from '../../models/HttpRequest.model';
import { WebRoot } from '../../models/generated/WebRoot.model';
import { WebBase } from '../../models/generated/WebBase.model';

export interface RootTextModel {
    Title?: string;
}

export interface WebRootModel extends HttpRequestModel  {
    WebRoot?: WebRoot;
}

export interface WebBaseCountryModel extends HttpRequestModel  {
    WebBaseCountryList?: WebBase[];
}

