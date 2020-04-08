import { TestBed } from '@angular/core/testing';

import { GenerateEnumsService } from './generate-enums.service';

describe('GenerateEnumsService', () => {
  let service: GenerateEnumsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GenerateEnumsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
