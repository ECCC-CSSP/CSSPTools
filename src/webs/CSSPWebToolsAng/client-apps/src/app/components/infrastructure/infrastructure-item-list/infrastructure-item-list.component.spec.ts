import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemListComponent } from 'src/app/components/infrastructure/infrastructure-item-list/infrastructure-item-list.component';

describe('InfrastructureItemListComponent', () => {
  let component: InfrastructureItemListComponent;
  let fixture: ComponentFixture<InfrastructureItemListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
