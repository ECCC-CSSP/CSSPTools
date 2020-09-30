import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { HttpRequestModel } from 'src/app/models';

export interface ChildCountTextModel extends HttpRequestModel {
    Title?: string
}

export interface ChildCountModel extends HttpRequestModel {
    Count: number;
}
