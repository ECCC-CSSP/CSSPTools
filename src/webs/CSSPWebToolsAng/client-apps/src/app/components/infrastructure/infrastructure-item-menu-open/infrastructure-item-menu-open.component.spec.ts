import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemMenuOpenComponent } from 'src/app/components/infrastructure/infrastructure-item-menu-open/infrastructure-item-menu-open.component';

describe('InfrastructureItemMenuOpenComponent', () => {
  let component: InfrastructureItemMenuOpenComponent;
  let fixture: ComponentFixture<InfrastructureItemMenuOpenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemMenuOpenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemMenuOpenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
