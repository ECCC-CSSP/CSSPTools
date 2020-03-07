using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebMVCAPI.Models
{
    public partial class CSSPDB2Context : DbContext
    {
        public CSSPDB2Context()
        {
        }

        public CSSPDB2Context(DbContextOptions<CSSPDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<AppErrLogs> AppErrLogs { get; set; }
        public virtual DbSet<AppTaskLanguages> AppTaskLanguages { get; set; }
        public virtual DbSet<AppTasks> AppTasks { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BoxModelLanguages> BoxModelLanguages { get; set; }
        public virtual DbSet<BoxModelResults> BoxModelResults { get; set; }
        public virtual DbSet<BoxModels> BoxModels { get; set; }
        public virtual DbSet<Classifications> Classifications { get; set; }
        public virtual DbSet<ClimateDataValues> ClimateDataValues { get; set; }
        public virtual DbSet<ClimateSites> ClimateSites { get; set; }
        public virtual DbSet<ContactPreferences> ContactPreferences { get; set; }
        public virtual DbSet<ContactShortcuts> ContactShortcuts { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<DocTemplates> DocTemplates { get; set; }
        public virtual DbSet<DrogueRunPositions> DrogueRunPositions { get; set; }
        public virtual DbSet<DrogueRuns> DrogueRuns { get; set; }
        public virtual DbSet<EmailDistributionListContactLanguages> EmailDistributionListContactLanguages { get; set; }
        public virtual DbSet<EmailDistributionListContacts> EmailDistributionListContacts { get; set; }
        public virtual DbSet<EmailDistributionListLanguages> EmailDistributionListLanguages { get; set; }
        public virtual DbSet<EmailDistributionLists> EmailDistributionLists { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<HelpDocs> HelpDocs { get; set; }
        public virtual DbSet<HydrometricDataValues> HydrometricDataValues { get; set; }
        public virtual DbSet<HydrometricSites> HydrometricSites { get; set; }
        public virtual DbSet<InfrastructureLanguages> InfrastructureLanguages { get; set; }
        public virtual DbSet<Infrastructures> Infrastructures { get; set; }
        public virtual DbSet<LabSheetDetails> LabSheetDetails { get; set; }
        public virtual DbSet<LabSheetTubeMPNDetails> LabSheetTubeMPNDetails { get; set; }
        public virtual DbSet<LabSheets> LabSheets { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<MWQMAnalysisReportParameters> MWQMAnalysisReportParameters { get; set; }
        public virtual DbSet<MWQMLookupMPNs> MWQMLookupMPNs { get; set; }
        public virtual DbSet<MWQMRunLanguages> MWQMRunLanguages { get; set; }
        public virtual DbSet<MWQMRuns> MWQMRuns { get; set; }
        public virtual DbSet<MWQMSampleLanguages> MWQMSampleLanguages { get; set; }
        public virtual DbSet<MWQMSamples> MWQMSamples { get; set; }
        public virtual DbSet<MWQMSiteStartEndDates> MWQMSiteStartEndDates { get; set; }
        public virtual DbSet<MWQMSites> MWQMSites { get; set; }
        public virtual DbSet<MWQMSubsectorLanguages> MWQMSubsectorLanguages { get; set; }
        public virtual DbSet<MWQMSubsectors> MWQMSubsectors { get; set; }
        public virtual DbSet<MapInfoPoints> MapInfoPoints { get; set; }
        public virtual DbSet<MapInfos> MapInfos { get; set; }
        public virtual DbSet<MikeBoundaryConditions> MikeBoundaryConditions { get; set; }
        public virtual DbSet<MikeScenarioResults> MikeScenarioResults { get; set; }
        public virtual DbSet<MikeScenarios> MikeScenarios { get; set; }
        public virtual DbSet<MikeSourceStartEnds> MikeSourceStartEnds { get; set; }
        public virtual DbSet<MikeSources> MikeSources { get; set; }
        public virtual DbSet<PolSourceObservationIssues> PolSourceObservationIssues { get; set; }
        public virtual DbSet<PolSourceObservations> PolSourceObservations { get; set; }
        public virtual DbSet<PolSourceSiteEffectTerms> PolSourceSiteEffectTerms { get; set; }
        public virtual DbSet<PolSourceSiteEffects> PolSourceSiteEffects { get; set; }
        public virtual DbSet<PolSourceSites> PolSourceSites { get; set; }
        public virtual DbSet<RainExceedanceClimateSites> RainExceedanceClimateSites { get; set; }
        public virtual DbSet<RainExceedances> RainExceedances { get; set; }
        public virtual DbSet<RatingCurveValues> RatingCurveValues { get; set; }
        public virtual DbSet<RatingCurves> RatingCurves { get; set; }
        public virtual DbSet<ReportSectionLanguages> ReportSectionLanguages { get; set; }
        public virtual DbSet<ReportSections> ReportSections { get; set; }
        public virtual DbSet<ReportTypeLanguages> ReportTypeLanguages { get; set; }
        public virtual DbSet<ReportTypes> ReportTypes { get; set; }
        public virtual DbSet<ResetPasswords> ResetPasswords { get; set; }
        public virtual DbSet<SamplingPlanEmails> SamplingPlanEmails { get; set; }
        public virtual DbSet<SamplingPlanSubsectorSites> SamplingPlanSubsectorSites { get; set; }
        public virtual DbSet<SamplingPlanSubsectors> SamplingPlanSubsectors { get; set; }
        public virtual DbSet<SamplingPlans> SamplingPlans { get; set; }
        public virtual DbSet<SpillLanguages> SpillLanguages { get; set; }
        public virtual DbSet<Spills> Spills { get; set; }
        public virtual DbSet<TVFileLanguages> TVFileLanguages { get; set; }
        public virtual DbSet<TVFiles> TVFiles { get; set; }
        public virtual DbSet<TVItemLanguages> TVItemLanguages { get; set; }
        public virtual DbSet<TVItemLinks> TVItemLinks { get; set; }
        public virtual DbSet<TVItemStats> TVItemStats { get; set; }
        public virtual DbSet<TVItemUserAuthorizations> TVItemUserAuthorizations { get; set; }
        public virtual DbSet<TVItems> TVItems { get; set; }
        public virtual DbSet<TVTypeUserAuthorizations> TVTypeUserAuthorizations { get; set; }
        public virtual DbSet<Tels> Tels { get; set; }
        public virtual DbSet<TideDataValues> TideDataValues { get; set; }
        public virtual DbSet<TideLocations> TideLocations { get; set; }
        public virtual DbSet<TideSites> TideSites { get; set; }
        public virtual DbSet<UseOfSites> UseOfSites { get; set; }
        public virtual DbSet<VPAmbients> VPAmbients { get; set; }
        public virtual DbSet<VPResults> VPResults { get; set; }
        public virtual DbSet<VPScenarioLanguages> VPScenarioLanguages { get; set; }
        public virtual DbSet<VPScenarios> VPScenarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CSSPDB2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressID);

                entity.HasIndex(e => e.AddressTVItemID)
                    .HasName("IX_AddressTVItemID");

                entity.HasIndex(e => e.AddressType)
                    .HasName("IX_AddressType");

                entity.HasIndex(e => e.CountryTVItemID)
                    .HasName("IX_CountryTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MunicipalityTVItemID)
                    .HasName("IX_MunicipalityTVItemID");

                entity.HasIndex(e => e.ProvinceTVItemID)
                    .HasName("IX_ProvinceTVItemID");

                entity.HasIndex(e => e.StreetName)
                    .HasName("IX_StreetName");

                entity.HasIndex(e => e.StreetNumber)
                    .HasName("IX_StreetNumber");

                entity.HasIndex(e => e.StreetType)
                    .HasName("IX_StreetType");

                entity.Property(e => e.GoogleAddressText).HasMaxLength(200);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.PostalCode).HasMaxLength(11);

                entity.Property(e => e.StreetName).HasMaxLength(200);

                entity.Property(e => e.StreetNumber).HasMaxLength(50);

                entity.HasOne(d => d.AddressTVItem)
                    .WithMany(p => p.AddressesAddressTVItem)
                    .HasForeignKey(d => d.AddressTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_AddressTVItemID");

                entity.HasOne(d => d.CountryTVItem)
                    .WithMany(p => p.AddressesCountryTVItem)
                    .HasForeignKey(d => d.CountryTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_CountryTVItemID");

                entity.HasOne(d => d.MunicipalityTVItem)
                    .WithMany(p => p.AddressesMunicipalityTVItem)
                    .HasForeignKey(d => d.MunicipalityTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_MunicipalityTVItemID");

                entity.HasOne(d => d.ProvinceTVItem)
                    .WithMany(p => p.AddressesProvinceTVItem)
                    .HasForeignKey(d => d.ProvinceTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_ProvinceTVItemID");
            });

            modelBuilder.Entity<AppErrLogs>(entity =>
            {
                entity.HasKey(e => e.AppErrLogID)
                    .HasName("PK_DBErrLogs");

                entity.HasIndex(e => e.DateTime_UTC)
                    .HasName("IX_DBErrLogDateTime");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.LineNumber)
                    .HasName("IX_DBErrLogLineNumber");

                entity.HasIndex(e => e.Tag)
                    .HasName("IX_DBErrLogUniqueTag");

                entity.Property(e => e.DateTime_UTC).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AppTaskLanguages>(entity =>
            {
                entity.HasKey(e => e.AppTaskLanguageID);

                entity.HasIndex(e => e.AppTaskID)
                    .HasName("IX_AppTaskID");

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.Property(e => e.ErrorText).HasMaxLength(250);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.StatusText).HasMaxLength(250);

                entity.Property(e => e.TranslationStatus).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.AppTask)
                    .WithMany(p => p.AppTaskLanguages)
                    .HasForeignKey(d => d.AppTaskID)
                    .HasConstraintName("FK_AppTaskLanguages_AppTasks");
            });

            modelBuilder.Entity<AppTasks>(entity =>
            {
                entity.HasKey(e => e.AppTaskID);

                entity.HasIndex(e => e.AppTaskCommand)
                    .HasName("IX_AppTaskName");

                entity.HasIndex(e => e.AppTaskStatus)
                    .HasName("IX_Status");

                entity.HasIndex(e => e.EndDateTime_UTC)
                    .HasName("IX_EndDateTime_UTC");

                entity.HasIndex(e => e.EstimatedLength_second)
                    .HasName("IX_EstimatedLength_second");

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.PercentCompleted)
                    .HasName("IX_PercentCompleted");

                entity.HasIndex(e => e.RemainingTime_second)
                    .HasName("IX_RemainingTime_second");

                entity.HasIndex(e => e.StartDateTime_UTC)
                    .HasName("IX_StartDateTime_UTC");

                entity.HasIndex(e => e.TVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.TVItemID2)
                    .HasName("IX_TVItemID2");

                entity.Property(e => e.AppTaskStatus).HasComment("Error = -1, Created = 1, Running = 2, Completed = 3");

                entity.Property(e => e.EndDateTime_UTC).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Parameters)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.StartDateTime_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.TVItem)
                    .WithMany(p => p.AppTasksTVItem)
                    .HasForeignKey(d => d.TVItemID)
                    .HasConstraintName("FK_AppTasks_TVItems");

                entity.HasOne(d => d.TVItemID2Navigation)
                    .WithMany(p => p.AppTasksTVItemID2Navigation)
                    .HasForeignKey(d => d.TVItemID2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppTasks_TVItems2");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<BoxModelLanguages>(entity =>
            {
                entity.HasKey(e => e.BoxModelLanguageID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ScenarioName)
                    .HasName("IX_ScenarioName");

                entity.HasIndex(e => e.TranslationStatus)
                    .HasName("IX_ScenarioNameStatus");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.ScenarioName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TranslationStatus).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.BoxModel)
                    .WithMany(p => p.BoxModelLanguages)
                    .HasForeignKey(d => d.BoxModelID)
                    .HasConstraintName("FK_BoxModelLanguages_BoxModels");
            });

            modelBuilder.Entity<BoxModelResults>(entity =>
            {
                entity.HasKey(e => e.BoxModelResultID);

                entity.HasIndex(e => e.BoxModelID)
                    .HasName("IX_BoxModelID");

                entity.HasIndex(e => e.BoxModelResultType)
                    .HasName("IX_ResultType");

                entity.HasIndex(e => e.CircleCenterLatitude)
                    .HasName("IX_CircleCenterLatitude");

                entity.HasIndex(e => e.CircleCenterLongitude)
                    .HasName("IX_CircleCenterLongitude");

                entity.HasIndex(e => e.FixLength)
                    .HasName("IX_FixHeight");

                entity.HasIndex(e => e.FixWidth)
                    .HasName("IX_FixWidth");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.LeftSideDiameterLineAngle_deg)
                    .HasName("IX_LeftSideDiameterLineAngle_deg");

                entity.HasIndex(e => e.LeftSideLineAngle_deg)
                    .HasName("IX_LeftSideLineAngle_deg");

                entity.HasIndex(e => e.LeftSideLineStartLatitude)
                    .HasName("IX_LeftSideLineStartLatitude");

                entity.HasIndex(e => e.LeftSideLineStartLongitude)
                    .HasName("IX_LeftSideLineStartLongitude");

                entity.HasIndex(e => e.Radius_m)
                    .HasName("IX_Radius_m");

                entity.HasIndex(e => e.RectLength_m)
                    .HasName("IX_RectHeight_m");

                entity.HasIndex(e => e.RectWidth_m)
                    .HasName("IX_RectWidth_m");

                entity.HasIndex(e => e.Surface_m2)
                    .HasName("IX_Surface_m2");

                entity.HasIndex(e => e.Volume_m3)
                    .HasName("IX_Volume_m3");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.BoxModel)
                    .WithMany(p => p.BoxModelResults)
                    .HasForeignKey(d => d.BoxModelID)
                    .HasConstraintName("FK_BoxModelResults_BoxModels");
            });

            modelBuilder.Entity<BoxModels>(entity =>
            {
                entity.HasKey(e => e.BoxModelID);

                entity.HasIndex(e => e.Concentration_MPN_100ml)
                    .HasName("IX_Concentration_MPN_100ml");

                entity.HasIndex(e => e.DecayRate_per_day)
                    .HasName("IX_DecayRate_per_day");

                entity.HasIndex(e => e.Depth_m)
                    .HasName("IX_Depth_m");

                entity.HasIndex(e => e.Dilution)
                    .HasName("IX_Dilution");

                entity.HasIndex(e => e.DischargeDuration_hour)
                    .HasName("IX_FlowDuration_hour");

                entity.HasIndex(e => e.Discharge_m3_day)
                    .HasName("IX_Flow_m3_day");

                entity.HasIndex(e => e.FCPreDisinfection_MPN_100ml)
                    .HasName("IX_FCPreDisinfection_MPN_100ml");

                entity.HasIndex(e => e.FCUntreated_MPN_100ml)
                    .HasName("IX_FCUntreated_MPN_100ml");

                entity.HasIndex(e => e.InfrastructureTVItemID)
                    .HasName("IX_InfrastructureTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.T90_hour)
                    .HasName("IX_T90_hour");

                entity.HasIndex(e => e.Temperature_C)
                    .HasName("IX_Temperature_C");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.InfrastructureTVItem)
                    .WithMany(p => p.BoxModels)
                    .HasForeignKey(d => d.InfrastructureTVItemID)
                    .HasConstraintName("FK_BoxModels_InfrastructureTVItemID");
            });

            modelBuilder.Entity<Classifications>(entity =>
            {
                entity.HasKey(e => e.ClassificationID);

                entity.HasIndex(e => e.ClassificationTVItemID)
                    .HasName("IX_ClassificationTVItemID");

                entity.HasIndex(e => e.ClassificationType)
                    .HasName("IX_ClassificationType");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.ClassificationTVItem)
                    .WithMany(p => p.Classifications)
                    .HasForeignKey(d => d.ClassificationTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Classifications_TVItems");
            });

            modelBuilder.Entity<ClimateDataValues>(entity =>
            {
                entity.HasKey(e => e.ClimateDataValueID);

                entity.HasIndex(e => e.CoolDegDays_C)
                    .HasName("IX_CoolDegDays_C");

                entity.HasIndex(e => e.DateTime_Local)
                    .HasName("IX_DateTime_UTC");

                entity.HasIndex(e => e.DirMaxGust_0North)
                    .HasName("IX_DirMaxGust_0North");

                entity.HasIndex(e => e.HasBeenRead)
                    .HasName("IX_HasBeenRead");

                entity.HasIndex(e => e.HeatDegDays_C)
                    .HasName("IX_HeatDegDays_C");

                entity.HasIndex(e => e.Keep)
                    .HasName("IX_Keep");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MaxTemp_C)
                    .HasName("IX_MaxTemp_C");

                entity.HasIndex(e => e.MinTemp_C)
                    .HasName("IX_MinTemp_C");

                entity.HasIndex(e => e.RainfallEntered_mm)
                    .HasName("IX_Rainfall_mm");

                entity.HasIndex(e => e.SnowOnGround_cm)
                    .HasName("IX_SnowOnGround_cm");

                entity.HasIndex(e => e.Snow_cm)
                    .HasName("IX_Snow_cm");

                entity.HasIndex(e => e.SpdMaxGust_kmh)
                    .HasName("IX_SpdMaxGust_kmh");

                entity.HasIndex(e => e.StorageDataType)
                    .HasName("IX_StorageDataType");

                entity.HasIndex(e => e.TotalPrecip_mm_cm)
                    .HasName("IX_TotalPrecip_mm_cm");

                entity.Property(e => e.DateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.HourlyValues).HasColumnType("text");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.ClimateSite)
                    .WithMany(p => p.ClimateDataValues)
                    .HasForeignKey(d => d.ClimateSiteID)
                    .HasConstraintName("FK_ClimateDataValues_ClimateSites");
            });

            modelBuilder.Entity<ClimateSites>(entity =>
            {
                entity.HasKey(e => e.ClimateSiteID);

                entity.HasIndex(e => e.ClimateID)
                    .HasName("IX_ClimateID");

                entity.HasIndex(e => e.ClimateSiteName)
                    .HasName("IX_ClimateSiteName");

                entity.HasIndex(e => e.ClimateSiteTVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.DailyEndDate_Local)
                    .HasName("IX_DailyEndDate_UTC");

                entity.HasIndex(e => e.DailyNow)
                    .HasName("IX_DailyNow");

                entity.HasIndex(e => e.DailyStartDate_Local)
                    .HasName("IX_DailyStartDate_UTC");

                entity.HasIndex(e => e.ECDBID)
                    .HasName("IX_ECDBID");

                entity.HasIndex(e => e.Elevation_m)
                    .HasName("IX_Elevation_m");

                entity.HasIndex(e => e.File_desc)
                    .HasName("IX_File_desc");

                entity.HasIndex(e => e.HourlyEndDate_Local)
                    .HasName("IX_HourlyEndDate_UTC");

                entity.HasIndex(e => e.HourlyNow)
                    .HasName("IX_HourlyNow");

                entity.HasIndex(e => e.HourlyStartDate_Local)
                    .HasName("IX_HourlyStartDate_UTC");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MonthlyEndDate_Local)
                    .HasName("IX_MonthlyEndDate_UTC");

                entity.HasIndex(e => e.MonthlyNow)
                    .HasName("IX_MonthlyNow");

                entity.HasIndex(e => e.MonthlyStartDate_Local)
                    .HasName("IX_MonthlyStartDate_UTC");

                entity.HasIndex(e => e.Province)
                    .HasName("IX_Province");

                entity.HasIndex(e => e.TCID)
                    .HasName("IX_TCID");

                entity.HasIndex(e => e.TimeOffset_hour)
                    .HasName("IX_TimeOffset_hour");

                entity.HasIndex(e => e.WMOID)
                    .HasName("IX_WMOID");

                entity.Property(e => e.ClimateID).HasMaxLength(10);

                entity.Property(e => e.ClimateSiteName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DailyEndDate_Local).HasColumnType("datetime");

                entity.Property(e => e.DailyStartDate_Local).HasColumnType("datetime");

                entity.Property(e => e.File_desc).HasMaxLength(50);

                entity.Property(e => e.HourlyEndDate_Local).HasColumnType("datetime");

                entity.Property(e => e.HourlyStartDate_Local).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.MonthlyEndDate_Local).HasColumnType("datetime");

                entity.Property(e => e.MonthlyStartDate_Local).HasColumnType("datetime");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.TCID).HasMaxLength(3);

                entity.HasOne(d => d.ClimateSiteTVItem)
                    .WithMany(p => p.ClimateSites)
                    .HasForeignKey(d => d.ClimateSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClimateSites_TVItems");
            });

            modelBuilder.Entity<ContactPreferences>(entity =>
            {
                entity.HasKey(e => e.ContactPreferenceID);

                entity.HasIndex(e => e.ContactID)
                    .HasName("IX_ContactID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MarkerSize)
                    .HasName("IX_MarkerSize");

                entity.HasIndex(e => e.TVType)
                    .HasName("IX_TVType");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactPreferences)
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactPreferences_Contacts");
            });

            modelBuilder.Entity<ContactShortcuts>(entity =>
            {
                entity.HasKey(e => e.ContactShortcutID);

                entity.HasIndex(e => e.ContactID)
                    .HasName("IX_ContactID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ShortCutAddress)
                    .HasName("IX_ShortCutAddress");

                entity.HasIndex(e => e.ShortCutText)
                    .HasName("IX_ShortCutText");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.ShortCutAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ShortCutText)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactShortcuts)
                    .HasForeignKey(d => d.ContactID)
                    .HasConstraintName("FK_ContactShortcuts_Contacts");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactID);

                entity.HasIndex(e => e.ContactTVItemID)
                    .HasName("IX_ContactTVItemID");

                entity.HasIndex(e => e.Disabled)
                    .HasName("IX_Disabled");

                entity.HasIndex(e => e.EmailValidated)
                    .HasName("IX_EmailValidated");

                entity.HasIndex(e => e.FirstName)
                    .HasName("IX_FirstName");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Id");

                entity.HasIndex(e => e.Initial)
                    .HasName("IX_Initial");

                entity.HasIndex(e => e.IsAdmin)
                    .HasName("IX_IsAdmin");

                entity.HasIndex(e => e.LastName)
                    .HasName("IX_LastName");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.LoginEmail)
                    .HasName("IX_LoginEmail");

                entity.HasIndex(e => e.WebName)
                    .HasName("IX_WebName");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Id).IsRequired();

                entity.Property(e => e.Initial).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.LoginEmail)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SamplingPlanner_ProvincesTVItemID).HasMaxLength(200);

                entity.Property(e => e.WebName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ContactTVItem)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ContactTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contacts_TVItems");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_Contacts_AspNetUsers");
            });

            modelBuilder.Entity<DocTemplates>(entity =>
            {
                entity.HasKey(e => e.DocTemplateID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TVFileTVItemID)
                    .HasName("IX_TVFileTVItemID");

                entity.HasIndex(e => e.TVType)
                    .HasName("IX_TVType");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.TVFileTVItem)
                    .WithMany(p => p.DocTemplates)
                    .HasForeignKey(d => d.TVFileTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocTemplates_TVItems");
            });

            modelBuilder.Entity<DrogueRunPositions>(entity =>
            {
                entity.HasKey(e => e.DrogueRunPositionID);

                entity.HasIndex(e => e.CalculatedDirection_deg)
                    .HasName("IX_CalculatedDirection_deg");

                entity.HasIndex(e => e.CalculatedSpeed_m_s)
                    .HasName("IX_CalculatedSpeed_m_s");

                entity.HasIndex(e => e.DrogueRunID)
                    .HasName("IX_DrogueRunID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.HasIndex(e => e.StepDateTime_Local)
                    .HasName("IX_StepDateTime_Local");

                entity.HasIndex(e => e.StepLat)
                    .HasName("IX_StepLat");

                entity.HasIndex(e => e.StepLng)
                    .HasName("IX_StepLng");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.StepDateTime_Local).HasColumnType("datetime");

                entity.HasOne(d => d.DrogueRun)
                    .WithMany(p => p.DrogueRunPositions)
                    .HasForeignKey(d => d.DrogueRunID)
                    .HasConstraintName("FK_DrogueRunPositions_DrogueRuns");
            });

            modelBuilder.Entity<DrogueRuns>(entity =>
            {
                entity.HasKey(e => e.DrogueRunID);

                entity.HasIndex(e => e.DrogueNumber)
                    .HasName("IX_DrogueNumber");

                entity.HasIndex(e => e.DrogueType)
                    .HasName("IX_DrogueType");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.RunStartDateTime)
                    .HasName("IX_RunStartDateTime");

                entity.HasIndex(e => e.SubsectorTVItemID)
                    .HasName("IX_SubsectorTVItemID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.RunStartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SubsectorTVItem)
                    .WithMany(p => p.DrogueRuns)
                    .HasForeignKey(d => d.SubsectorTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DrogueRuns_TVItems");
            });

            modelBuilder.Entity<EmailDistributionListContactLanguages>(entity =>
            {
                entity.HasKey(e => e.EmailDistributionListContactLanguageID);

                entity.HasIndex(e => e.Agency)
                    .HasName("IX_Agency");

                entity.HasIndex(e => e.EmailDistributionListContactID)
                    .HasName("IX_EmailDistributionListContactID");

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.Property(e => e.Agency)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TranslationStatus).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.EmailDistributionListContact)
                    .WithMany(p => p.EmailDistributionListContactLanguages)
                    .HasForeignKey(d => d.EmailDistributionListContactID)
                    .HasConstraintName("FK_EmailDistributionListContactLanguages_EmailDistributionListContacts");
            });

            modelBuilder.Entity<EmailDistributionListContacts>(entity =>
            {
                entity.HasKey(e => e.EmailDistributionListContactID);

                entity.HasIndex(e => e.EmailDistributionListID)
                    .HasName("IX_EmailDistributionListID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.EmailDistributionList)
                    .WithMany(p => p.EmailDistributionListContacts)
                    .HasForeignKey(d => d.EmailDistributionListID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmailDistributionListContacts_EmailDistributionLists");
            });

            modelBuilder.Entity<EmailDistributionListLanguages>(entity =>
            {
                entity.HasKey(e => e.EmailDistributionListLanguageID);

                entity.HasIndex(e => e.EmailDistributionListID)
                    .HasName("IX_EmailDistributionListID");

                entity.HasIndex(e => e.EmailListName)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.Property(e => e.EmailListName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TranslationStatus).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.EmailDistributionList)
                    .WithMany(p => p.EmailDistributionListLanguages)
                    .HasForeignKey(d => d.EmailDistributionListID)
                    .HasConstraintName("FK_EmailDistributionListLanguages_EmailDistributionLists");
            });

            modelBuilder.Entity<EmailDistributionLists>(entity =>
            {
                entity.HasKey(e => e.EmailDistributionListID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.HasIndex(e => e.ParentTVItemID)
                    .HasName("IX_ParentTVItemID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.ParentTVItem)
                    .WithMany(p => p.EmailDistributionLists)
                    .HasForeignKey(d => d.ParentTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmailDistributionLists_TVItems");
            });

            modelBuilder.Entity<Emails>(entity =>
            {
                entity.HasKey(e => e.EmailID);

                entity.HasIndex(e => e.EmailAddress)
                    .HasName("IX_EmailText");

                entity.HasIndex(e => e.EmailTVItemID)
                    .HasName("IX_EmailTVItemID");

                entity.HasIndex(e => e.EmailType)
                    .HasName("IX_EmailTypeTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EmailType).HasComment("");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.EmailTVItem)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.EmailTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmailTVItemID_TVItems");
            });

            modelBuilder.Entity<HelpDocs>(entity =>
            {
                entity.HasKey(e => e.HelpDocID);

                entity.HasIndex(e => e.DocKey)
                    .HasName("IX_DocKey");

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.Property(e => e.DocHTMLText)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DocKey)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");
            });

            modelBuilder.Entity<HydrometricDataValues>(entity =>
            {
                entity.HasKey(e => e.HydrometricDataValueID);

                entity.HasIndex(e => e.DateTime_Local)
                    .HasName("IX_DateTime_UTC");

                entity.HasIndex(e => e.DischargeEntered_m3_s)
                    .HasName("IX_DischargeEntered_m3_s");

                entity.HasIndex(e => e.Discharge_m3_s)
                    .HasName("IX_Discharge_m3_s");

                entity.HasIndex(e => e.HasBeenRead)
                    .HasName("IX_HasBeenRead");

                entity.HasIndex(e => e.HydrometricSiteID)
                    .HasName("IX_HydrometricSiteID");

                entity.HasIndex(e => e.Keep)
                    .HasName("IX_Keep");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Level_m)
                    .HasName("IX_Level_m");

                entity.HasIndex(e => e.StorageDataType)
                    .HasName("IX_StorageDataType");

                entity.Property(e => e.DateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.HourlyValues).HasColumnType("text");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.HydrometricSite)
                    .WithMany(p => p.HydrometricDataValues)
                    .HasForeignKey(d => d.HydrometricSiteID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HydrometricDataValues_HydrometricSites");
            });

            modelBuilder.Entity<HydrometricSites>(entity =>
            {
                entity.HasKey(e => e.HydrometricSiteID);

                entity.HasIndex(e => e.DrainageArea_km2)
                    .HasName("IX_DrainageArea_km2");

                entity.HasIndex(e => e.Elevation_m)
                    .HasName("IX_Elevation_m");

                entity.HasIndex(e => e.EndDate_Local)
                    .HasName("IX_EndDate_UTC");

                entity.HasIndex(e => e.FedSiteNumber)
                    .HasName("IX_FedSiteNumber");

                entity.HasIndex(e => e.HasDischarge)
                    .HasName("IX_HasDischarge");

                entity.HasIndex(e => e.HasLevel)
                    .HasName("IX_HasLevel");

                entity.HasIndex(e => e.HasRatingCurve)
                    .HasName("IX_HasRatingCurve");

                entity.HasIndex(e => e.HydrometricSiteName)
                    .HasName("IX_HydrometricSiteName");

                entity.HasIndex(e => e.HydrometricSiteTVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.IsActive)
                    .HasName("IX_IsActive");

                entity.HasIndex(e => e.IsNatural)
                    .HasName("IX_IsNatural");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Province)
                    .HasName("IX_Province");

                entity.HasIndex(e => e.QuebecSiteNumber)
                    .HasName("IX_QuebecSiteNumber");

                entity.HasIndex(e => e.RHBN)
                    .HasName("IX_RHBN");

                entity.HasIndex(e => e.RealTime)
                    .HasName("IX_RealTime");

                entity.HasIndex(e => e.Sediment)
                    .HasName("IX_Sediment");

                entity.HasIndex(e => e.StartDate_Local)
                    .HasName("IX_StartDate_UTC");

                entity.HasIndex(e => e.TimeOffset_hour)
                    .HasName("IX_TimeOffset_hour");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EndDate_Local).HasColumnType("datetime");

                entity.Property(e => e.FedSiteNumber).HasMaxLength(7);

                entity.Property(e => e.HydrometricSiteName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.QuebecSiteNumber).HasMaxLength(7);

                entity.Property(e => e.StartDate_Local).HasColumnType("datetime");

                entity.HasOne(d => d.HydrometricSiteTVItem)
                    .WithMany(p => p.HydrometricSites)
                    .HasForeignKey(d => d.HydrometricSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HydrometricSites_TVItems");
            });

            modelBuilder.Entity<InfrastructureLanguages>(entity =>
            {
                entity.HasKey(e => e.InfrastructureLanguageID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TranslationStatus)
                    .HasName("IX_InputDataCommentStatus");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TranslationStatus).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.Infrastructure)
                    .WithMany(p => p.InfrastructureLanguages)
                    .HasForeignKey(d => d.InfrastructureID)
                    .HasConstraintName("FK_InfrastructureLanguages_Infrastructures");
            });

            modelBuilder.Entity<Infrastructures>(entity =>
            {
                entity.HasKey(e => e.InfrastructureID);

                entity.HasIndex(e => e.AverageDepth_m)
                    .HasName("IX_AverageDepth_m");

                entity.HasIndex(e => e.AverageFlow_m3_day)
                    .HasName("IX_AverageFlow_m3_s");

                entity.HasIndex(e => e.CanOverflow)
                    .HasName("IX_CanOverflow");

                entity.HasIndex(e => e.DecayRate_per_day)
                    .HasName("IX_DecayRate_per_day");

                entity.HasIndex(e => e.DesignFlow_m3_day)
                    .HasName("IX_DesignFlow_m3_s");

                entity.HasIndex(e => e.DistanceFromShore_m)
                    .HasName("IX_DistanceFromShore_m");

                entity.HasIndex(e => e.FarFieldVelocity_m_s)
                    .HasName("IX_FarFieldVelocity_m_s");

                entity.HasIndex(e => e.HorizontalAngle_deg)
                    .HasName("IX_HorizontalAngle_deg");

                entity.HasIndex(e => e.InfrastructureTVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.LSID)
                    .HasName("IX_LSID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.NearFieldVelocity_m_s)
                    .HasName("IX_NearFieldVelocity_m_s");

                entity.HasIndex(e => e.NumberOfPorts)
                    .HasName("IX_NumberOfPorts");

                entity.HasIndex(e => e.PeakFlow_m3_day)
                    .HasName("IX_PeakFlow_m3_s");

                entity.HasIndex(e => e.PercFlowOfTotal)
                    .HasName("IX_PercFlowOfTotal");

                entity.HasIndex(e => e.PopServed)
                    .HasName("IX_PopServed");

                entity.HasIndex(e => e.PortDiameter_m)
                    .HasName("IX_PortDiameter_m");

                entity.HasIndex(e => e.PortElevation_m)
                    .HasName("IX_PortElevation_m");

                entity.HasIndex(e => e.PortSpacing_m)
                    .HasName("IX_PortSpacing_m");

                entity.HasIndex(e => e.PrismID)
                    .HasName("IX_PrismID");

                entity.HasIndex(e => e.ReceivingWaterSalinity_PSU)
                    .HasName("IX_ReceivingWaterSalinity_PSU");

                entity.HasIndex(e => e.ReceivingWaterTemperature_C)
                    .HasName("IX_ReceivingWaterTemperature_C");

                entity.HasIndex(e => e.ReceivingWater_MPN_per_100ml)
                    .HasName("IX_ReceivingWater_MPN_per_100ml");

                entity.HasIndex(e => e.Site)
                    .HasName("IX_Site");

                entity.HasIndex(e => e.SiteID)
                    .HasName("IX_SiteID");

                entity.HasIndex(e => e.TPID)
                    .HasName("IX_TPID");

                entity.HasIndex(e => e.TimeOffset_hour)
                    .HasName("IX_TimeOffset_hour");

                entity.HasIndex(e => e.VerticalAngle_deg)
                    .HasName("IX_VerticalAngle_deg");

                entity.Property(e => e.InfrastructureCategory).HasMaxLength(1);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TempCatchAllRemoveLater).HasColumnType("text");

                entity.HasOne(d => d.CivicAddressTVItem)
                    .WithMany(p => p.InfrastructuresCivicAddressTVItem)
                    .HasForeignKey(d => d.CivicAddressTVItemID)
                    .HasConstraintName("FK_Infrastructures_CivicAddressTVItemID");

                entity.HasOne(d => d.InfrastructureTVItem)
                    .WithMany(p => p.InfrastructuresInfrastructureTVItem)
                    .HasForeignKey(d => d.InfrastructureTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Infrastructures_TVItems");

                entity.HasOne(d => d.SeeOtherMunicipalityTVItem)
                    .WithMany(p => p.InfrastructuresSeeOtherMunicipalityTVItem)
                    .HasForeignKey(d => d.SeeOtherMunicipalityTVItemID)
                    .HasConstraintName("FK_Infrastructures_SeeOtherTVItemID");
            });

            modelBuilder.Entity<LabSheetDetails>(entity =>
            {
                entity.HasKey(e => e.LabSheetDetailID);

                entity.HasIndex(e => e.Bath3Negative44_5)
                    .HasName("IX_Negative44_5");

                entity.HasIndex(e => e.Bath3NonTarget44_5)
                    .HasName("IX_NonTarget44_5");

                entity.HasIndex(e => e.Bath3Positive44_5)
                    .HasName("IX_Positive44_5");

                entity.HasIndex(e => e.Blank35)
                    .HasName("IX_Blank35");

                entity.HasIndex(e => e.DailyDuplicateAcceptable)
                    .HasName("IX_DuplicateAcceptable");

                entity.HasIndex(e => e.DailyDuplicatePrecisionCriteria)
                    .HasName("IX_DuplicatePrecisionCriteria");

                entity.HasIndex(e => e.DailyDuplicateRLog)
                    .HasName("IX_DuplicateRLog");

                entity.HasIndex(e => e.IncubationBath1StartTime)
                    .HasName("IX_IncubationStartTime");

                entity.HasIndex(e => e.IncubationBath3EndTime)
                    .HasName("IX_IncubationEndTime");

                entity.HasIndex(e => e.IncubationBath3TimeCalculated_minutes)
                    .HasName("IX_IncubationTimeCalculated_minutes");

                entity.HasIndex(e => e.LabSheetID)
                    .HasName("IX_LabSheetID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Lot35)
                    .HasName("IX_Lot35");

                entity.HasIndex(e => e.Lot44_5)
                    .HasName("IX_Lot44_5");

                entity.HasIndex(e => e.Negative35)
                    .HasName("IX_Negative35");

                entity.HasIndex(e => e.Positive35)
                    .HasName("IX_Positive35");

                entity.HasIndex(e => e.ResultsRecordedBy)
                    .HasName("IX_ResultsRecordedBy");

                entity.HasIndex(e => e.ResultsRecordedDate)
                    .HasName("IX_ResultsRecordedDate");

                entity.HasIndex(e => e.RunDate)
                    .HasName("IX_RunDate");

                entity.HasIndex(e => e.SalinitiesReadBy)
                    .HasName("IX_SalinitiesReadBy");

                entity.HasIndex(e => e.SalinitiesReadDate)
                    .HasName("IX_SalinitiesReadDate");

                entity.HasIndex(e => e.SampleBottleLotNumber)
                    .HasName("IX_SampleBottleLotNumber");

                entity.HasIndex(e => e.SampleCrewInitials)
                    .HasName("IX_SampleCrewInitials");

                entity.HasIndex(e => e.SamplingPlanID)
                    .HasName("IX_MWQMPlanID");

                entity.HasIndex(e => e.SubsectorTVItemID)
                    .HasName("IX_SubsectorTVItemID");

                entity.HasIndex(e => e.TCAverage)
                    .HasName("IX_TCAverage");

                entity.HasIndex(e => e.TCField1)
                    .HasName("IX_TCField1");

                entity.HasIndex(e => e.TCField2)
                    .HasName("IX_TCField2");

                entity.HasIndex(e => e.TCFirst)
                    .HasName("IX_TCFirst");

                entity.HasIndex(e => e.TCLab1)
                    .HasName("IX_TCLab1");

                entity.HasIndex(e => e.TCLab2)
                    .HasName("IX_TCLab2");

                entity.HasIndex(e => e.Tides)
                    .HasName("IX_Tides");

                entity.HasIndex(e => e.Version)
                    .HasName("IX_Version");

                entity.HasIndex(e => e.WaterBath3)
                    .HasName("IX_WaterBath");

                entity.Property(e => e.Bath1Blank44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath1Negative44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath1NonTarget44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath1Positive44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath2Blank44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath2Negative44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath2NonTarget44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath2Positive44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath3Blank44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath3Negative44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath3NonTarget44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Bath3Positive44_5)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Blank35)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ControlLot).HasMaxLength(100);

                entity.Property(e => e.IncubationBath1EndTime).HasColumnType("datetime");

                entity.Property(e => e.IncubationBath1StartTime).HasColumnType("datetime");

                entity.Property(e => e.IncubationBath2EndTime).HasColumnType("datetime");

                entity.Property(e => e.IncubationBath2StartTime).HasColumnType("datetime");

                entity.Property(e => e.IncubationBath3EndTime).HasColumnType("datetime");

                entity.Property(e => e.IncubationBath3StartTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Lot35).HasMaxLength(20);

                entity.Property(e => e.Lot44_5).HasMaxLength(20);

                entity.Property(e => e.Negative35)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.NonTarget35)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Positive35)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ResultsReadBy).HasMaxLength(20);

                entity.Property(e => e.ResultsReadDate).HasColumnType("datetime");

                entity.Property(e => e.ResultsRecordedBy).HasMaxLength(20);

                entity.Property(e => e.ResultsRecordedDate).HasColumnType("datetime");

                entity.Property(e => e.RunComment).HasMaxLength(250);

                entity.Property(e => e.RunDate).HasColumnType("datetime");

                entity.Property(e => e.RunWeatherComment).HasMaxLength(250);

                entity.Property(e => e.SalinitiesReadBy).HasMaxLength(20);

                entity.Property(e => e.SalinitiesReadDate).HasColumnType("datetime");

                entity.Property(e => e.SampleBottleLotNumber).HasMaxLength(20);

                entity.Property(e => e.SampleCrewInitials).HasMaxLength(20);

                entity.Property(e => e.Tides)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.WaterBath1).HasMaxLength(10);

                entity.Property(e => e.WaterBath2).HasMaxLength(10);

                entity.Property(e => e.WaterBath3).HasMaxLength(10);

                entity.Property(e => e.Weather).HasMaxLength(250);

                entity.HasOne(d => d.LabSheet)
                    .WithMany(p => p.LabSheetDetails)
                    .HasForeignKey(d => d.LabSheetID)
                    .HasConstraintName("FK_LabSheetDetails_LabSheets");

                entity.HasOne(d => d.SamplingPlan)
                    .WithMany(p => p.LabSheetDetails)
                    .HasForeignKey(d => d.SamplingPlanID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LabSheetDetails_SamplingPlans");

                entity.HasOne(d => d.SubsectorTVItem)
                    .WithMany(p => p.LabSheetDetails)
                    .HasForeignKey(d => d.SubsectorTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LabSheetDetails_SubsectorTVItemID");
            });

            modelBuilder.Entity<LabSheetTubeMPNDetails>(entity =>
            {
                entity.HasKey(e => e.LabSheetTubeMPNDetailID)
                    .HasName("PK_LabSheetTubeMPNDetailID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MPN)
                    .HasName("IX_MPN");

                entity.HasIndex(e => e.MWQMSiteTVItemID)
                    .HasName("IX_MWQMSiteTVItemID");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.HasIndex(e => e.ProcessedBy)
                    .HasName("IX_ProcessedBy");

                entity.HasIndex(e => e.Salinity)
                    .HasName("IX_Salinity");

                entity.HasIndex(e => e.SampleDateTime)
                    .HasName("IX_SampleDateTime");

                entity.HasIndex(e => e.SampleType)
                    .HasName("IX_SampleType");

                entity.HasIndex(e => e.SiteComment)
                    .HasName("IX_SiteComment");

                entity.HasIndex(e => e.Temperature)
                    .HasName("IX_Temperature");

                entity.HasIndex(e => e.Tube0_1)
                    .HasName("IX_Tube0_1");

                entity.HasIndex(e => e.Tube10)
                    .HasName("IX_Tube10");

                entity.HasIndex(e => e.Tube1_0)
                    .HasName("IX_Tube1_0");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.ProcessedBy).HasMaxLength(10);

                entity.Property(e => e.SampleDateTime).HasColumnType("datetime");

                entity.Property(e => e.SiteComment).HasMaxLength(250);

                entity.HasOne(d => d.LabSheetDetail)
                    .WithMany(p => p.LabSheetTubeMPNDetails)
                    .HasForeignKey(d => d.LabSheetDetailID)
                    .HasConstraintName("FK_LabSheetTubeMPNDetails_LabSheetDetails");

                entity.HasOne(d => d.MWQMSiteTVItem)
                    .WithMany(p => p.LabSheetTubeMPNDetails)
                    .HasForeignKey(d => d.MWQMSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LabSheetTubeMPNDetails_TVItems");
            });

            modelBuilder.Entity<LabSheets>(entity =>
            {
                entity.HasKey(e => e.LabSheetID);

                entity.HasIndex(e => e.AcceptedOrRejectedByContactTVItemID)
                    .HasName("IX_ApprovedByContactTVItemID");

                entity.HasIndex(e => e.AcceptedOrRejectedDateTime)
                    .HasName("IX_ApprovedDateTime");

                entity.HasIndex(e => e.Day)
                    .HasName("IX_Day");

                entity.HasIndex(e => e.FileLastModifiedDate_Local)
                    .HasName("IX_FileLastModifiedDate_Local");

                entity.HasIndex(e => e.FileName)
                    .HasName("IX_FileName");

                entity.HasIndex(e => e.LabSheetStatus)
                    .HasName("IX_LabSheetStatus");

                entity.HasIndex(e => e.LabSheetType)
                    .HasName("IX_LabSheetType");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MWQMRunTVItemID)
                    .HasName("IX_MWQMRunTVItemID");

                entity.HasIndex(e => e.Month)
                    .HasName("IX_Month");

                entity.HasIndex(e => e.OtherServerLabSheetID)
                    .HasName("IX_OtherServerLabSheetID");

                entity.HasIndex(e => e.SampleType)
                    .HasName("IX_SampleType");

                entity.HasIndex(e => e.SamplingPlanID)
                    .HasName("IX_SamplingPlanID");

                entity.HasIndex(e => e.SamplingPlanName)
                    .HasName("IX_SamplingPlanName");

                entity.HasIndex(e => e.SamplingPlanType)
                    .HasName("IX_SamplingPlanType");

                entity.HasIndex(e => e.SubsectorTVItemID)
                    .HasName("IX_SubsectorTVItemID");

                entity.HasIndex(e => e.Year)
                    .HasName("IX_Year");

                entity.Property(e => e.AcceptedOrRejectedDateTime).HasColumnType("datetime");

                entity.Property(e => e.FileContent)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FileLastModifiedDate_Local).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.RejectReason).HasMaxLength(250);

                entity.Property(e => e.SamplingPlanName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.AcceptedOrRejectedByContactTVItem)
                    .WithMany(p => p.LabSheetsAcceptedOrRejectedByContactTVItem)
                    .HasForeignKey(d => d.AcceptedOrRejectedByContactTVItemID)
                    .HasConstraintName("FK_LabSheets_ApprovedByContactTVItemID");

                entity.HasOne(d => d.MWQMRunTVItem)
                    .WithMany(p => p.LabSheetsMWQMRunTVItem)
                    .HasForeignKey(d => d.MWQMRunTVItemID)
                    .HasConstraintName("FK_LabSheets_MWQMRunTVItemID");

                entity.HasOne(d => d.SamplingPlan)
                    .WithMany(p => p.LabSheets)
                    .HasForeignKey(d => d.SamplingPlanID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LabSheets_SamplingPlans");

                entity.HasOne(d => d.SubsectorTVItem)
                    .WithMany(p => p.LabSheetsSubsectorTVItem)
                    .HasForeignKey(d => d.SubsectorTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LabSheets_SubsectorTVItemID");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogID);

                entity.HasIndex(e => e.ID)
                    .HasName("IX_ID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.LogCommand)
                    .HasName("IX_LogCommand");

                entity.HasIndex(e => e.TableName)
                    .HasName("IX_TableName");

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.LastUpdateDate_UTC)
                    .HasColumnType("datetime")
                    .HasComment("");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MWQMAnalysisReportParameters>(entity =>
            {
                entity.HasKey(e => e.MWQMAnalysisReportParameterID);

                entity.HasIndex(e => e.AnalysisName)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.AnalysisReportYear)
                    .HasName("IX_AnalysisReportYear");

                entity.HasIndex(e => e.ExcelTVFileTVItemID)
                    .HasName("IX_ExcelTVFileTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.NumberOfRuns)
                    .HasName("IX_NumberOfRuns");

                entity.HasIndex(e => e.StartDate)
                    .HasName("IX_StartDate");

                entity.HasIndex(e => e.SubsectorTVItemID)
                    .HasName("IX_SubsectorTVItemID");

                entity.Property(e => e.AnalysisName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.RunsToOmit)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.ShowDataTypes).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ExcelTVFileTVItem)
                    .WithMany(p => p.MWQMAnalysisReportParametersExcelTVFileTVItem)
                    .HasForeignKey(d => d.ExcelTVFileTVItemID)
                    .HasConstraintName("FK_MWQMAnalysisReportParameters_ExcelTVFileTVItemID");

                entity.HasOne(d => d.SubsectorTVItem)
                    .WithMany(p => p.MWQMAnalysisReportParametersSubsectorTVItem)
                    .HasForeignKey(d => d.SubsectorTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MWQMAnalysisReportParameters_SubsectorTVItemID");
            });

            modelBuilder.Entity<MWQMLookupMPNs>(entity =>
            {
                entity.HasKey(e => e.MWQMLookupMPNID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MPN_100ml)
                    .HasName("IX_MPN_100ml");

                entity.HasIndex(e => new { e.Tubes01, e.Tubes1, e.Tubes10 })
                    .HasName("IX_MWQMMPNs")
                    .IsUnique();

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");
            });

            modelBuilder.Entity<MWQMRunLanguages>(entity =>
            {
                entity.HasKey(e => e.MWQMRunLanguageID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MWQMRunID)
                    .HasName("IX_MWQMRunID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.RunComment)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.RunWeatherComment)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TranslationStatusRunComment).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.MWQMRun)
                    .WithMany(p => p.MWQMRunLanguages)
                    .HasForeignKey(d => d.MWQMRunID)
                    .HasConstraintName("FK_MWQMRunLanguages_MWQMRuns");
            });

            modelBuilder.Entity<MWQMRuns>(entity =>
            {
                entity.HasKey(e => e.MWQMRunID);

                entity.HasIndex(e => e.AnalyzeMethod)
                    .HasName("IX_AnayseMethodTVItemID");

                entity.HasIndex(e => e.DateTime_Local)
                    .HasName("IX_Date_UTC");

                entity.HasIndex(e => e.EndDateTime_Local)
                    .HasName("IX_EndTime_UTC");

                entity.HasIndex(e => e.LabAnalyzeBath1IncubationStartDateTime_Local)
                    .HasName("IX_LabAnalyseTime_UTC");

                entity.HasIndex(e => e.LabReceivedDateTime_Local)
                    .HasName("IX_LabReceivedTime_UTC");

                entity.HasIndex(e => e.LabRunSampleApprovalDateTime_Local)
                    .HasName("IX_ValidateTime_UTC");

                entity.HasIndex(e => e.LabSampleApprovalContactTVItemID)
                    .HasName("IX_ValidatorContactID");

                entity.HasIndex(e => e.Laboratory)
                    .HasName("IX_LabTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MWQMRunTVItemID)
                    .HasName("IX_MWQMRunTVItemID");

                entity.HasIndex(e => e.RainDay1_mm)
                    .HasName("IX_PPT24_mm");

                entity.HasIndex(e => e.RainDay2_mm)
                    .HasName("IX_PPT48_mm");

                entity.HasIndex(e => e.RainDay3_mm)
                    .HasName("IX_PPT72_mm");

                entity.HasIndex(e => e.RainDay4_mm)
                    .HasName("IX_PPT96_mm");

                entity.HasIndex(e => e.RainDay5_mm)
                    .HasName("IX_PPT120_mm");

                entity.HasIndex(e => e.SampleCrewInitials)
                    .HasName("IX_SamplingContactID");

                entity.HasIndex(e => e.SampleMatrix)
                    .HasName("IX_MatrixTVItemID");

                entity.HasIndex(e => e.SampleStatus)
                    .HasName("IX_StatusTVItemID");

                entity.HasIndex(e => e.SeaStateAtEnd_BeaufortScale)
                    .HasName("IX_SeaStateAtEnd_BeaufortScale");

                entity.HasIndex(e => e.SeaStateAtStart_BeaufortScale)
                    .HasName("IX_SeaStateAtStart_BeaufortScale");

                entity.HasIndex(e => e.StartDateTime_Local)
                    .HasName("IX_StartTime_UTC");

                entity.HasIndex(e => e.SubsectorTVItemID)
                    .HasName("IX_MWQMSiteTVItemID");

                entity.HasIndex(e => e.TemperatureControl1_C)
                    .HasName("IX_TemperatureControl_C");

                entity.HasIndex(e => e.Tide_End)
                    .HasName("IX_Tide_End");

                entity.HasIndex(e => e.Tide_Start)
                    .HasName("IX_Tide_Start");

                entity.HasIndex(e => e.WaterLevelAtBrook_m)
                    .HasName("IX_WaterLevelAtBrook_m");

                entity.HasIndex(e => e.WaveHightAtEnd_m)
                    .HasName("IX_WaveHightAtEnd_m");

                entity.HasIndex(e => e.WaveHightAtStart_m)
                    .HasName("IX_WaveHightAtStart_m");

                entity.Property(e => e.DateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.EndDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LabAnalyzeBath1IncubationStartDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LabAnalyzeBath2IncubationStartDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LabAnalyzeBath3IncubationStartDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LabReceivedDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LabRunSampleApprovalDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.SampleCrewInitials).HasMaxLength(20);

                entity.Property(e => e.StartDateTime_Local).HasColumnType("datetime");

                entity.HasOne(d => d.LabSampleApprovalContactTVItem)
                    .WithMany(p => p.MWQMRunsLabSampleApprovalContactTVItem)
                    .HasForeignKey(d => d.LabSampleApprovalContactTVItemID)
                    .HasConstraintName("FK_MWQMRuns_ValidatorTVItemContacts");

                entity.HasOne(d => d.MWQMRunTVItem)
                    .WithMany(p => p.MWQMRunsMWQMRunTVItem)
                    .HasForeignKey(d => d.MWQMRunTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MWQMRuns_TVItems");

                entity.HasOne(d => d.SubsectorTVItem)
                    .WithMany(p => p.MWQMRunsSubsectorTVItem)
                    .HasForeignKey(d => d.SubsectorTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MWQMRuns_MWQMSiteTVItems");
            });

            modelBuilder.Entity<MWQMSampleLanguages>(entity =>
            {
                entity.HasKey(e => e.MWQMSampleLanguageID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TranslationStatus)
                    .HasName("IX_MWQMSampleNoteStatus");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.MWQMSampleNote)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TranslationStatus).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.MWQMSample)
                    .WithMany(p => p.MWQMSampleLanguages)
                    .HasForeignKey(d => d.MWQMSampleID)
                    .HasConstraintName("FK_MWQMSampleLanguages_MWQMSamples");
            });

            modelBuilder.Entity<MWQMSamples>(entity =>
            {
                entity.HasKey(e => e.MWQMSampleID);

                entity.HasIndex(e => e.Depth_m)
                    .HasName("IX_Depth_m");

                entity.HasIndex(e => e.FecCol_MPN_100ml)
                    .HasName("IX_FecCol_MPN_100ml");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MWQMRunTVItemID)
                    .HasName("IX_MWQMRunTVItemID");

                entity.HasIndex(e => e.MWQMSiteTVItemID)
                    .HasName("IX_MWQMSiteTVItemID");

                entity.HasIndex(e => e.PH)
                    .HasName("IX_PH");

                entity.HasIndex(e => e.Salinity_PPT)
                    .HasName("IX_Salinity_PSU");

                entity.HasIndex(e => e.SampleDateTime_Local)
                    .HasName("IX_SampleDateTime_UTC");

                entity.HasIndex(e => e.SampleType_old)
                    .HasName("IX_SampleType");

                entity.HasIndex(e => e.WaterTemp_C)
                    .HasName("IX_WaterTemp_C");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.ProcessedBy).HasMaxLength(10);

                entity.Property(e => e.SampleDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.SampleTypesText)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeText).HasMaxLength(6);

                entity.HasOne(d => d.MWQMRunTVItem)
                    .WithMany(p => p.MWQMSamplesMWQMRunTVItem)
                    .HasForeignKey(d => d.MWQMRunTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MWQMSamples_MWQMRunTVItemID");

                entity.HasOne(d => d.MWQMSiteTVItem)
                    .WithMany(p => p.MWQMSamplesMWQMSiteTVItem)
                    .HasForeignKey(d => d.MWQMSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MWQMSamples_MWQMSites");
            });

            modelBuilder.Entity<MWQMSiteStartEndDates>(entity =>
            {
                entity.HasKey(e => e.MWQMSiteStartEndDateID);

                entity.HasIndex(e => e.EndDate)
                    .HasName("IX_EndDate");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MWQMSiteTVItemID)
                    .HasName("IX_MWQMSiteTVItemID");

                entity.HasIndex(e => e.StartDate)
                    .HasName("IX_StartDate");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.MWQMSiteTVItem)
                    .WithMany(p => p.MWQMSiteStartEndDates)
                    .HasForeignKey(d => d.MWQMSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MWQMSiteStartEndDates_TVItems");
            });

            modelBuilder.Entity<MWQMSites>(entity =>
            {
                entity.HasKey(e => e.MWQMSiteID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MWQMSiteLatestClassification)
                    .HasName("IX_MWQMSiteLatestClassification");

                entity.HasIndex(e => e.MWQMSiteNumber)
                    .HasName("IX_MWQMSiteNumber");

                entity.HasIndex(e => e.MWQMSiteTVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.MWQMSiteDescription)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MWQMSiteNumber)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(d => d.MWQMSiteTVItem)
                    .WithMany(p => p.MWQMSites)
                    .HasForeignKey(d => d.MWQMSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MWQMSites_TVItems");
            });

            modelBuilder.Entity<MWQMSubsectorLanguages>(entity =>
            {
                entity.HasKey(e => e.MWQMSubsectorLanguageID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.SubsectorDesc)
                    .HasName("IX_SubsectorDesc");

                entity.HasIndex(e => e.TranslationStatusSubsectorDesc)
                    .HasName("IX_SubsectorDescStatus");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.LogBook).HasColumnType("text");

                entity.Property(e => e.SubsectorDesc)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TranslationStatusSubsectorDesc).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.MWQMSubsector)
                    .WithMany(p => p.MWQMSubsectorLanguages)
                    .HasForeignKey(d => d.MWQMSubsectorID)
                    .HasConstraintName("FK_MWQMSubsectorLanguages_MWQMSubsectors");
            });

            modelBuilder.Entity<MWQMSubsectors>(entity =>
            {
                entity.HasKey(e => e.MWQMSubsectorID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MWQMSubsectorTVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.SubsectorHistoricKey)
                    .HasName("IX_SubsectorHistoricKey");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.SubsectorHistoricKey)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TideLocationSIDText).HasMaxLength(30);

                entity.HasOne(d => d.MWQMSubsectorTVItem)
                    .WithMany(p => p.MWQMSubsectors)
                    .HasForeignKey(d => d.MWQMSubsectorTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MWQMSubsectors_TVItems");
            });

            modelBuilder.Entity<MapInfoPoints>(entity =>
            {
                entity.HasKey(e => e.MapInfoPointID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Lat)
                    .HasName("IX_Lat");

                entity.HasIndex(e => e.Lng)
                    .HasName("IX_Lng");

                entity.HasIndex(e => e.MapInfoID)
                    .HasName("IX_MapInfoID");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.MapInfo)
                    .WithMany(p => p.MapInfoPoints)
                    .HasForeignKey(d => d.MapInfoID)
                    .HasConstraintName("FK_MapInfoPoints_MapInfos");
            });

            modelBuilder.Entity<MapInfos>(entity =>
            {
                entity.HasKey(e => e.MapInfoID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.LatMax)
                    .HasName("IX_LatMax");

                entity.HasIndex(e => e.LatMin)
                    .HasName("IX_LatMin");

                entity.HasIndex(e => e.LngMax)
                    .HasName("IX_LngMax");

                entity.HasIndex(e => e.LngMin)
                    .HasName("IX_LngMin");

                entity.HasIndex(e => e.MapInfoDrawType)
                    .HasName("IX_DrawType");

                entity.HasIndex(e => e.TVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.TVType)
                    .HasName("IX_MapInfoPurpose");

                entity.Property(e => e.LastUpdateDate_UTC)
                    .HasColumnType("datetime")
                    .HasComment("");

                entity.HasOne(d => d.TVItem)
                    .WithMany(p => p.MapInfos)
                    .HasForeignKey(d => d.TVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MapInfos_TVItems");
            });

            modelBuilder.Entity<MikeBoundaryConditions>(entity =>
            {
                entity.HasKey(e => e.MikeBoundaryConditionID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MikeBoundaryConditionCode)
                    .HasName("IX_MikeBoundaryConditionCode");

                entity.HasIndex(e => e.MikeBoundaryConditionFormat)
                    .HasName("IX_MIkeBoundaryConditionFormat");

                entity.HasIndex(e => e.MikeBoundaryConditionID)
                    .HasName("IX_MikeBoundaryConditionID");

                entity.HasIndex(e => e.MikeBoundaryConditionLength_m)
                    .HasName("IX_MikeBoundaryConditionLength_m");

                entity.HasIndex(e => e.MikeBoundaryConditionLevelOrVelocity)
                    .HasName("IX_MikeBoundaryConditionLevelOrVelocity");

                entity.HasIndex(e => e.MikeBoundaryConditionName)
                    .HasName("IX_MikeBoundaryConditionName");

                entity.HasIndex(e => e.MikeBoundaryConditionTVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.NumberOfWebTideNodes)
                    .HasName("IX_NumberOfWebTideNodes");

                entity.HasIndex(e => e.WebTideDataSet)
                    .HasName("IX_WebTideDataSet");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.MikeBoundaryConditionCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MikeBoundaryConditionFormat)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MikeBoundaryConditionLength_m).HasComment("Start, End, Middle");

                entity.Property(e => e.MikeBoundaryConditionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WebTideDataFromStartToEndDate)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.MikeBoundaryConditionTVItem)
                    .WithMany(p => p.MikeBoundaryConditions)
                    .HasForeignKey(d => d.MikeBoundaryConditionTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MikeBoundaryConditions_TVItems");
            });

            modelBuilder.Entity<MikeScenarioResults>(entity =>
            {
                entity.HasKey(e => e.MikeScenarioResultID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MikeScenarioTVItemID)
                    .HasName("IX_MikeScenarioTVItemID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.MikeResultsJSON).HasColumnType("text");

                entity.HasOne(d => d.MikeScenarioTVItem)
                    .WithMany(p => p.MikeScenarioResults)
                    .HasForeignKey(d => d.MikeScenarioTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MikeScenarioResults_TVItems");
            });

            modelBuilder.Entity<MikeScenarios>(entity =>
            {
                entity.HasKey(e => e.MikeScenarioID);

                entity.HasIndex(e => e.AmbientSalinity_PSU)
                    .HasName("IX_AmbientSalinity_PSU");

                entity.HasIndex(e => e.AmbientTemperature_C)
                    .HasName("IX_AmbientTemperature_C");

                entity.HasIndex(e => e.DecayFactorAmplitude)
                    .HasName("IX_DecayFactorAmplitude");

                entity.HasIndex(e => e.DecayFactor_per_day)
                    .HasName("IX_DecayFactor_per_day");

                entity.HasIndex(e => e.DecayIsConstant)
                    .HasName("IX_DecayIsConstant");

                entity.HasIndex(e => e.EstimatedHydroFileSize)
                    .HasName("IX_MikeScenarios");

                entity.HasIndex(e => e.EstimatedTransFileSize)
                    .HasName("IX_EstimatedTransFileSize");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ManningNumber)
                    .HasName("IX_ManningNumber");

                entity.HasIndex(e => e.MikeScenarioEndDateTime_Local)
                    .HasName("IX_ScenarioEndDateAndTime_UTC");

                entity.HasIndex(e => e.MikeScenarioExecutionTime_min)
                    .HasName("IX_ScenarioExecutionTime_min");

                entity.HasIndex(e => e.MikeScenarioStartDateTime_Local)
                    .HasName("IX_ScenarioStartDateAndTime_UTC");

                entity.HasIndex(e => e.MikeScenarioStartExecutionDateTime_Local)
                    .HasName("IX_ScenarioStartExecutionDateAndTime");

                entity.HasIndex(e => e.MikeScenarioTVItemID)
                    .HasName("IX_MikeScenarioTVItemID");

                entity.HasIndex(e => e.NumberOfElements)
                    .HasName("IX_NumberOfElements");

                entity.HasIndex(e => e.NumberOfHydroOutputParameters)
                    .HasName("IX_NumberOfHydroOutputParameters");

                entity.HasIndex(e => e.NumberOfSigmaLayers)
                    .HasName("IX_NumberOfSigmaLayers");

                entity.HasIndex(e => e.NumberOfTimeSteps)
                    .HasName("IX_NumberOfTimeSteps");

                entity.HasIndex(e => e.NumberOfTransOutputParameters)
                    .HasName("IX_NumberOfTransOutputParameters");

                entity.HasIndex(e => e.NumberOfZLayers)
                    .HasName("IX_NumberOfZLayers");

                entity.HasIndex(e => e.ParentMikeScenarioID)
                    .HasName("IX_ParentMikeScenarioID");

                entity.HasIndex(e => e.ResultFrequency_min)
                    .HasName("IX_ResultFrequency_min");

                entity.HasIndex(e => e.WindDirection_deg)
                    .HasName("IX_WindDirection_deg");

                entity.HasIndex(e => e.WindSpeed_km_h)
                    .HasName("IX_WindSpeed_m_s");

                entity.Property(e => e.ErrorInfo).HasColumnType("text");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.MikeScenarioEndDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.MikeScenarioStartDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.MikeScenarioStartExecutionDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.ScenarioStatus).HasComment("Error = -1, Copying = 1, Copied = 2, Changing = 3, Changed = 4, AskToRun = 5, Running = 6, Completed = 7");

                entity.HasOne(d => d.MikeScenarioTVItem)
                    .WithMany(p => p.MikeScenarios)
                    .HasForeignKey(d => d.MikeScenarioTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MikeScenarios_TVItems");

                entity.HasOne(d => d.ParentMikeScenario)
                    .WithMany(p => p.InverseParentMikeScenario)
                    .HasForeignKey(d => d.ParentMikeScenarioID)
                    .HasConstraintName("FK_MikeScenarios_MikeScenarios");
            });

            modelBuilder.Entity<MikeSourceStartEnds>(entity =>
            {
                entity.HasKey(e => e.MikeSourceStartEndID);

                entity.HasIndex(e => e.EndDateAndTime_Local)
                    .HasName("IX_EndDateAndTime_UTC");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MikeSourceID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.SourceFlowEnd_m3_day)
                    .HasName("IX_SourceFlowEnd_m3_day");

                entity.HasIndex(e => e.SourceFlowStart_m3_day)
                    .HasName("IX_SourceFlowStart_m3_day");

                entity.HasIndex(e => e.SourcePollutionEnd_MPN_100ml)
                    .HasName("IX_SourcePollutionEnd_MPN_100ml");

                entity.HasIndex(e => e.SourcePollutionStart_MPN_100ml)
                    .HasName("IX_SourcePollutionStart_MPN_100ml");

                entity.HasIndex(e => e.SourceSalinityEnd_PSU)
                    .HasName("IX_SourceSalinityEnd_PSU");

                entity.HasIndex(e => e.SourceSalinityStart_PSU)
                    .HasName("IX_SourceSalinityStart_PSU");

                entity.HasIndex(e => e.SourceTemperatureEnd_C)
                    .HasName("IX_SourceTemperatureEnd_C");

                entity.HasIndex(e => e.SourceTemperatureStart_C)
                    .HasName("IX_SourceTemperatureStart_C");

                entity.HasIndex(e => e.StartDateAndTime_Local)
                    .HasName("IX_StartDateAndTime_UTC");

                entity.Property(e => e.EndDateAndTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.StartDateAndTime_Local).HasColumnType("datetime");

                entity.HasOne(d => d.MikeSource)
                    .WithMany(p => p.MikeSourceStartEnds)
                    .HasForeignKey(d => d.MikeSourceID)
                    .HasConstraintName("FK_MikeSourceStartEnds_MikeSources");
            });

            modelBuilder.Entity<MikeSources>(entity =>
            {
                entity.HasKey(e => e.MikeSourceID);

                entity.HasIndex(e => e.DrainageArea_km2)
                    .HasName("IX_DrainageArea_km2");

                entity.HasIndex(e => e.Factor)
                    .HasName("IX_Factor");

                entity.HasIndex(e => e.HydrometricTVItemID)
                    .HasName("IX_HydrometricTVItemID");

                entity.HasIndex(e => e.Include)
                    .HasName("IX_Include");

                entity.HasIndex(e => e.IsRiver)
                    .HasName("IX_IsRiver");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MikeSourceTVItemID)
                    .HasName("IX_MikeSourceTVItemID");

                entity.HasIndex(e => e.SourceNumberString)
                    .HasName("IX_SourceNumberString");

                entity.HasIndex(e => e.UseHydrometric)
                    .HasName("IX_UseHydrometric");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.SourceNumberString)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.HydrometricTVItem)
                    .WithMany(p => p.MikeSourcesHydrometricTVItem)
                    .HasForeignKey(d => d.HydrometricTVItemID)
                    .HasConstraintName("FK_MikeSources_HydrometricTVItemID");

                entity.HasOne(d => d.MikeSourceTVItem)
                    .WithMany(p => p.MikeSourcesMikeSourceTVItem)
                    .HasForeignKey(d => d.MikeSourceTVItemID)
                    .HasConstraintName("FK_MikeSources_TVItems");
            });

            modelBuilder.Entity<PolSourceObservationIssues>(entity =>
            {
                entity.HasKey(e => e.PolSourceObservationIssueID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.HasIndex(e => e.PolSourceObservationID)
                    .HasName("IX_PolSourceObservationID");

                entity.Property(e => e.ExtraComment).HasColumnType("text");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.ObservationInfo)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.PolSourceObservation)
                    .WithMany(p => p.PolSourceObservationIssues)
                    .HasForeignKey(d => d.PolSourceObservationID)
                    .HasConstraintName("FK_PolSourceObservationIssues_PolSourceObservations");
            });

            modelBuilder.Entity<PolSourceObservations>(entity =>
            {
                entity.HasKey(e => e.PolSourceObservationID);

                entity.HasIndex(e => e.ContactTVItemID)
                    .HasName("IX_ContactTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ObservationDate_Local)
                    .HasName("IX_ObservationDate_UTC");

                entity.HasIndex(e => e.PolSourceObservationID)
                    .HasName("IX_PolSourceObservationID");

                entity.HasIndex(e => e.PolSourceSiteID)
                    .HasName("IX_PolSourceSiteID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.ObservationDate_Local).HasColumnType("datetime");

                entity.Property(e => e.Observation_ToBeDeleted)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.ContactTVItem)
                    .WithMany(p => p.PolSourceObservations)
                    .HasForeignKey(d => d.ContactTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolSourceObservations_TVItemContact");

                entity.HasOne(d => d.PolSourceSite)
                    .WithMany(p => p.PolSourceObservations)
                    .HasForeignKey(d => d.PolSourceSiteID)
                    .HasConstraintName("FK_PolSourceObservations_PolSourceSites");
            });

            modelBuilder.Entity<PolSourceSiteEffectTerms>(entity =>
            {
                entity.HasKey(e => e.PolSourceSiteEffectTermID);

                entity.HasIndex(e => e.EffectTermEN)
                    .HasName("IX_EffectTermEN");

                entity.HasIndex(e => e.EffectTermFR)
                    .HasName("IX_EffectTermFR");

                entity.HasIndex(e => e.IsGroup)
                    .HasName("IX_IsGroup");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.UnderGroupID)
                    .HasName("IX_UnderGroupID");

                entity.Property(e => e.EffectTermEN)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EffectTermFR)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.UnderGroup)
                    .WithMany(p => p.InverseUnderGroup)
                    .HasForeignKey(d => d.UnderGroupID)
                    .HasConstraintName("FK_PolSourceSiteEffectTerms_PolSourceSiteEffectTerms");
            });

            modelBuilder.Entity<PolSourceSiteEffects>(entity =>
            {
                entity.HasKey(e => e.PolSourceSiteEffectID);

                entity.HasIndex(e => e.AnalysisDocumentTVItemID)
                    .HasName("IX_AnalysisDocumentTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MWQMSiteTVItemID)
                    .HasName("IX_MWQMSiteTVItemID");

                entity.HasIndex(e => e.PolSourceSiteOrInfrastructureTVItemID)
                    .HasName("IX_PolSourceSiteOrInfrastructureTVItemID");

                entity.Property(e => e.Comments).HasColumnType("text");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.PolSourceSiteEffectTermIDs).HasMaxLength(250);

                entity.HasOne(d => d.AnalysisDocumentTVItem)
                    .WithMany(p => p.PolSourceSiteEffectsAnalysisDocumentTVItem)
                    .HasForeignKey(d => d.AnalysisDocumentTVItemID)
                    .HasConstraintName("FK_PolSourceSiteEffects_AnalysisDocumentTVItemID");

                entity.HasOne(d => d.MWQMSiteTVItem)
                    .WithMany(p => p.PolSourceSiteEffectsMWQMSiteTVItem)
                    .HasForeignKey(d => d.MWQMSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolSourceSiteEffects_MWQMSiteTVItemID");

                entity.HasOne(d => d.PolSourceSiteOrInfrastructureTVItem)
                    .WithMany(p => p.PolSourceSiteEffectsPolSourceSiteOrInfrastructureTVItem)
                    .HasForeignKey(d => d.PolSourceSiteOrInfrastructureTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolSourceSiteEffects_PolSourceSiteOrInfrastructureTVItemID");
            });

            modelBuilder.Entity<PolSourceSites>(entity =>
            {
                entity.HasKey(e => e.PolSourceSiteID);

                entity.HasIndex(e => e.CivicAddressTVItemID)
                    .HasName("IX_CivicAddressTVItemID");

                entity.HasIndex(e => e.IsPointSource)
                    .HasName("IX_IsPointSource");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Oldsiteid)
                    .HasName("IX_Oldsiteid");

                entity.HasIndex(e => e.PolSourceSiteID)
                    .HasName("IX_PolSourceSites");

                entity.HasIndex(e => e.PolSourceSiteTVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.Site)
                    .HasName("IX_Site");

                entity.HasIndex(e => e.SiteID)
                    .HasName("IX_siteid");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Temp_Locator_CanDelete).HasMaxLength(50);

                entity.HasOne(d => d.CivicAddressTVItem)
                    .WithMany(p => p.PolSourceSitesCivicAddressTVItem)
                    .HasForeignKey(d => d.CivicAddressTVItemID)
                    .HasConstraintName("FK_PolSourceSites_TVItems1");

                entity.HasOne(d => d.PolSourceSiteTVItem)
                    .WithMany(p => p.PolSourceSitesPolSourceSiteTVItem)
                    .HasForeignKey(d => d.PolSourceSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolSourceSites_TVItems");
            });

            modelBuilder.Entity<RainExceedanceClimateSites>(entity =>
            {
                entity.HasKey(e => e.RainExceedanceClimateSiteID);

                entity.HasIndex(e => e.ClimateSiteTVItemID)
                    .HasName("IX_ClimateSiteTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.RainExceedanceTVItemID)
                    .HasName("IX_RainExceedanceTVItemID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.ClimateSiteTVItem)
                    .WithMany(p => p.RainExceedanceClimateSitesClimateSiteTVItem)
                    .HasForeignKey(d => d.ClimateSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RainExceedance_ClimateSiteTVItemID");

                entity.HasOne(d => d.RainExceedanceTVItem)
                    .WithMany(p => p.RainExceedanceClimateSitesRainExceedanceTVItem)
                    .HasForeignKey(d => d.RainExceedanceTVItemID)
                    .HasConstraintName("FK_RainExceedance_RainExceedanceTVItemID");
            });

            modelBuilder.Entity<RainExceedances>(entity =>
            {
                entity.HasKey(e => e.RainExceedanceID);

                entity.HasIndex(e => e.EndDay)
                    .HasName("IX_EndDay");

                entity.HasIndex(e => e.EndMonth)
                    .HasName("IX_EndMonth");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.OnlyStaffEmailDistributionListID)
                    .HasName("IX_OnlyStaffEmailDistributionListID");

                entity.HasIndex(e => e.RainExceedanceTVItemID)
                    .HasName("IX_RainExceedanceTVItemID");

                entity.HasIndex(e => e.RainMaximum_mm)
                    .HasName("IX_RainMaximum_mm");

                entity.HasIndex(e => e.StakeholdersEmailDistributionListID)
                    .HasName("IX_StakeholdersEmailDistributionListID");

                entity.HasIndex(e => e.StartDay)
                    .HasName("IX_StartDay");

                entity.HasIndex(e => e.StartMonth)
                    .HasName("IX_StartMonth");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.OnlyStaffEmailDistributionList)
                    .WithMany(p => p.RainExceedancesOnlyStaffEmailDistributionList)
                    .HasForeignKey(d => d.OnlyStaffEmailDistributionListID)
                    .HasConstraintName("FK_RainExceedances_OnlyStaffEmailDistributionLists1");

                entity.HasOne(d => d.RainExceedanceTVItem)
                    .WithMany(p => p.RainExceedances)
                    .HasForeignKey(d => d.RainExceedanceTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RainExceedances_RainExceedanceTVItemID");

                entity.HasOne(d => d.StakeholdersEmailDistributionList)
                    .WithMany(p => p.RainExceedancesStakeholdersEmailDistributionList)
                    .HasForeignKey(d => d.StakeholdersEmailDistributionListID)
                    .HasConstraintName("FK_RainExceedances_StakeholdersEmailDistributionLists");
            });

            modelBuilder.Entity<RatingCurveValues>(entity =>
            {
                entity.HasKey(e => e.RatingCurveValueID);

                entity.HasIndex(e => e.DischargeValue_m3_s)
                    .HasName("IX_DischargeValue");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.RatingCurveID)
                    .HasName("IX_RatingCurveID");

                entity.HasIndex(e => e.StageValue_m)
                    .HasName("IX_StageValue");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.RatingCurve)
                    .WithMany(p => p.RatingCurveValues)
                    .HasForeignKey(d => d.RatingCurveID)
                    .HasConstraintName("FK_RatingCurveValues_RatingCurves");
            });

            modelBuilder.Entity<RatingCurves>(entity =>
            {
                entity.HasKey(e => e.RatingCurveID);

                entity.HasIndex(e => e.HydrometricSiteID)
                    .HasName("IX_HydrometricSiteID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.RatingCurveNumber)
                    .HasName("IX_RatingCurveNumber");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.RatingCurveNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.HydrometricSite)
                    .WithMany(p => p.RatingCurves)
                    .HasForeignKey(d => d.HydrometricSiteID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RatingCurves_HydrometricSites");
            });

            modelBuilder.Entity<ReportSectionLanguages>(entity =>
            {
                entity.HasKey(e => e.ReportSectionLanguageID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ReportSectionID)
                    .HasName("IX_ReportSectionID");

                entity.HasIndex(e => e.ReportSectionName)
                    .HasName("IX_ReportSectionName");

                entity.HasIndex(e => e.TranslationStatusReportSectionName)
                    .HasName("IX_TranslationStatusReportSectionName");

                entity.HasIndex(e => e.TranslationStatusReportSectionText)
                    .HasName("IX_TranslationStatusReportSectionText");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.ReportSectionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReportSectionText)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TranslationStatusReportSectionName).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.ReportSection)
                    .WithMany(p => p.ReportSectionLanguages)
                    .HasForeignKey(d => d.ReportSectionID)
                    .HasConstraintName("FK_ReportSectionLanguages_ReportSections");
            });

            modelBuilder.Entity<ReportSections>(entity =>
            {
                entity.HasKey(e => e.ReportSectionID);

                entity.HasIndex(e => e.IsStatic)
                    .HasName("IX_IsStatic");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.HasIndex(e => e.ParentReportSectionID)
                    .HasName("IX_ParentReportSectionID");

                entity.HasIndex(e => e.ReportTypeID)
                    .HasName("IX_ReportTypeID");

                entity.HasIndex(e => e.TVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.Year)
                    .HasName("IX_Year");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.ParentReportSection)
                    .WithMany(p => p.InverseParentReportSection)
                    .HasForeignKey(d => d.ParentReportSectionID)
                    .HasConstraintName("FK_ReportSections_ReportSections");

                entity.HasOne(d => d.ReportType)
                    .WithMany(p => p.ReportSections)
                    .HasForeignKey(d => d.ReportTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportSections_ReportTypes");

                entity.HasOne(d => d.TVItem)
                    .WithMany(p => p.ReportSections)
                    .HasForeignKey(d => d.TVItemID)
                    .HasConstraintName("FK_ReportSections_TVItems");

                entity.HasOne(d => d.TemplateReportSection)
                    .WithMany(p => p.InverseTemplateReportSection)
                    .HasForeignKey(d => d.TemplateReportSectionID)
                    .HasConstraintName("FK_ReportSections_ReportSections1");
            });

            modelBuilder.Entity<ReportTypeLanguages>(entity =>
            {
                entity.HasKey(e => e.ReportTypeLanguageID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ReportTypeID)
                    .HasName("IX_ReportTypeID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartOfFileName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TranslationStatusName).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.ReportType)
                    .WithMany(p => p.ReportTypeLanguages)
                    .HasForeignKey(d => d.ReportTypeID)
                    .HasConstraintName("FK_ReportTypeLanguages_ReportTypes");
            });

            modelBuilder.Entity<ReportTypes>(entity =>
            {
                entity.HasKey(e => e.ReportTypeID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TVType)
                    .HasName("IX_TVType");

                entity.HasIndex(e => e.UniqueCode)
                    .HasName("IX_UniqueCode");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.UniqueCode)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ResetPasswords>(entity =>
            {
                entity.HasKey(e => e.ResetPasswordID);

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Email");

                entity.HasIndex(e => e.ExpireDate_Local)
                    .HasName("IX_ExpireDate");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ExpireDate_Local).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");
            });

            modelBuilder.Entity<SamplingPlanEmails>(entity =>
            {
                entity.HasKey(e => e.SamplingPlanEmailID);

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Email");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.SamplingPlanID)
                    .HasName("IX_SamplingPlanID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.SamplingPlan)
                    .WithMany(p => p.SamplingPlanEmails)
                    .HasForeignKey(d => d.SamplingPlanID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SamplingPlanEmails_SamplingPlans");
            });

            modelBuilder.Entity<SamplingPlanSubsectorSites>(entity =>
            {
                entity.HasKey(e => e.SamplingPlanSubsectorSiteID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MWQMSiteTVItemID)
                    .HasName("IX_MWQMSiteTVItemID");

                entity.HasIndex(e => e.SamplingPlanSubsectorID)
                    .HasName("IX_SamplingPlanSubsectorID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.MWQMSiteTVItem)
                    .WithMany(p => p.SamplingPlanSubsectorSites)
                    .HasForeignKey(d => d.MWQMSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SamplingPlanSubsectorSites_MWQMSiteTVItemID");

                entity.HasOne(d => d.SamplingPlanSubsector)
                    .WithMany(p => p.SamplingPlanSubsectorSites)
                    .HasForeignKey(d => d.SamplingPlanSubsectorID)
                    .HasConstraintName("FK_SamplingPlanSubsectorSites_SamplingPlanSubsectors");
            });

            modelBuilder.Entity<SamplingPlanSubsectors>(entity =>
            {
                entity.HasKey(e => e.SamplingPlanSubsectorID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.SamplingPlanID)
                    .HasName("IX_SamplingPlanID");

                entity.HasIndex(e => e.SubsectorTVItemID)
                    .HasName("IX_SubsectorTVItemID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.SamplingPlan)
                    .WithMany(p => p.SamplingPlanSubsectors)
                    .HasForeignKey(d => d.SamplingPlanID)
                    .HasConstraintName("FK_SamplingPlanSubsectors_SamplingPlans");

                entity.HasOne(d => d.SubsectorTVItem)
                    .WithMany(p => p.SamplingPlanSubsectors)
                    .HasForeignKey(d => d.SubsectorTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SamplingPlanSubsectors_SubsectorTVItemID");
            });

            modelBuilder.Entity<SamplingPlans>(entity =>
            {
                entity.HasKey(e => e.SamplingPlanID);

                entity.HasIndex(e => e.AccessCode)
                    .HasName("IX_SecretCode");

                entity.HasIndex(e => e.CreatorTVItemID)
                    .HasName("IX_CreatorTVItemID");

                entity.HasIndex(e => e.ForGroupName)
                    .HasName("IX_ForGroupName");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ProvinceTVItemID)
                    .HasName("IX_ProvinceTVItemID");

                entity.HasIndex(e => e.SamplingPlanFileTVItemID)
                    .HasName("IX_SamplingPlanFileTVItemID");

                entity.HasIndex(e => e.SamplingPlanName)
                    .HasName("IX_SamplingPlanName")
                    .IsUnique();

                entity.HasIndex(e => e.Year)
                    .HasName("IX_Year");

                entity.Property(e => e.AccessCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ApprovalCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.BackupDirectory)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ForGroupName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.SamplingPlanName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.CreatorTVItem)
                    .WithMany(p => p.SamplingPlansCreatorTVItem)
                    .HasForeignKey(d => d.CreatorTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SamplingPlans_CreatorTVItemID");

                entity.HasOne(d => d.ProvinceTVItem)
                    .WithMany(p => p.SamplingPlansProvinceTVItem)
                    .HasForeignKey(d => d.ProvinceTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SamplingPlans_ProvinceTVItemID");

                entity.HasOne(d => d.SamplingPlanFileTVItem)
                    .WithMany(p => p.SamplingPlansSamplingPlanFileTVItem)
                    .HasForeignKey(d => d.SamplingPlanFileTVItemID)
                    .HasConstraintName("FK_SamplingPlans_SamplingPlanFileTVItemID");
            });

            modelBuilder.Entity<SpillLanguages>(entity =>
            {
                entity.HasKey(e => e.SpillLanguageID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TranslationStatus)
                    .HasName("IX_SpillCommentStatus");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.SpillComment)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TranslationStatus).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.Spill)
                    .WithMany(p => p.SpillLanguages)
                    .HasForeignKey(d => d.SpillID)
                    .HasConstraintName("FK_SpillLanguages_Spills");
            });

            modelBuilder.Entity<Spills>(entity =>
            {
                entity.HasKey(e => e.SpillID);

                entity.HasIndex(e => e.AverageFlow_m3_day)
                    .HasName("IX_AverageFlow_m3_s");

                entity.HasIndex(e => e.EndDateTime_Local)
                    .HasName("IX_EndDateTime_UTC");

                entity.HasIndex(e => e.InfrastructureTVItemID)
                    .HasName("IX_InfrastructureTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MunicipalityTVItemID)
                    .HasName("IX_MunicipalityTVItemID");

                entity.HasIndex(e => e.StartDateTime_Local)
                    .HasName("IX_StartDateTime_UTC");

                entity.Property(e => e.EndDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime_Local).HasColumnType("datetime");

                entity.HasOne(d => d.InfrastructureTVItem)
                    .WithMany(p => p.SpillsInfrastructureTVItem)
                    .HasForeignKey(d => d.InfrastructureTVItemID)
                    .HasConstraintName("FK_Spills_InfrastructureTVItemID");

                entity.HasOne(d => d.MunicipalityTVItem)
                    .WithMany(p => p.SpillsMunicipalityTVItem)
                    .HasForeignKey(d => d.MunicipalityTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Spills_MunicipalityTVItemID");
            });

            modelBuilder.Entity<TVFileLanguages>(entity =>
            {
                entity.HasKey(e => e.TVFileLanguageID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactTVItemID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TVFileID)
                    .HasName("IX_TVFileID");

                entity.HasIndex(e => e.TranslationStatus)
                    .HasName("IX_TranslationStatus");

                entity.Property(e => e.FileDescription).HasColumnType("text");

                entity.Property(e => e.Language).HasComment("Error = 0, EN = 1, FR = 2, ENAndFR = 3");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TranslationStatus).HasComment("Error = 0, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.HasOne(d => d.TVFile)
                    .WithMany(p => p.TVFileLanguages)
                    .HasForeignKey(d => d.TVFileID)
                    .HasConstraintName("FK_TVFileLanguages_TVFiles");
            });

            modelBuilder.Entity<TVFiles>(entity =>
            {
                entity.HasKey(e => e.TVFileID)
                    .HasName("PK_TVFileID");

                entity.HasIndex(e => e.FileCreatedDate_UTC)
                    .HasName("IX_FileCreatedDate_UTC");

                entity.HasIndex(e => e.FilePurpose)
                    .HasName("IX_FilePurpose");

                entity.HasIndex(e => e.FileSize_kb)
                    .HasName("IX_FileSize");

                entity.HasIndex(e => e.FileType)
                    .HasName("IX_FileType");

                entity.HasIndex(e => e.FromWater)
                    .HasName("IX_FromWater");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ReportTypeID)
                    .HasName("IX_TVFiles");

                entity.HasIndex(e => e.ServerFileName)
                    .HasName("IX_ServerFileName");

                entity.HasIndex(e => e.ServerFilePath)
                    .HasName("IX_ServerFilePath");

                entity.HasIndex(e => e.TVFileTVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.Year)
                    .HasName("IX_Year");

                entity.Property(e => e.ClientFilePath).HasMaxLength(250);

                entity.Property(e => e.FileCreatedDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.FileInfo).HasColumnType("text");

                entity.Property(e => e.FilePurpose).HasComment("-1 = Error, 1 = Input, 2 = MikeResult, 3 = KMZResult, 4 = Information, 5 = Image, 6 = Picture, 7 = Report, 8 = InputMDF");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Parameters).HasColumnType("text");

                entity.Property(e => e.ServerFileName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ServerFilePath)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.TVFileTVItem)
                    .WithMany(p => p.TVFiles)
                    .HasForeignKey(d => d.TVFileTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TVFiles_TVItems");
            });

            modelBuilder.Entity<TVItemLanguages>(entity =>
            {
                entity.HasKey(e => e.TVItemLanguageID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateUserInfoID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.TVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.TVText)
                    .HasName("IX_TVText");

                entity.HasIndex(e => e.TranslationStatus)
                    .HasName("IX_TranslationStatusTVItemID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TVText)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.TVItem)
                    .WithMany(p => p.TVItemLanguages)
                    .HasForeignKey(d => d.TVItemID)
                    .HasConstraintName("FK_TVItemLanguages_TVItems");
            });

            modelBuilder.Entity<TVItemLinks>(entity =>
            {
                entity.HasKey(e => e.TVItemLinkID);

                entity.HasIndex(e => e.EndDateTime_Local)
                    .HasName("IX_EndDateTime_UTC");

                entity.HasIndex(e => e.FromTVItemID)
                    .HasName("IX_TVItemIDFrom");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ParentTVItemLinkID)
                    .HasName("IX_ParentTVItemLinkID");

                entity.HasIndex(e => e.StartDateTime_Local)
                    .HasName("IX_StartDateTime_UTC");

                entity.HasIndex(e => e.ToTVItemID)
                    .HasName("IX_TVItemIDTo");

                entity.Property(e => e.EndDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.TVPath)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.FromTVItem)
                    .WithMany(p => p.TVItemLinksFromTVItem)
                    .HasForeignKey(d => d.FromTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TVItemLinks_FromTVItems");

                entity.HasOne(d => d.ParentTVItemLink)
                    .WithMany(p => p.InverseParentTVItemLink)
                    .HasForeignKey(d => d.ParentTVItemLinkID)
                    .HasConstraintName("FK_TVItemLinks_ParentTVItemLinks");

                entity.HasOne(d => d.ToTVItem)
                    .WithMany(p => p.TVItemLinksToTVItem)
                    .HasForeignKey(d => d.ToTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TVItemLinks_ToTVItems");
            });

            modelBuilder.Entity<TVItemStats>(entity =>
            {
                entity.HasKey(e => e.TVItemStatID);

                entity.HasIndex(e => e.ChildCount)
                    .HasName("IX_ChildCount");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.TVType)
                    .HasName("IX_TVType");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.TVItem)
                    .WithMany(p => p.TVItemStats)
                    .HasForeignKey(d => d.TVItemID)
                    .HasConstraintName("FK_TVItemStats_TVItems");
            });

            modelBuilder.Entity<TVItemUserAuthorizations>(entity =>
            {
                entity.HasKey(e => e.TVItemUserAuthorizationID)
                    .HasName("PK_TVItemsUserAuthorizations");

                entity.HasIndex(e => e.ContactTVItemID)
                    .HasName("IX_ContactTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TVAuth)
                    .HasName("IX_TVAuth");

                entity.HasIndex(e => e.TVItemID1)
                    .HasName("IX_TVItemID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TVAuth).HasComment("0 = no access, 1 = read, 2 = edit, 3 = create, 4 = delete, 5 = admin");

                entity.HasOne(d => d.ContactTVItem)
                    .WithMany(p => p.TVItemUserAuthorizationsContactTVItem)
                    .HasForeignKey(d => d.ContactTVItemID)
                    .HasConstraintName("FK_TVItemUserAuthorizations_Contacts");

                entity.HasOne(d => d.TVItemID1Navigation)
                    .WithMany(p => p.TVItemUserAuthorizationsTVItemID1Navigation)
                    .HasForeignKey(d => d.TVItemID1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TVItemsUserAuthorizations_TVItems");
            });

            modelBuilder.Entity<TVItems>(entity =>
            {
                entity.HasKey(e => e.TVItemID);

                entity.HasIndex(e => e.IsActive)
                    .HasName("IX_IsActive");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.ParentID)
                    .HasName("IX_ParentID");

                entity.HasIndex(e => e.TVLevel)
                    .HasName("IX_TVLevel");

                entity.HasIndex(e => e.TVPath)
                    .HasName("IX_TVPath");

                entity.HasIndex(e => e.TVType)
                    .HasName("IX_TVType");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TVPath)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TVItems_ParentID");
            });

            modelBuilder.Entity<TVTypeUserAuthorizations>(entity =>
            {
                entity.HasKey(e => e.TVTypeUserAuthorizationID);

                entity.HasIndex(e => e.ContactTVItemID)
                    .HasName("IX_ContactTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TVAuth)
                    .HasName("IX_TVAuth");

                entity.HasIndex(e => e.TVType)
                    .HasName("IX_TVType");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TVAuth).HasComment("0 = no access, 1 = read, 2 = edit, 3 = create, 4 = delete, 5 = admin");

                entity.HasOne(d => d.ContactTVItem)
                    .WithMany(p => p.TVTypeUserAuthorizations)
                    .HasForeignKey(d => d.ContactTVItemID)
                    .HasConstraintName("FK_TVTypeUserAuthorizations_Contacts");
            });

            modelBuilder.Entity<Tels>(entity =>
            {
                entity.HasKey(e => e.TelID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TelNumber)
                    .HasName("IX_TelNumber");

                entity.HasIndex(e => e.TelTVItemID)
                    .HasName("IX_TelTVItemID");

                entity.HasIndex(e => e.TelType)
                    .HasName("IX_TelTypeTVItemID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TelNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TelType).HasComment("Error = -1, Home = 1, Work = 2, HomeCell = 3, WorkCell = 4, Personal = 5, Personal2 = 6");

                entity.HasOne(d => d.TelTVItem)
                    .WithMany(p => p.Tels)
                    .HasForeignKey(d => d.TelTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TelTVItemID_TVItems");
            });

            modelBuilder.Entity<TideDataValues>(entity =>
            {
                entity.HasKey(e => e.TideDataValueID);

                entity.HasIndex(e => e.DateTime_Local)
                    .HasName("IX_DateTime_UTC");

                entity.HasIndex(e => e.Depth_m)
                    .HasName("IX_Depth_m");

                entity.HasIndex(e => e.Keep)
                    .HasName("IX_Keep");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.StorageDataType)
                    .HasName("IX_StorageDataType");

                entity.HasIndex(e => e.TideDataType)
                    .HasName("IX_TideDataType");

                entity.HasIndex(e => e.TideSiteTVItemID)
                    .HasName("IX_TideSiteTVItemID");

                entity.HasIndex(e => e.UVelocity_m_s)
                    .HasName("IX_UVelocity_m_s");

                entity.HasIndex(e => e.VVelocity_m_s)
                    .HasName("IX_VVelocity_m_s");

                entity.Property(e => e.DateTime_Local).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TideDataType).HasComment("Hourly = 1, Daily = 2");

                entity.HasOne(d => d.TideSiteTVItem)
                    .WithMany(p => p.TideDataValues)
                    .HasForeignKey(d => d.TideSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TideDataValues_TVItems");
            });

            modelBuilder.Entity<TideLocations>(entity =>
            {
                entity.HasKey(e => e.TideLocationID)
                    .HasName("PK_TideLocations_1");

                entity.HasIndex(e => e.Lat)
                    .HasName("IX_Lat");

                entity.HasIndex(e => e.Lng)
                    .HasName("IX_Lng");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.Prov)
                    .HasName("IX_Prov");

                entity.HasIndex(e => e.Zone)
                    .HasName("IX_Zone");

                entity.HasIndex(e => e.sid)
                    .HasName("IX_sid");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Prov)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TideSites>(entity =>
            {
                entity.HasKey(e => e.TideSiteID);

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Province)
                    .HasName("IX_Province");

                entity.HasIndex(e => e.TideSiteName)
                    .HasName("IX_TideSiteName");

                entity.HasIndex(e => e.TideSiteTVItemID)
                    .HasName("IX_TVItemID");

                entity.HasIndex(e => e.Zone)
                    .HasName("IX_Zone");

                entity.HasIndex(e => e.sid)
                    .HasName("IX_sid");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TideSiteName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.TideSiteTVItem)
                    .WithMany(p => p.TideSites)
                    .HasForeignKey(d => d.TideSiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TideSites_TVItems");
            });

            modelBuilder.Entity<UseOfSites>(entity =>
            {
                entity.HasKey(e => e.UseOfSiteID)
                    .HasName("PK_UseOfClimateSites");

                entity.HasIndex(e => e.EndYear)
                    .HasName("IX_EndYear");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.HasIndex(e => e.SiteTVItemID)
                    .HasName("IX_SiteTVItemID");

                entity.HasIndex(e => e.StartYear)
                    .HasName("IX_StartYear");

                entity.HasIndex(e => e.SubsectorTVItemID)
                    .HasName("IX_SubsectorTVItemID");

                entity.HasIndex(e => e.TVType)
                    .HasName("IX_TVType");

                entity.HasIndex(e => e.UseEquation)
                    .HasName("IX_UseEquation");

                entity.HasIndex(e => e.UseWeight)
                    .HasName("IX_UseWeight");

                entity.HasIndex(e => e.Weight_perc)
                    .HasName("IX_Weight_perc");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.SiteTVItem)
                    .WithMany(p => p.UseOfSitesSiteTVItem)
                    .HasForeignKey(d => d.SiteTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UseOfSites_SiteTVItems");

                entity.HasOne(d => d.SubsectorTVItem)
                    .WithMany(p => p.UseOfSitesSubsectorTVItem)
                    .HasForeignKey(d => d.SubsectorTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UseOfSites_SubsectorTVItems");
            });

            modelBuilder.Entity<VPAmbients>(entity =>
            {
                entity.HasKey(e => e.VPAmbientID);

                entity.HasIndex(e => e.AmbientSalinity_PSU)
                    .HasName("IX_AmbientSalinity_PSU");

                entity.HasIndex(e => e.AmbientTemperature_C)
                    .HasName("IX_AmbientTemperature_C");

                entity.HasIndex(e => e.BackgroundConcentration_MPN_100ml)
                    .HasName("IX_BackgroundConcentration_MPN_100ml");

                entity.HasIndex(e => e.CurrentDirection_deg)
                    .HasName("IX_CurrentDirection_deg");

                entity.HasIndex(e => e.CurrentSpeed_m_s)
                    .HasName("IX_CurrentSpeed_m_s");

                entity.HasIndex(e => e.FarFieldCurrentDirection_deg)
                    .HasName("IX_FarFieldCurrentDirection_deg");

                entity.HasIndex(e => e.FarFieldCurrentSpeed_m_s)
                    .HasName("IX_FarFieldCurrentSpeed_m_s");

                entity.HasIndex(e => e.FarFieldDiffusionCoefficient)
                    .HasName("IX_FarFieldDiffusionCoefficient");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.MeasurementDepth_m)
                    .HasName("IX_MeasurementDepth_m");

                entity.HasIndex(e => e.PollutantDecayRate_per_day)
                    .HasName("IX_PollutantDecayRate_per_day");

                entity.HasIndex(e => e.Row)
                    .HasName("IX_Row");

                entity.HasIndex(e => e.VPScenarioID)
                    .HasName("IX_VPScenarioID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.VPScenario)
                    .WithMany(p => p.VPAmbients)
                    .HasForeignKey(d => d.VPScenarioID)
                    .HasConstraintName("FK_VPAmbients_VPScenarios");
            });

            modelBuilder.Entity<VPResults>(entity =>
            {
                entity.HasKey(e => e.VPResultID);

                entity.HasIndex(e => e.Concentration_MPN_100ml)
                    .HasName("IX_Concentration_MPN_100ml");

                entity.HasIndex(e => e.Dilution)
                    .HasName("IX_Dilution");

                entity.HasIndex(e => e.DispersionDistance_m)
                    .HasName("IX_DispersionDistance_m");

                entity.HasIndex(e => e.FarFieldWidth_m)
                    .HasName("IX_FarFieldWidth_m");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.Ordinal)
                    .HasName("IX_Ordinal");

                entity.HasIndex(e => e.TravelTime_hour)
                    .HasName("IX_TravelTime_hour");

                entity.HasIndex(e => e.VPScenarioID)
                    .HasName("IX_VPScenarioID");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.HasOne(d => d.VPScenario)
                    .WithMany(p => p.VPResults)
                    .HasForeignKey(d => d.VPScenarioID)
                    .HasConstraintName("FK_VPResults_VPScenarios");
            });

            modelBuilder.Entity<VPScenarioLanguages>(entity =>
            {
                entity.HasKey(e => e.VPScenarioLanguageID);

                entity.HasIndex(e => e.Language)
                    .HasName("IX_Language");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.TranslationStatus)
                    .HasName("IX_VPScenarioNameStatus");

                entity.HasIndex(e => e.VPScenarioID)
                    .HasName("IX_VPScenarioID");

                entity.HasIndex(e => e.VPScenarioName)
                    .HasName("IX_VPScenarioName");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.TranslationStatus).HasComment("Error -1, Not Translated = 1, Electronically Translated = 2, Translated = 3");

                entity.Property(e => e.VPScenarioName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.VPScenario)
                    .WithMany(p => p.VPScenarioLanguages)
                    .HasForeignKey(d => d.VPScenarioID)
                    .HasConstraintName("FK_VPScenarioLanguages_VPScenarios");
            });

            modelBuilder.Entity<VPScenarios>(entity =>
            {
                entity.HasKey(e => e.VPScenarioID)
                    .HasName("PK_Scenarios");

                entity.HasIndex(e => e.AcuteMixZone_m)
                    .HasName("IX_AcuteMixZone_m");

                entity.HasIndex(e => e.ChronicMixZone_m)
                    .HasName("IX_ChronicMixZone_m");

                entity.HasIndex(e => e.EffluentConcentration_MPN_100ml)
                    .HasName("IX_EffluentConcentration_MPN_100ml");

                entity.HasIndex(e => e.EffluentFlow_m3_s)
                    .HasName("IX_EffluentFlow_m3_s");

                entity.HasIndex(e => e.EffluentSalinity_PSU)
                    .HasName("IX_EffluentSalinity_PSU");

                entity.HasIndex(e => e.EffluentTemperature_C)
                    .HasName("IX_EffluentTemperature_C");

                entity.HasIndex(e => e.EffluentVelocity_m_s)
                    .HasName("IX_EffluentVelocity_m_s");

                entity.HasIndex(e => e.FroudeNumber)
                    .HasName("IX_FroudeNumber");

                entity.HasIndex(e => e.HorizontalAngle_deg)
                    .HasName("IX_HorizontalAngle_deg");

                entity.HasIndex(e => e.InfrastructureTVItemID)
                    .HasName("IX_InfrastructureTVItemID");

                entity.HasIndex(e => e.LastUpdateContactTVItemID)
                    .HasName("IX_LastUpdateContactID");

                entity.HasIndex(e => e.LastUpdateDate_UTC)
                    .HasName("IX_LastUpdateDate_UTC");

                entity.HasIndex(e => e.NumberOfPorts)
                    .HasName("IX_NumberOfPorts");

                entity.HasIndex(e => e.PortDepth_m)
                    .HasName("IX_PortDepth_m");

                entity.HasIndex(e => e.PortDiameter_m)
                    .HasName("IX_PortDiameter_m");

                entity.HasIndex(e => e.PortElevation_m)
                    .HasName("IX_PortElevation_m");

                entity.HasIndex(e => e.PortSpacing_m)
                    .HasName("IX_PortSpacing_m");

                entity.HasIndex(e => e.UseAsBestEstimate)
                    .HasName("IX_UseAsBestEstimate");

                entity.HasIndex(e => e.VPScenarioID)
                    .HasName("IX_VPScenarios");

                entity.HasIndex(e => e.VerticalAngle_deg)
                    .HasName("IX_VerticalAngle_deg");

                entity.Property(e => e.LastUpdateDate_UTC).HasColumnType("datetime");

                entity.Property(e => e.RawResults).HasColumnType("text");

                entity.Property(e => e.VPScenarioStatus).HasComment("Error = -1, Copying = 1, Copied = 2, Changing = 3, Changed = 4, AskToRun = 5, Running = 6, Completed = 7");

                entity.HasOne(d => d.InfrastructureTVItem)
                    .WithMany(p => p.VPScenarios)
                    .HasForeignKey(d => d.InfrastructureTVItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VPScenarios_InfrastructureTVItems");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
