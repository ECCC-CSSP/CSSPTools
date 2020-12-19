import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MunicipalityItemComponent } from 'src/app/components/municipality/municipality-item/municipality-item.component';

describe('MunicipalityItemComponent', () => {
  let component: MunicipalityItemComponent;
  let fixture: ComponentFixture<MunicipalityItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MunicipalityItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MunicipalityItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
