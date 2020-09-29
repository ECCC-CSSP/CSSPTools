import { ChildCountTextModel } from './child-count.models';
import { ChildCountService } from './child-count.service';

export function LoadLocalesChildCountText(childCountService: ChildCountService) {
  let childCountTextModel: ChildCountTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    childCountTextModel.Title = 'Yes Le Titre';
  }

  childCountService.UpdateChildCountText(childCountTextModel);
}
