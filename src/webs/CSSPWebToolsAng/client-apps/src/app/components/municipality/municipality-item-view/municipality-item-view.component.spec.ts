import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MunicipalityItemViewComponent } from 'src/app/components/municipality/municipality-item-view/municipality-item-view.component';

describe('MunicipalityItemViewComponent', () => {
  let component: MunicipalityItemViewComponent;
  let fixture: ComponentFixture<MunicipalityItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ MunicipalityItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MunicipalityItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy(); 
  });
});
