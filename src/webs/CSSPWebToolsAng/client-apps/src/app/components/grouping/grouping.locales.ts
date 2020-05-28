import { GroupingTextModel } from './grouping.models';
import { GroupingService } from './grouping.service';

export function LoadLocalesGroupingText(groupingService: GroupingService) {
  let groupingTextModel: GroupingTextModel = { 
    Title: 'The title',
}

  if ($localize.locale === 'fr-CA') {
      groupingTextModel.Title = 'Le Titre';
    }

  groupingService.UpdateGroupingText(groupingTextModel);
}
