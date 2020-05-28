import { TestBed } from '@angular/core/testing';

import { GroupingService } from './grouping.service';

describe('GroupingService', () => {
  let service: GroupingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GroupingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
