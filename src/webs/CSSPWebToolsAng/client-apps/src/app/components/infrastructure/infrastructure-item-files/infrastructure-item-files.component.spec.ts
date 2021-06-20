import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfrastructureItemFilesComponent } from 'src/app/components/infrastructure/infrastructure-item-files/infrastructure-item-files.component';

describe('InfrastructureItemFilesComponent', () => {
  let component: InfrastructureItemFilesComponent;
  let fixture: ComponentFixture<InfrastructureItemFilesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ InfrastructureItemFilesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InfrastructureItemFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
