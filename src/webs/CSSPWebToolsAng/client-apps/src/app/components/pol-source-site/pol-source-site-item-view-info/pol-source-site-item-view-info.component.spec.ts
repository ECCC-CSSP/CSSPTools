import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteItemViewInfoComponent } from 'src/app/components/pol-source-site/pol-source-site-item-view-info/pol-source-site-item-view-info.component';

describe('PolSourceSiteItemViewInfoComponent', () => {
  let component: PolSourceSiteItemViewInfoComponent;
  let fixture: ComponentFixture<PolSourceSiteItemViewInfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemViewInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemViewInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
