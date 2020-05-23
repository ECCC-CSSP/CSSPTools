import { HttpErrorResponse } from '@angular/common/http';

export interface ActionCommandTextModel {
    CurrentStatus?: string;
    WorkingText?: string;
}

export interface ActionCommandModel {
    ActionCommandList: ActionCommand[];
}

export interface ActionCommand
{
    ActionCommandID?: string;
    Action: string;
    Command: string;
    FullFileName?: string;
    Description?: string;
    TempStatusText?: string;
    ErrorText?: string;
    ExecutionStatusText?: string;
    FilesStatusText?: string;
    PercentCompleted?: number;
    LastUpdateDate?: Date;

    ViewDetails?: boolean;
    Error?: HttpErrorResponse;
    Status?: string;
    Working?: boolean;
}
