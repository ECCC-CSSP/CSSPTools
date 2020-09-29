import { TestBed } from '@angular/core/testing';

import { SideNavMenuService } from './sidenav-menu.service';

describe('SideNavMenuService', () => {
  let service: SideNavMenuService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SideNavMenuService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
