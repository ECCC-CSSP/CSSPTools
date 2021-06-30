import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteLocalizeAllComponent } from 'src/app/components/pol-source-site/pol-source-site-localize-all/pol-source-site-localize-all.component';

describe('PolSourceSiteLocalizeAllComponent', () => {
  let component: PolSourceSiteLocalizeAllComponent;
  let fixture: ComponentFixture<PolSourceSiteLocalizeAllComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteLocalizeAllComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteLocalizeAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
