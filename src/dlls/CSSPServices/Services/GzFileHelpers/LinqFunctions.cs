/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class GzFileService : ControllerBase, IGzFileService
    {
        private async Task<TVItem> GetTVItemRoot()
        {
            return await (from c in db.TVItems
                          where c.TVLevel == 0
                          && c.TVType == TVTypeEnum.Root
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<TVItem> GetTVItemWithTVItemID(int TVItemID)
        {
            return await (from c in db.TVItems
                          where c.TVItemID == TVItemID
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }

        private async Task<List<TVItemLanguage>> GetTVItemLanguageListWithTVItemID(int TVItemID)
        {
            return await (from c in db.TVItems
                          from cl in db.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVItemID == TVItemID
                          select cl).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemStat>> GetTVItemStatListWithTVItemID(int TVItemID)
        {
            return await (from c in db.TVItems
                          from cs in db.TVItemStats
                          where c.TVItemID == cs.TVItemID
                          && c.TVItemID == TVItemID
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfo>> GetMapInfoListWithTVItemID(int TVItemID)
        {
            return await (from mi in db.MapInfos
                          where mi.TVItemID == TVItemID
                          select mi).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfoPoint>> GetMapInfoPointListWithTVItemID(int TVItemID)
        {
            return await (from mi in db.MapInfos
                          from mip in db.MapInfoPoints
                          where mi.MapInfoID == mip.MapInfoID
                          && mi.TVItemID == TVItemID
                          select mip).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVFile>> GetTVFileListWithTVItemID(int TVItemID)
        {
            return await (from c in db.TVItems
                          from cf in db.TVItems
                          from f in db.TVFiles
                          where c.TVItemID == cf.ParentID
                          && cf.TVType == TVTypeEnum.File
                          && f.TVFileTVItemID == cf.TVItemID
                          && c.TVItemID == TVItemID
                          select f).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVFileLanguage>> GetTVFileLanguageListWithTVItemID(int TVItemID)
        {
            return await (from c in db.TVItems
                          from cf in db.TVItems
                          from f in db.TVFiles
                          from fl in db.TVFileLanguages
                          where c.TVItemID == cf.ParentID
                          && cf.TVType == TVTypeEnum.File
                          && f.TVFileTVItemID == cf.TVItemID
                          && f.TVFileID == fl.TVFileID
                          && c.TVItemID == TVItemID
                          select fl).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItem>> GetTVItemChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in db.TVItems
                              where c.TVPath.Contains(parentTVItem.TVPath + "p")
                              && c.ParentID == parentTVItem.TVItemID
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select c).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          where c.TVPath.Contains(parentTVItem.TVPath + "p")
                          && c.ParentID == parentTVItem.TVItemID
                          && c.TVType == tvType
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemLanguage>> GetTVItemLanguageChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVPath.Contains(parentTVItem.TVPath + "p")
                              && c.ParentID == parentTVItem.TVItemID
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select cl).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from cl in db.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVPath.Contains(parentTVItem.TVPath + "p")
                          && c.ParentID == parentTVItem.TVItemID
                          && c.TVType == tvType
                          select cl).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemStat>> GetTVItemStatChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in db.TVItems
                              from cs in db.TVItemStats
                              where c.TVItemID == cs.TVItemID
                              && c.TVPath.Contains(parentTVItem.TVPath + "p")
                              && c.ParentID == parentTVItem.TVItemID
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select cs).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from cs in db.TVItemStats
                          where c.TVItemID == cs.TVItemID
                          && c.TVPath.Contains(parentTVItem.TVPath + "p")
                          && c.ParentID == parentTVItem.TVItemID
                          && c.TVType == tvType
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfo>> GetMapInfoChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in db.TVItems
                              from mi in db.MapInfos
                              where c.TVItemID == mi.TVItemID
                              && c.TVPath.Contains(parentTVItem.TVPath + "p")
                              && c.ParentID == parentTVItem.TVItemID
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select mi).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from mi in db.MapInfos
                          where c.TVItemID == mi.TVItemID
                          && c.TVPath.Contains(parentTVItem.TVPath + "p")
                          && c.ParentID == parentTVItem.TVItemID
                          && c.TVType == tvType
                          select mi).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfoPoint>> GetMapInfoPointChildrenListWithTVItemID(TVItem parentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in db.TVItems
                              from mi in db.MapInfos
                              from mip in db.MapInfoPoints
                              where c.TVItemID == mi.TVItemID
                              && mi.MapInfoID == mip.MapInfoID
                              && c.TVPath.Contains(parentTVItem.TVPath + "p")
                              && c.ParentID == parentTVItem.TVItemID
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select mip).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from mi in db.MapInfos
                          from mip in db.MapInfoPoints
                          where c.TVItemID == mi.TVItemID
                          && mi.MapInfoID == mip.MapInfoID
                          && c.TVPath.Contains(parentTVItem.TVPath + "p")
                          && c.ParentID == parentTVItem.TVItemID
                          && c.TVType == tvType
                          select mip).AsNoTracking().ToListAsync();
        }
        private async Task<List<SamplingPlan>> GetSamplingPlanListWithProvinceTVItemID(int provinceTVItemID)
        {
            return await (from c in db.SamplingPlans
                          where c.ProvinceTVItemID == provinceTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<Infrastructure>> GetInfrastructureListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select ci).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemLink>> GetInfrastructureTVItemLinkListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from t in db.TVItemLinks
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && (c.TVItemID == t.FromTVItemID
                          || c.TVItemID == t.ToTVItemID)
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          && t.FromTVType == TVTypeEnum.Infrastructure
                          && t.ToTVType == TVTypeEnum.Infrastructure
                          select t).AsNoTracking().ToListAsync();
        }
        private async Task<List<Address>> GetInfrastructureCivicAddressListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from a in db.Addresses
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          && ci.CivicAddressTVItemID != null
                          && ci.CivicAddressTVItemID == a.AddressTVItemID
                          select a).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfo>> GetInfrastructureMapInfoListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from mi in db.MapInfos
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVItemID == mi.TVItemID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select mi).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfoPoint>> GetInfrastructureMapInfoPointListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from mi in db.MapInfos
                          from mip in db.MapInfoPoints
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVItemID == mi.TVItemID
                          && mi.MapInfoID == mip.MapInfoID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select mip).AsNoTracking().ToListAsync();
        }
        private async Task<List<InfrastructureLanguage>> GetInfrastructureLanguageListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from cil in db.InfrastructureLanguages
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureID == cil.InfrastructureID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select cil).AsNoTracking().ToListAsync();
        }
        private async Task<List<BoxModel>> GetBoxModelListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from bm in db.BoxModels
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select bm).AsNoTracking().ToListAsync();
        }
        private async Task<List<BoxModelLanguage>> GetBoxModelLanguageListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from bm in db.BoxModels
                          from bml in db.BoxModelLanguages
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                          && bm.BoxModelID == bml.BoxModelID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select bml).AsNoTracking().ToListAsync();
        }
        private async Task<List<BoxModelResult>> GetBoxModelResultListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from bm in db.BoxModels
                          from bmr in db.BoxModelResults
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                          && bm.BoxModelID == bmr.BoxModelID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select bmr).AsNoTracking().ToListAsync();
        }
        private async Task<List<VPScenario>> GetVPScenarioListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from vps in db.VPScenarios
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select vps).AsNoTracking().ToListAsync();
        }
        private async Task<List<VPScenarioLanguage>> GetVPScenarioLanguageListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from vps in db.VPScenarios
                          from vpsl in db.VPScenarioLanguages
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                          && vps.VPScenarioID == vpsl.VPScenarioID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select vpsl).AsNoTracking().ToListAsync();
        }
        private async Task<List<VPAmbient>> GetVPAmbientListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from vps in db.VPScenarios
                          from vpa in db.VPAmbients
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                          && vps.VPScenarioID == vpa.VPScenarioID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select vpa).AsNoTracking().ToListAsync();
        }
        private async Task<List<VPResult>> GetVPResultListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from c in db.TVItems
                          from ci in db.Infrastructures
                          from vps in db.VPScenarios
                          from vpr in db.VPResults
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                          && vps.VPScenarioID == vpr.VPScenarioID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && c.ParentID == tvItemMunicipality.TVItemID
                          && c.TVType == TVTypeEnum.Infrastructure
                          select vpr).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemLink>> GetTVItemLinkListContactUnderMunicipality(int municipalityTVItemID)
        {
            return await (from c in db.TVItemLinks
                          where c.FromTVItemID == municipalityTVItemID
                          && c.FromTVType == TVTypeEnum.Municipality
                          && c.ToTVType == TVTypeEnum.Contact
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<Contact>> GetMunicipalityContactListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from tl in db.TVItemLinks
                          from c in db.Contacts
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == tvItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<Email>> GetMunicipalityContactEmailListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from tl in db.TVItemLinks
                          from c in db.Contacts
                          from e in db.Emails
                          from tl2 in db.TVItemLinks
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == tvItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          && tl2.FromTVItemID == tl.ToTVItemID
                          && tl2.ToTVItemID == e.EmailTVItemID
                          && tl2.FromTVType == TVTypeEnum.Contact
                          && tl2.ToTVType == TVTypeEnum.Email
                          select e).AsNoTracking().ToListAsync();
        }
        private async Task<List<Tel>> GetMunicipalityContactTelListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from tl in db.TVItemLinks
                          from c in db.Contacts
                          from t in db.Tels
                          from tl2 in db.TVItemLinks
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == tvItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          && tl2.FromTVItemID == tl.ToTVItemID
                          && tl2.ToTVItemID == t.TelTVItemID
                          && tl2.FromTVType == TVTypeEnum.Contact
                          && tl2.ToTVType == TVTypeEnum.Tel
                          select t).AsNoTracking().ToListAsync();
        }
        private async Task<List<Address>> GetMunicipalityContactAddressListUnderMunicipality(TVItem tvItemMunicipality)
        {
            return await (from tl in db.TVItemLinks
                          from c in db.Contacts
                          from a in db.Addresses
                          from tl2 in db.TVItemLinks
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == tvItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          && tl2.FromTVItemID == tl.ToTVItemID
                          && tl2.ToTVItemID == a.AddressTVItemID
                          && tl2.FromTVType == TVTypeEnum.Contact
                          && tl2.ToTVType == TVTypeEnum.Address
                          select a).AsNoTracking().ToListAsync();
        }
        private async Task<SamplingPlan> GetSamplingPlanWithSamplingPlanID(int samplingPlanID)
        {
            return await (from c in db.SamplingPlans
                          where c.SamplingPlanID == samplingPlanID
                          select c).FirstOrDefaultAsync();
        }
        private async Task<List<SamplingPlanEmail>> GetSamplingPlanEmailListWithSamplingPlanID(int samplingPlanID)
        {
            return await (from c in db.SamplingPlanEmails
                          where c.SamplingPlanID == samplingPlanID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<SamplingPlanSubsector>> GetSamplingPlanSubsectorListWithSamplingPlanID(int samplingPlanID)
        {
            return await (from c in db.SamplingPlanSubsectors
                          where c.SamplingPlanID == samplingPlanID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<SamplingPlanSubsectorSite>> GetSamplingPlanSubsectorSiteListWithSamplingPlanID(int samplingPlanID)
        {
            return await (from c in db.SamplingPlanSubsectors
                          from cs in db.SamplingPlanSubsectorSites
                          where c.SamplingPlanSubsectorID == cs.SamplingPlanSubsectorID
                          && c.SamplingPlanID == samplingPlanID
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSample>> GetWQMSampleListFromSubsector10Years(TVItem tvItemSubsector, int Year)
        {
            DateTime StartDate = new DateTime(Year, 1, 1);
            DateTime EndDate = new DateTime(Year + 9, 12, 31);

            return await (from c in db.TVItems
                          from sa in db.MWQMSamples
                          where c.TVItemID == sa.MWQMSiteTVItemID
                          && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                          && c.ParentID == tvItemSubsector.TVItemID
                          && c.TVType == TVTypeEnum.MWQMSite
                          && sa.SampleDateTime_Local >= StartDate
                          && sa.SampleDateTime_Local <= EndDate
                          select sa).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSampleLanguage>> GetWQMSampleLanguageListFromSubsector10Years(TVItem tvItemSubsector, int Year)
        {
            DateTime StartDate = new DateTime(Year, 1, 1);
            DateTime EndDate = new DateTime(Year + 9, 12, 31);

            List<int> MWQMSampleIDList = await (from c in db.TVItems
                                                from sa in db.MWQMSamples
                                                where c.TVItemID == sa.MWQMSiteTVItemID
                                                && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                                                && c.ParentID == tvItemSubsector.TVItemID
                                                && c.TVType == TVTypeEnum.MWQMSite
                                                && sa.SampleDateTime_Local >= StartDate
                                                && sa.SampleDateTime_Local <= EndDate
                                                select sa.MWQMSampleID).ToListAsync();

            return await (from sal in db.MWQMSampleLanguages
                          where MWQMSampleIDList.Contains(sal.MWQMSampleID)
                          select sal).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMRun>> GetMWQMRunListFromSubsector(TVItem tvItemSubsector)
        {
            return await (from c in db.TVItems
                          from r in db.MWQMRuns
                          where c.TVItemID == r.MWQMRunTVItemID
                          && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                          && c.ParentID == tvItemSubsector.TVItemID
                          && c.TVType == TVTypeEnum.MWQMRun
                          select r).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMRunLanguage>> GetMWQMRunLanguageListFromSubsector(TVItem tvItemSubsector)
        {
            List<int> MWQMRunIDList = await (from c in db.TVItems
                                             from r in db.MWQMRuns
                                             where c.TVItemID == r.MWQMRunTVItemID
                                             && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                                             && c.ParentID == tvItemSubsector.TVItemID
                                             && c.TVType == TVTypeEnum.MWQMRun
                                             select r.MWQMRunID).ToListAsync();

            return await (from rl in db.MWQMRunLanguages
                          where MWQMRunIDList.Contains(rl.MWQMRunID)
                          select rl).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSite>> GetMWQMSiteListFromSubsector(TVItem tvItemSubsector)
        {
            return await (from c in db.TVItems
                          from s in db.MWQMSites
                          where c.TVItemID == s.MWQMSiteTVItemID
                          && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                          && c.ParentID == tvItemSubsector.TVItemID
                          && c.TVType == TVTypeEnum.MWQMSite
                          select s).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSiteStartEndDate>> GetMWQMSiteStartEndDateListFromSubsector(TVItem tvItemSubsector)
        {
            List<int> MWQMSiteIDList = await (from c in db.TVItems
                                             from s in db.MWQMSites
                                             where c.TVItemID == s.MWQMSiteTVItemID
                                             && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                                             && c.ParentID == tvItemSubsector.TVItemID
                                             && c.TVType == TVTypeEnum.MWQMSite
                                             select s.MWQMSiteID).ToListAsync();

            return await (from sd in db.MWQMSiteStartEndDates
                          where MWQMSiteIDList.Contains(sd.MWQMSiteTVItemID)
                          select sd).AsNoTracking().ToListAsync();
        }
        private async Task<List<Contact>> GetAllContact()
        {
            return await (from c in db.Contacts
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<ClimateSite>> GetClimateSiteListUnderProvince(TVItem tvItemProvince)
        {
            return await (from c in db.TVItems
                          from cs in db.ClimateSites
                          where c.TVItemID == cs.ClimateSiteTVItemID
                          && c.TVPath.Contains(tvItemProvince.TVPath + "p")
                          && c.ParentID == tvItemProvince.TVItemID
                          && c.TVType == TVTypeEnum.ClimateSite
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<HydrometricSite>> GetHydrometricSiteListUnderProvince(TVItem tvItemProvince)
        {
            return await (from c in db.TVItems
                          from hs in db.HydrometricSites
                          where c.TVItemID == hs.HydrometricSiteTVItemID
                          && c.TVPath.Contains(tvItemProvince.TVPath + "p")
                          && c.ParentID == tvItemProvince.TVItemID
                          && c.TVType == TVTypeEnum.HydrometricSite
                          select hs).AsNoTracking().ToListAsync();
        }
        private async Task<List<RatingCurve>> GetRatingCurveListUnderProvince(TVItem tvItemProvince)
        {
            return await (from c in db.TVItems
                          from hs in db.HydrometricSites
                          from rc in db.RatingCurves
                          where c.TVItemID == hs.HydrometricSiteTVItemID
                          && hs.HydrometricSiteID == rc.HydrometricSiteID
                          && c.TVPath.Contains(tvItemProvince.TVPath + "p")
                          && c.ParentID == tvItemProvince.TVItemID
                          && c.TVType == TVTypeEnum.HydrometricSite
                          select rc).AsNoTracking().ToListAsync();
        }
        private async Task<List<RatingCurveValue>> GetRatingCurveValueListUnderProvince(TVItem tvItemProvince)
        {
            return await (from c in db.TVItems
                          from hs in db.HydrometricSites
                          from rc in db.RatingCurves
                          from rcv in db.RatingCurveValues
                          where c.TVItemID == hs.HydrometricSiteTVItemID
                          && hs.HydrometricSiteID == rc.HydrometricSiteID
                          && rc.RatingCurveID == rcv.RatingCurveID
                          && c.TVPath.Contains(tvItemProvince.TVPath + "p")
                          && c.ParentID == tvItemProvince.TVItemID
                          && c.TVType == TVTypeEnum.HydrometricSite
                          select rcv).AsNoTracking().ToListAsync();
        }
        private async Task<List<DrogueRun>> GetDrogueRunListUnderProvince(int subsectorTVItemID)
        {
            return await (from c in db.DrogueRuns
                          where c.SubsectorTVItemID == subsectorTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<DrogueRunPosition>> GetDrogueRunPositionListUnderProvince(int subsectorTVItemID)
        {
            return await (from c in db.DrogueRuns
                          from p in db.DrogueRunPositions
                          where c.DrogueRunID == p.DrogueRunID
                          && c.SubsectorTVItemID == subsectorTVItemID
                          select p).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMAnalysisReportParameter>> GetMWQMAnalysisReportParameterListUnderSubsector(int subsectorTVItemID)
        {
            return await (from c in db.MWQMAnalysisReportParameters
                          where c.SubsectorTVItemID == subsectorTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMLookupMPN>> GetMWQMLookupMPN()
        {
            return await (from c in db.MWQMLookupMPNs
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<MikeScenario> GetMikeScenarioWithTVItemID(int mikeScenarioTVItemID)
        {
            return await (from c in db.MikeScenarios
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<List<MikeBoundaryCondition>> GetMikeBoundaryConditionListUnderMikeScenario(TVItem tvItemMikeScenario)
        {
            return await (from c in db.TVItems
                          from bc in db.MikeBoundaryConditions
                          where c.TVItemID == bc.MikeBoundaryConditionTVItemID
                          && c.TVPath.Contains(tvItemMikeScenario.TVPath + "p")
                          && c.ParentID == tvItemMikeScenario.TVItemID
                          && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                          || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                          select bc).AsNoTracking().ToListAsync();
        }
        private async Task<List<MikeSource>> GetMikeSourceListUnderMikeScenario(TVItem tvItemMikeScenario)
        {
            return await (from c in db.TVItems
                          from ms in db.MikeSources
                          where c.TVItemID == ms.MikeSourceTVItemID
                          && c.TVPath.Contains(tvItemMikeScenario.TVPath + "p")
                          && c.ParentID == tvItemMikeScenario.TVItemID
                          && c.TVType == TVTypeEnum.MikeSource
                          select ms).AsNoTracking().ToListAsync();
        }
        private async Task<List<MikeSourceStartEnd>> GetMikeSourceStartEndListUnderMikeScenario(TVItem tvItemMikeScenario)
        {
            return await (from c in db.TVItems
                          from ms in db.MikeSources
                          from msse in db.MikeSourceStartEnds
                          where c.TVItemID == ms.MikeSourceTVItemID
                          && ms.MikeSourceID == msse.MikeSourceID
                          && c.TVPath.Contains(tvItemMikeScenario.TVPath + "p")
                          && c.ParentID == tvItemMikeScenario.TVItemID
                          && c.TVType == TVTypeEnum.MikeSource
                          select msse).AsNoTracking().ToListAsync();
        }
        private async Task<List<EmailDistributionList>> GetEmailDistributionListListUnderCountry(int TVItemID)
        {
            return await (from c in db.EmailDistributionLists
                          where c.ParentTVItemID == TVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<EmailDistributionListLanguage>> GetEmailDistributionListLanguageListUnderCountry(int TVItemID)
        {
            return await (from c in db.EmailDistributionLists
                          from cl in db.EmailDistributionListLanguages
                          where c.ParentTVItemID == TVItemID
                          && c.EmailDistributionListID == cl.EmailDistributionListID
                          select cl).AsNoTracking().ToListAsync();
        }
        private async Task<List<EmailDistributionListContact>> GetEmailDistributionListContactListUnderCountry(int TVItemID)
        {
            return await (from c in db.EmailDistributionLists
                          from ec in db.EmailDistributionListContacts
                          where c.ParentTVItemID == TVItemID
                          && c.EmailDistributionListID == ec.EmailDistributionListID
                          select ec).AsNoTracking().ToListAsync();
        }
        private async Task<List<EmailDistributionListContactLanguage>> GetEmailDistributionListContactLanguageListUnderCountry(int TVItemID)
        {
            return await (from c in db.EmailDistributionLists
                          from ec in db.EmailDistributionListContacts
                          from ecl in db.EmailDistributionListContactLanguages
                          where c.ParentTVItemID == TVItemID
                          && c.EmailDistributionListID == ec.EmailDistributionListID
                          && ec.EmailDistributionListContactID == ecl.LastUpdateContactTVItemID
                          select ecl).AsNoTracking().ToListAsync();
        }
        private async Task<List<ClimateDataValue>> GetClimateDataValueListForClimateSite(int TVItemID)
        {
            return await (from c in db.ClimateSites
                          from cv in db.ClimateDataValues
                          where c.ClimateSiteID == cv.ClimateSiteID
                          && c.ClimateSiteTVItemID == TVItemID
                          select cv).AsNoTracking().ToListAsync();
        }
        private async Task<List<HydrometricDataValue>> GetHydrometricDataValueListForHydrometricSite(int TVItemID)
        {
            return await (from c in db.HydrometricSites
                          from cv in db.HydrometricDataValues
                          where c.HydrometricSiteID == cv.HydrometricSiteID
                          && c.HydrometricSiteTVItemID == TVItemID
                          select cv).AsNoTracking().ToListAsync();
        }
        private async Task<List<HelpDoc>> GetHelpDoc()
        {
            return await (from c in db.HelpDocs
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<LabSheet>> GetLabSheetListUnderSubsector(int subsectorTVItemID)
        {
            return await (from c in db.LabSheets
                          where c.SubsectorTVItemID == subsectorTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<LabSheetDetail>> GetLabSheetDetailListUnderSubsector(int subsectorTVItemID)
        {
            return await (from c in db.LabSheets
                          from cd in db.LabSheetDetails
                          where c.LabSheetID == cd.LabSheetID
                          && c.SubsectorTVItemID == subsectorTVItemID
                          select cd).AsNoTracking().ToListAsync();
        }
        private async Task<List<LabSheetTubeMPNDetail>> GetLabSheetTubeMPNDetailListUnderSubsector(int subsectorTVItemID)
        {
            return await (from c in db.LabSheets
                          from cd in db.LabSheetDetails
                          from ct in db.LabSheetTubeMPNDetails
                          where c.LabSheetID == cd.LabSheetID
                          && cd.LabSheetDetailID == ct.LabSheetDetailID
                          && c.SubsectorTVItemID == subsectorTVItemID
                          select ct).AsNoTracking().ToListAsync();
        }
        private async Task<MWQMSubsector> GetMWQMSubsector(int subsectorTVItemID)
        {
            return await (from c in db.MWQMSubsectors
                          where c.MWQMSubsectorID == subsectorTVItemID
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<List<MWQMSubsectorLanguage>> GetMWQMSubsectorLanguageList(int subsectorTVItemID)
        {
            return await (from c in db.MWQMSubsectors
                          from cl in db.MWQMSubsectorLanguages
                          where c.MWQMSubsectorID == cl.MWQMSubsectorID
                          && c.MWQMSubsectorID == subsectorTVItemID
                          select cl).AsNoTracking().ToListAsync();
        }
        private async Task<List<TideLocation>> GetTideLocation()
        {
            return await (from c in db.TideLocations
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<UseOfSite>> GetUseOfSiteList(int subsectorTVItemID)
        {
            return await (from c in db.UseOfSites
                          where c.SubsectorTVItemID == subsectorTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceSite>> GetPolSourceSiteListFromSubsector(TVItem tvItemSubsector)
        {
            return await (from c in db.TVItems
                          from p in db.PolSourceSites
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                          && c.ParentID == tvItemSubsector.TVItemID
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select p).AsNoTracking().ToListAsync();
        }
        private async Task<List<Address>> GetPolSourceSiteAddressListFromSubsector(TVItem tvItemSubsector)
        {
            return await (from c in db.TVItems
                          from p in db.PolSourceSites
                          from a in db.Addresses
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.CivicAddressTVItemID != null
                          && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                          && c.ParentID == tvItemSubsector.TVItemID
                          && c.TVType == TVTypeEnum.PolSourceSite
                          && p.CivicAddressTVItemID == a.AddressTVItemID
                          select a).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceObservation>> GetPolSourceObservationListFromSubsector(TVItem tvItemSubsector)
        {
            return await (from c in db.TVItems
                          from p in db.PolSourceSites
                          from po in db.PolSourceObservations
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.PolSourceSiteID == po.PolSourceSiteID
                          && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                          && c.ParentID == tvItemSubsector.TVItemID
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select po).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceObservationIssue>> GetPolSourceObservationIssueListFromSubsector(TVItem tvItemSubsector)
        {
            return await (from c in db.TVItems
                          from p in db.PolSourceSites
                          from po in db.PolSourceObservations
                          from poi in db.PolSourceObservationIssues
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.PolSourceSiteID == po.PolSourceSiteID
                          && po.PolSourceObservationID == poi.PolSourceObservationID
                          && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                          && c.ParentID == tvItemSubsector.TVItemID
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select poi).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceSiteEffect>> GetPolSourceSiteEffectListFromSubsector(TVItem tvItemSubsector)
        {
            return await (from c in db.TVItems
                          from p in db.PolSourceSites
                          from pe in db.PolSourceSiteEffects
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.PolSourceSiteID == pe.PolSourceSiteOrInfrastructureTVItemID
                          && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                          && c.ParentID == tvItemSubsector.TVItemID
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select pe).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermListFromSubsector(TVItem tvItemSubsector)
        {
            return await (from c in db.TVItems
                          from p in db.PolSourceSites
                          from pe in db.PolSourceSiteEffects
                          from pet in db.PolSourceSiteEffectTerms
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.PolSourceSiteID == pe.PolSourceSiteOrInfrastructureTVItemID
                          && pe.PolSourceSiteEffectID == pet.PolSourceSiteEffectTermID
                          && c.TVPath.Contains(tvItemSubsector.TVPath + "p")
                          && c.ParentID == tvItemSubsector.TVItemID
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select pet).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceGrouping>> GetPolSourceGroupingList()
        {
            return await (from c in db.PolSourceGroupings
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceGroupingLanguage>> GetPolSourceGroupingLanguageList()
        {
            return await (from c in db.PolSourceGroupingLanguages
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<ReportType>> GetReportTypeList()
        {
            return await (from c in db.ReportTypes
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<ReportSection>> GetReportSectionList()
        {
            return await (from c in db.ReportSections
                          select c).AsNoTracking().ToListAsync();
        }
    }
}
