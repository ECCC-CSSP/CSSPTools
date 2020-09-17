import { TestBed } from '@angular/core/testing';

import { WebApiNotFoundService } from './web-api-not-found.service';

describe('WebApiNotFoundService', () => {
  let service: WebApiNotFoundService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WebApiNotFoundService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
