import { HttpErrorResponse } from '@angular/common/http';

export interface HttpStatus
{
    Working?: boolean;
    Error?: HttpErrorResponse;
    Status?: string;
}
