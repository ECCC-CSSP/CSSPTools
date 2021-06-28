import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactItemModifyComponent } from 'src/app/components/contact/contact-item-modify/contact-item-modify.component';

describe('ContactItemModifyComponent', () => {
  let component: ContactItemModifyComponent;
  let fixture: ComponentFixture<ContactItemModifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ContactItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
