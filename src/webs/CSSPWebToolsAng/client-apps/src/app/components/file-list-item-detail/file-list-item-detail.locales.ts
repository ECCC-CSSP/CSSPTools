import { FileListItemDetailTextModel } from './file-list-item-detail.models';
import { FileListItemDetailService } from './file-list-item-detail.service';

export function LoadLocalesFileListItemDetailText(FileListItemDetailService: FileListItemDetailService) {
  let FileListItemDetailTextModel: FileListItemDetailTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    FileListItemDetailTextModel.Title = 'Yes Le Titre';
  }

  FileListItemDetailService.UpdateFileListItemDetailText(FileListItemDetailTextModel);
}
