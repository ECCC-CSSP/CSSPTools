import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteItemViewFilesComponent } from 'src/app/components/pol-source-site/pol-source-site-item-view-files/pol-source-site-item-view-files.component';

describe('PolSourceSiteItemViewFilesComponent', () => {
  let component: PolSourceSiteItemViewFilesComponent;
  let fixture: ComponentFixture<PolSourceSiteItemViewFilesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemViewFilesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemViewFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
