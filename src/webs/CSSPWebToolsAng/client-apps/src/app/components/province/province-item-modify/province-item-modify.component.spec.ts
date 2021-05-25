import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvinceItemModifyComponent } from 'src/app/components/province/province-item-modify/province-item-modify.component';

describe('ProvinceItemModifyComponent', () => {
  let component: ProvinceItemModifyComponent;
  let fixture: ComponentFixture<ProvinceItemModifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvinceItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinceItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
