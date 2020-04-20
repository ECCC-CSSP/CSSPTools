import { HttpErrorResponse } from '@angular/common/http';

export interface GenerateModelsModel {
    Models_ModelClassName_Test?: string;
    ModelsGenerated_cs?: string;
    ModelsTestGenerated_cs?: string;
    GeneratePolSourceEnumCodeFiles?: string;
    Error?: HttpErrorResponse;
    Status?: string;
    Working?: boolean;
    CurrentStatus?: string;
    WorkingText?: string;
}
