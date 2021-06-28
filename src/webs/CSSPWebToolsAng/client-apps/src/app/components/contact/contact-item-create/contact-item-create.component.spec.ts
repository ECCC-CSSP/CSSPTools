import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactItemCreateComponent } from 'src/app/components/contact/contact-item-create/contact-item-create.component';

describe('ContactItemCreateComponent', () => {
  let component: ContactItemCreateComponent;
  let fixture: ComponentFixture<ContactItemCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ContactItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
