import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogBookItemComponent } from 'src/app/components/log-book/log-book-item/log-book-item.component';

describe('LogBookItemComponent', () => {
  let component: LogBookItemComponent;
  let fixture: ComponentFixture<LogBookItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ LogBookItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LogBookItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
