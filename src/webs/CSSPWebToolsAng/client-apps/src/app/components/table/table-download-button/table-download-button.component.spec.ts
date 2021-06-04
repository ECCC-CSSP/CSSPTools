import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableDownloadButtonComponent } from 'src/app/components/table/table-download-button/table-download-button.component';

describe('TableDownloadButtonComponent', () => {
  let component: TableDownloadButtonComponent;
  let fixture: ComponentFixture<TableDownloadButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableDownloadButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableDownloadButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
