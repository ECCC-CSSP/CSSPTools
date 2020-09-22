import { TestBed } from '@angular/core/testing';

import { LoggedInContactService } from './logged-in-contact.service';

describe('LoggedInContactService', () => {
  let service: LoggedInContactService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoggedInContactService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
