import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteItemComponent } from 'src/app/components/mwqm-site/mwqm-site-item/mwqm-site-item.component';

describe('MWQMSiteItemComponent', () => {
  let component: MWQMSiteItemComponent;
  let fixture: ComponentFixture<MWQMSiteItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
