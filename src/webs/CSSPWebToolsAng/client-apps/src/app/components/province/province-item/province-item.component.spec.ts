import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvinceItemComponent } from 'src/app/components/province/province-item/province-item.component';

describe('ProvinceItemComponent', () => {
  let component: ProvinceItemComponent;
  let fixture: ComponentFixture<ProvinceItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvinceItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinceItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
