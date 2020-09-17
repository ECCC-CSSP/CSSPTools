import { MWQMRun } from './generated/MWQMRun.model';
import { MWQMRunLanguage } from './generated/MWQMRunLanguage.model';
import { WebBase } from './webbase';

export class WebMWQMRun {
    TVItemParentList: WebBase[] = [];
    MWQMRunModelList: MWQMRunModel[] = [];
}

export class MWQMRunModel extends WebBase {
    MWQMRun: MWQMRun = new MWQMRun();
    MWQMRunLanguageList: MWQMRunLanguage[] = [];
}
