import { TestBed } from '@angular/core/testing';

import { GenerateServicesService } from './generate-services.service';

describe('ServicesService', () => {
  let service: GenerateServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GenerateServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
