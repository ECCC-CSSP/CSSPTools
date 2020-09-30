import { TVItemListDetailRootTextModel } './tvitem-list-detail-root.models';
import { TVItemListDetailRootService } './tvitem-list-detail-root.service';

export function LoadLocalesTVItemListDetailRootText(TVItemListDetailRootService: TVItemListDetailRootService) {
  let TVItemListDetailRootTextModel: TVItemListDetailRootTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    TVItemListDetailRootTextModel.Title = 'Yes Le Titre';
  }

  TVItemListDetailRootService.UpdateTVItemListDetailRootText(TVItemListDetailRootTextModel);
}
