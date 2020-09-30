import { TestBed } from '@angular/core/testing';

import { TVItemListDetailProvinceService } from './tvitem-list-detail-province.service';

describe('TVItemListDetailProvinceService', () => {
  let service: TVItemListDetailProvinceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TVItemListDetailProvinceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
