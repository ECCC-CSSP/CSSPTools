import { FileListItemTextModel } from './file-list-item.models';
import { FileListItemService } from '././file-list-item.service

export function LoadLocalesFileListItemText(FileListItemService: FileListItemService) {
  let FileListItemTextModel: FileListItemTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    FileListItemTextModel.Title = 'Yes Le Titre';
  }

  FileListItemService.UpdateFileListItemText(FileListItemTextModel);
}
