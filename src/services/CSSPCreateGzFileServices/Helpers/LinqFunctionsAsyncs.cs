namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<TVItem> GetTVItemRootAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          where c.TVLevel == 0
                          && c.TVType == TVTypeEnum.Root
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }

        return await (from c in db.TVItems
                      where c.TVLevel == 0
                      && c.TVType == TVTypeEnum.Root
                      select c).AsNoTracking().FirstOrDefaultAsync();

    }
    private async Task<TVItem> GetTVItemWithTVItemIDAsync(int TVItemID)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          where c.TVItemID == TVItemID
                          select c).AsNoTracking().FirstOrDefaultAsync();
        }

        return await (from c in db.TVItems
                      where c.TVItemID == TVItemID
                      select c).AsNoTracking().FirstOrDefaultAsync();
    }
    private async Task<List<TVItemLanguage>> GetTVItemLanguageWithTVItemIDAsync(int TVItemID)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVItemID == TVItemID
                          select cl).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cl in db.TVItemLanguages
                      where c.TVItemID == cl.TVItemID
                      && c.TVItemID == TVItemID
                      select cl).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVFile>> GetTVFileListWithTVItemIDAsync(int TVItemID)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from cf in db.TVItems
                      from f in db.TVFiles
                      where c.TVItemID == cf.ParentID
                      && cf.TVType == TVTypeEnum.File
                      && f.TVFileTVItemID == cf.TVItemID
                      && c.TVItemID == TVItemID
                      select f).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVFile>> GetAllTVFileListUnderAsync(TVItem tvItem)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from f in dbLocal.TVFiles
                          where c.TVItemID == f.TVFileTVItemID
                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                          && c.TVType == TVTypeEnum.File
                          select f).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from f in db.TVFiles
                      where c.TVItemID == f.TVFileTVItemID
                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                      && c.TVType == TVTypeEnum.File
                      select f).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVFileLanguage>> GetTVFileLanguageListWithTVItemIDAsync(int TVItemID)
    {
        if (Local)
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
    private async Task<List<TVFileLanguage>> GetAllTVFileLanguageListUnderAsync(TVItem tvItem)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from f in dbLocal.TVFiles
                          from fl in dbLocal.TVFileLanguages
                          where c.TVItemID == f.TVFileTVItemID
                          && f.TVFileID == fl.TVFileID
                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                          && c.TVType == TVTypeEnum.File
                          select fl).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from f in db.TVFiles
                      from fl in db.TVFileLanguages
                      where c.TVItemID == f.TVFileTVItemID
                      && f.TVFileID == fl.TVFileID
                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                      && c.TVType == TVTypeEnum.File
                      select fl).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItem>> GetTVItemListFileUnderMunicipalityAsync(TVItem MunicipalityTVItem)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          where c.TVPath.Contains(MunicipalityTVItem.TVPath + "p")
                          && c.TVType == TVTypeEnum.File
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      where c.TVPath.Contains(MunicipalityTVItem.TVPath + "p")
                      && c.TVType == TVTypeEnum.File
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItemLanguage>> GetTVItemLanguageListFileUnderMunicipalityAsync(TVItem MunicipalityTVItem)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVPath.Contains(MunicipalityTVItem.TVPath + "p")
                          && c.TVType == TVTypeEnum.File
                          select cl).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cl in db.TVItemLanguages
                      where c.TVItemID == cl.TVItemID
                      && c.TVPath.Contains(MunicipalityTVItem.TVPath + "p")
                      && c.TVType == TVTypeEnum.File
                      select cl).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItem>> GetTVItemChildrenListWithTVItemIDAsync(TVItem ParentTVItem, TVTypeEnum tvType)
    {
        if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
        {
            if (Local)
            {
                return await (from c in dbLocal.TVItems
                              where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select c).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                          || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                          select c).AsNoTracking().ToListAsync();
        }

        if (tvType == TVTypeEnum.File)
        {
            if (Local)
            {
                return await (from c in dbLocal.TVItems
                              where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && c.TVType == tvType
                              && c.TVLevel == ParentTVItem.TVLevel + 1
                              select c).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          && c.TVLevel == ParentTVItem.TVLevel + 1
                          select c).AsNoTracking().ToListAsync();
        }

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                      && c.TVType == tvType
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItem>> GetTVItemAllChildrenListWithTVItemIDAsync(TVItem ParentTVItem, TVTypeEnum tvType)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      where c.TVPath.Contains(ParentTVItem.TVPath + "p")
                      && c.TVType == tvType
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMSample>> GetMWQMSampleListUnderSubsectorAsync(TVItem subsectorTVItem)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from s in dbLocal.MWQMSamples
                          where c.TVItemID == s.MWQMSiteTVItemID
                          && c.TVType == TVTypeEnum.MWQMSite
                          && c.TVPath.Contains(subsectorTVItem.TVPath + "p")
                          select s).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from s in db.MWQMSamples
                      where c.TVItemID == s.MWQMSiteTVItemID
                      && c.TVType == TVTypeEnum.MWQMSite
                      && c.TVPath.Contains(subsectorTVItem.TVPath + "p")
                      select s).AsNoTracking().ToListAsync();
    }
    private int GetMWQMSampleCountOtherByYearUnderCountry(TVItem countryTVItem, int Year)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && !s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Year == Year
                    select s).Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && !s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Year == Year
                select s).Count();
    }
    private int GetMWQMSampleCountOtherByMonthUnderCountry(TVItem countryTVItem, MonthEnum Month)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && !s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Month == (int)Month
                    select s).Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && !s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Month == (int)Month
                select s).Count();
    }
    private int GetMWQMSampleCountOtherBySeasonUnderCountry(TVItem countryTVItem, SeasonEnum Season)
    {
        if (Local)
        {
            switch (Season)
            {
                case SeasonEnum.Winter:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day < 21))
                            select s).Count();
                case SeasonEnum.Spring:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day < 21))
                            select s).Count();
                case SeasonEnum.Summer:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day < 21))
                            select s).Count();
                case SeasonEnum.Fall:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day < 21))
                            select s).Count();
                default:
                    return -1;
            }
        }

        switch (Season)
        {
            case SeasonEnum.Winter:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day < 21))
                        select s).Count();
            case SeasonEnum.Spring:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day < 21))
                        select s).Count();
            case SeasonEnum.Summer:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day < 21))
                        select s).Count();
            case SeasonEnum.Fall:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day < 21))
                        select s).Count();
            default:
                return -1;
        }
    }
    private int GetMWQMSampleCountRoutineByYearUnderCountry(TVItem countryTVItem, int Year)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Year == Year
                    select s).Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Year == Year
                select s).Count();
    }
    private int GetMWQMSampleCountRoutineByMonthUnderCountry(TVItem countryTVItem, MonthEnum Month)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Month == (int)Month
                    select s).Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Month == (int)Month
                select s).Count();
    }
    private int GetMWQMSampleCountRoutineBySeasonUnderCountry(TVItem countryTVItem, SeasonEnum Season)
    {
        if (Local)
        {
            switch (Season)
            {
                case SeasonEnum.Winter:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day < 21))
                            select s).Count();
                case SeasonEnum.Spring:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day < 21))
                            select s).Count();
                case SeasonEnum.Summer:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day < 21))
                            select s).Count();
                case SeasonEnum.Fall:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day < 21))
                            select s).Count();
                default:
                    return -1;
            }
        }

        switch (Season)
        {
            case SeasonEnum.Winter:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day < 21))
                        select s).Count();
            case SeasonEnum.Spring:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day < 21))
                        select s).Count();
            case SeasonEnum.Summer:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day < 21))
                        select s).Count();
            case SeasonEnum.Fall:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day < 21))
                        select s).Count();
            default:
                return -1;
        }
    }
    private int GetMWQMSiteCountOtherByYearUnderCountry(TVItem countryTVItem, int Year)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && !s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Year == Year
                    select s.MWQMSiteTVItemID).Distinct().Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && !s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Year == Year
                select s.MWQMSiteTVItemID).Distinct().Count();
    }
    private int GetMWQMSiteCountOtherByMonthUnderCountry(TVItem countryTVItem, MonthEnum Month)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && !s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Month == (int)Month
                    select s.MWQMSiteTVItemID).Distinct().Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && !s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Month == (int)Month
                select s.MWQMSiteTVItemID).Distinct().Count();
    }
    private int GetMWQMSiteCountOtherBySeasonUnderCountry(TVItem countryTVItem, SeasonEnum Season)
    {
        if (Local)
        {
            switch (Season)
            {
                case SeasonEnum.Winter:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMSiteTVItemID).Distinct().Count();
                case SeasonEnum.Spring:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMSiteTVItemID).Distinct().Count();
                case SeasonEnum.Summer:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMSiteTVItemID).Distinct().Count();
                case SeasonEnum.Fall:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMSiteTVItemID).Distinct().Count();
                default:
                    return -1;
            }
        }

        switch (Season)
        {
            case SeasonEnum.Winter:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMSiteTVItemID).Distinct().Count();
            case SeasonEnum.Spring:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMSiteTVItemID).Distinct().Count();
            case SeasonEnum.Summer:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMSiteTVItemID).Distinct().Count();
            case SeasonEnum.Fall:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMSiteTVItemID).Distinct().Count();
            default:
                return -1;
        }
    }
    private int GetMWQMSiteCountRoutineByYearUnderCountry(TVItem countryTVItem, int Year)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Year == Year
                    select s.MWQMSiteTVItemID).Distinct().Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Year == Year
                select s.MWQMSiteTVItemID).Distinct().Count();
    }
    private int GetMWQMSiteCountRoutineByMonthUnderCountry(TVItem countryTVItem, MonthEnum Month)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Month == (int)Month
                    select s.MWQMSiteTVItemID).Distinct().Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Month == (int)Month
                select s.MWQMSiteTVItemID).Distinct().Count();
    }
    private int GetMWQMSiteCountRoutineBySeasonUnderCountry(TVItem countryTVItem, SeasonEnum Season)
    {
        if (Local)
        {
            switch (Season)
            {
                case SeasonEnum.Winter:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMSiteTVItemID).Distinct().Count();
                case SeasonEnum.Spring:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMSiteTVItemID).Distinct().Count();
                case SeasonEnum.Summer:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMSiteTVItemID).Distinct().Count();
                case SeasonEnum.Fall:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMSiteTVItemID).Distinct().Count();
                default:
                    return -1;
            }
        }

        switch (Season)
        {
            case SeasonEnum.Winter:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMSiteTVItemID).Distinct().Count();
            case SeasonEnum.Spring:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMSiteTVItemID).Distinct().Count();
            case SeasonEnum.Summer:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMSiteTVItemID).Distinct().Count();
            case SeasonEnum.Fall:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMSiteTVItemID).Distinct().Count();
            default:
                return -1;
        }
    }
    private int GetMWQMRunCountOtherByYearUnderCountry(TVItem countryTVItem, int Year)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && !s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Year == Year
                    select s.MWQMRunTVItemID).Distinct().Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && !s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Year == Year
                select s.MWQMRunTVItemID).Distinct().Count();
    }
    private int GetMWQMRunCountOtherByMonthUnderCountry(TVItem countryTVItem, MonthEnum Month)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && !s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Month == (int)Month
                    select s.MWQMRunTVItemID).Distinct().Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && !s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Month == (int)Month
                select s.MWQMRunTVItemID).Distinct().Count();
    }
    private int GetMWQMRunCountOtherBySeasonUnderCountry(TVItem countryTVItem, SeasonEnum Season)
    {
        if (Local)
        {
            switch (Season)
            {
                case SeasonEnum.Winter:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMRunTVItemID).Distinct().Count();
                case SeasonEnum.Spring:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMRunTVItemID).Distinct().Count();
                case SeasonEnum.Summer:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMRunTVItemID).Distinct().Count();
                case SeasonEnum.Fall:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && !s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMRunTVItemID).Distinct().Count();
                default:
                    return -1;
            }
        }

        switch (Season)
        {
            case SeasonEnum.Winter:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMRunTVItemID).Distinct().Count();
            case SeasonEnum.Spring:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMRunTVItemID).Distinct().Count();
            case SeasonEnum.Summer:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMRunTVItemID).Distinct().Count();
            case SeasonEnum.Fall:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && !s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMRunTVItemID).Distinct().Count();
            default:
                return -1;
        }
    }
    private int GetMWQMRunCountRoutineByYearUnderCountry(TVItem countryTVItem, int Year)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Year == Year
                    select s.MWQMRunTVItemID).Distinct().Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Year == Year
                select s.MWQMRunTVItemID).Distinct().Count();
    }
    private int GetMWQMRunCountRoutineByMonthUnderCountry(TVItem countryTVItem, MonthEnum Month)
    {
        if (Local)
        {
            return (from c in dbLocal.TVItems
                    from s in dbLocal.MWQMSamples
                    where c.TVItemID == s.MWQMSiteTVItemID
                    && c.TVType == TVTypeEnum.MWQMSite
                    && c.TVPath.Contains(countryTVItem.TVPath + "p")
                    && s.SampleTypesText.Contains("109,")
                    && s.SampleDateTime_Local.Month == (int)Month
                    select s.MWQMRunTVItemID).Distinct().Count();
        }

        return (from c in db.TVItems
                from s in db.MWQMSamples
                where c.TVItemID == s.MWQMSiteTVItemID
                && c.TVType == TVTypeEnum.MWQMSite
                && c.TVPath.Contains(countryTVItem.TVPath + "p")
                && s.SampleTypesText.Contains("109,")
                && s.SampleDateTime_Local.Month == (int)Month
                select s.MWQMRunTVItemID).Distinct().Count();
    }
    private int GetMWQMRunCountRoutineBySeasonUnderCountry(TVItem countryTVItem, SeasonEnum Season)
    {
        if (Local)
        {
            switch (Season)
            {
                case SeasonEnum.Winter:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMRunTVItemID).Distinct().Count();
                case SeasonEnum.Spring:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMRunTVItemID).Distinct().Count();
                case SeasonEnum.Summer:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMRunTVItemID).Distinct().Count();
                case SeasonEnum.Fall:
                    return (from c in dbLocal.TVItems
                            from s in dbLocal.MWQMSamples
                            where c.TVItemID == s.MWQMSiteTVItemID
                            && c.TVType == TVTypeEnum.MWQMSite
                            && c.TVPath.Contains(countryTVItem.TVPath + "p")
                            && s.SampleTypesText.Contains("109,")
                            && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                            && s.SampleDateTime_Local.Day > 20)
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                            || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                            || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                            && s.SampleDateTime_Local.Day < 21))
                            select s.MWQMRunTVItemID).Distinct().Count();
                default:
                    return -1;
            }
        }

        switch (Season)
        {
            case SeasonEnum.Winter:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.January
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.February
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMRunTVItemID).Distinct().Count();
            case SeasonEnum.Spring:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.March
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.April
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.May
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMRunTVItemID).Distinct().Count();
            case SeasonEnum.Summer:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.June
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.July
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.August
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMRunTVItemID).Distinct().Count();
            case SeasonEnum.Fall:
                return (from c in db.TVItems
                        from s in db.MWQMSamples
                        where c.TVItemID == s.MWQMSiteTVItemID
                        && c.TVType == TVTypeEnum.MWQMSite
                        && c.TVPath.Contains(countryTVItem.TVPath + "p")
                        && s.SampleTypesText.Contains("109,")
                        && ((s.SampleDateTime_Local.Month == (int)MonthEnum.September
                        && s.SampleDateTime_Local.Day > 20)
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.October
                        || s.SampleDateTime_Local.Month == (int)MonthEnum.November
                        || (s.SampleDateTime_Local.Month == (int)MonthEnum.December
                        && s.SampleDateTime_Local.Day < 21))
                        select s.MWQMRunTVItemID).Distinct().Count();
            default:
                return -1;
        }
    }
    private async Task<List<TVItemLanguage>> GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem ParentTVItem, TVTypeEnum tvType)
    {
        if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
        {
            if (Local)
            {
                return await (from c in dbLocal.TVItems
                              from cl in dbLocal.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select cl).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from cl in db.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                          || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                          select cl).AsNoTracking().ToListAsync();
        }

        if (tvType == TVTypeEnum.File)
        {
            if (Local)
            {
                return await (from c in dbLocal.TVItems
                              from cl in dbLocal.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && c.TVType == tvType
                              && c.TVLevel == ParentTVItem.TVLevel + 1
                              select cl).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from cl in db.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          && c.TVLevel == ParentTVItem.TVLevel + 1
                          select cl).AsNoTracking().ToListAsync();
        }

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select cl).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cl in db.TVItemLanguages
                      where c.TVItemID == cl.TVItemID
                      && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                      && c.TVType == tvType
                      select cl).AsNoTracking().ToListAsync();

    }
    private async Task<List<TVItemLanguage>> GetTVItemLanguageAllChildrenListWithTVItemIDAsync(TVItem ParentTVItem, TVTypeEnum tvType)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select cl).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cl in db.TVItemLanguages
                      where c.TVItemID == cl.TVItemID
                      && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                      && c.TVType == tvType
                      select cl).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItemStat>> GetTVItemStatChildrenListWithTVItemIDAsync(TVItem ParentTVItem, TVTypeEnum tvType)
    {
        if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
        {
            if (Local)
            {
                return await (from c in dbLocal.TVItems
                              from cs in dbLocal.TVItemStats
                              where c.TVItemID == cs.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select cs).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from cs in db.TVItemStats
                          where c.TVItemID == cs.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                          || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                          select cs).AsNoTracking().ToListAsync();
        }

        if (tvType == TVTypeEnum.File)
        {
            if (Local)
            {
                return await (from c in dbLocal.TVItems
                              from cs in dbLocal.TVItemStats
                              where c.TVItemID == cs.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && c.TVType == tvType
                              && c.TVLevel == ParentTVItem.TVLevel + 1
                              select cs).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from cs in db.TVItemStats
                          where c.TVItemID == cs.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          && c.TVLevel == ParentTVItem.TVLevel + 1
                          select cs).AsNoTracking().ToListAsync();
        }

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cs in dbLocal.TVItemStats
                          where c.TVItemID == cs.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select cs).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cs in db.TVItemStats
                      where c.TVItemID == cs.TVItemID
                      && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                      && c.TVType == tvType
                      select cs).AsNoTracking().ToListAsync();
    }
    private async Task<List<MapInfo>> GetMapInfoChildrenListWithTVItemIDAsync(TVItem ParentTVItem, TVTypeEnum tvType)
    {
        if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
        {
            if (Local)
            {
                return await (from c in dbLocal.TVItems
                              from mi in dbLocal.MapInfos
                              where c.TVItemID == mi.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              select mi).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from mi in db.MapInfos
                          where c.TVItemID == mi.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                          || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                          select mi).AsNoTracking().ToListAsync();
        }

        if (tvType == TVTypeEnum.File)
        {
            if (Local)
            {
                return await (from c in dbLocal.TVItems
                              from mi in dbLocal.MapInfos
                              where c.TVItemID == mi.TVItemID
                              && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                              && c.TVType == tvType
                              && c.TVLevel == ParentTVItem.TVLevel + 1
                              select mi).AsNoTracking().ToListAsync();
            }

            return await (from c in db.TVItems
                          from mi in db.MapInfos
                          where c.TVItemID == mi.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          && c.TVLevel == ParentTVItem.TVLevel + 1
                          select mi).AsNoTracking().ToListAsync();
        }

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from mi in dbLocal.MapInfos
                          where c.TVItemID == mi.TVItemID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select mi).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from mi in db.MapInfos
                      where c.TVItemID == mi.TVItemID
                      && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                      && c.TVType == tvType
                      select mi).AsNoTracking().ToListAsync();
    }
    private async Task<List<MapInfoPoint>> GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem ParentTVItem, TVTypeEnum tvType)
    {
        if (tvType == TVTypeEnum.MikeBoundaryConditionMesh || tvType == TVTypeEnum.MikeBoundaryConditionWebTide)
        {
            if (Local)
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

            return await (from c in db.TVItems
                          from mi in db.MapInfos
                          from mip in db.MapInfoPoints
                          where c.TVItemID == mi.TVItemID
                          && mi.MapInfoID == mip.MapInfoID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                          || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                          select mip).AsNoTracking().ToListAsync();
        }

        if (tvType == TVTypeEnum.File)
        {
            if (Local)
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

            return await (from c in db.TVItems
                          from mi in db.MapInfos
                          from mip in db.MapInfoPoints
                          where c.TVItemID == mi.TVItemID
                          && mi.MapInfoID == mip.MapInfoID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          && c.TVLevel == ParentTVItem.TVLevel + 1
                          select mip).AsNoTracking().ToListAsync();
        }

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from mi in dbLocal.MapInfos
                          from mip in dbLocal.MapInfoPoints
                          where c.TVItemID == mi.TVItemID
                          && mi.MapInfoID == mip.MapInfoID
                          && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                          && c.TVType == tvType
                          select mip).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from mi in db.MapInfos
                      from mip in db.MapInfoPoints
                      where c.TVItemID == mi.TVItemID
                      && mi.MapInfoID == mip.MapInfoID
                      && c.TVPath.Contains(ParentTVItem.TVPath + "p")
                      && c.TVType == tvType
                      select mip).AsNoTracking().ToListAsync();
    }
    private async Task<List<Infrastructure>> GetInfrastructureListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          select ci).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      select ci).AsNoTracking().ToListAsync();
    }
    private async Task<List<MikeScenario>> GetMikeScenarioListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.MikeScenarios
                          where c.TVItemID == ci.MikeScenarioTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.MikeScenario
                          select ci).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from ci in db.MikeScenarios
                      where c.TVItemID == ci.MikeScenarioTVItemID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.MikeScenario
                      select ci).AsNoTracking().ToListAsync();
    }
    private async Task<List<MikeSource>> GetMikeSourceListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.MikeSources
                          where c.TVItemID == ci.MikeSourceTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.MikeSource
                          select ci).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from ci in db.MikeSources
                      where c.TVItemID == ci.MikeSourceTVItemID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.MikeSource
                      select ci).AsNoTracking().ToListAsync();
    }
    private async Task<List<MikeSourceStartEnd>> GetMikeSourceStartEndListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from ci in db.MikeSources
                      from se in db.MikeSourceStartEnds
                      where c.TVItemID == ci.MikeSourceTVItemID
                      && ci.MikeSourceID == se.MikeSourceID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.MikeSource
                      select se).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItemLink>> GetInfrastructureTVItemLinkListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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
                          select t).Distinct().AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from t in db.TVItemLinks
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && (c.TVItemID == t.FromTVItemID
                      || c.TVItemID == t.ToTVItemID)
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      && t.FromTVType == TVTypeEnum.Infrastructure
                      && t.ToTVType == TVTypeEnum.Infrastructure
                      select t).Distinct().AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItemLink>> GetAllTVItemLinkAsync(TVTypeEnum fromTVType, TVTypeEnum toTVType)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItemLinks
                          where t.FromTVType == fromTVType
                          && t.ToTVType == toTVType
                          select t).Distinct().AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItemLinks
                      where t.FromTVType == fromTVType
                      && t.ToTVType == toTVType
                      select t).Distinct().AsNoTracking().ToListAsync();
    }
    private async Task<List<Address>> GetInfrastructureCivicAddressListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from ci in dbLocal.Infrastructures
                          from a in dbLocal.Addresses
                          where c.TVItemID == ci.InfrastructureTVItemID
                          && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                          && c.TVType == TVTypeEnum.Infrastructure
                          && ci.CivicAddressTVItemID != null
                          && ci.CivicAddressTVItemID == a.AddressTVItemID
                          select a).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from a in db.Addresses
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      && ci.CivicAddressTVItemID != null
                      && ci.CivicAddressTVItemID == a.AddressTVItemID
                      select a).AsNoTracking().ToListAsync();
    }
    private async Task<List<InfrastructureLanguage>> GetInfrastructureLanguageListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from cil in db.InfrastructureLanguages
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && ci.InfrastructureID == cil.InfrastructureID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      select cil).AsNoTracking().ToListAsync();
    }
    private async Task<List<BoxModel>> GetBoxModelListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from bm in db.BoxModels
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      select bm).AsNoTracking().ToListAsync();
    }
    private async Task<List<BoxModelLanguage>> GetBoxModelLanguageListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from bm in db.BoxModels
                      from bml in db.BoxModelLanguages
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                      && bm.BoxModelID == bml.BoxModelID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      select bml).AsNoTracking().ToListAsync();
    }
    private async Task<List<BoxModelResult>> GetBoxModelResultListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from bm in db.BoxModels
                      from bmr in db.BoxModelResults
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && ci.InfrastructureTVItemID == bm.InfrastructureTVItemID
                      && bm.BoxModelID == bmr.BoxModelID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      select bmr).AsNoTracking().ToListAsync();
    }
    private async Task<List<VPScenario>> GetVPScenarioListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from vps in db.VPScenarios
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      select vps).AsNoTracking().ToListAsync();
    }
    private async Task<List<VPScenarioLanguage>> GetVPScenarioLanguageListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from vps in db.VPScenarios
                      from vpsl in db.VPScenarioLanguages
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                      && vps.VPScenarioID == vpsl.VPScenarioID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      select vpsl).AsNoTracking().ToListAsync();
    }
    private async Task<List<VPAmbient>> GetVPAmbientListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from vps in db.VPScenarios
                      from vpa in db.VPAmbients
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                      && vps.VPScenarioID == vpa.VPScenarioID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      select vpa).AsNoTracking().ToListAsync();
    }
    private async Task<List<VPResult>> GetVPResultListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from ci in db.Infrastructures
                      from vps in db.VPScenarios
                      from vpr in db.VPResults
                      where c.TVItemID == ci.InfrastructureTVItemID
                      && ci.InfrastructureTVItemID == vps.InfrastructureTVItemID
                      && vps.VPScenarioID == vpr.VPScenarioID
                      && c.TVPath.Contains(TVItemMunicipality.TVPath + "p")
                      && c.TVType == TVTypeEnum.Infrastructure
                      select vpr).AsNoTracking().ToListAsync();
    }
    private async Task<List<Contact>> GetMunicipalityContactListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
        {
            return await (from tl in dbLocal.TVItemLinks
                          from c in dbLocal.Contacts
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == TVItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from tl in db.TVItemLinks
                      from c in db.Contacts
                      where tl.ToTVItemID == c.ContactTVItemID
                      && tl.FromTVItemID == TVItemMunicipality.TVItemID
                      && tl.FromTVType == TVTypeEnum.Municipality
                      && tl.ToTVType == TVTypeEnum.Contact
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<int>> GetMunicipalityContactEmailTVItemIDListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
        {
            return await (from tl in dbLocal.TVItemLinks
                          from c in dbLocal.Contacts
                          from tl2 in dbLocal.TVItemLinks
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == TVItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          && tl2.FromTVItemID == tl.ToTVItemID
                          && tl2.FromTVType == TVTypeEnum.Contact
                          && tl2.ToTVType == TVTypeEnum.Email
                          select tl2.ToTVItemID).ToListAsync();
        }

        return await (from tl in db.TVItemLinks
                      from c in db.Contacts
                      from tl2 in db.TVItemLinks
                      where tl.ToTVItemID == c.ContactTVItemID
                      && tl.FromTVItemID == TVItemMunicipality.TVItemID
                      && tl.FromTVType == TVTypeEnum.Municipality
                      && tl.ToTVType == TVTypeEnum.Contact
                      && tl2.FromTVItemID == tl.ToTVItemID
                      && tl2.FromTVType == TVTypeEnum.Contact
                      && tl2.ToTVType == TVTypeEnum.Email
                      select tl2.ToTVItemID).ToListAsync();
    }
    private async Task<List<int>> GetMunicipalityContactTelTVItemIDListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
        {
            return await (from tl in dbLocal.TVItemLinks
                          from c in dbLocal.Contacts
                          from tl2 in dbLocal.TVItemLinks
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == TVItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          && tl2.FromTVItemID == tl.ToTVItemID
                          && tl2.FromTVType == TVTypeEnum.Contact
                          && tl2.ToTVType == TVTypeEnum.Tel
                          select tl2.ToTVItemID).ToListAsync();
        }

        return await (from tl in db.TVItemLinks
                      from c in db.Contacts
                      from tl2 in db.TVItemLinks
                      where tl.ToTVItemID == c.ContactTVItemID
                      && tl.FromTVItemID == TVItemMunicipality.TVItemID
                      && tl.FromTVType == TVTypeEnum.Municipality
                      && tl.ToTVType == TVTypeEnum.Contact
                      && tl2.FromTVItemID == tl.ToTVItemID
                      && tl2.FromTVType == TVTypeEnum.Contact
                      && tl2.ToTVType == TVTypeEnum.Tel
                      select tl2.ToTVItemID).ToListAsync();
    }
    private async Task<List<int>> GetMunicipalityContactAddressTVItemIDListUnderMunicipalityAsync(TVItem TVItemMunicipality)
    {
        if (Local)
        {
            return await (from tl in dbLocal.TVItemLinks
                          from c in dbLocal.Contacts
                          from tl2 in dbLocal.TVItemLinks
                          where tl.ToTVItemID == c.ContactTVItemID
                          && tl.FromTVItemID == TVItemMunicipality.TVItemID
                          && tl.FromTVType == TVTypeEnum.Municipality
                          && tl.ToTVType == TVTypeEnum.Contact
                          && tl2.FromTVItemID == tl.ToTVItemID
                          && tl2.FromTVType == TVTypeEnum.Contact
                          && tl2.ToTVType == TVTypeEnum.Address
                          select tl2.ToTVItemID).ToListAsync();
        }

        return await (from tl in db.TVItemLinks
                      from c in db.Contacts
                      from tl2 in db.TVItemLinks
                      where tl.ToTVItemID == c.ContactTVItemID
                      && tl.FromTVItemID == TVItemMunicipality.TVItemID
                      && tl.FromTVType == TVTypeEnum.Municipality
                      && tl.ToTVType == TVTypeEnum.Contact
                      && tl2.FromTVItemID == tl.ToTVItemID
                      && tl2.FromTVType == TVTypeEnum.Contact
                      && tl2.ToTVType == TVTypeEnum.Address
                      select tl2.ToTVItemID).ToListAsync();
    }
    private async Task<List<SamplingPlan>> GetAllSamplingPlanUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from c in dbLocal.SamplingPlans
                          where c.ProvinceTVItemID == TVItemProvince.TVItemID
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.SamplingPlans
                      where c.ProvinceTVItemID == TVItemProvince.TVItemID
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<SamplingPlanEmail>> GetAllSamplingPlanEmailUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from sp in dbLocal.SamplingPlans
                          from spe in dbLocal.SamplingPlanEmails
                          where t.TVItemID == sp.ProvinceTVItemID
                          && sp.SamplingPlanID == spe.SamplingPlanID
                          && t.TVItemID == TVItemProvince.TVItemID
                          select spe).AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from sp in db.SamplingPlans
                      from spe in db.SamplingPlanEmails
                      where t.TVItemID == sp.ProvinceTVItemID
                      && sp.SamplingPlanID == spe.SamplingPlanID
                      && t.TVItemID == TVItemProvince.TVItemID
                      select spe).AsNoTracking().ToListAsync();
    }
    private async Task<List<SamplingPlanSubsector>> GetAllSamplingPlanSubsectorUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from sp in dbLocal.SamplingPlans
                          from sps in dbLocal.SamplingPlanSubsectors
                          where t.TVItemID == sp.ProvinceTVItemID
                          && sp.SamplingPlanID == sps.SamplingPlanID
                          && t.TVItemID == TVItemProvince.TVItemID
                          select sps).AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from sp in db.SamplingPlans
                      from sps in db.SamplingPlanSubsectors
                      where t.TVItemID == sp.ProvinceTVItemID
                      && sp.SamplingPlanID == sps.SamplingPlanID
                      && t.TVItemID == TVItemProvince.TVItemID
                      select sps).AsNoTracking().ToListAsync();
    }
    private async Task<List<SamplingPlanSubsectorSite>> GetAllSamplingPlanSubsectorSiteUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from sp in dbLocal.SamplingPlans
                          from sps in dbLocal.SamplingPlanSubsectors
                          from spss in dbLocal.SamplingPlanSubsectorSites
                          where t.TVItemID == sp.ProvinceTVItemID
                          && sp.SamplingPlanID == sps.SamplingPlanID
                          && sps.SamplingPlanSubsectorID == spss.SamplingPlanSubsectorID
                          && t.TVItemID == TVItemProvince.TVItemID
                          select spss).AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from sp in db.SamplingPlans
                      from sps in db.SamplingPlanSubsectors
                      from spss in db.SamplingPlanSubsectorSites
                      where t.TVItemID == sp.ProvinceTVItemID
                      && sp.SamplingPlanID == sps.SamplingPlanID
                      && sps.SamplingPlanSubsectorID == spss.SamplingPlanSubsectorID
                      && t.TVItemID == TVItemProvince.TVItemID
                      select spss).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMSample>> GetWQMSampleListFromSubsector1980_2020Async(TVItem TVItemSubsector)
    {
        DateTime StartDate = new DateTime(1980, 1, 1);
        DateTime EndDate = new DateTime(2020, 12, 31);

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from sa in dbLocal.MWQMSamples
                          where c.TVItemID == sa.MWQMSiteTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.MWQMSite
                          && sa.SampleDateTime_Local >= StartDate
                          && sa.SampleDateTime_Local <= EndDate
                          select sa).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from sa in db.MWQMSamples
                      where c.TVItemID == sa.MWQMSiteTVItemID
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.MWQMSite
                      && sa.SampleDateTime_Local >= StartDate
                      && sa.SampleDateTime_Local <= EndDate
                      select sa).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMSample>> GetWQMSampleListFromSubsector2021_2060Async(TVItem TVItemSubsector)
    {
        DateTime StartDate = new DateTime(2021, 1, 1);
        DateTime EndDate = new DateTime(2060, 12, 31);

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from sa in dbLocal.MWQMSamples
                          where c.TVItemID == sa.MWQMSiteTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.MWQMSite
                          && sa.SampleDateTime_Local >= StartDate
                          && sa.SampleDateTime_Local <= EndDate
                          select sa).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from sa in db.MWQMSamples
                      where c.TVItemID == sa.MWQMSiteTVItemID
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.MWQMSite
                      && sa.SampleDateTime_Local >= StartDate
                      && sa.SampleDateTime_Local <= EndDate
                      select sa).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMSampleLanguage>> GetWQMSampleLanguageListFromSubsector1980_2020Async(TVItem TVItemSubsector)
    {
        DateTime StartDate = new DateTime(1980, 1, 1);
        DateTime EndDate = new DateTime(2020, 12, 31);

        if (Local)
        {
            List<int> MWQMSampleIDList2 = await (from c in dbLocal.TVItems
                                                 from sa in dbLocal.MWQMSamples
                                                 where c.TVItemID == sa.MWQMSiteTVItemID
                                                 && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                                 && c.TVType == TVTypeEnum.MWQMSite
                                                 && sa.SampleDateTime_Local >= StartDate
                                                 && sa.SampleDateTime_Local <= EndDate
                                                 select sa.MWQMSampleID).ToListAsync();

            return await (from sal in dbLocal.MWQMSampleLanguages
                          where MWQMSampleIDList2.Contains(sal.MWQMSampleID)
                          select sal).AsNoTracking().ToListAsync();
        }

        List<int> MWQMSampleIDList = await (from c in db.TVItems
                                            from sa in db.MWQMSamples
                                            where c.TVItemID == sa.MWQMSiteTVItemID
                                            && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                            && c.TVType == TVTypeEnum.MWQMSite
                                            && sa.SampleDateTime_Local >= StartDate
                                            && sa.SampleDateTime_Local <= EndDate
                                            select sa.MWQMSampleID).ToListAsync();

        return await (from sal in db.MWQMSampleLanguages
                      where MWQMSampleIDList.Contains(sal.MWQMSampleID)
                      select sal).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMSampleLanguage>> GetWQMSampleLanguageListFromSubsector2021_2060Async(TVItem TVItemSubsector)
    {
        DateTime StartDate = new DateTime(2021, 1, 1);
        DateTime EndDate = new DateTime(2060, 12, 31);

        if (Local)
        {
            List<int> MWQMSampleIDList2 = await (from c in dbLocal.TVItems
                                                 from sa in dbLocal.MWQMSamples
                                                 where c.TVItemID == sa.MWQMSiteTVItemID
                                                 && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                                 && c.TVType == TVTypeEnum.MWQMSite
                                                 && sa.SampleDateTime_Local >= StartDate
                                                 && sa.SampleDateTime_Local <= EndDate
                                                 select sa.MWQMSampleID).ToListAsync();

            return await (from sal in dbLocal.MWQMSampleLanguages
                          where MWQMSampleIDList2.Contains(sal.MWQMSampleID)
                          select sal).AsNoTracking().ToListAsync();
        }

        List<int> MWQMSampleIDList = await (from c in db.TVItems
                                            from sa in db.MWQMSamples
                                            where c.TVItemID == sa.MWQMSiteTVItemID
                                            && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                            && c.TVType == TVTypeEnum.MWQMSite
                                            && sa.SampleDateTime_Local >= StartDate
                                            && sa.SampleDateTime_Local <= EndDate
                                            select sa.MWQMSampleID).ToListAsync();

        return await (from sal in db.MWQMSampleLanguages
                      where MWQMSampleIDList.Contains(sal.MWQMSampleID)
                      select sal).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMRun>> GetMWQMRunListFromSubsectorAsync(TVItem TVItemSubsector)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from r in dbLocal.MWQMRuns
                          where c.TVItemID == r.MWQMRunTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.MWQMRun
                          select r).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from r in db.MWQMRuns
                      where c.TVItemID == r.MWQMRunTVItemID
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.MWQMRun
                      select r).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMRunLanguage>> GetMWQMRunLanguageListFromSubsectorAsync(TVItem TVItemSubsector)
    {
        if (Local)
        {
            List<int> MWQMRunIDList2 = await (from c in dbLocal.TVItems
                                              from r in dbLocal.MWQMRuns
                                              where c.TVItemID == r.MWQMRunTVItemID
                                              && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                              && c.TVType == TVTypeEnum.MWQMRun
                                              select r.MWQMRunID).ToListAsync();

            return await (from rl in dbLocal.MWQMRunLanguages
                          where MWQMRunIDList2.Contains(rl.MWQMRunID)
                          select rl).AsNoTracking().ToListAsync();
        }

        List<int> MWQMRunIDList = await (from c in db.TVItems
                                         from r in db.MWQMRuns
                                         where c.TVItemID == r.MWQMRunTVItemID
                                         && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                                         && c.TVType == TVTypeEnum.MWQMRun
                                         select r.MWQMRunID).ToListAsync();

        return await (from rl in db.MWQMRunLanguages
                      where MWQMRunIDList.Contains(rl.MWQMRunID)
                      select rl).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMSite>> GetMWQMSiteListFromSubsectorAsync(TVItem TVItemSubsector)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from cl in db.TVItemLanguages
                      from s in db.MWQMSites
                      where c.TVItemID == cl.TVItemID
                      && c.TVItemID == s.MWQMSiteTVItemID
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.MWQMSite
                      && cl.Language == LanguageEnum.en
                      orderby c.IsActive, cl.TVText
                      select s).AsNoTracking().ToListAsync();
    }
    private async Task<List<Classification>> GetClassificationListFromSubsectorAsync(TVItem TVItemSubsector)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          from s in dbLocal.Classifications
                          where c.TVItemID == cl.TVItemID
                          && c.TVItemID == s.ClassificationTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.Classification
                          && cl.Language == LanguageEnum.en
                          orderby c.IsActive, cl.TVText
                          select s).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cl in db.TVItemLanguages
                      from s in db.Classifications
                      where c.TVItemID == cl.TVItemID
                      && c.TVItemID == s.ClassificationTVItemID
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.Classification
                      && cl.Language == LanguageEnum.en
                      orderby c.IsActive, cl.TVText
                      select s).AsNoTracking().ToListAsync();
    }
    private async Task<List<Contact>> GetAllContactAsync()
    {
        if (Local)
        {
            List<Contact> contactList2 = await (from c in dbLocal.Contacts
                                                orderby c.LastName, c.FirstName, c.Initial
                                                select c).AsNoTracking().ToListAsync();

            foreach (Contact contact in contactList2)
            {
                contact.PasswordHash = "";
                contact.Token = "";
            }

            return contactList2;
        }

        List<Contact> contactList = await (from c in db.Contacts
                                           orderby c.LastName, c.FirstName, c.Initial
                                           select c).AsNoTracking().ToListAsync();

        foreach (Contact contact in contactList)
        {
            contact.PasswordHash = "";
            contact.Token = "";
        }

        return contactList;
    }
    private async Task<List<Address>> GetAllAddressAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.Addresses
                          orderby c.GoogleAddressText, c.PostalCode
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.Addresses
                      orderby c.GoogleAddressText, c.PostalCode
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<Email>> GetAllEmailAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.Emails
                          orderby c.EmailAddress
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.Emails
                      orderby c.EmailAddress
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<Tel>> GetAllTelAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.Tels
                          orderby c.TelNumber
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.Tels
                      orderby c.TelNumber
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<ClimateSite>> GetClimateSiteListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cs in dbLocal.ClimateSites
                          where c.TVItemID == cs.ClimateSiteTVItemID
                          && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && c.TVType == TVTypeEnum.ClimateSite
                          orderby cs.ClimateSiteName
                          select cs).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cs in db.ClimateSites
                      where c.TVItemID == cs.ClimateSiteTVItemID
                      && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && c.TVType == TVTypeEnum.ClimateSite
                      orderby cs.ClimateSiteName
                      select cs).AsNoTracking().ToListAsync();
    }
    private async Task<List<TideSite>> GetTideSiteListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cs in dbLocal.TideSites
                          where c.TVItemID == cs.TideSiteTVItemID
                          && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && c.TVType == TVTypeEnum.TideSite
                          orderby cs.TideSiteName
                          select cs).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cs in db.TideSites
                      where c.TVItemID == cs.TideSiteTVItemID
                      && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && c.TVType == TVTypeEnum.TideSite
                      orderby cs.TideSiteName
                      select cs).AsNoTracking().ToListAsync();
    }
    private async Task<List<HydrometricSite>> GetHydrometricSiteListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from hs in dbLocal.HydrometricSites
                          where c.TVItemID == hs.HydrometricSiteTVItemID
                          && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && c.TVType == TVTypeEnum.HydrometricSite
                          orderby hs.HydrometricSiteName
                          select hs).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from hs in db.HydrometricSites
                      where c.TVItemID == hs.HydrometricSiteTVItemID
                      && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && c.TVType == TVTypeEnum.HydrometricSite
                      orderby hs.HydrometricSiteName
                      select hs).AsNoTracking().ToListAsync();
    }
    private async Task<List<RainExceedance>> GetRainExceedanceUnderCountryAsync(TVItem TVItemCountry)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from tl in dbLocal.TVItemLanguages
                          from c in dbLocal.RainExceedances
                          where t.TVItemID == tl.TVItemID
                          && t.TVItemID == c.RainExceedanceTVItemID
                          && t.TVPath.Contains(TVItemCountry.TVPath + "p")
                          && t.TVType == TVTypeEnum.RainExceedance
                          orderby tl.TVText
                          select c).Distinct().AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from tl in db.TVItemLanguages
                      from c in db.RainExceedances
                      where t.TVItemID == tl.TVItemID
                      && t.TVItemID == c.RainExceedanceTVItemID
                      && t.TVPath.Contains(TVItemCountry.TVPath + "p")
                      && t.TVType == TVTypeEnum.RainExceedance
                      orderby tl.TVText
                      select c).Distinct().AsNoTracking().ToListAsync();
    }
    private async Task<List<RainExceedanceClimateSite>> GetRainExceedanceClimateSiteUnderCountryAsync(TVItem TVItemCountry)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from tl in dbLocal.TVItemLanguages
                          from c in dbLocal.RainExceedances
                          from cc in dbLocal.RainExceedanceClimateSites
                          where t.TVItemID == tl.TVItemID
                          && t.TVItemID == c.RainExceedanceTVItemID
                          && c.RainExceedanceTVItemID == cc.RainExceedanceTVItemID
                          && t.TVPath.Contains(TVItemCountry.TVPath + "p")
                          && t.TVType == TVTypeEnum.RainExceedance
                          orderby tl.TVText
                          select cc).Distinct().AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from tl in db.TVItemLanguages
                      from c in db.RainExceedances
                      from cc in db.RainExceedanceClimateSites
                      where t.TVItemID == tl.TVItemID
                      && t.TVItemID == c.RainExceedanceTVItemID
                      && c.RainExceedanceTVItemID == cc.RainExceedanceTVItemID
                      && t.TVPath.Contains(TVItemCountry.TVPath + "p")
                      && t.TVType == TVTypeEnum.RainExceedance
                      orderby tl.TVText
                      select cc).Distinct().AsNoTracking().ToListAsync();
    }
    private async Task<List<RatingCurve>> GetRatingCurveListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from hs in db.HydrometricSites
                      from rc in db.RatingCurves
                      where c.TVItemID == hs.HydrometricSiteTVItemID
                      && hs.HydrometricSiteID == rc.HydrometricSiteID
                      && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && c.TVType == TVTypeEnum.HydrometricSite
                      orderby hs.HydrometricSiteName
                      select rc).AsNoTracking().ToListAsync();
    }
    private async Task<List<RatingCurveValue>> GetRatingCurveValueListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from hs in db.HydrometricSites
                      from rc in db.RatingCurves
                      from rcv in db.RatingCurveValues
                      where c.TVItemID == hs.HydrometricSiteTVItemID
                      && hs.HydrometricSiteID == rc.HydrometricSiteID
                      && rc.RatingCurveID == rcv.RatingCurveID
                      && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && c.TVType == TVTypeEnum.HydrometricSite
                      orderby hs.HydrometricSiteName
                      select rcv).AsNoTracking().ToListAsync();
    }
    private async Task<List<DrogueRun>> GetDrogueRunListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from d in dbLocal.DrogueRuns
                          where t.TVItemID == d.SubsectorTVItemID
                          && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && t.TVType == TVTypeEnum.Subsector
                          select d).AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from d in db.DrogueRuns
                      where t.TVItemID == d.SubsectorTVItemID
                      && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && t.TVType == TVTypeEnum.Subsector
                      select d).AsNoTracking().ToListAsync();
    }
    private async Task<List<DrogueRunPosition>> GetDrogueRunPositionListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from d in dbLocal.DrogueRuns
                          from p in dbLocal.DrogueRunPositions
                          where t.TVItemID == d.SubsectorTVItemID
                          && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && t.TVType == TVTypeEnum.Subsector
                          && d.DrogueRunID == p.DrogueRunID
                          select p).AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from d in db.DrogueRuns
                      from p in db.DrogueRunPositions
                      where t.TVItemID == d.SubsectorTVItemID
                      && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && t.TVType == TVTypeEnum.Subsector
                      && d.DrogueRunID == p.DrogueRunID
                      select p).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMAnalysisReportParameter>> GetAllMWQMAnalysisReportParameterListAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.MWQMAnalysisReportParameters
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.MWQMAnalysisReportParameters
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMLookupMPN>> GetMWQMLookupMPNAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.MWQMLookupMPNs
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.MWQMLookupMPNs
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<MikeBoundaryCondition>> GetMikeBoundaryConditionListUnderMunicipalityAsync(TVItem tvItemMunicipality)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from bc in dbLocal.MikeBoundaryConditions
                          where c.TVItemID == bc.MikeBoundaryConditionTVItemID
                          && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                          && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                          || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                          select bc).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from bc in db.MikeBoundaryConditions
                      where c.TVItemID == bc.MikeBoundaryConditionTVItemID
                      && c.TVPath.Contains(tvItemMunicipality.TVPath + "p")
                      && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                      || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                      select bc).AsNoTracking().ToListAsync();
    }
    private async Task<List<EmailDistributionList>> GetEmailDistributionListListUnderCountryAsync(TVItem tvItemCountry)
    {
        if (Local)
        {
            return await (from c in dbLocal.EmailDistributionLists
                          where c.ParentTVItemID == tvItemCountry.TVItemID
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.EmailDistributionLists
                      where c.ParentTVItemID == tvItemCountry.TVItemID
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<EmailDistributionListLanguage>> GetEmailDistributionListLanguageListUnderCountryAsync(TVItem tvItemCountry)
    {
        if (Local)
        {
            return await (from c in dbLocal.EmailDistributionLists
                          from cl in dbLocal.EmailDistributionListLanguages
                          where c.ParentTVItemID == tvItemCountry.TVItemID
                          && c.EmailDistributionListID == cl.EmailDistributionListID
                          select cl).AsNoTracking().ToListAsync();
        }

        return await (from c in db.EmailDistributionLists
                      from cl in db.EmailDistributionListLanguages
                      where c.ParentTVItemID == tvItemCountry.TVItemID
                      && c.EmailDistributionListID == cl.EmailDistributionListID
                      select cl).AsNoTracking().ToListAsync();
    }
    private async Task<List<EmailDistributionListContact>> GetEmailDistributionListContactListUnderCountryAsync(TVItem tvItemCountry)
    {
        if (Local)
        {
            return await (from c in dbLocal.EmailDistributionLists
                          from ec in dbLocal.EmailDistributionListContacts
                          where c.ParentTVItemID == tvItemCountry.TVItemID
                          && c.EmailDistributionListID == ec.EmailDistributionListID
                          select ec).AsNoTracking().ToListAsync();
        }

        return await (from c in db.EmailDistributionLists
                      from ec in db.EmailDistributionListContacts
                      where c.ParentTVItemID == tvItemCountry.TVItemID
                      && c.EmailDistributionListID == ec.EmailDistributionListID
                      select ec).AsNoTracking().ToListAsync();
    }
    private async Task<List<EmailDistributionListContactLanguage>> GetEmailDistributionListContactLanguageListUnderCountryAsync(TVItem tvItemCountry)
    {
        if (Local)
        {
            return await (from c in dbLocal.EmailDistributionLists
                          from ec in dbLocal.EmailDistributionListContacts
                          from ecl in dbLocal.EmailDistributionListContactLanguages
                          where c.ParentTVItemID == tvItemCountry.TVItemID
                          && c.EmailDistributionListID == ec.EmailDistributionListID
                          && ec.EmailDistributionListContactID == ecl.LastUpdateContactTVItemID
                          select ecl).AsNoTracking().ToListAsync();
        }

        return await (from c in db.EmailDistributionLists
                      from ec in db.EmailDistributionListContacts
                      from ecl in db.EmailDistributionListContactLanguages
                      where c.ParentTVItemID == tvItemCountry.TVItemID
                      && c.EmailDistributionListID == ec.EmailDistributionListID
                      && ec.EmailDistributionListContactID == ecl.LastUpdateContactTVItemID
                      select ecl).AsNoTracking().ToListAsync();
    }
    private async Task<List<ClimateDataValue>> GetClimateDataValueListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from c in dbLocal.ClimateSites
                          from cv in dbLocal.ClimateDataValues
                          where t.TVItemID == c.ClimateSiteTVItemID
                          && c.ClimateSiteID == cv.ClimateSiteID
                          && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && t.TVType == TVTypeEnum.ClimateSite
                          select cv).AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from c in db.ClimateSites
                      from cv in db.ClimateDataValues
                      where t.TVItemID == c.ClimateSiteTVItemID
                      && c.ClimateSiteID == cv.ClimateSiteID
                      && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && t.TVType == TVTypeEnum.ClimateSite
                      select cv).AsNoTracking().ToListAsync();
    }
    private async Task<List<TideDataValue>> GetTideDataValueListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from c in dbLocal.TideSites
                          from cv in dbLocal.TideDataValues
                          where t.TVItemID == c.TideSiteTVItemID
                          && c.TideSiteTVItemID == cv.TideSiteTVItemID
                          && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && t.TVType == TVTypeEnum.TideSite
                          select cv).AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from c in db.TideSites
                      from cv in db.TideDataValues
                      where t.TVItemID == c.TideSiteTVItemID
                      && c.TideSiteTVItemID == cv.TideSiteTVItemID
                      && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && t.TVType == TVTypeEnum.TideSite
                      select cv).AsNoTracking().ToListAsync();
    }
    private async Task<List<HydrometricDataValue>> GetHydrometricDataValueListUnderProvinceAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from t in dbLocal.TVItems
                          from c in dbLocal.HydrometricSites
                          from cv in dbLocal.HydrometricDataValues
                          where t.TVItemID == c.HydrometricSiteTVItemID
                          && c.HydrometricSiteID == cv.HydrometricSiteID
                          && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && t.TVType == TVTypeEnum.HydrometricSite
                          select cv).AsNoTracking().ToListAsync();
        }

        return await (from t in db.TVItems
                      from c in db.HydrometricSites
                      from cv in db.HydrometricDataValues
                      where t.TVItemID == c.HydrometricSiteTVItemID
                      && c.HydrometricSiteID == cv.HydrometricSiteID
                      && t.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && t.TVType == TVTypeEnum.HydrometricSite
                      select cv).AsNoTracking().ToListAsync();
    }
    private async Task<List<HelpDoc>> GetHelpDocAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.HelpDocs
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.HelpDocs
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<LabSheet>> GetLabSheetListUnderSubsectorAsync(int subsectorTVItemID)
    {
        if (Local)
        {
            return await (from c in dbLocal.LabSheets
                          where c.SubsectorTVItemID == subsectorTVItemID
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.LabSheets
                      where c.SubsectorTVItemID == subsectorTVItemID
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<LabSheetDetail>> GetLabSheetDetailListUnderSubsectorAsync(int subsectorTVItemID)
    {
        if (Local)
        {
            return await (from c in dbLocal.LabSheets
                          from cd in dbLocal.LabSheetDetails
                          where c.LabSheetID == cd.LabSheetID
                          && c.SubsectorTVItemID == subsectorTVItemID
                          select cd).AsNoTracking().ToListAsync();
        }

        return await (from c in db.LabSheets
                      from cd in db.LabSheetDetails
                      where c.LabSheetID == cd.LabSheetID
                      && c.SubsectorTVItemID == subsectorTVItemID
                      select cd).AsNoTracking().ToListAsync();
    }
    private async Task<List<LabSheetTubeMPNDetail>> GetLabSheetTubeMPNDetailListUnderSubsectorAsync(int subsectorTVItemID)
    {
        if (Local)
        {
            return await (from c in dbLocal.LabSheets
                          from cd in dbLocal.LabSheetDetails
                          from ct in dbLocal.LabSheetTubeMPNDetails
                          where c.LabSheetID == cd.LabSheetID
                          && cd.LabSheetDetailID == ct.LabSheetDetailID
                          && c.SubsectorTVItemID == subsectorTVItemID
                          select ct).AsNoTracking().ToListAsync();
        }

        return await (from c in db.LabSheets
                      from cd in db.LabSheetDetails
                      from ct in db.LabSheetTubeMPNDetails
                      where c.LabSheetID == cd.LabSheetID
                      && cd.LabSheetDetailID == ct.LabSheetDetailID
                      && c.SubsectorTVItemID == subsectorTVItemID
                      select ct).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMSubsector>> GetAllMWQMSubsectorAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.MWQMSubsectors
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.MWQMSubsectors
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<MWQMSubsectorLanguage>> GetAllMWQMSubsectorLanguageAsync()
    {
        if (Local)
        {
            return await (from cl in dbLocal.MWQMSubsectorLanguages
                          select cl).AsNoTracking().ToListAsync();
        }

        return await (from cl in db.MWQMSubsectorLanguages
                      select cl).AsNoTracking().ToListAsync();
    }
    private async Task<List<TideLocation>> GetTideLocationAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.TideLocations
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TideLocations
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<UseOfSite>> GetAllUseOfSiteListAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.UseOfSites
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.UseOfSites
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<PolSourceSite>> GetPolSourceSiteListFromSubsectorAsync(TVItem TVItemSubsector)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from p in dbLocal.PolSourceSites
                          where c.TVItemID == p.PolSourceSiteTVItemID
                          && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                          && c.TVType == TVTypeEnum.PolSourceSite
                          select p).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from p in db.PolSourceSites
                      where c.TVItemID == p.PolSourceSiteTVItemID
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.PolSourceSite
                      select p).AsNoTracking().ToListAsync();
    }
    private async Task<List<Address>> GetPolSourceSiteAddressListFromSubsectorAsync(TVItem TVItemSubsector)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from p in db.PolSourceSites
                      from a in db.Addresses
                      where c.TVItemID == p.PolSourceSiteTVItemID
                      && p.CivicAddressTVItemID != null
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.PolSourceSite
                      && p.CivicAddressTVItemID == a.AddressTVItemID
                      select a).AsNoTracking().ToListAsync();
    }
    private async Task<List<PolSourceObservation>> GetPolSourceObservationListFromSubsectorAsync(TVItem TVItemSubsector)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from p in db.PolSourceSites
                      from po in db.PolSourceObservations
                      where c.TVItemID == p.PolSourceSiteTVItemID
                      && p.PolSourceSiteID == po.PolSourceSiteID
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.PolSourceSite
                      select po).AsNoTracking().ToListAsync();
    }
    private async Task<List<PolSourceObservationIssue>> GetPolSourceObservationIssueListFromSubsectorAsync(TVItem TVItemSubsector)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from p in db.PolSourceSites
                      from po in db.PolSourceObservations
                      from poi in db.PolSourceObservationIssues
                      where c.TVItemID == p.PolSourceSiteTVItemID
                      && p.PolSourceSiteID == po.PolSourceSiteID
                      && po.PolSourceObservationID == poi.PolSourceObservationID
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.PolSourceSite
                      select poi).AsNoTracking().ToListAsync();
    }
    private async Task<List<PolSourceSiteEffect>> GetPolSourceSiteEffectListFromSubsectorAsync(TVItem TVItemSubsector)
    {
        if (Local)
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

        return await (from c in db.TVItems
                      from p in db.PolSourceSites
                      from pe in db.PolSourceSiteEffects
                      where c.TVItemID == p.PolSourceSiteTVItemID
                      && p.PolSourceSiteID == pe.PolSourceSiteOrInfrastructureTVItemID
                      && c.TVPath.Contains(TVItemSubsector.TVPath + "p")
                      && c.TVType == TVTypeEnum.PolSourceSite
                      select pe).AsNoTracking().ToListAsync();
    }
    private async Task<List<PolSourceGrouping>> GetPolSourceGroupingListAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.PolSourceGroupings
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.PolSourceGroupings
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<PolSourceGroupingLanguage>> GetPolSourceGroupingLanguageListAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.PolSourceGroupingLanguages
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.PolSourceGroupingLanguages
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<PolSourceSiteEffectTerm>> GetPolSourceSiteEffectTermListAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.PolSourceSiteEffectTerms
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.PolSourceSiteEffectTerms
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<ReportType>> GetReportTypeListAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.ReportTypes
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.ReportTypes
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<ReportSection>> GetReportSectionListAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.ReportSections
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.ReportSections
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItem>> GetSearchableTVItemAsync()
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          where c.TVType == TVTypeEnum.Country
                          || c.TVType == TVTypeEnum.Province
                          || c.TVType == TVTypeEnum.Area
                          || c.TVType == TVTypeEnum.Sector
                          || c.TVType == TVTypeEnum.Subsector
                          || c.TVType == TVTypeEnum.Municipality
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      where c.TVType == TVTypeEnum.Country
                      || c.TVType == TVTypeEnum.Province
                      || c.TVType == TVTypeEnum.Area
                      || c.TVType == TVTypeEnum.Sector
                      || c.TVType == TVTypeEnum.Subsector
                      || c.TVType == TVTypeEnum.Municipality
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItemLanguage>> GetSearchableTVItemLanguageAsync()
    {
        if (Local)
        {
            List<int> TVItemIDList = await (from c in dbLocal.TVItems
                                            where c.TVType == TVTypeEnum.Country
                                            || c.TVType == TVTypeEnum.Province
                                            || c.TVType == TVTypeEnum.Area
                                            || c.TVType == TVTypeEnum.Sector
                                            || c.TVType == TVTypeEnum.Subsector
                                            || c.TVType == TVTypeEnum.Municipality
                                            select c.TVItemID).ToListAsync();


            return await (from cl in dbLocal.TVItemLanguages
                          where TVItemIDList.Contains(cl.TVItemID)
                          select cl).ToListAsync();
        }

        List<int> TVItemIDList2 = await (from c in db.TVItems
                                         where c.TVType == TVTypeEnum.Country
                                         || c.TVType == TVTypeEnum.Province
                                         || c.TVType == TVTypeEnum.Area
                                         || c.TVType == TVTypeEnum.Sector
                                         || c.TVType == TVTypeEnum.Subsector
                                         || c.TVType == TVTypeEnum.Municipality
                                         select c.TVItemID).ToListAsync();


        return await (from cl in db.TVItemLanguages
                      where TVItemIDList2.Contains(cl.TVItemID)
                      select cl).ToListAsync();
    }
    private async Task<List<TVItem>> GetTVItemParentListWithTVItemAsync(TVItem TVItem)
    {
        List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          where ParentsTVItemID.Contains(c.TVItemID)
                          orderby c.TVLevel
                          select c).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      where ParentsTVItemID.Contains(c.TVItemID)
                      orderby c.TVLevel
                      select c).AsNoTracking().ToListAsync();
    }
    private async Task<List<int>> GetMunicipalityWithInfrastructureTVItemIDListAsync(TVItem TVItemProvince)
    {
        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from c2 in dbLocal.TVItems
                          let infExist = (from d in dbLocal.Infrastructures
                                          where d.InfrastructureTVItemID == c2.TVItemID
                                          select d).Any()
                          where c2.ParentID == c.TVItemID
                          && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                          && c.TVType == TVTypeEnum.Municipality
                          && c2.TVType == TVTypeEnum.Infrastructure
                          && infExist == true
                          select c.TVItemID).Distinct().ToListAsync();
        }

        return await (from c in db.TVItems
                      from c2 in db.TVItems
                      let infExist = (from d in db.Infrastructures
                                      where d.InfrastructureTVItemID == c2.TVItemID
                                      select d).Any()
                      where c2.ParentID == c.TVItemID
                      && c.TVPath.Contains(TVItemProvince.TVPath + "p")
                      && c.TVType == TVTypeEnum.Municipality
                      && c2.TVType == TVTypeEnum.Infrastructure
                      && infExist == true
                      select c.TVItemID).Distinct().ToListAsync();
    }
    private async Task<List<TVItemLanguage>> GetTVItemLanguageParentListWithTVItemAsync(TVItem TVItem)
    {
        List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cl in dbLocal.TVItemLanguages
                          where c.TVItemID == cl.TVItemID
                          && ParentsTVItemID.Contains(c.TVItemID)
                          select cl).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cl in db.TVItemLanguages
                      where c.TVItemID == cl.TVItemID
                      && ParentsTVItemID.Contains(c.TVItemID)
                      select cl).AsNoTracking().ToListAsync();
    }
    private async Task<List<TVItemStat>> GetTVItemStatParentListWithTVItemAsync(TVItem TVItem)
    {
        List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from cs in dbLocal.TVItemStats
                          where c.TVItemID == cs.TVItemID
                          && ParentsTVItemID.Contains(c.TVItemID)
                          select cs).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from cs in db.TVItemStats
                      where c.TVItemID == cs.TVItemID
                      && ParentsTVItemID.Contains(c.TVItemID)
                      select cs).AsNoTracking().ToListAsync();
    }
    private async Task<List<MapInfo>> GetMapInfoParentListWithTVItemAsync(TVItem TVItem)
    {
        List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from mi in dbLocal.MapInfos
                          where c.TVItemID == mi.TVItemID
                          && ParentsTVItemID.Contains(c.TVItemID)
                          select mi).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from mi in db.MapInfos
                      where c.TVItemID == mi.TVItemID
                      && ParentsTVItemID.Contains(c.TVItemID)
                      select mi).AsNoTracking().ToListAsync();
    }
    private async Task<List<MapInfoPoint>> GetMapInfoPointParentListWithTVItemAsync(TVItem TVItem)
    {
        List<int> ParentsTVItemID = TVItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

        if (Local)
        {
            return await (from c in dbLocal.TVItems
                          from mi in dbLocal.MapInfos
                          from mip in dbLocal.MapInfoPoints
                          where c.TVItemID == mi.TVItemID
                          && mi.MapInfoID == mip.MapInfoID
                          && ParentsTVItemID.Contains(c.TVItemID)
                          select mip).AsNoTracking().ToListAsync();
        }

        return await (from c in db.TVItems
                      from mi in db.MapInfos
                      from mip in db.MapInfoPoints
                      where c.TVItemID == mi.TVItemID
                      && mi.MapInfoID == mip.MapInfoID
                      && ParentsTVItemID.Contains(c.TVItemID)
                      select mip).AsNoTracking().ToListAsync();
    }
}

