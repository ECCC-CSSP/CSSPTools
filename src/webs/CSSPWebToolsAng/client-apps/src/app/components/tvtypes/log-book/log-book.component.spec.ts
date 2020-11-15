import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogBookComponent } from 'src/app/components/tvtypes/log-book/log-book.component';

describe('LogBookComponent', () => {
  let component: LogBookComponent;
  let fixture: ComponentFixture<LogBookComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ LogBookComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LogBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
