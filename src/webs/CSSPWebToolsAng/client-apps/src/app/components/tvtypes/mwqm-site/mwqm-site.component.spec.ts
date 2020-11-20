import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteComponent } from 'src/app/components/tvtypes/mwqm-site/mwqm-site.component';

describe('MWQMSiteComponent', () => {
  let component: MWQMSiteComponent;
  let fixture: ComponentFixture<MWQMSiteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
