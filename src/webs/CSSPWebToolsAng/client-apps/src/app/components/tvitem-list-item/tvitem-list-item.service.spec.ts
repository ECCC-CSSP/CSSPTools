import { TestBed } from '@angular/core/testing';

import { TVItemListItemService } from './tvitem-list-item.service';

describe('TVItemListItemService', () => {
  let service: TVItemListItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TVItemListItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
