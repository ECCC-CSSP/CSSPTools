import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileSortMenuComponent } from 'src/app/components/files/file-sort-menu/file-sort-menu.component';

describe('FileSortMenuComponent', () => {
  let component: FileSortMenuComponent;
  let fixture: ComponentFixture<FileSortMenuComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileSortMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileSortMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
