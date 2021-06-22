import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoxModelItemInputComponent } from 'src/app/components/box-model/box-model-item-input/box-model-item-input.component';

describe('BoxModelItemInputComponent', () => {
  let component: BoxModelItemInputComponent;
  let fixture: ComponentFixture<BoxModelItemInputComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ BoxModelItemInputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BoxModelItemInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
