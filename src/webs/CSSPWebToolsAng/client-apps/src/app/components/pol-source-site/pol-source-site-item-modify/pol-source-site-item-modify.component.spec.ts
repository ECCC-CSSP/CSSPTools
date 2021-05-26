import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteItemModifyComponent } from 'src/app/components/pol-source-site/pol-source-site-item-modify/pol-source-site-item-modify.component';

describe('PolSourceSiteItemModifyComponent', () => {
  let component: PolSourceSiteItemModifyComponent;
  let fixture: ComponentFixture<PolSourceSiteItemModifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
