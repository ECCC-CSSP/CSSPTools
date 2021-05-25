import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvinceItemCreateComponent } from 'src/app/components/country/country-item-create/country-item-create.component';

describe('ProvinceItemCreateComponent', () => {
  let component: ProvinceItemCreateComponent;
  let fixture: ComponentFixture<ProvinceItemCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvinceItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinceItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
