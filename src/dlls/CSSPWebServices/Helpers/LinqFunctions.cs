/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        TVItem GetTVItemRoot()
        {
            return (from c in db.TVItems
                    where c.TVLevel == 0
                    && c.TVType == TVTypeEnum.Root
                    select c).AsNoTracking().FirstOrDefault();
        }
        TVItem GetTVItemWithTVItemID(int TVItemID)
        {
            return (from c in db.TVItems
                    where c.TVItemID == TVItemID
                    select c).AsNoTracking().FirstOrDefault();
        }

        List<TVItemLanguage> GetTVItemLanguageListWithTVItemID(int TVItemID)
        {
            return (from c in db.TVItems
                    from cl in db.TVItemLanguages
                    where c.TVItemID == cl.TVItemID
                    && c.TVItemID == TVItemID
                    select cl).AsNoTracking().ToList();
        }
        List<TVItemStat> GetTVItemStatListWithTVItemID(int TVItemID)
        {
            return (from c in db.TVItems
                    from cs in db.TVItemStats
                    where c.TVItemID == cs.TVItemID
                    && c.TVItemID == TVItemID
                    select cs).AsNoTracking().ToList();
        }
        List<MapInfo> GetMapInfoListWithTVItemID(int TVItemID)
        {
            return (from mi in db.MapInfos
                    where mi.TVItemID == TVItemID
                    select mi).AsNoTracking().ToList();
        }
        List<MapInfoPoint> GetMapInfoPointListWithTVItemID(int TVItemID)
        {
            return (from mi in db.MapInfos
                    from mip in db.MapInfoPoints
                    where mi.MapInfoID == mip.MapInfoID
                    && mi.TVItemID == TVItemID
                    select mip).AsNoTracking().ToList();
        }
        List<TVFile> GetTVFileListWithTVItemID(int TVItemID)
        {
            return (from c in db.TVItems
                    from cf in db.TVItems
                    from f in db.TVFiles
                    where c.TVItemID == cf.ParentID
                    && cf.TVType == TVTypeEnum.File
                    && f.TVFileTVItemID == cf.TVItemID
                    && c.TVItemID == TVItemID
                    select f).AsNoTracking().ToList();
        }
        List<TVFileLanguage> GetTVFileLanguageListWithTVItemID(int TVItemID)
        {
            return (from c in db.TVItems
                    from cf in db.TVItems
                    from f in db.TVFiles
                    from fl in db.TVFileLanguages
                    where c.TVItemID == cf.ParentID
                    && cf.TVType == TVTypeEnum.File
                    && f.TVFileTVItemID == cf.TVItemID
                    && f.TVFileID == fl.TVFileID
                    && c.TVItemID == TVItemID
                    select fl).AsNoTracking().ToList();
        }
        List<TVItem> GetTVItemChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            return (from c in db.TVItems
                    where c.TVPath.Contains(parentTVItem.TVPath + "p")
                    && c.ParentID == parentTVItem.TVItemID
                    && c.TVType == tvType
                    select c).AsNoTracking().ToList();
        }
        List<TVItemLanguage> GetTVItemLanguageChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            return (from c in db.TVItems
                    from cl in db.TVItemLanguages
                    where c.TVItemID == cl.TVItemID
                    && c.TVPath.Contains(parentTVItem.TVPath + "p")
                    && c.ParentID == parentTVItem.TVItemID
                    && c.TVType == tvType
                    select cl).AsNoTracking().ToList();
        }
        List<TVItemStat> GetTVItemStatChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            return (from c in db.TVItems
                    from cs in db.TVItemStats
                    where c.TVItemID == cs.TVItemID
                    && c.TVPath.Contains(parentTVItem.TVPath + "p")
                    && c.ParentID == parentTVItem.TVItemID
                    && c.TVType == tvType
                    select cs).AsNoTracking().ToList();
        }
        List<MapInfo> GetMapInfoChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            return (from c in db.TVItems
                    from mi in db.MapInfos
                    where c.TVItemID == mi.TVItemID
                    && c.TVPath.Contains(parentTVItem.TVPath + "p")
                    && c.ParentID == parentTVItem.TVItemID
                    && c.TVType == tvType
                    select mi).AsNoTracking().ToList();
        }
        List<MapInfoPoint> GetMapInfoPointChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            return (from c in db.TVItems
                    from mi in db.MapInfos
                    from mip in db.MapInfoPoints
                    where c.TVItemID == mi.TVItemID
                    && mi.MapInfoID == mip.MapInfoID
                    && c.TVPath.Contains(parentTVItem.TVPath + "p")
                    && c.ParentID == parentTVItem.TVItemID
                    && c.TVType == tvType
                    select mip).AsNoTracking().ToList();
        }
        List<SamplingPlan> GetSamplingPlanListWithProvinceTVItemID(int provinceTVItemID)
        {
            return (from c in db.SamplingPlans
                    where c.ProvinceTVItemID == provinceTVItemID
                    select c).AsNoTracking().ToList();
        }
        List<Infrastructure> GetInfrastructureListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return (from c in db.TVItems
                    from ci in db.Infrastructures
                    where c.TVItemID == ci.InfrastructureTVItemID
                    && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                    && c.ParentID == tvItemMunicipality.TVItemID
                    && c.TVType == TVTypeEnum.Infrastructure
                    select ci).AsNoTracking().ToList();
        }
        List<TVItemLink> GetInfrastructureTVItemLinkListForInfrastructure(Infrastructure infrastructure)
        {
            return (from c in db.TVItemLinks
                    where (c.FromTVItemID == infrastructure.InfrastructureTVItemID
                    || c.ToTVItemID == infrastructure.InfrastructureTVItemID)
                    && c.FromTVType == TVTypeEnum.Infrastructure
                    && c.ToTVType == TVTypeEnum.Infrastructure
                    select c).AsNoTracking().ToList();
        }
        Address GetAddressWithTVItemID(int TVItemID)
        {
            return (from c in db.Addresses
                    where c.AddressTVItemID == TVItemID
                    select c).AsNoTracking().FirstOrDefault();
        }
        List<InfrastructureLanguage> GetInfrastructureLanguageListForInfrastructure(Infrastructure infrastructure)
        {
            return (from c in db.InfrastructureLanguages
                    where c.InfrastructureID == infrastructure.InfrastructureID
                    select c).AsNoTracking().ToList();
        }
        List<BoxModel> GetBoxModelListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return (from c in db.TVItems
                    from ci in db.Infrastructures
                    from bm in db.BoxModels
                    where c.TVItemID == ci.InfrastructureTVItemID
                    && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                    && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                    && c.ParentID == tvItemMunicipality.TVItemID
                    && c.TVType == TVTypeEnum.Infrastructure
                    select bm).AsNoTracking().ToList();
        }
        List<BoxModelLanguage> GetBoxModelLanguageListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return (from c in db.TVItems
                    from ci in db.Infrastructures
                    from bm in db.BoxModels
                    from bml in db.BoxModelLanguages
                    where c.TVItemID == ci.InfrastructureTVItemID
                    && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                    && bm.BoxModelID == bml.BoxModelID
                    && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                    && c.ParentID == tvItemMunicipality.TVItemID
                    && c.TVType == TVTypeEnum.Infrastructure
                    select bml).AsNoTracking().ToList();
        }
        List<BoxModelResult> GetBoxModelResultListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return (from c in db.TVItems
                    from ci in db.Infrastructures
                    from bm in db.BoxModels
                    from bmr in db.BoxModelResults
                    where c.TVItemID == ci.InfrastructureTVItemID
                    && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                    && bm.BoxModelID == bmr.BoxModelID
                    && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                    && c.ParentID == tvItemMunicipality.TVItemID
                    && c.TVType == TVTypeEnum.Infrastructure
                    select bmr).AsNoTracking().ToList();
        }
        List<VPScenario> GetVPScenarioListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return (from c in db.TVItems
                    from ci in db.Infrastructures
                    from vps in db.VPScenarios
                    where c.TVItemID == ci.InfrastructureTVItemID
                    && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                    && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                    && c.ParentID == tvItemMunicipality.TVItemID
                    && c.TVType == TVTypeEnum.Infrastructure
                    select vps).AsNoTracking().ToList();
        }
        List<VPScenarioLanguage> GetVPScenarioLanguageListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return (from c in db.TVItems
                    from ci in db.Infrastructures
                    from vps in db.VPScenarios
                    from vpsl in db.VPScenarioLanguages
                    where c.TVItemID == ci.InfrastructureTVItemID
                    && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                    && vps.VPScenarioID == vpsl.VPScenarioID
                    && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                    && c.ParentID == tvItemMunicipality.TVItemID
                    && c.TVType == TVTypeEnum.Infrastructure
                    select vpsl).AsNoTracking().ToList();
        }
        List<VPAmbient> GetVPAmbientListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return (from c in db.TVItems
                    from ci in db.Infrastructures
                    from vps in db.VPScenarios
                    from vpa in db.VPAmbients
                    where c.TVItemID == ci.InfrastructureTVItemID
                    && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                    && vps.VPScenarioID == vpa.VPScenarioID
                    && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                    && c.ParentID == tvItemMunicipality.TVItemID
                    && c.TVType == TVTypeEnum.Infrastructure
                    select vpa).AsNoTracking().ToList();
        }
        List<VPResult> GetVPResultListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return (from c in db.TVItems
                    from ci in db.Infrastructures
                    from vps in db.VPScenarios
                    from vpr in db.VPResults
                    where c.TVItemID == ci.InfrastructureTVItemID
                    && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                    && vps.VPScenarioID == vpr.VPScenarioID
                    && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                    && c.ParentID == tvItemMunicipality.TVItemID
                    && c.TVType == TVTypeEnum.Infrastructure
                    select vpr).AsNoTracking().ToList();
        }
        List<TVItemLink> GetTVItemLinkListContactUnderMunicipality(int municipalityTVItemID)
        {
            return (from c in db.TVItemLinks
                    where c.FromTVItemID == municipalityTVItemID
                    && c.FromTVType == TVTypeEnum.Municipality
                    && c.ToTVType == TVTypeEnum.Contact
                    select c).AsNoTracking().ToList();
        }
        Contact GetContactWithContactTVItemID(int contactTVItemID)
        {
            return (from c in db.Contacts
                    where c.ContactTVItemID == contactTVItemID
                    select c).AsNoTracking().FirstOrDefault();
        }
        List<TVItemLink> GetTVItemLinkListContactOtherEmail(int contactTVItemID)
        {
            return (from c in db.TVItemLinks
                    where c.FromTVItemID == contactTVItemID
                    && c.FromTVType == TVTypeEnum.Contact
                    && c.ToTVType == TVTypeEnum.Email
                    select c).AsNoTracking().ToList();
        }
        Email GetEmailWithEmailTVItemID(int emailTVItemID)
        {
            return (from c in db.Emails
                    where c.EmailTVItemID == emailTVItemID
                    select c).AsNoTracking().FirstOrDefault();
        }
        List<TVItemLink> GetTVItemLinkListContactTel(int contactTVItemID)
        {
            return (from c in db.TVItemLinks
                    where c.FromTVItemID == contactTVItemID
                    && c.FromTVType == TVTypeEnum.Contact
                    && c.ToTVType == TVTypeEnum.Tel
                    select c).AsNoTracking().ToList();
        }
        Tel GetTelWithTelTVItemID(int telTVItemID)
        {
            return (from c in db.Tels
                    where c.TelTVItemID == telTVItemID
                    select c).AsNoTracking().FirstOrDefault();
        }
        List<TVItemLink> GetTVItemLinkListContactAddress(int contactTVItemID)
        {
            return (from c in db.TVItemLinks
                    where c.FromTVItemID == contactTVItemID
                    && c.FromTVType == TVTypeEnum.Contact
                    && c.ToTVType == TVTypeEnum.Address
                    select c).AsNoTracking().ToList();
        }
        Address GetAddressWithAddressTVItemID(int addressTVItemID)
        {
            return (from c in db.Addresses
                    where c.AddressTVItemID == addressTVItemID
                    select c).AsNoTracking().FirstOrDefault();
        }
        SamplingPlan GetSamplingPlanWithSamplingPlanID(int samplingPlanID)
        {
            return (from c in db.SamplingPlans
                    where c.SamplingPlanID == samplingPlanID
                    select c).FirstOrDefault();
        }
        List<SamplingPlanEmail> GetSamplingPlanEmailListWithSamplingPlanID(int samplingPlanID)
        {
            return (from c in db.SamplingPlanEmails
                    where c.SamplingPlanID == samplingPlanID
                    select c).AsNoTracking().ToList();
        }
        List<SamplingPlanSubsector> GetSamplingPlanSubsectorListWithSamplingPlanID(int samplingPlanID)
        {
            return (from c in db.SamplingPlanSubsectors
                    where c.SamplingPlanID == samplingPlanID
                    select c).AsNoTracking().ToList();
        }
        List<SamplingPlanSubsectorSite> GetSamplingPlanSubsectorSiteListWithSamplingPlanID(int samplingPlanID)
        {
            return (from c in db.SamplingPlanSubsectors
                    from cs in db.SamplingPlanSubsectorSites
                    where c.SamplingPlanSubsectorID == cs.SamplingPlanSubsectorID
                    && c.SamplingPlanID == samplingPlanID
                    select cs).AsNoTracking().ToList();
        }
        List<MWQMSample> GetWQMSampleListFromSubsector10Years(TVItem tvItemSubsector, int Year)
        {
            DateTime StartDate = new DateTime(Year, 1, 1);
            DateTime EndDate = new DateTime(Year + 9, 12, 31);

            return (from c in db.TVItems
                    from s in db.MWQMSites
                    from sa in db.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVItemID == sa.MWQMSiteTVItemID
                    && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                    && c.ParentID == tvItemSubsector.TVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && sa.SampleDateTime_Local >= StartDate
                    && sa.SampleDateTime_Local <= EndDate
                    select sa).AsNoTracking().ToList();
        }
        List<MWQMSampleLanguage> GetWQMSampleLanguageListFromSubsector10Years(TVItem tvItemSubsector, int Year)
        {
            DateTime StartDate = new DateTime(Year, 1, 1);
            DateTime EndDate = new DateTime(Year + 9, 12, 31);

            return (from c in db.TVItems
                    from s in db.MWQMSites
                    from sa in db.MWQMSamples
                    from sal in db.MWQMSampleLanguages
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVItemID == sa.MWQMSiteTVItemID
                    && sa.MWQMSampleID == sal.MWQMSampleID
                    && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                    && c.ParentID == tvItemSubsector.TVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && sa.SampleDateTime_Local >= StartDate
                    && sa.SampleDateTime_Local <= EndDate
                    select sal).AsNoTracking().ToList();
        }
    }
}
