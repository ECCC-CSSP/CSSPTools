import { TestBed } from '@angular/core/testing';

import { AppShellService } from './app-shell.service';

describe('AppShellService', () => {
  let service: AppShellService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppShellService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
