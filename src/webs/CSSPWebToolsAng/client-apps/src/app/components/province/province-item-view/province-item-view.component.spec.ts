import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvinceItemViewComponent } from 'src/app/components/province/province-item-view/province-item-view.component';

describe('ProvinceItemViewComponent', () => {
  let component: ProvinceItemViewComponent;
  let fixture: ComponentFixture<ProvinceItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvinceItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinceItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
