import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemViewComponent } from 'src/app/components/infrastructure/infrastructure-item-view/infrastructure-item-view.component';

describe('InfrastructureItemViewComponent', () => {
  let component: InfrastructureItemViewComponent;
  let fixture: ComponentFixture<InfrastructureItemViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
