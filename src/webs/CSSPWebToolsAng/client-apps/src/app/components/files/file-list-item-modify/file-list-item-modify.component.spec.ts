import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemModifyComponent } from 'src/app/components/files/file-list-item-modify/file-list-item-modify.component';

describe('FileListItemModifyComponent', () => {
  let component: FileListItemModifyComponent;
  let fixture: ComponentFixture<FileListItemModifyComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
