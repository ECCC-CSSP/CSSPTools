/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<TVItem> GetTVItemRoot()
        {
            return await (from c in dbLocal.TVItems
                          where c.TVLevel == 0
                          && c.TVType == TVTypeEnum.Root
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<TVItem> GetTVItemWithTVItemID(int TVItemID)
        {
            return await (from c in dbLocal.TVItems
                          where c.TVItemID == TVItemID
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }

        private async Task<List<TVItemLanguage>> GetTVItemLanguageListWithTVItemID(int TVItemID)
        {
            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVItemID == TVItemID
                          select cl).AsNoTracking().ToListAsync();

        }
        private async Task<List<TVItemStat>> GetTVItemStatListWithTVItemID(int TVItemID)
        {
            return await (from c in dbLocal.TVItems
                          from cs in dbLocal.TVItemStats
                          where c.TVItemID == cs.TVItemID
                          && c.TVItemID == TVItemID
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfo>> GetMapInfoListWithTVItemID(int TVItemID)
        {
            return await (from mi in dbLocal.MapInfos
                          where mi.TVItemID == TVItemID
                          select mi).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfoPoint>> GetMapInfoPointListWithTVItemID(int TVItemID)
        {
            return await (from mi in dbLocal.MapInfos
                          from mip in dbLocal.MapInfoPoints
                          where mi.MapInfoID == mip.MapInfoID
                          && mi.TVItemID == TVItemID
                          select mip).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVFile>> GetTVFileListWithTVItemID(int TVItemID)
        {
            return await (from c in dbLocal.TVItems
                          from cf in dbLocal.TVItems
                          from f in dbLocal.TVFiles
                          where c.TVItemID == cf.ParentID
                          && cf.TVType == TVTypeEnum.File
                          && f.TVFileTVItemID == cf.TVItemID
                          && c.TVItemID == TVItemID
                          select f).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVFileLanguage>> GetTVFileLanguageListWithTVItemID(int TVItemID)
        {
            return await (from c in dbLocal.TVItems
                          from cf in dbLocal.TVItems
                          from f in dbLocal.TVFiles
                          from fl in dbLocal.TVFileLanguages
                          where c.TVItemID == cf.ParentID
                          && cf.TVType == TVTypeEnum.File
                          && f.TVFileTVItemID == cf.TVItemID
                          && f.TVFileID == fl.TVFileID
                          && c.TVItemID == TVItemID
                          select fl).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItem>> GetTVItemChildrenListWithTVItemID(TVItem ParentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in dbLocal.TVItems
                              where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select c).AsNoTracking().ToListAsync();
            }

            if (tvType == TVTypeEnum.File)
            {
                return await (from c in dbLocal.TVItems
                              where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && c.TVType == tvType
                              && c.TVLevel == ParentTVItem.TVLevel + 1
                              select c).AsNoTracking().ToListAsync();
            }

            return await (from c in dbLocal.TVItems
                          where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemLanguage>> GetTVItemLanguageChildrenListWithTVItemID(TVItem ParentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in dbLocal.TVItems
                              from cl in dbLocal.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select cl).AsNoTracking().ToListAsync();

            }

            if (tvType == TVTypeEnum.File)
            {
                return await (from c in dbLocal.TVItems
                              from cl in dbLocal.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && c.TVType == tvType
                              && c.TVLevel == ParentTVItem.TVLevel + 1
                              select cl).AsNoTracking().ToListAsync();
            }

            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select cl).AsNoTracking().ToListAsync();

        }
        private async Task<List<TVItemStat>> GetTVItemStatChildrenListWithTVItemID(TVItem ParentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in dbLocal.TVItems
                              from cs in dbLocal.TVItemStats
                              where c.TVItemID == cs.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select cs).AsNoTracking().ToListAsync();
            }

            if (tvType == TVTypeEnum.File)
            {
                return await (from c in dbLocal.TVItems
                              from cs in dbLocal.TVItemStats
                              where c.TVItemID == cs.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && c.TVType == tvType
                              && c.TVLevel == ParentTVItem.TVLevel + 1
                              select cs).AsNoTracking().ToListAsync();
            }
            return await (from c in dbLocal.TVItems
                          from cs in dbLocal.TVItemStats
                          where c.TVItemID == cs.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfo>> GetMapInfoChildrenListWithTVItemID(TVItem ParentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in dbLocal.TVItems
                              from mi in dbLocal.MapInfos
                              where c.TVItemID == mi.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select mi).AsNoTracking().ToListAsync();
            }

            if (tvType == TVTypeEnum.File)
            {
                return await (from c in dbLocal.TVItems
                              from mi in dbLocal.MapInfos
                              where c.TVItemID == mi.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && c.TVType == tvType
                              && c.TVLevel == ParentTVItem.TVLevel + 1
                              select mi).AsNoTracking().ToListAsync();

            }

            return await (from c in dbLocal.TVItems
                          from mi in dbLocal.MapInfos
                          where c.TVItemID == mi.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select mi).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfoPoint>> GetMapInfoPointChildrenListWithTVItemID(TVItem ParentTVItem, TVTypeEnum tvType)
        {
            if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
            {
                return await (from c in dbLocal.TVItems
                              from mi in dbLocal.MapInfos
                              from mip in dbLocal.MapInfoPoints
                              where c.TVItemID == mi.TVItemID
                              && mi.MapInfoID == mip.MapInfoID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select mip).AsNoTracking().ToListAsync();
            }

            if (tvType == TVTypeEnum.File)
            {
                return await (from c in dbLocal.TVItems
                              from mi in dbLocal.MapInfos
                              from mip in dbLocal.MapInfoPoints
                              where c.TVItemID == mi.TVItemID
                              && mi.MapInfoID == mip.MapInfoID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && c.TVType == tvType
                              && c.TVLevel == ParentTVItem.TVLevel + 1
                              select mip).AsNoTracking().ToListAsync();
            }

            return await (from c in dbLocal.TVItems
                          from mi in dbLocal.MapInfos
                          from mip in dbLocal.MapInfoPoints
                          where c.TVItemID == mi.TVItemID
                          && mi.MapInfoID == mip.MapInfoID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select mip).AsNoTracking().ToListAsync();
        }
        private async Task<List<SamplingPlan>> GetSamplingPlanListWithProvinceTVItemID(int provinceTVItemID)
        {
            return await (from c in dbLocal.SamplingPlans
                          where c.ProvinceTVItemID == provinceTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<Infrastructure>> GetInfrastructureListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select ci).AsNoTracking().ToListAsync();
        }
        private async Task<List<MikeScenario>> GetMikeScenarioListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.MikeScenarios
                          where c.TVItemID == ci.MikeScenarioTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.MikeScenario
                          select ci).AsNoTracking().ToListAsync();
        }
        private async Task<List<MikeSource>> GetMikeSourceListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.MikeSources
                          where c.TVItemID == ci.MikeSourceTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.MikeSource
                          select ci).AsNoTracking().ToListAsync();
        }
        private async Task<List<MikeSourceStartEnd>> GetMikeSourceStartEndListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.MikeSources
                          from se in dbLocal.MikeSourceStartEnds
                          where c.TVItemID == ci.MikeSourceTVItemID
                          && ci.MikeSourceID == se.MikeSourceID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.MikeSource
                          select se).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemLink>> GetInfrastructureTVItemLinkListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from t in dbLocal.TVItemLinks
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && (c.TVItemID == t.FromTVItemID
                          || c.TVItemID == t.ToTVItemID)
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          && t.FromTVType == TVTypeEnum.Infrastructure
                          && t.ToTVType == TVTypeEnum.Infrastructure
                          select t).AsNoTracking().ToListAsync();
        }
        private async Task<Address> GetInfrastructureCivicAddressListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from a in dbLocal.Addresses
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          && ci.CivicAddressTVItemID != null
                          && ci.CivicAddressTVItemID == a.AddressTVItemID
                          select a).AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<List<MapInfo>> GetInfrastructureMapInfoListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from mi in dbLocal.MapInfos
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVItemID == mi.TVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select mi).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfoPoint>> GetInfrastructureMapInfoPointListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from mi in dbLocal.MapInfos
                          from mip in dbLocal.MapInfoPoints
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVItemID == mi.TVItemID
                          && mi.MapInfoID == mip.MapInfoID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select mip).AsNoTracking().ToListAsync();
        }
        private async Task<List<InfrastructureLanguage>> GetInfrastructureLanguageListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from cil in dbLocal.InfrastructureLanguages
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureID == cil.InfrastructureID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select cil).AsNoTracking().ToListAsync();
        }
        private async Task<List<BoxModel>> GetBoxModelListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from bm in dbLocal.BoxModels
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select bm).AsNoTracking().ToListAsync();
        }
        private async Task<List<BoxModelLanguage>> GetBoxModelLanguageListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from bm in dbLocal.BoxModels
                          from bml in dbLocal.BoxModelLanguages
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                          && bm.BoxModelID == bml.BoxModelID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select bml).AsNoTracking().ToListAsync();
        }
        private async Task<List<BoxModelResult>> GetBoxModelResultListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from bm in dbLocal.BoxModels
                          from bmr in dbLocal.BoxModelResults
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                          && bm.BoxModelID == bmr.BoxModelID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select bmr).AsNoTracking().ToListAsync();
        }
        private async Task<List<VPScenario>> GetVPScenarioListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from vps in dbLocal.VPScenarios
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select vps).AsNoTracking().ToListAsync();
        }
        private async Task<List<VPScenarioLanguage>> GetVPScenarioLanguageListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from vps in dbLocal.VPScenarios
                          from vpsl in dbLocal.VPScenarioLanguages
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                          && vps.VPScenarioID == vpsl.VPScenarioID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select vpsl).AsNoTracking().ToListAsync();
        }
        private async Task<List<VPAmbient>> GetVPAmbientListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from vps in dbLocal.VPScenarios
                          from vpa in dbLocal.VPAmbients
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                          && vps.VPScenarioID == vpa.VPScenarioID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select vpa).AsNoTracking().ToListAsync();
        }
        private async Task<List<VPResult>> GetVPResultListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from vps in dbLocal.VPScenarios
                          from vpr in dbLocal.VPResults
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                          && vps.VPScenarioID == vpr.VPScenarioID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select vpr).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemLink>> GetTVItemLinkListContactUnderMunicipality(int municipalityTVItemID)
        {
            return await (from c in dbLocal.TVItemLinks
                          where c.FromTVItemID == municipalityTVItemID
                          && c.FromTVType == TVTypeEnum.Municipality
                          && c.ToTVType == TVTypeEnum.Contact
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<Contact>> GetMunicipalityContactListUnderMunicipality(TVItem lcoalTVItemMunicipality)
        {
            return await (from tl in dbLocal.TVItemLinks
                          from c in dbLocal.Contacts
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == lcoalTVItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<Email>> GetMunicipalityContactEmailListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from tl in dbLocal.TVItemLinks
                          from c in dbLocal.Contacts
                          from e in dbLocal.Emails
                          from tl2 in dbLocal.TVItemLinks
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == TVItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          && tl2.FromTVItemID == tl.ToTVItemID
                          && tl2.ToTVItemID == e.EmailTVItemID
                          && tl2.FromTVType == TVTypeEnum.Contact
                          && tl2.ToTVType == TVTypeEnum.Email
                          select e).AsNoTracking().ToListAsync();
        }
        private async Task<List<Tel>> GetMunicipalityContactTelListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from tl in dbLocal.TVItemLinks
                          from c in dbLocal.Contacts
                          from t in dbLocal.Tels
                          from tl2 in dbLocal.TVItemLinks
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == TVItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          && tl2.FromTVItemID == tl.ToTVItemID
                          && tl2.ToTVItemID == t.TelTVItemID
                          && tl2.FromTVType == TVTypeEnum.Contact
                          && tl2.ToTVType == TVTypeEnum.Tel
                          select t).AsNoTracking().ToListAsync();
        }
        private async Task<List<Address>> GetMunicipalityContactAddressListUnderMunicipality(TVItem TVItemMunicipality)
        {
            return await (from tl in dbLocal.TVItemLinks
                          from c in dbLocal.Contacts
                          from a in dbLocal.Addresses
                          from tl2 in dbLocal.TVItemLinks
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == TVItemMunicipality.TVItemID
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
            return await (from c in dbLocal.SamplingPlans
                          where c.SamplingPlanID == samplingPlanID
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<List<SamplingPlanEmail>> GetSamplingPlanEmailListWithSamplingPlanID(int samplingPlanID)
        {
            return await (from c in dbLocal.SamplingPlanEmails
                          where c.SamplingPlanID == samplingPlanID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<SamplingPlanSubsector>> GetSamplingPlanSubsectorListWithSamplingPlanID(int samplingPlanID)
        {
            return await (from c in dbLocal.SamplingPlanSubsectors
                          where c.SamplingPlanID == samplingPlanID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<SamplingPlanSubsectorSite>> GetSamplingPlanSubsectorSiteListWithSamplingPlanID(int samplingPlanID)
        {
            return await (from c in dbLocal.SamplingPlanSubsectors
                          from cs in dbLocal.SamplingPlanSubsectorSites
                          where c.SamplingPlanSubsectorID == cs.SamplingPlanSubsectorID
                          && c.SamplingPlanID == samplingPlanID
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSample>> GetWQMSampleListFromSubsector1980_2020(TVItem TVItemSubsector)
        {
            DateTime StartDate = new DateTime(1980, 1, 1);
            DateTime EndDate = new DateTime(2020, 12, 31);

            return await (from c in dbLocal.TVItems
                          from sa in dbLocal.MWQMSamples
                          where c.TVItemID == sa.MWQMSiteTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.MWQMSite
                          && sa.SampleDateTime_Local >= StartDate
                          && sa.SampleDateTime_Local <= EndDate
                          select sa).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSample>> GetWQMSampleListFromSubsector2021_2060(TVItem TVItemSubsector)
        {
            DateTime StartDate = new DateTime(2021, 1, 1);
            DateTime EndDate = new DateTime(2060, 12, 31);

            return await (from c in dbLocal.TVItems
                          from sa in dbLocal.MWQMSamples
                          where c.TVItemID == sa.MWQMSiteTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.MWQMSite
                          && sa.SampleDateTime_Local >= StartDate
                          && sa.SampleDateTime_Local <= EndDate
                          select sa).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSampleLanguage>> GetWQMSampleLanguageListFromSubsector1980_2020(TVItem TVItemSubsector)
        {
            DateTime StartDate = new DateTime(1980, 1, 1);
            DateTime EndDate = new DateTime(2020, 12, 31);

            List<int> MWQMSampleIDList = await (from c in dbLocal.TVItems
                                                from sa in dbLocal.MWQMSamples
                                                where c.TVItemID == sa.MWQMSiteTVItemID
                                                && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                                && c.TVType == TVTypeEnum.MWQMSite
                                                && sa.SampleDateTime_Local >= StartDate
                                                && sa.SampleDateTime_Local <= EndDate
                                                select sa.MWQMSampleID).ToListAsync();

            return await (from sal in dbLocal.MWQMSampleLanguages
                          where MWQMSampleIDList.Contains(sal.MWQMSampleID)
                          select sal).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSampleLanguage>> GetWQMSampleLanguageListFromSubsector2021_2060(TVItem TVItemSubsector)
        {
            DateTime StartDate = new DateTime(2021, 1, 1);
            DateTime EndDate = new DateTime(2060, 12, 31);

            List<int> MWQMSampleIDList = await (from c in dbLocal.TVItems
                                                from sa in dbLocal.MWQMSamples
                                                where c.TVItemID == sa.MWQMSiteTVItemID
                                                && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                                && c.TVType == TVTypeEnum.MWQMSite
                                                && sa.SampleDateTime_Local >= StartDate
                                                && sa.SampleDateTime_Local <= EndDate
                                                select sa.MWQMSampleID).ToListAsync();

            return await (from sal in dbLocal.MWQMSampleLanguages
                          where MWQMSampleIDList.Contains(sal.MWQMSampleID)
                          select sal).AsNoTracking().ToListAsync();
        }
        private async Task<List<Classification>> GetClassificationListFromSubsector(TVItem TVItemSubsector)
        {
            return await (from c in dbLocal.TVItems
                          from r in dbLocal.Classifications
                          where c.TVItemID == r.ClassificationTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.Classification
                          select r).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMRun>> GetMWQMRunListFromSubsector(TVItem TVItemSubsector)
        {
            return await (from c in dbLocal.TVItems
                          from r in dbLocal.MWQMRuns
                          where c.TVItemID == r.MWQMRunTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.MWQMRun
                          select r).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMRunLanguage>> GetMWQMRunLanguageListFromSubsector(TVItem TVItemSubsector)
        {
            List<int> MWQMRunIDList = await (from c in dbLocal.TVItems
                                             from r in dbLocal.MWQMRuns
                                             where c.TVItemID == r.MWQMRunTVItemID
                                             && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                             && c.TVType == TVTypeEnum.MWQMRun
                                             select r.MWQMRunID).ToListAsync();

            return await (from rl in dbLocal.MWQMRunLanguages
                          where MWQMRunIDList.Contains(rl.MWQMRunID)
                          select rl).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSite>> GetMWQMSiteListFromSubsector(TVItem TVItemSubsector)
        {
            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          from s in dbLocal.MWQMSites
                          where c.TVItemID == cl.TVItemID
                          && c.TVItemID == s.MWQMSiteTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.MWQMSite
                          && cl.Language == LanguageEnum.en
                          orderby c.IsActive, cl.TVText
                          select s).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMSiteStartEndDate>> GetMWQMSiteStartEndDateListFromSubsector(TVItem TVItemSubsector)
        {
            List<int> MWQMSiteIDList = await (from c in dbLocal.TVItems
                                              from cl in dbLocal.TVItemLanguages
                                              from s in dbLocal.MWQMSites
                                              where c.TVItemID == cl.TVItemID
                                              && c.TVItemID == s.MWQMSiteTVItemID
                                              && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                              && c.TVType == TVTypeEnum.MWQMSite
                                              && cl.Language == LanguageEnum.en
                                              orderby c.IsActive, cl.TVText
                                              select s.MWQMSiteID).ToListAsync();

            return await (from sd in dbLocal.MWQMSiteStartEndDates
                          where MWQMSiteIDList.Contains(sd.MWQMSiteTVItemID)
                          select sd).AsNoTracking().ToListAsync();
        }
        private async Task<List<Contact>> GetAllContact()
        {
            List<Contact> contactList = await (from c in dbLocal.Contacts
                                               orderby c.LastName, c.FirstName, c.Initial
                                               select c).AsNoTracking().ToListAsync();

            foreach (Contact contact in contactList)
            {
                contact.PasswordHash = "";
                contact.Token = "";
            }

            return contactList;
        }
        private async Task<List<Address>> GetAllAddress()
        {
            return await (from c in dbLocal.Addresses
                          orderby c.GoogleAddressText, c.PostalCode
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<Email>> GetAllEmail()
        {
            return await (from c in dbLocal.Emails
                          orderby c.EmailAddress
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<Tel>> GetAllTel()
        {
            return await (from c in dbLocal.Tels
                          orderby c.TelNumber
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<ClimateSite>> GetClimateSiteListUnderProvince(TVItem TVItemProvince)
        {
            return await (from c in dbLocal.TVItems
                          from cs in dbLocal.ClimateSites
                          where c.TVItemID == cs.ClimateSiteTVItemID
                          && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && c.TVType == TVTypeEnum.ClimateSite
                          orderby cs.ClimateSiteName
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<TideSite>> GetTideSiteListUnderProvince(TVItem TVItemProvince)
        {
            return await (from c in dbLocal.TVItems
                          from cs in dbLocal.TideSites
                          where c.TVItemID == cs.TideSiteTVItemID
                          && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && c.TVType == TVTypeEnum.TideSite
                          orderby cs.TideSiteName
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<HydrometricSite>> GetHydrometricSiteListUnderProvince(TVItem TVItemProvince)
        {
            return await (from c in dbLocal.TVItems
                          from hs in dbLocal.HydrometricSites
                          where c.TVItemID == hs.HydrometricSiteTVItemID
                          && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && c.TVType == TVTypeEnum.HydrometricSite
                          orderby hs.HydrometricSiteName
                          select hs).AsNoTracking().ToListAsync();
        }
        private async Task<List<RatingCurve>> GetRatingCurveListUnderProvince(TVItem TVItemProvince)
        {
            return await (from c in dbLocal.TVItems
                          from hs in dbLocal.HydrometricSites
                          from rc in dbLocal.RatingCurves
                          where c.TVItemID == hs.HydrometricSiteTVItemID
                          && hs.HydrometricSiteID == rc.HydrometricSiteID
                          && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && c.TVType == TVTypeEnum.HydrometricSite
                          orderby hs.HydrometricSiteName
                          select rc).AsNoTracking().ToListAsync();
        }
        private async Task<List<RatingCurveValue>> GetRatingCurveValueListUnderProvince(TVItem TVItemProvince)
        {
            return await (from c in dbLocal.TVItems
                          from hs in dbLocal.HydrometricSites
                          from rc in dbLocal.RatingCurves
                          from rcv in dbLocal.RatingCurveValues
                          where c.TVItemID == hs.HydrometricSiteTVItemID
                          && hs.HydrometricSiteID == rc.HydrometricSiteID
                          && rc.RatingCurveID == rcv.RatingCurveID
                          && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && c.TVType == TVTypeEnum.HydrometricSite
                          orderby hs.HydrometricSiteName
                          select rcv).AsNoTracking().ToListAsync();
        }
        private async Task<List<DrogueRun>> GetDrogueRunListUnderProvince(int subsectorTVItemID)
        {
            return await (from c in dbLocal.DrogueRuns
                          where c.SubsectorTVItemID == subsectorTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<DrogueRunPosition>> GetDrogueRunPositionListUnderProvince(int subsectorTVItemID)
        {
            return await (from c in dbLocal.DrogueRuns
                          from p in dbLocal.DrogueRunPositions
                          where c.DrogueRunID == p.DrogueRunID
                          && c.SubsectorTVItemID == subsectorTVItemID
                          select p).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMAnalysisReportParameter>> GetMWQMAnalysisReportParameterListUnderSubsector(int subsectorTVItemID)
        {
            return await (from c in dbLocal.MWQMAnalysisReportParameters
                          where c.SubsectorTVItemID == subsectorTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<MWQMLookupMPN>> GetMWQMLookupMPN()
        {
            return await (from c in dbLocal.MWQMLookupMPNs
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<MikeScenario> GetMikeScenarioWithTVItemID(int mikeScenarioTVItemID)
        {
            return await (from c in dbLocal.MikeScenarios
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<List<MikeBoundaryCondition>> GetMikeBoundaryConditionListUnderMikeScenario(TVItem tvItemMikeScenario)
        {
            return await (from c in dbLocal.TVItems
                          from bc in dbLocal.MikeBoundaryConditions
                          where c.TVItemID == bc.MikeBoundaryConditionTVItemID
                          && c.TVPath.Contains(tvItemMikeScenario.TVPath + "p")
                          && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                          || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                          select bc).AsNoTracking().ToListAsync();
        }
        private async Task<List<MikeSource>> GetMikeSourceListUnderMikeScenario(TVItem tvItemMikeScenario)
        {
            return await (from c in dbLocal.TVItems
                          from ms in dbLocal.MikeSources
                          where c.TVItemID == ms.MikeSourceTVItemID
                          && c.TVPath.Contains(tvItemMikeScenario.TVPath + "p")
                          && c.TVType == TVTypeEnum.MikeSource
                          select ms).AsNoTracking().ToListAsync();
        }
        private async Task<List<MikeSourceStartEnd>> GetMikeSourceStartEndListUnderMikeScenario(TVItem TVItemMikeScenario)
        {
            return await (from c in dbLocal.TVItems
                          from ms in dbLocal.MikeSources
                          from se in dbLocal.MikeSourceStartEnds
                          where c.TVItemID == ms.MikeSourceTVItemID
                          && ms.MikeSourceID == se.MikeSourceID
                          && c.TVPath.Contains(TVItemMikeScenario.TVPath + "p")
                          && c.TVType == TVTypeEnum.MikeSource
                          select se).AsNoTracking().ToListAsync();
        }
        private async Task<List<EmailDistributionList>> GetEmailDistributionListListUnderCountry(int TVItemID)
        {
            return await (from c in dbLocal.EmailDistributionLists
                          where c.ParentTVItemID == TVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<EmailDistributionListLanguage>> GetEmailDistributionListLanguageListUnderCountry(int TVItemID)
        {
            return await (from c in dbLocal.EmailDistributionLists
                          from cl in dbLocal.EmailDistributionListLanguages
                          where c.ParentTVItemID == TVItemID
                          && c.EmailDistributionListID == cl.EmailDistributionListID
                          select cl).AsNoTracking().ToListAsync();
        }
        private async Task<List<EmailDistributionListContact>> GetEmailDistributionListContactListUnderCountry(int TVItemID)
        {
            return await (from c in dbLocal.EmailDistributionLists
                          from ec in dbLocal.EmailDistributionListContacts
                          where c.ParentTVItemID == TVItemID
                          && c.EmailDistributionListID == ec.EmailDistributionListID
                          select ec).AsNoTracking().ToListAsync();
        }
        private async Task<List<EmailDistributionListContactLanguage>> GetEmailDistributionListContactLanguageListUnderCountry(int TVItemID)
        {
            return await (from c in dbLocal.EmailDistributionLists
                          from ec in dbLocal.EmailDistributionListContacts
                          from ecl in dbLocal.EmailDistributionListContactLanguages
                          where c.ParentTVItemID == TVItemID
                          && c.EmailDistributionListID == ec.EmailDistributionListID
                          && ec.EmailDistributionListContactID == ecl.LastUpdateContactTVItemID
                          select ecl).AsNoTracking().ToListAsync();
        }
        private async Task<List<ClimateDataValue>> GetClimateDataValueListForClimateSite(int TVItemID)
        {
            return await (from c in dbLocal.ClimateSites
                          from cv in dbLocal.ClimateDataValues
                          where c.ClimateSiteID == cv.ClimateSiteID
                          && c.ClimateSiteTVItemID == TVItemID
                          orderby cv.DateTime_Local
                          select cv).AsNoTracking().ToListAsync();
        }
        private async Task<List<TideDataValue>> GetTideDataValueListForTideSite(int TVItemID)
        {
            return await (from c in dbLocal.TideSites
                          from cv in dbLocal.TideDataValues
                          where c.TideSiteTVItemID == cv.TideSiteTVItemID
                          && c.TideSiteTVItemID == TVItemID
                          select cv).AsNoTracking().ToListAsync();
        }
        private async Task<List<HydrometricDataValue>> GetHydrometricDataValueListForHydrometricSite(int TVItemID)
        {
            return await (from c in dbLocal.HydrometricSites
                          from hv in dbLocal.HydrometricDataValues
                          where c.HydrometricSiteID == hv.HydrometricSiteID
                          && c.HydrometricSiteTVItemID == TVItemID
                          orderby hv.DateTime_Local
                          select hv).AsNoTracking().ToListAsync();
        }
        private async Task<List<HelpDoc>> GetHelpDoc()
        {
            return await (from c in dbLocal.HelpDocs
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<LabSheet>> GetLabSheetListUnderSubsector(int subsectorTVItemID)
        {
            return await (from c in dbLocal.LabSheets
                          where c.SubsectorTVItemID == subsectorTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<LabSheetDetail>> GetLabSheetDetailListUnderSubsector(int subsectorTVItemID)
        {
            return await (from c in dbLocal.LabSheets
                          from cd in dbLocal.LabSheetDetails
                          where c.LabSheetID == cd.LabSheetID
                          && c.SubsectorTVItemID == subsectorTVItemID
                          select cd).AsNoTracking().ToListAsync();
        }
        private async Task<List<LabSheetTubeMPNDetail>> GetLabSheetTubeMPNDetailListUnderSubsector(int subsectorTVItemID)
        {
            return await (from c in dbLocal.LabSheets
                          from cd in dbLocal.LabSheetDetails
                          from ct in dbLocal.LabSheetTubeMPNDetails
                          where c.LabSheetID == cd.LabSheetID
                          && cd.LabSheetDetailID == ct.LabSheetDetailID
                          && c.SubsectorTVItemID == subsectorTVItemID
                          select ct).AsNoTracking().ToListAsync();
        }
        private async Task<MWQMSubsector> GetMWQMSubsector(int subsectorTVItemID)
        {
            return await (from c in dbLocal.MWQMSubsectors
                          where c.MWQMSubsectorID == subsectorTVItemID
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<List<MWQMSubsectorLanguage>> GetMWQMSubsectorLanguageList(int subsectorTVItemID)
        {
            return await (from c in dbLocal.MWQMSubsectors
                          from cl in dbLocal.MWQMSubsectorLanguages
                          where c.MWQMSubsectorID == cl.MWQMSubsectorID
                          && c.MWQMSubsectorID == subsectorTVItemID
                          select cl).AsNoTracking().ToListAsync();
        }
        private async Task<List<TideLocation>> GetTideLocation()
        {
            return await (from c in dbLocal.TideLocations
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<UseOfSite>> GetUseOfSiteList(int subsectorTVItemID)
        {
            return await (from c in dbLocal.UseOfSites
                          where c.SubsectorTVItemID == subsectorTVItemID
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceSite>> GetPolSourceSiteListFromSubsector(TVItem TVItemSubsector)
        {
            return await (from c in dbLocal.TVItems
                          from p in dbLocal.PolSourceSites
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select p).AsNoTracking().ToListAsync();
        }
        private async Task<List<Address>> GetPolSourceSiteAddressListFromSubsector(TVItem TVItemSubsector)
        {
            return await (from c in dbLocal.TVItems
                          from p in dbLocal.PolSourceSites
                          from a in dbLocal.Addresses
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.CivicAddressTVItemID != null
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.PolSourceSite
                          && p.CivicAddressTVItemID == a.AddressTVItemID
                          select a).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceObservation>> GetPolSourceObservationListFromSubsector(TVItem TVItemSubsector)
        {
            return await (from c in dbLocal.TVItems
                          from p in dbLocal.PolSourceSites
                          from po in dbLocal.PolSourceObservations
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.PolSourceSiteID == po.PolSourceSiteID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select po).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceObservationIssue>> GetPolSourceObservationIssueListFromSubsector(TVItem TVItemSubsector)
        {
            return await (from c in dbLocal.TVItems
                          from p in dbLocal.PolSourceSites
                          from po in dbLocal.PolSourceObservations
                          from poi in dbLocal.PolSourceObservationIssues
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.PolSourceSiteID == po.PolSourceSiteID
                          && po.PolSourceObservationID == poi.PolSourceObservationID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select poi).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceSiteEffect>> GetPolSourceSiteEffectListFromSubsector(TVItem TVItemSubsector)
        {
            return await (from c in dbLocal.TVItems
                          from p in dbLocal.PolSourceSites
                          from pe in dbLocal.PolSourceSiteEffects
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.PolSourceSiteID == pe.PolSourceSiteOrInfrastructureTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select pe).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermListFromSubsector(TVItem TVItemSubsector)
        {
            return await (from c in dbLocal.TVItems
                          from p in dbLocal.PolSourceSites
                          from pe in dbLocal.PolSourceSiteEffects
                          from pet in dbLocal.PolSourceSiteEffectTerms
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && p.PolSourceSiteID == pe.PolSourceSiteOrInfrastructureTVItemID
                          && pe.PolSourceSiteEffectID == pet.PolSourceSiteEffectTermID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select pet).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceGrouping>> GetPolSourceGroupingList()
        {
            return await (from c in dbLocal.PolSourceGroupings
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceGroupingLanguage>> GetPolSourceGroupingLanguageList()
        {
            return await (from c in dbLocal.PolSourceGroupingLanguages
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermList()
        {
            return await (from c in dbLocal.PolSourceSiteEffectTerms
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<ReportType>> GetReportTypeList()
        {
            return await (from c in dbLocal.ReportTypes
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<ReportSection>> GetReportSectionList()
        {
            return await (from c in dbLocal.ReportSections
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItem>> GetAllTVItem()
        {
            return await (from c in dbLocal.TVItems
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemLanguage>> GetAllTVItemLanguage()
        {
            return await (from cl in dbLocal.TVItemLanguages
                          select cl).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItem>> GetTVItemParentListWithTVItemID(TVItem TVItem)
        {
            List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

            return await (from c in dbLocal.TVItems
                          where ParentsTVItemID.Contains(c.TVItemID)
                          orderby c.TVLevel
                          select c).AsNoTracking().ToListAsync();
        }
        private async Task<List<TVItemLanguage>> GetTVItemLanguageParentListWithTVItemID(TVItem TVItem)
        {
            List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && ParentsTVItemID.Contains(c.TVItemID)
                          select cl).AsNoTracking().ToListAsync();

        }
        private async Task<List<TVItemStat>> GetTVItemStatParentListWithTVItemID(TVItem TVItem)
        {
            List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

            return await (from c in dbLocal.TVItems
                          from cs in dbLocal.TVItemStats
                          where c.TVItemID == cs.TVItemID
                          && ParentsTVItemID.Contains(c.TVItemID)
                          select cs).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfo>> GetMapInfoParentListWithTVItemID(TVItem TVItem)
        {
            List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

            return await (from c in dbLocal.TVItems
                          from mi in dbLocal.MapInfos
                          where c.TVItemID == mi.TVItemID
                          && ParentsTVItemID.Contains(c.TVItemID)
                          select mi).AsNoTracking().ToListAsync();
        }
        private async Task<List<MapInfoPoint>> GetMapInfoPointParentListWithTVItemID(TVItem TVItem)
        {
            List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

            return await (from c in dbLocal.TVItems
                          from mi in dbLocal.MapInfos
                          from mip in dbLocal.MapInfoPoints
                          where c.TVItemID == mi.TVItemID
                          && mi.MapInfoID == mip.MapInfoID
                          && ParentsTVItemID.Contains(c.TVItemID)
                          select mip).AsNoTracking().ToListAsync();
        }
    }
}
