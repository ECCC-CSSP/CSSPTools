import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteItemCreateComponent } from 'src/app/components/pol-source-site/pol-source-site-item-create/pol-source-site-item-create.component';

describe('PolSourceSiteItemCreateComponent', () => {
  let component: PolSourceSiteItemCreateComponent;
  let fixture: ComponentFixture<PolSourceSiteItemCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
