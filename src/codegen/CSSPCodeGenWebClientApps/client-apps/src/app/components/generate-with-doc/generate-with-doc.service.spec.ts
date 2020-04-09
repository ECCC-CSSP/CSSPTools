import { TestBed } from '@angular/core/testing';

import { GenerateWithDocService } from './generate-with-doc.service';

describe('GenerateWithDocService', () => {
  let service: GenerateWithDocService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GenerateWithDocService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
