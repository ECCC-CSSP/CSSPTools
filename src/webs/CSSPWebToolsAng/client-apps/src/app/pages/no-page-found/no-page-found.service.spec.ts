import { TestBed } from '@angular/core/testing';

import { NoPageFoundService } from './no-page-found.service';

describe('NoPageFoundService', () => {
  let service: NoPageFoundService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NoPageFoundService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
