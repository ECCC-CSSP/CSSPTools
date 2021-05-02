import { Contact } from 'src/app/models/generated/db/Contact.model';
import { SearchResult } from 'src/app/models/generated/helper/SearchResult.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebClimateSites } from 'src/app/models/generated/web/WebClimateSites.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebDrogueRuns } from 'src/app/models/generated/web/WebDrogueRuns.model';
import { WebHydrometricSites } from 'src/app/models/generated/web/WebHydrometricSites.model';
import { WebMikeScenarios } from 'src/app/models/generated/web/WebMikeScenarios.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebMWQMRuns } from 'src/app/models/generated/web/WebMWQMRuns.model';
import { WebMWQMSites } from 'src/app/models/generated/web/WebMWQMSites.model';
import { WebPolSourceSites } from 'src/app/models/generated/web/WebPolSourceSites.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
//import { Subscription } from 'rxjs';
import { WebAllCountries } from './generated/web/WebAllCountries.model';
import { WebAllMunicipalities } from './generated/web/WebAllMunicipalities.model';
import { WebAllProvinces } from './generated/web/WebAllProvinces.model';
import { WebAllReportTypes } from './generated/web/WebAllReportTypes.model';
import { WebAllContacts } from './generated/web/WebAllContacts.model';
import { WebAllHelpDocs } from './generated/web/WebAllHelpDocs.model';
import { WebAllMWQMLookupMPNs } from './generated/web/WebAllMWQMLookupMPNs.model';
import { WebAllPolSourceGroupings } from './generated/web/WebAllPolSourceGroupings.model';
import { WebAllPolSourceSiteEffectTerms } from './generated/web/WebAllPolSourceSiteEffectTerms.model';
import { WebAllTideLocations } from './generated/web/WebAllTideLocations.model';
import { WebAllAddresses } from './generated/web/WebAllAddresses.model';
import { WebAllEmails } from './generated/web/WebAllEmails.model';
import { WebAllTels } from './generated/web/WebAllTels.model';
import { WebAllTVItemLanguages } from './generated/web/WebAllTVItemLanguages.model';
import { WebAllTVItems } from './generated/web/WebAllTVItems.model';
import { WebLabSheets } from './generated/web/WebLabSheets.model';
import { WebMWQMSamples } from './generated/web/WebMWQMSamples.model';
import { WebTideSites } from './generated/web/WebTideSites.model';
import { StatMWQMRun } from './generated/web/StatMWQMRun.model';
import { MWQMSiteModel } from './generated/web/MWQMSiteModel.model';
import { StatMWQMSite } from './generated/web/StatMWQMSite.model';
import { TVItemModel } from './generated/web/TVItemModel.model';

export interface AppLoaded {
    LoggedInContact?: Contact;
    BreadCrumbTVItemModelList?: TVItemModel[];

    // Map related items
    Map?: google.maps.Map;
    Zoom?: number;
    Center?: google.maps.LatLngLiteral;
    Options?: google.maps.MapOptions;
    GoogleCrossPolylineListMVC?: google.maps.MVCArray<google.maps.Polyline>;
    GoogleMarkerListMVC?: google.maps.MVCArray<google.maps.Marker>;
    GooglePolygonListMVC?: google.maps.MVCArray<google.maps.Polygon>;
    GooglePolylineListMVC?: google.maps.MVCArray<google.maps.Polyline>;
    InfoContent?: string;

    MarkerOriginal?: google.maps.LatLngLiteral;
    MarkerChanged?: google.maps.LatLngLiteral;   

    // Complete list not related to a TVItemID
    WebAllAddresses?: WebAllAddresses;
    WebAllContacts?: WebAllContacts;
    WebAllCountries?: WebAllCountries;
    WebAllEmails?: WebAllEmails;
    WebAllHelpDocs?: WebAllHelpDocs;
    WebAllMunicipalities?: WebAllMunicipalities;
    WebAllMWQMLookupMPNs?: WebAllMWQMLookupMPNs;
    WebAllPolSourceGroupings?: WebAllPolSourceGroupings;
    WebAllPolSourceSiteEffectTerms?: WebAllPolSourceSiteEffectTerms;
    WebAllProvinces?: WebAllProvinces;
    WebAllReportTypes?: WebAllReportTypes;
    WebAllTels?: WebAllTels;
    WebAllTideLocations?: WebAllTideLocations;
    WebAllTVItemLanguages?: WebAllTVItemLanguages;
    WebAllTVItems?: WebAllTVItems;
    WebArea?: WebArea;
    WebClimateSites?: WebClimateSites;
    WebCountry?: WebCountry;
    WebDrogueRuns?: WebDrogueRuns;
    WebHydrometricSites?: WebHydrometricSites;
    WebLabSheets?: WebLabSheets;
    WebMikeScenarios?: WebMikeScenarios;
    WebMunicipality?: WebMunicipality;
    WebMWQMRuns?: WebMWQMRuns;
    WebMWQMSamples?: WebMWQMSamples;
    WebMWQMSites?: WebMWQMSites;
    WebPolSourceSites?: WebPolSourceSites;
    WebProvince?: WebProvince;
    WebRoot?: WebRoot;
    WebSector?: WebSector;
    WebSubsector?: WebSubsector;
    WebTideSites?: WebTideSites;

    SearchResult?: SearchResult[];

    // MWQMRunRoutingList?: MWQMRun[];
    MWQMSiteList?: MWQMSiteModel[];
    StatMWQMRunList?: StatMWQMRun[];
    StatMWQMSiteList?: StatMWQMSite[];

}
