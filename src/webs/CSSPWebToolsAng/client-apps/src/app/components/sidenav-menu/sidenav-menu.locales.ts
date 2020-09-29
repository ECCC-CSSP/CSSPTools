import { SideNavMenuTextModel } from './sidenav-menu.models';
import { SideNavMenuService } from './sidenav-menu.service';

export function LoadLocalesSideNavMenuText(SideNavMenuService: SideNavMenuService) {
  let SideNavMenuTextModel: SideNavMenuTextModel = {
    Title: 'Yes The title',
  }

  if ($localize.locale === 'fr-CA') {
    SideNavMenuTextModel.Title = 'Yes Le Titre';
  }

  SideNavMenuService.UpdateSideNavMenuText(SideNavMenuTextModel);
}
