import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactItemComponent } from 'src/app/components/contact/contact-item/contact-item.component';

describe('ContactItemComponent', () => {
  let component: ContactItemComponent;
  let fixture: ComponentFixture<ContactItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ContactItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
