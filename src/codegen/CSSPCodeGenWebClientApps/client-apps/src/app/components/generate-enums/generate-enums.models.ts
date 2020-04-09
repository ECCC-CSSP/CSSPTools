import { HttpErrorResponse } from '@angular/common/http';

export interface GenerateEnumsModel {
    CompareEnumsAndOldEnums?: string;
    CompareEnumsAndOldEnumsWorking?: boolean;
    EnumsGenerated_cs?: string;
    EnumsGenerated_csWorking?: boolean;
    EnumsTestGenerated_cs?: string;
    EnumsTestGenerated_csWorking?: boolean;
    GeneratePolSourceEnumCodeFiles?: string;
    GeneratePolSourceEnumCodeFilesWorking?: boolean;
    Error?: HttpErrorResponse;
    Status?: string;
    Working?: boolean;
}
