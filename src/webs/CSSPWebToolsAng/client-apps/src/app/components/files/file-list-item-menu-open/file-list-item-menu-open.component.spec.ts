import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FileListItemMenuOpenComponent } from 'src/app/components/files/file-list-item-menu-open/file-list-item-menu-open.component';

describe('FileListItemMenuOpenComponent', () => {
  let component: FileListItemMenuOpenComponent;
  let fixture: ComponentFixture<FileListItemMenuOpenComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ FileListItemMenuOpenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileListItemMenuOpenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
