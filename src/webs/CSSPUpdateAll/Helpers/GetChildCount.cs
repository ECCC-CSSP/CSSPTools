using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace CSSPUpdateAll
{
    public partial class Startup
    {
        private int GetChildCount(TVItem tvItem, TVTypeEnum ChildTVType, List<TVItem> TVItemList, List<TVItemLink> TVItemLinkList)
        {
            int ChildCount = -1;
            switch (ChildTVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (tvItem.TVType == TVTypeEnum.Root)
                        {
                            ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Address)
                                          select c).Count();
                        }
                        else
                        {
                            if (tvItem.TVType == TVTypeEnum.Municipality)
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Municipality)
                                              from cl in TVItemLinkList.Where(c => c.FromTVType == TVTypeEnum.Municipality && c.ToTVType == TVTypeEnum.Contact)
                                              let addressCount = (from cll in TVItemLinkList.Where(c => c.FromTVType == TVTypeEnum.Contact && c.ToTVType == TVTypeEnum.Address)
                                                                  where cll.FromTVItemID == c.TVItemID
                                                                  select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVItemID == tvItem.TVItemID
                                              && cl.ToTVType == TVTypeEnum.Contact
                                              select addressCount).DefaultIfEmpty().Sum();
;
                            }
                            else
                            {
                                ChildCount = (from c in TVItemList.Where(c => c.TVType == ChildTVType)
                                              from cl in TVItemLinkList.Where(c => c.FromTVType == ChildTVType)
                                              let addressCount = (from cll in TVItemLinkList.Where(c => c.ToTVType == ChildTVType && c.ToTVType == TVTypeEnum.Address)
                                                                  where cll.FromTVItemID == c.TVItemID
                                                                  select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              && cl.ToTVType == TVTypeEnum.Contact
                                              select addressCount).DefaultIfEmpty().Sum()
                                              +
                                              (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Infrastructure)
                                               from ci in db.Infrastructures
                                               where c.TVItemID == ci.InfrastructureTVItemID
                                               && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                               && ci.CivicAddressTVItemID > 0
                                               select c).Count()
                                          +
                                          (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.PolSourceSite)
                                           from ci in db.PolSourceSites
                                           where c.TVItemID == ci.PolSourceSiteTVItemID
                                           && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                           && ci.CivicAddressTVItemID > 0
                                           select c).Count()
;
                            };
                        }
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        ChildCount = (from c in TVItemList.Where(c => c.TVType == ChildTVType)
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.BoxModel:
                    {
                        if (tvItem.TVType == TVTypeEnum.Infrastructure)
                        {
                            ChildCount = (from b in db.BoxModels
                                          where b.InfrastructureTVItemID == tvItem.TVItemID
                                          select b).Count();
                        }
                        else
                        {
                            ChildCount = (from c in TVItemList
                                          from b in db.BoxModels
                                          where c.TVItemID == b.InfrastructureTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          select b).Count();
                        }
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (tvItem.TVType == TVTypeEnum.Root || tvItem.TVType == TVTypeEnum.Country || tvItem.TVType == TVTypeEnum.Province)
                        {
                            ChildCount = (from c in TVItemList
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.ClimateSite
                                          select c).Count();
                        }
                        else if (tvItem.TVType == TVTypeEnum.Area || tvItem.TVType == TVTypeEnum.Sector)
                        {
                            ChildCount = (from c in TVItemList
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.Subsector
                                          && cu.TVType == TVTypeEnum.ClimateSite
                                          select c).Count();
                        }
                        else if (tvItem.TVType == TVTypeEnum.Subsector)
                        {
                            ChildCount = (from c in TVItemList
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVItemID == tvItem.TVItemID
                                          && c.TVType == TVTypeEnum.Subsector
                                          && cu.TVType == TVTypeEnum.ClimateSite
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (tvItem.TVType == TVTypeEnum.Municipality)
                        {
                            ChildCount = (from c in TVItemList
                                          from cl in TVItemLinkList
                                          where c.TVItemID == cl.FromTVItemID
                                          && c.TVItemID == tvItem.TVItemID
                                          && cl.ToTVType == TVTypeEnum.Contact
                                          select c).Count();
                        }
                        else
                        {
                            ChildCount = (from c in TVItemList.Where(c => c.TVType == TVTypeEnum.Municipality)
                                          from cl in TVItemLinkList.Where(c => c.FromTVType == TVTypeEnum.Municipality && c.ToTVType == TVTypeEnum.Contact)
                                          where c.TVItemID == cl.FromTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.Country
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        if (tvItem.TVType == TVTypeEnum.Root)
                        {
                            ChildCount = (from c in TVItemList
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.Email
                                          select c).Count();
                        }
                        else
                        {
                            if (tvItem.TVType == TVTypeEnum.Municipality)
                            {
                                ChildCount = (from c in TVItemList
                                              from cl in TVItemLinkList
                                              let emailCount = (from cll in TVItemLinkList
                                                                where cll.FromTVItemID == c.TVItemID
                                                                && cll.ToTVType == TVTypeEnum.Email
                                                                select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVItemID == tvItem.TVItemID
                                              && cl.ToTVType == TVTypeEnum.Contact
                                              select emailCount).DefaultIfEmpty().Sum();
                            }
                            else
                            {
                                ChildCount = (from c in TVItemList
                                              from cl in TVItemLinkList
                                              let emailCount = (from cll in TVItemLinkList
                                                                where cll.FromTVItemID == c.TVItemID
                                                                && cll.ToTVType == TVTypeEnum.Email
                                                                select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              && cl.ToTVType == TVTypeEnum.Contact
                                              select emailCount).DefaultIfEmpty().Sum();
                            }
                        }
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        int TVLevelFile = tvItem.TVLevel + 1;
                        ChildCount = (from c in TVItemList
                                      from f in db.TVFiles
                                      where c.TVItemID == f.TVFileTVItemID
                                      && c.TVLevel == TVLevelFile
                                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.File
                                      && f.FilePurpose != FilePurposeEnum.Template
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (tvItem.TVType == TVTypeEnum.Root || tvItem.TVType == TVTypeEnum.Country || tvItem.TVType == TVTypeEnum.Province)
                        {
                            ChildCount = (from c in TVItemList
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.HydrometricSite
                                          select c).Count();
                        }
                        else if (tvItem.TVType == TVTypeEnum.Area || tvItem.TVType == TVTypeEnum.Sector)
                        {
                            ChildCount = (from c in TVItemList
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.Subsector
                                          && cu.TVType == TVTypeEnum.HydrometricSite
                                          select c).Count();
                        }
                        else if (tvItem.TVType == TVTypeEnum.Subsector)
                        {
                            ChildCount = (from c in TVItemList
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVItemID == tvItem.TVItemID
                                          && c.TVType == TVTypeEnum.Subsector
                                          && cu.TVType == TVTypeEnum.HydrometricSite
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.Infrastructure
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.LiftStation:
                    {
                        ChildCount = (from c in TVItemList
                                      from inf in db.Infrastructures
                                      where c.TVItemID == inf.InfrastructureTVItemID
                                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && inf.InfrastructureType == InfrastructureTypeEnum.LiftStation
                                      select inf).Count();
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.MikeScenario
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.MikeSource
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.Municipality
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (tvItem.TVType == TVTypeEnum.MWQMSite)
                        {
                            ChildCount = (from c in db.MWQMSamples
                                          where c.MWQMSiteTVItemID == tvItem.TVItemID
                                          select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        else
                        {
                            ChildCount = (from c in TVItemList
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.MWQMRun
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (tvItem.TVType == TVTypeEnum.MWQMRun)
                        {
                            ChildCount = (from c in db.MWQMSamples
                                          where c.MWQMRunTVItemID == tvItem.TVItemID
                                          select c.MWQMSiteTVItemID).Distinct().Count();
                        }
                        else
                        {
                            ChildCount = (from c in TVItemList
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.MWQMSite
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSiteSample:
                    {
                        if (tvItem.TVType == TVTypeEnum.MWQMRun)
                        {
                            ChildCount = (from s in db.MWQMSamples
                                          where s.MWQMRunTVItemID == tvItem.TVItemID
                                          select s).Count();
                        }
                        else if (tvItem.TVType == TVTypeEnum.MWQMSite)
                        {
                            ChildCount = (from s in db.MWQMSamples
                                          where s.MWQMSiteTVItemID == tvItem.TVItemID
                                          select s).Count();
                        }
                        else
                        {
                            ChildCount = 0;
                            if ((from c in TVItemList
                                 where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                 && c.TVType == TVTypeEnum.MWQMSite
                                 select c).Any())
                            {
                                ChildCount = (from c in TVItemList
                                              let count = (from s in db.MWQMSamples
                                                           where s.MWQMSiteTVItemID == c.TVItemID
                                                           select s).Count()
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              && c.TVType == TVTypeEnum.MWQMSite
                                              select count).Sum();
                            }
                        }
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.PolSourceSite
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.Province
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.Sector
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.Subsector
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Spill:
                    {
                        ChildCount = (from c in TVItemList
                                      from s in db.Spills
                                      where (c.TVItemID == s.MunicipalityTVItemID
                                      || c.TVItemID == s.InfrastructureTVItemID)
                                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && (c.TVType == TVTypeEnum.Municipality
                                      || c.TVType == TVTypeEnum.Infrastructure)
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (tvItem.TVType == TVTypeEnum.Root)
                        {
                            ChildCount = (from c in TVItemList
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.Tel
                                          select c).Count();
                        }
                        else
                        {
                            if (tvItem.TVType == TVTypeEnum.Municipality)
                            {
                                ChildCount = (from c in TVItemList
                                              from cl in TVItemLinkList
                                              let telCount = (from cll in TVItemLinkList
                                                              where cll.FromTVItemID == c.TVItemID
                                                              && cll.ToTVType == TVTypeEnum.Tel
                                                              select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVItemID == tvItem.TVItemID
                                              && cl.ToTVType == TVTypeEnum.Contact
                                              select telCount).DefaultIfEmpty().Sum();
                            }
                            else
                            {
                                ChildCount = (from c in TVItemList
                                              from cl in TVItemLinkList
                                              let telCount = (from cll in TVItemLinkList
                                                              where cll.FromTVItemID == c.TVItemID
                                                              && cll.ToTVType == TVTypeEnum.Tel
                                                              select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              && cl.ToTVType == TVTypeEnum.Contact
                                              select telCount).DefaultIfEmpty().Sum();
                            }
                        }
                    }
                    break;
                case TVTypeEnum.TideSite:
                    {
                        if (tvItem.TVType == TVTypeEnum.Root || tvItem.TVType == TVTypeEnum.Country || tvItem.TVType == TVTypeEnum.Province)
                        {
                            ChildCount = (from c in TVItemList
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.TideSite
                                          select c).Count();
                        }
                        else if (tvItem.TVType == TVTypeEnum.Area || tvItem.TVType == TVTypeEnum.Sector)
                        {
                            ChildCount = (from c in TVItemList
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == TVTypeEnum.Subsector
                                          && cu.TVType == TVTypeEnum.TideSite
                                          select c).Count();
                        }
                        else if (tvItem.TVType == TVTypeEnum.Subsector)
                        {
                            ChildCount = (from c in TVItemList
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVItemID == tvItem.TVItemID
                                          && c.TVType == TVTypeEnum.Subsector
                                          && cu.TVType == TVTypeEnum.TideSite
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.TotalFile:
                    {
                        ChildCount = (from c in TVItemList
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == TVTypeEnum.File
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.VisualPlumesScenario:
                    {
                        if (tvItem.TVType == TVTypeEnum.Infrastructure)
                        {
                            ChildCount = (from v in db.VPScenarios
                                          where v.InfrastructureTVItemID == tvItem.TVItemID
                                          select v).Count();
                        }
                        else
                        {
                            ChildCount = (from c in TVItemList
                                          from v in db.VPScenarios
                                          where c.TVItemID == v.InfrastructureTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          select v).Count();
                        }
                    }
                    break;
                case TVTypeEnum.WasteWaterTreatmentPlant:
                    {
                        ChildCount = (from c in TVItemList
                                      from inf in db.Infrastructures
                                      where c.TVItemID == inf.InfrastructureTVItemID
                                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && inf.InfrastructureType == InfrastructureTypeEnum.WWTP
                                      select inf).Count();
                    }
                    break;
                default:
                    break;
            }

            return ChildCount;
        }
    }
}
