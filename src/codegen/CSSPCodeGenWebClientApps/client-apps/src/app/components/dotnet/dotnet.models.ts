import { HttpErrorResponse } from '@angular/common/http';

export interface DotNetModel {
    CompareEnumsAndOldEnums?: string;
    EnumsGenerated_cs?: string;
    EnumsTestGenerated_cs?: string;
    GeneratePolSourceEnumCodeFiles?: string;
    CurrentStatus?: string;
    WorkingText?: string;
    DotNetActionCommandList?: DotNetActionCommand[];
}

export interface DotNetActionCommand
{
    Action: string;
    FileName: string;
    StatusOnly?: boolean;
    Error?: HttpErrorResponse;
    Status?: string;
    Working?: boolean;
}
