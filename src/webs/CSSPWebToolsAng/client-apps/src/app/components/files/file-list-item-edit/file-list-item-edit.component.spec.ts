import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemEditComponent } from 'src/app/components/files/file-list-item-edit/file-list-item-edit.component';

describe('FileListItemEditComponent', () => {
  let component: FileListItemEditComponent;
  let fixture: ComponentFixture<FileListItemEditComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
