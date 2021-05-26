import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteItemModifyComponent } from 'src/app/components/mwqm-site/mwqm-site-item-modify/mwqm-site-item-modify.component';

describe('MWQMSiteItemModifyComponent', () => {
  let component: MWQMSiteItemModifyComponent;
  let fixture: ComponentFixture<MWQMSiteItemModifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
