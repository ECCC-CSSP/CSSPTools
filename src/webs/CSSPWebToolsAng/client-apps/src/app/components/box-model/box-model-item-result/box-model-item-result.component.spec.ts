
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoxModelItemResultComponent } from 'src/app/components/box-model/box-model-item-result/box-model-item-result.component';

describe('BoxModelItemResultComponent', () => {
  let component: BoxModelItemResultComponent;
  let fixture: ComponentFixture<BoxModelItemResultComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ BoxModelItemResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BoxModelItemResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
