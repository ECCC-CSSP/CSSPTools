import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemModifyComponent } from 'src/app/components/infrastructure/infrastructure-item-modify/infrastructure-item-modify.component';

describe('InfrastructureItemModifyComponent', () => {
  let component: InfrastructureItemModifyComponent;
  let fixture: ComponentFixture<InfrastructureItemModifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
