import { WebRoot } from '../../models/generated/WebRoot.model';
import { WebBase } from '../../models/generated/WebBase.model';
import { HttpStatus } from '../../models/HttpStatus.model';

export interface RootVar extends HttpStatus {
    RootTitle?: string;
    WebRoot?: WebRoot;
    WebBaseCountryList?: WebBase[];
}
