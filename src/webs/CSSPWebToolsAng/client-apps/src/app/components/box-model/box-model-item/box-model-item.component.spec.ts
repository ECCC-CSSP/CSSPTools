import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoxModelItemComponent } from 'src/app/components/box-model/box-model-item/box-model-item.component';

describe('BoxModelItemComponent', () => {
  let component: BoxModelItemComponent;
  let fixture: ComponentFixture<BoxModelItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ BoxModelItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BoxModelItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
