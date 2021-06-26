import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteItemViewTablesComponent } from 'src/app/components/mwqm-site/mwqm-site-item-view-tables/mwqm-site-item-view-tables.component';

describe('MWQMSiteItemViewTablesComponent', () => {
  let component: MWQMSiteItemViewTablesComponent;
  let fixture: ComponentFixture<MWQMSiteItemViewTablesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemViewTablesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemViewTablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
