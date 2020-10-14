import { HttpStatus } from '../../models/HttpStatus.model';

export interface ChildCountVar extends HttpStatus {
    ChildCountTitle?: string
    Count: number;
}
