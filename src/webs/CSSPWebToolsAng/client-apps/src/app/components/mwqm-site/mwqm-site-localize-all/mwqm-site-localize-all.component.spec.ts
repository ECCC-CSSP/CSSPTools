import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteLocalizeAllComponent } from 'src/app/components/mwqm-site/mwqm-site-localize-all/mwqm-site-localize-all.component';

describe('MWQMSiteLocalizeAllComponent', () => {
  let component: MWQMSiteLocalizeAllComponent;
  let fixture: ComponentFixture<MWQMSiteLocalizeAllComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteLocalizeAllComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteLocalizeAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
