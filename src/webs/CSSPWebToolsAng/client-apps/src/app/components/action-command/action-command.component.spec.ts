import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionCommandComponent } from './action-command.component';

describe('ActionCommandComponent', () => {
  let component: ActionCommandComponent;
  let fixture: ComponentFixture<ActionCommandComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActionCommandComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActionCommandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
