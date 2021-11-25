namespace CSSPDBServices;

public partial class AppTaskDBService : ControllerBase, IAppTaskDBService
{
    private async Task<bool> ValidateAppTaskDBAsync(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
    {
        string retStr = "";
        AppTask appTask = validationContext.ObjectInstance as AppTask;

        if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
        {
            if (appTask.AppTaskID == 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
            }

            if (!(from c in db.AppTasks.AsNoTracking() select c).Where(c => c.AppTaskID == appTask.AppTaskID).Any())
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTask.AppTaskID.ToString()));
            }
        }

        retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTask.DBCommand);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }

        TVItem TVItemTVItemID = null;
        TVItemTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();

        if (TVItemTVItemID == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", appTask.TVItemID.ToString()));
        }
        else
        {
            List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Country,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.Outfall,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.SeeOtherMunicipality,
                    TVTypeEnum.LineOverflow,
                };
            if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow"));
            }
        }

        TVItem TVItemTVItemID2 = null;
        TVItemTVItemID2 = (from c in db.TVItems.AsNoTracking() where c.TVItemID == appTask.TVItemID2 select c).FirstOrDefault();

        if (TVItemTVItemID2 == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID2", appTask.TVItemID2.ToString()));
        }
        else
        {
            List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Country,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.Outfall,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.SeeOtherMunicipality,
                    TVTypeEnum.LineOverflow,
                };
            if (!AllowableTVTypes.Contains(TVItemTVItemID2.TVType))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "TVItemID2", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow"));
            }
        }

        retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTask.AppTaskCommand);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
        }

        retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTask.AppTaskStatus);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
        }

        if (appTask.PercentCompleted < 0 || appTask.PercentCompleted > 100)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "PercentCompleted", "0", "100"));
        }

        if (string.IsNullOrWhiteSpace(appTask.Parameters))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Parameters"));
        }

        //Parameters has no StringLength Attribute

        retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTask.Language);
        if (!string.IsNullOrWhiteSpace(retStr))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
        }

        if (appTask.StartDateTime_UTC.Year == 1)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "StartDateTime_UTC"));
        }
        else
        {
            if (appTask.StartDateTime_UTC.Year < 1980)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1980"));
            }
        }

        if (appTask.EndDateTime_UTC != null && ((DateTime)appTask.EndDateTime_UTC).Year < 1980)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1980"));
        }

        if (appTask.StartDateTime_UTC > appTask.EndDateTime_UTC)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateTime_UTC", "AppTaskStartDateTime_UTC"));
        }

        if (appTask.EstimatedLength_second != null)
        {
            if (appTask.EstimatedLength_second < 0 || appTask.EstimatedLength_second > 1000000)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "EstimatedLength_second", "0", "1000000"));
            }
        }

        if (appTask.RemainingTime_second != null)
        {
            if (appTask.RemainingTime_second < 0 || appTask.RemainingTime_second > 1000000)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "RemainingTime_second", "0", "1000000"));
            }
        }

        if (appTask.LastUpdateDate_UTC.Year == 1)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "LastUpdateDate_UTC"));
        }
        else
        {
            if (appTask.LastUpdateDate_UTC.Year < 1980)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"));
            }
        }

        TVItem TVItemLastUpdateContactTVItemID = null;
        TVItemLastUpdateContactTVItemID = (from c in db.TVItems.AsNoTracking() where c.TVItemID == appTask.LastUpdateContactTVItemID select c).FirstOrDefault();

        if (TVItemLastUpdateContactTVItemID == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appTask.LastUpdateContactTVItemID.ToString()));
        }
        else
        {
            List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
            if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"));
            }
        }

        return errRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
    }
}


