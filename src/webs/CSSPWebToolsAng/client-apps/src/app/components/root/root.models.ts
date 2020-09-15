import { WebRoot } from '../../models/webroot';
import { HttpRequestModel } from '../../models/http.model';

export interface RootTextModel {
    Title?: string;
}

export interface WebRootModel extends HttpRequestModel  {
    WebRoot?: WebRoot;
}

