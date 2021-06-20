import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemInformationComponent } from 'src/app/components/infrastructure/infrastructure-item-information/infrastructure-item-information.component';

describe('InfrastructureItemInformationComponent', () => {
  let component: InfrastructureItemInformationComponent;
  let fixture: ComponentFixture<InfrastructureItemInformationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemInformationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
