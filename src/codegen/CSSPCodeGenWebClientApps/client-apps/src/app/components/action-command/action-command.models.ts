import { HttpErrorResponse } from '@angular/common/http';

export interface ActionCommandModel {
    CurrentStatus?: string;
    WorkingText?: string;
    DotNetActionCommandList?: ActionCommand[];
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

    StatusOnly?: boolean;
    Error?: HttpErrorResponse;
    Status?: string;
    Working?: boolean;
}
