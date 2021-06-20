import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemVisualPlumesComponent } from 'src/app/components/infrastructure/infrastructure-item-visual-plumes/infrastructure-item-visual-plumes.component';

describe('InfrastructureItemVisualPlumesComponent', () => {
  let component: InfrastructureItemVisualPlumesComponent;
  let fixture: ComponentFixture<InfrastructureItemVisualPlumesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemVisualPlumesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemVisualPlumesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
