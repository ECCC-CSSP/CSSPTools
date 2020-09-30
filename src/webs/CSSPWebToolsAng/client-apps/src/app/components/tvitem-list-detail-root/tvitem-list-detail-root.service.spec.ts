import { TestBed } from '@angular/core/testing';

import { TVItemListDetailRootService } './tvitem-list-detail-root.service';

describe('TVItemListDetailRootService', () => {
  let service: TVItemListDetailRootService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TVItemListDetailRootService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
