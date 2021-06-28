import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactItemViewComponent } from 'src/app/components/contact/contact-item-view/contact-item-view.component';

describe('ContactItemViewComponent', () => {
  let component: ContactItemViewComponent;
  let fixture: ComponentFixture<ContactItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ContactItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
