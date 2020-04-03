import { TestBed } from '@angular/core/testing';

import { AppCodeService } from './app-code.service';

describe('AppCodeService', () => {
  let service: AppCodeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppCodeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
