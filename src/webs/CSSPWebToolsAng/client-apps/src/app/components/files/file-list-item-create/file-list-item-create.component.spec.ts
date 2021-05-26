import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemCreateComponent } from 'src/app/components/files/file-list-item-create/file-list-item-create.component';

describe('FileListItemCreateComponent', () => {
  let component: FileListItemCreateComponent;
  let fixture: ComponentFixture<FileListItemCreateComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
