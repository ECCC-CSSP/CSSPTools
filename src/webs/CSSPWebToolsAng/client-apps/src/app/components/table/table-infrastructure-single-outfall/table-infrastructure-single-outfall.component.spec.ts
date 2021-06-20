import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableInfrastructureSingleOutfallComponent } from 'src/app/components/table/table-infrastructure-single-outfall/table-infrastructure-single-outfall.component';

describe('TableInfrastructureSingleOutfallComponent', () => {
  let component: TableInfrastructureSingleOutfallComponent;
  let fixture: ComponentFixture<TableInfrastructureSingleOutfallComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableInfrastructureSingleOutfallComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableInfrastructureSingleOutfallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
