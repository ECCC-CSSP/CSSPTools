import { TestBed } from '@angular/core/testing';

import { FileListItemDetailService } from './file-list-item-detail.service';

describe('FileListItemDetailService', () => {
  let service: FileListItemDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FileListItemDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
