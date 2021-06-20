import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemCreateComponent } from 'src/app/components/infrastructure/infrastructure-item-create/infrastructure-item-create.component';

describe('InfrastructureItemCreateComponent', () => {
  let component: InfrastructureItemCreateComponent;
  let fixture: ComponentFixture<InfrastructureItemCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
