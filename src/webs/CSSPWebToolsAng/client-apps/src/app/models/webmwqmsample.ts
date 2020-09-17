import { MWQMSample } from './generated/MWQMSample.model';
import { MWQMSampleLanguage } from './generated/MWQMSampleLanguage.model';
import { WebBase } from './webbase';

export class WebMWQMSample {
    TVItemParentList: WebBase[] = [];
    MWQMSampleList: MWQMSample[] = [];
    MWQMSampleLanguageList: MWQMSampleLanguage[] = [];
}
