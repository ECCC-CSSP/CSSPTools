import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailDistributionListComponent } from 'src/app/components/tvtypes/email-distribution-list/email-distribution-list.component';

describe('EmailDistributionListComponent', () => {
  let component: EmailDistributionListComponent;
  let fixture: ComponentFixture<EmailDistributionListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ EmailDistributionListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailDistributionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
