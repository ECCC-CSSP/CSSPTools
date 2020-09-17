import { DrogueRun } from './generated/DrogueRun.model';
import { DrogueRunPosition } from './generated/DrogueRunPosition.model';
import { WebBase } from './webbase';

export class WebDrogueRun {
    TVItemParentList: WebBase[] = [];
    DrogueRunList: DrogueRun[] = [];
    DrogueRunPositionList: DrogueRunPosition[] = [];
}
