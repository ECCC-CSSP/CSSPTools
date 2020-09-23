import { HttpErrorResponse } from '@angular/common/http';

export interface HttpRequestModel
{
    Working?: boolean;
    Error?: HttpErrorResponse;
    Status?: string;
}
