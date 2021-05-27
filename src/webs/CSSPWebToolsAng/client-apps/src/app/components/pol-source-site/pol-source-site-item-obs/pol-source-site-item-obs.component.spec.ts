import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteItemObsComponent } from 'src/app/components/pol-source-site/pol-source-site-item-obs/pol-source-site-item-obs.component';

describe('PolSourceSiteItemObsComponent', () => {
  let component: PolSourceSiteItemObsComponent;
  let fixture: ComponentFixture<PolSourceSiteItemObsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemObsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemObsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
