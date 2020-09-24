import { TestBed } from '@angular/core/testing';

import { TVItemListService } from './tvitem-list.service';

describe('TVItemListService', () => {
  let service: TVItemListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TVItemListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
