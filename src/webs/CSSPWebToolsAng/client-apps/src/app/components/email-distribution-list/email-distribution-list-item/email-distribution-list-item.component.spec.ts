import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailDistributionListItemComponent } from 'src/app/components/email-distribution-list/email-distribution-list-item/email-distribution-list-item.component';

describe('EmailDistributionListItemComponent', () => {
  let component: EmailDistributionListItemComponent;
  let fixture: ComponentFixture<EmailDistributionListItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ EmailDistributionListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailDistributionListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
