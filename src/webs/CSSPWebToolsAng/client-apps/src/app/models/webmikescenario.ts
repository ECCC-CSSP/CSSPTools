import { MikeBoundaryCondition } from './generated/MikeBoundaryCondition.model';
import { MikeScenario } from './generated/MikeScenario.model';
import { MikeSource } from './generated/MikeSource.model';
import { MikeSourceStartEnd } from './generated/MikeSourceStartEnd.model';
import { WebBase } from './webbase';

export class WebMikeScenario extends WebBase {
    TVItemParentList: WebBase[] = [];
    MikeScenario: MikeScenario = new MikeScenario();
    MikeSourceModelList: MikeSourceModel[] = [];
    MikeBoundaryConditionModelWebTideList: MikeBoundaryConditionModel[] = [];
    MikeBoundaryConditionModelMeshList: MikeBoundaryConditionModel[] = [];
}

export class MikeSourceModel extends WebBase {
    MikeSource: MikeSource = new MikeSource();
    MikeSourceStartEndList: MikeSourceStartEnd[] = [];
}

export class MikeBoundaryConditionModel extends WebBase {
    MikeBoundaryConditionList: MikeBoundaryCondition[] = [];
}