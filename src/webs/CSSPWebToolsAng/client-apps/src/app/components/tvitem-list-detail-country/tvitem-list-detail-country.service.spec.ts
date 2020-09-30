import { TestBed } from '@angular/core/testing';

import { TVItemListDetailCountryService } './tvitem-list-detail-country.service';

describe('TVItemListDetailCountryService', () => {
  let service: TVItemListDetailCountryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TVItemListDetailCountryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
