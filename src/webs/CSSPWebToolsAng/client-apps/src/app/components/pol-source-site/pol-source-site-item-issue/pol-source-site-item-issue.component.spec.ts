import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolSourceSiteItemIssueComponent } from 'src/app/components/pol-source-site/pol-source-site-item-issue/pol-source-site-item-issue.component';

describe('PolSourceSiteItemIssueComponent', () => {
  let component: PolSourceSiteItemIssueComponent;
  let fixture: ComponentFixture<PolSourceSiteItemIssueComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ PolSourceSiteItemIssueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolSourceSiteItemIssueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
