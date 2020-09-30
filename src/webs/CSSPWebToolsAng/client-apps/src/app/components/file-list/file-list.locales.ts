import { FileListTextModel } from './file-list.models';
import { FileListService } from './file-list.service';

export function LoadLocalesFileListText(FileListService: FileListService) {
  let FileListTextModel: FileListTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    FileListTextModel.Title = 'Yes Le Titre';
  }

  FileListService.UpdateFileListText(FileListTextModel);
}
