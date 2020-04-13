import { HttpErrorResponse } from '@angular/common/http';

export interface GenerateEnumsModel {
    CompareEnumsAndOldEnums?: string;
    EnumsGenerated_cs?: string;
    EnumsTestGenerated_cs?: string;
    GeneratePolSourceEnumCodeFiles?: string;
    Error?: HttpErrorResponse;
    Status?: string;
    Working?: boolean;
    StatusTitle?: string;
    WorkingText?: string;
}
