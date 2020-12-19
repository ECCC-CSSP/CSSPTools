import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteItemEditComponent } from 'src/app/components/mwqm-site/mwqm-site-item-edit/mwqm-site-item-edit.component';

describe('MWQMSiteItemEditComponent', () => {
  let component: MWQMSiteItemEditComponent;
  let fixture: ComponentFixture<MWQMSiteItemEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
