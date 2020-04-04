import { TestBed } from '@angular/core/testing';

import { AppNoPageFoundService } from './app-no-page-found.service';

describe('AppNoPageFoundService', () => {
  let service: AppNoPageFoundService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppNoPageFoundService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
