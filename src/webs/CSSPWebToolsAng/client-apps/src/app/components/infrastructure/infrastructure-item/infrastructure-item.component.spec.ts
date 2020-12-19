import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemComponent } from 'src/app/components/infrastructure/infrastructure-item/infrastructure-item.component';

describe('InfrastructureItemComponent', () => {
  let component: InfrastructureItemComponent;
  let fixture: ComponentFixture<InfrastructureItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
