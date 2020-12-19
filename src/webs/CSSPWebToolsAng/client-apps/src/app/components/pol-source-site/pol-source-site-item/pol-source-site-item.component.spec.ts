import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteItemComponent } from 'src/app/components/pol-source-site/pol-source-site-item/pol-source-site-item.component';

describe('PolSourceSiteItemComponent', () => {
  let component: PolSourceSiteItemComponent;
  let fixture: ComponentFixture<PolSourceSiteItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
