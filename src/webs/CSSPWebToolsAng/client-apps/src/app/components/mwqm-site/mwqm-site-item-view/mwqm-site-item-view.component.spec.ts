import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteItemViewComponent } from 'src/app/components/mwqm-site/mwqm-site-item-view/mwqm-site-item-view.component';

describe('MWQMSiteItemViewComponent', () => {
  let component: MWQMSiteItemViewComponent;
  let fixture: ComponentFixture<MWQMSiteItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
