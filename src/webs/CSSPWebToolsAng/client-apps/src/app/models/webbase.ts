import { HttpErrorResponse } from '@angular/common/http';

import { MapInfo } from './generated/MapInfo.model';
import { MapInfoPoint } from './generated/MapInfoPoint.model';
import { TVFile } from './generated/TVFile.model';
import { TVFileLanguage } from './generated/TVFileLanguage.model';
import { TVItem } from './generated/TVItem.model';
import { TVItemLanguage } from './generated/TVItemLanguage.model';
import { TVItemStat } from './generated/TVItemStat.model';

export class WebBase {
    TVItemModel: TVItemModel = new TVItemModel();
}

export class TVItemModel {
    TVItem: TVItem = new TVItem();
    TVItemLanguageEN: TVItemLanguage = new TVItemLanguage();
    TVItemLanguageFR: TVItemLanguage = new TVItemLanguage();
    TVItemStatList: TVItemStat[] = [];
    MapInfoModelList: MapInfoModel[] = [];
    TVFileModelList: TVFileModel[] = [];
}

export class MapInfoModel {
    MapInfo: MapInfo = new MapInfo();
    MapInfoPointList: MapInfoPoint[] = [];
}

export class TVFileModel {
    TVFile: TVFile = new TVFile();
    TVFileLanguageEN: TVFileLanguage = new TVFileLanguage();
    TVFileLanguageFR: TVFileLanguage = new TVFileLanguage();
}
