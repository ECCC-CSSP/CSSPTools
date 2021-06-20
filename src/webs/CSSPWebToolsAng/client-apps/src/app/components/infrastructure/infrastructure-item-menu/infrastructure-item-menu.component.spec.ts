import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemMenuComponent } from 'src/app/components/infrastructure/infrastructure-item-menu/infrastructure-item-menu.component';

describe('InfrastructureItemMenuComponent', () => {
  let component: InfrastructureItemMenuComponent;
  let fixture: ComponentFixture<InfrastructureItemMenuComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
