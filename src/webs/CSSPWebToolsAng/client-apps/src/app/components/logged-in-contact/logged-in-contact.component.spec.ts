import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LoggedInContactComponent } from './logged-in-contact.component';

describe('LoggedInContactComponent', () => {
  let component: LoggedInContactComponent;
  let fixture: ComponentFixture<LoggedInContactComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ LoggedInContactComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoggedInContactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
