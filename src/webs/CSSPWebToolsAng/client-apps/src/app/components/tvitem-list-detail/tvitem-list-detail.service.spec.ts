import { TestBed } from '@angular/core/testing';

import { TVItemListDetailService } from './tvitem-list-detail.service';

describe('TVItemListDetailService', () => {
  let service: TVItemListDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TVItemListDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
