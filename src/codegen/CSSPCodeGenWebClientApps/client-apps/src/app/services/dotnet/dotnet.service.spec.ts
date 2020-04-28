import { TestBed } from '@angular/core/testing';

import { DotNetService } from './dotnet.service';

describe('DotNetService', () => {
  let service: DotNetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DotNetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
