import { HttpRequestModel } from '../../models/HttpRequest.model';
import { WebRoot } from '../../models/generated/WebRoot.model';

export interface RootTextModel {
    Title?: string;
}

export interface WebRootModel extends HttpRequestModel  {
    WebRoot?: WebRoot;
}

