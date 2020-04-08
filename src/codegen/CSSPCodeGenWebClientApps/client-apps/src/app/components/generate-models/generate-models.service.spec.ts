import { TestBed } from '@angular/core/testing';

import { GenerateModelsService } from './generate-models.service';

describe('GenerateModelsService', () => {
  let service: GenerateModelsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GenerateModelsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
