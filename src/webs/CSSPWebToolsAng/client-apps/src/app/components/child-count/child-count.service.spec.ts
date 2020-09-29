import { TestBed } from '@angular/core/testing';

import { ChildCountService } from './child-count.service';

describe('ChildCountService', () => {
  let service: ChildCountService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChildCountService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
