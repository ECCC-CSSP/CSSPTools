import { BreadCrumbTextModel } from './bread-crumb.models';
import { BreadCrumbService } from './bread-crumb.service';

export function LoadLocalesBreadCrumbText(breadCrumbService: BreadCrumbService) {
  let breadCrumbTextModel: BreadCrumbTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    breadCrumbTextModel.Title = 'Yes Le Titre';
  }

  breadCrumbService.UpdateBreadCrumbText(breadCrumbTextModel);
}
