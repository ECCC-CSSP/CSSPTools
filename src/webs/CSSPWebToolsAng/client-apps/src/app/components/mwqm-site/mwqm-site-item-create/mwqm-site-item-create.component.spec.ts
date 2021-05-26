import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteItemCreateComponent } from 'src/app/components/mwqm-site/mwqm-site-item-create/mwqm-site-item-create.component';

describe('MWQMSiteItemCreateComponent', () => {
  let component: MWQMSiteItemCreateComponent;
  let fixture: ComponentFixture<MWQMSiteItemCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
