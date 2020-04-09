import { TestBed } from '@angular/core/testing';

import { GenerateAngularService } from './generate-angular.service';

describe('GenerateAngularService', () => {
  let service: GenerateAngularService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GenerateAngularService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
