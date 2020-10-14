import { Contact } from 'src/app/models/generated/Contact.model';
import { HttpStatus } from 'src/app/models/HttpStatus.model';

export interface LoggedInContactVar extends HttpStatus  {
    LoggedInContactTitle?: string
    Contact?: Contact;
}

