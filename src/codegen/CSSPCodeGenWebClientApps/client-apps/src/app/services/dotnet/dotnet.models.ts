import { HttpErrorResponse } from '@angular/common/http';

export interface DotNetModel {
    // DotNetTemp?: string;
    Error?: HttpErrorResponse;
    Status?: string;
    Working?: boolean;
    CurrentStatus?: string;
    WorkingText?: string;
}
