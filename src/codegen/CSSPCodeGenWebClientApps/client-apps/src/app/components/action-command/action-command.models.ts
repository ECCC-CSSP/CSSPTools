import { HttpRequestModel } from 'src/app/models/http.model';

export interface ActionCommandTextModel {
    CurrentStatus?: string;
    WorkingText?: string;
}

export interface GetAllModel extends HttpRequestModel {

}

export interface RefillAllModel extends HttpRequestModel {
    
}

export interface ActionCommandModel {
    ActionCommandList: ActionCommand[];
}

export interface ActionCommand extends HttpRequestModel
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
}
