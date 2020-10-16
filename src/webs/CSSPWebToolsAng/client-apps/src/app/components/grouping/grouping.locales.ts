import { AppService } from '../../app.service';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { GroupingTextModel } from './grouping.models';
import { GroupingService } from './grouping.service';

export function LoadLocalesGroupingText(appService: AppService, groupingService: GroupingService) {
  let groupingTextModel: GroupingTextModel = { 
    Title: 'The title',
}

  if (appService.AppVar$.getValue().Language == LanguageEnum.fr) {
      groupingTextModel.Title = 'Le Titre';
    }

  groupingService.UpdateGroupingText(groupingTextModel);
}
