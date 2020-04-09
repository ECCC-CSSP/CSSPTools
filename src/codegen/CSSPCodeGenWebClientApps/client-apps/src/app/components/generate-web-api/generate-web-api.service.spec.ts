import { TestBed } from '@angular/core/testing';

import { GenerateWebAPIService } from './generate-web-api.service';

describe('GenerateWebAPIService', () => {
  let service: GenerateWebAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GenerateWebAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
