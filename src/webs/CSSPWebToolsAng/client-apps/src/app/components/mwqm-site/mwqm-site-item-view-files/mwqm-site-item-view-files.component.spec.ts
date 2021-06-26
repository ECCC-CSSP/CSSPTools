import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MWQMSiteItemViewFilesComponent } from 'src/app/components/mwqm-site/mwqm-site-item-view-files/mwqm-site-item-view-files.component';

describe('MWQMSiteItemViewFilesComponent', () => {
  let component: MWQMSiteItemViewFilesComponent;
  let fixture: ComponentFixture<MWQMSiteItemViewFilesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MWQMSiteItemViewFilesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MWQMSiteItemViewFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
