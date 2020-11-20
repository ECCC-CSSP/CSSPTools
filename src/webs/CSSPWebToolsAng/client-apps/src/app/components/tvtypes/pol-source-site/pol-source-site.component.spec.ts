import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteComponent } from 'src/app/components/tvtypes/pol-source-site/pol-source-site.component';

describe('PolSourceSiteComponent', () => {
  let component: PolSourceSiteComponent;
  let fixture: ComponentFixture<PolSourceSiteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
