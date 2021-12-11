import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { ContactModel } from 'src/app/models/generated/models/ContactModel.model';
import { PolSourceObservationModel } from 'src/app/models/generated/models/PolSourceObservationModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { PolSourceSiteService } from 'src/app/services/helpers/pol-source-site.service';

@Component({
  selector: 'app-pol-source-site-item-obs',
  templateUrl: './pol-source-site-item-obs.component.html',
  styleUrls: ['./pol-source-site-item-obs.component.css']
})
export class PolSourceSiteItemObsComponent implements OnInit, OnDestroy {
  @Input() PolSourceObservationModel: PolSourceObservationModel;

  contactModel: ContactModel = <ContactModel>{};
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public polSourceSiteService: PolSourceSiteService,
    public dateFormatService: DateFormatService) { }

  ngOnInit(): void {
    this.contactModel = this.polSourceSiteService.GetContactModel(this.PolSourceObservationModel.PolSourceObservation.ContactTVItemID);
  }

  ngOnDestroy(): void {
  }

}
