import { TestBed } from '@angular/core/testing';

import { FileListService } from './file-list.service';

describe('FileListService', () => {
  let service: FileListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FileListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
