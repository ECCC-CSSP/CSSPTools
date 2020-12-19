import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteItemEditComponent } from 'src/app/components/pol-source-site/pol-source-site-item-edit/pol-source-site-item-edit.component';

describe('PolSourceSiteItemEditComponent', () => {
  let component: PolSourceSiteItemEditComponent;
  let fixture: ComponentFixture<PolSourceSiteItemEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
