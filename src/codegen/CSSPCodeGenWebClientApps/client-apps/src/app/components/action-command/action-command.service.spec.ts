import { TestBed } from '@angular/core/testing';

import { ActionCommandService } from './action-command.service';

describe('ActionCommandService', () => {
  let service: ActionCommandService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ActionCommandService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
