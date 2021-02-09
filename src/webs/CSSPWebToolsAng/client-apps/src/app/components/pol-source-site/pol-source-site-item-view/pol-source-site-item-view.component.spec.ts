import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteItemViewComponent } from 'src/app/components/pol-source-site/pol-source-site-item-view/pol-source-site-item-view.component';

describe('PolSourceSiteItemViewComponent', () => {
  let component: PolSourceSiteItemViewComponent;
  let fixture: ComponentFixture<PolSourceSiteItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
